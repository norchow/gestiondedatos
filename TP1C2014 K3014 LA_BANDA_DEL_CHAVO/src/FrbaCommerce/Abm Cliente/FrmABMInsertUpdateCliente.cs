using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Persistance;
using System.Data.SqlClient;
using Persistance.Entities;
using Session;
using FrbaCommerce.Home;
using Tools;
using FrbaCommerce.Login;

namespace FrbaCommerce.Abm_Cliente
{
    public partial class FrmABMInsertUpdateCliente : Form
    {
        public bool insertMode { get; set; }
        public bool insertDefaultUser = false;
        public SqlTransaction currentTransaction { get; set; }
        private bool _abmCliente;
        private Cliente CurrentCliente { get; set; }
        public bool CompleteAction = false;
        private Usuario currentUser;

        public FrmABMInsertUpdateCliente(SqlTransaction transaction)
        {
            InitializeComponent();
            _abmCliente = true;
            insertMode = transaction != null;
            insertDefaultUser = true;
            this.currentTransaction = transaction;
        }

        public FrmABMInsertUpdateCliente(Cliente cliente)
        {
            InitializeComponent();
            _abmCliente = false;

            insertMode = cliente == null;

            if (!insertMode)
                CurrentCliente = cliente;
        }

        public FrmABMInsertUpdateCliente(SqlTransaction transaction, Boolean abmCliente, Usuario user)
        {
            InitializeComponent();
            insertMode = transaction != null;
            _abmCliente = abmCliente;
            currentUser = user;
            //Mantengo la transacción abierta para asegurarme que no queden usuarios de tipo cliente sin el respectivo
            //registro en la tabla cliente
            this.currentTransaction = transaction;
        }

        private void FrmABMInsertUpdateCliente_Load(object sender, EventArgs e)
        {
            this.Text = (insertMode) ? string.Format("{0} - {1}", "FrbaCommerce", "Nuevo cliente") : string.Format("{0} - {1}", "FrbaCommerce", "Modificar cliente");

            #region Cargo los tipos de documento

            CboTipoDocumento.DataSource = TipoDocumentoPersistance.GetAll(this.currentTransaction);
            CboTipoDocumento.ValueMember = "ID";
            CboTipoDocumento.DisplayMember = "Descripcion";

            #endregion 

            if (!insertMode)
            {
                #region Cargo los datos del cliente

                TxtNombre.Text = CurrentCliente.Nombre;
                TxtApellido.Text = CurrentCliente.Apellido;
                CboTipoDocumento.SelectedValue = CurrentCliente.TipoDocumento;
                TxtDocumento.Text = CurrentCliente.NroDocumento.ToString();
                TxtMail.Text = CurrentCliente.Mail;
                TxtTelefono.Text = CurrentCliente.Telefono;
                TxtDireccion.Text = CurrentCliente.Direccion;
                TxtCodigoPostal.Text = CurrentCliente.CodigoPostal;
                TxtCuil.Text = CurrentCliente.CUIL;                
                DtpFechaNacimiento.Value = CurrentCliente.FechaNacimiento;
                CboTipoDocumento.Enabled = false;
                TxtDocumento.Enabled = false;

                #endregion
            }
        }

        private void LblCancelar_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que quiere cancelar la operacion?", "Atencion", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialogAnswer)
            {
                Hide();
                //Si vino del registrarme, lo mando de nuevo al login
                if (!_abmCliente)
                {
                    var frmLogin = new FrmLogin();
                    frmLogin.ShowDialog();
                }
            }
        }

        private void LblGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validaciones

                var exceptionMessage = string.Empty;

                if (string.IsNullOrEmpty(TxtNombre.Text))
                    exceptionMessage += "El nombre del cliente no puede ser vacío.\n";

                if (string.IsNullOrEmpty(TxtApellido.Text))
                    exceptionMessage += "El apellido del cliente no puede ser vacío.\n";

                if (string.IsNullOrEmpty(CboTipoDocumento.Text))
                    exceptionMessage += "El tipo de documento del cliente no puede ser vacío.\n";

                if (string.IsNullOrEmpty(TxtDocumento.Text))
                    exceptionMessage += "El número de documento del cliente no puede ser vacío.\n";
                else 
                {
                    int nroDoc;
                    if (!int.TryParse(TxtDocumento.Text, out nroDoc))
                        exceptionMessage += "El número de documento del cliente no es válido.\n";
                }

                if (string.IsNullOrEmpty(TxtMail.Text))
                    exceptionMessage += "El mail del cliente no puede ser vacío.\n";

