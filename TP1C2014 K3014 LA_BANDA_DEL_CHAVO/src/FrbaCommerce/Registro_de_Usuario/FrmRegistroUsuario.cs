using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Persistance;
using Persistance.Entities;
using Logic;
using Tools;
using FrbaCommerce.Abm_Cliente;
using FrbaCommerce.Abm_Empresa;
using FrbaCommerce.Home;
using Session;

namespace FrbaCommerce.Registro_de_Usuario
{
    public partial class FrmRegistroUsuario : Form
    {

        private Boolean _abmEmpresa;

        public FrmRegistroUsuario()
        {
            InitializeComponent();
            _abmEmpresa = false;
        }

        public FrmRegistroUsuario(Boolean abmEmpresa)
        {
            InitializeComponent();
            _abmEmpresa = abmEmpresa;
        }

        private void FrmRegistroUsuario_Load(object sender, EventArgs e)
        {
            CboRoles.DisplayMember = "Descripcion";
            CboRoles.ValueMember = "ID_Rol";
            CboRoles.DataSource = RolPersistance.GetAllNotAdmin();

            if (_abmEmpresa){
                CboRoles.SelectedIndex = 1;
                CboRoles.Enabled = false;
            }
        }

        private void CboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void LblGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validations
                var exceptionMessage = string.Empty;

                if (string.IsNullOrEmpty(TxtUsuario.Text))
                    throw new Exception("El usuario no puede ser vacío.");

                if (string.IsNullOrEmpty(TxtContrasena.Text))
                    throw new Exception("La contraseña no puede ser vacía.");

                if (UsuarioPersistance.GetByUsername(TxtUsuario.Text) != null)
                    exceptionMessage += Environment.NewLine + "Ya existe un usuario con el nombre ingresado.";


                if (!string.IsNullOrEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);
                #endregion

                #region Insert the new user

                var user = new Usuario();
                user.Username = TxtUsuario.Text;
                user.Password = SHA256Helper.Encode(TxtContrasena.Text);

                var dialogAnswer = MessageBox.Show("Esta seguro que quiere insertar el nuevo usuario?", "Atencion", MessageBoxButtons.YesNo);
                if (dialogAnswer == DialogResult.Yes)
                {
                    using (var transaction = DataBaseManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
                    {
                        if (_abmEmpresa)
                            user = UsuarioPersistance.InsertUserTemporal(user, transaction);
                        else
                            user = UsuarioPersistance.InsertUser(user, transaction);

                        Rol selectedRol = (Rol)CboRoles.SelectedItem;
                        RolPersistance.InsertUserRole(user, selectedRol, transaction);

                        if (!_abmEmpresa)
                        {
                            //Cargo los datos en sesion
                            SessionManager.CurrentUser = user;
                            SessionManager.CurrentRol = selectedRol;
                            SessionManager.CurrentRol.Funcionalidades = FuncionalidadPersistance.GetByRole(SessionManager.CurrentRol, transaction);
                        }

                        switch (selectedRol.Descripcion)
                        {
                            case "Cliente":
                                this.Hide();
                                var frmABMInsertUpdateCliente = new FrmABMInsertUpdateCliente(transaction);
                                frmABMInsertUpdateCliente.ShowDialog();
                                break;
                            case "Empresa":
                                this.Hide();
                                var frmABMInsertUpdateEmpresa = new FrmABMInsertUpdateEmpresa(transaction, _abmEmpresa, user);
                                frmABMInsertUpdateEmpresa.ShowDialog();
                                break;
                            default:
                                transaction.Commit();
                                this.Hide();
                                var frmHome = new FrmHome();
                                frmHome.ShowDialog();
                                break;
                        }
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }

        private void LblCancelar_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que quiere cancelar la operacion?", "Atencion", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialogAnswer)
            {
                Close();
            }
        }
    }
}
