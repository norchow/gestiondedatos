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

        public FrmRegistroUsuario()
        {
            InitializeComponent();
        }

        private void FrmRegistroUsuario_Load(object sender, EventArgs e)
        {
            CboRoles.DisplayMember = "Descripcion";
            CboRoles.ValueMember = "ID_Rol";
            CboRoles.DataSource = RolPersistance.GetAllNotAdmin();
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
                        user = UsuarioPersistance.InsertUser(user, transaction);
                        //CompleteAction = true;

                        SessionManager.CurrentUser = user;
                        Rol selectedRol = (Rol)CboRoles.SelectedItem;
                        switch (selectedRol.Descripcion)
                        {
                            case "Cliente":
                                this.Hide();
                                var frmABMInsertUpdateCliente = new FrmABMInsertUpdateCliente(transaction);
                                frmABMInsertUpdateCliente.ShowDialog();
                                break;
                            case "Empresa":
                                this.Hide();
                                var frmABMInsertUpdateEmpresa = new FrmABMInsertUpdateEmpresa(transaction);
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