                if (string.IsNullOrEmpty(TxtTelefono.Text))
                    exceptionMessage += "El teléfono del cliente no puede ser vacío.\n";

                if (string.IsNullOrEmpty(TxtDireccion.Text))
                    exceptionMessage += "La dirección del cliente no puede ser vacío.\n";

                if (string.IsNullOrEmpty(TxtCodigoPostal.Text))
                    exceptionMessage += "El código postal del cliente no puede ser vacío.\n";

                if (string.IsNullOrEmpty(TxtCuil.Text))
                    exceptionMessage += "El CUIL del cliente no puede ser vacío.\n";
                else
                {
                    if (!TypesHelper.IsCUITValid(TxtCuil.Text))
                        exceptionMessage += Environment.NewLine + "El CUIL no es válido.\n";
                }

                if (!string.IsNullOrEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);

                #endregion

                if (insertMode)
                {
                    //Valido que no se dupliquen los telefonos ni documentos
                    if (ClientePersistance.GetByPhone(TxtTelefono.Text, this.currentTransaction) != null)
                        throw new Exception("Ya existe un cliente con el teléfono ingresado.");

                    if (ClientePersistance.GetByDocument((int)CboTipoDocumento.SelectedValue, Int32.Parse(TxtDocumento.Text), this.currentTransaction) != null)
                        throw new Exception("Ya existe un cliente con el tipo y número de documento ingresados.");

                    #region Inserto el nuevo cliente

                    var client = new Cliente();
                    client.IdUsuario = SessionManager.CurrentUser.ID;
                    client.Nombre = TxtNombre.Text;
                    client.Apellido = TxtApellido.Text;
                    client.TipoDocumento = (int)CboTipoDocumento.SelectedValue;
                    client.NroDocumento = Int32.Parse(TxtDocumento.Text);
                    client.Mail = TxtMail.Text;
                    client.Telefono = TxtTelefono.Text;
                    client.Direccion = TxtDireccion.Text;
                    client.CodigoPostal = TxtCodigoPostal.Text;
                    client.CUIL = TxtCuil.Text;
                    client.FechaNacimiento = DtpFechaNacimiento.Value;

                    var dialogAnswer = MessageBox.Show("¿Está seguro que quiere insertar el nuevo cliente?", "Atencion", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        //Si es el administrador el que hace el Alta, se genera un usuario con password temporal
                        if (insertDefaultUser)
                        {
                            var user = new Usuario();
                            user.Username = client.NroDocumento.ToString();
                            user.Password = SHA256Helper.Encode("temporal");
                            var userIngresado = UsuarioPersistance.InsertUserTemporal(user, this.currentTransaction);

                            client.IdUsuario = userIngresado.ID;
                            ClientePersistance.InsertClient(client, this.currentTransaction);
                            this.currentTransaction.Commit();

                            var rol = RolPersistance.GetByName("Cliente");
                            RolPersistance.InsertUserRole(userIngresado, rol, null);
                        }
                        else
                        {
                            ClientePersistance.InsertClient(client, this.currentTransaction);
                            this.currentTransaction.Commit();
                        }

                        MessageBox.Show("El Cliente ha sido ingresado con éxito." , "Atención!");
                        this.Hide();
                        if (!_abmCliente)
                        {
                            var frmHome = new FrmHome();
                            frmHome.ShowDialog();
                        }
                    }

                    #endregion
                }
                else
                {
                    if (TxtTelefono.Text != CurrentCliente.Telefono)
                    {
                        if (ClientePersistance.GetByPhone(TxtTelefono.Text, this.currentTransaction) != null)
                            throw new Exception("Ya existe un cliente con el teléfono ingresado.");
                    }

                    var client = new Cliente();
                    client.IdUsuario = CurrentCliente.IdUsuario;
                    client.Nombre = TxtNombre.Text; 
                    client.Apellido = TxtApellido.Text;
                    client.TipoDocumento = (int)CboTipoDocumento.SelectedValue;
                    client.NroDocumento = Convert.ToInt32(TxtDocumento.Text);
                    client.Mail = TxtMail.Text;
                    client.Telefono = TxtTelefono.Text;
                    client.Direccion = TxtDireccion.Text;
                    client.CodigoPostal = TxtCodigoPostal.Text;
                    client.CUIL = TxtCuil.Text;
                    client.FechaNacimiento = DtpFechaNacimiento.Value;

                    var dialogAnswer = MessageBox.Show("¿Está seguro que quiere modificar el cliente?", "Atención", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        ClientePersistance.UpdateClient(client);
                        CompleteAction = true;
                        this.Hide();
                    }   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }
    }
}
