using System;
using System.Linq;
using System.Windows.Forms;
using FrbaCommerce.Home;
using Session;
using Persistance;
using FrbaCommerce.Registro_de_Usuario;

namespace FrbaCommerce.Login
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void DoLogin(string userName, string password)
        {
            try
            {
                //Realizo validaciones de datos ingresados
                if (string.IsNullOrEmpty(userName))
                    throw new Exception("El usuario no puede ser vacío.");

                if (string.IsNullOrEmpty(password))
                    throw new Exception("La contraseña no puede ser vacía.");

                //Valido que los datos del usuario ingresados sean correctos
                var user = UsuarioPersistance.Login(userName, password);

                //El usuario no se encuentra habilitado
                if (!user.Habilitado)
                    throw new Exception("No puede loguearse. El usuario se encuentra inhabilitado debido a que acumula más de 10 compras sin rendir. Por favor, acérquese a la oficina de administración.");

                //Pregunto si por lo menos tiene un rol asignado que se encuentre activo
                if (user.RolesActivos != null)
                {
                    //Seteo el usuario en sesion
                    SessionManager.CurrentUser = user;

                    //Mientras que el usuario posea una contraseña temporal, lo obligo a que la cambie
                    while (SessionManager.CurrentUser.PassTemporal)
                    {
                        MessageBox.Show("Posee una contraseña temporal. Debera cambiarla a continuacion.", "Atención");

                        //Muestro el formulario para el cambio de contraseña
                        var resetPassword = new FrmResetPassword();
                        resetPassword.ShowDialog();

                        //Refresco el currentUser por si ya lo modificó
                        SessionManager.CurrentUser = UsuarioPersistance.GetByUsername(SessionManager.CurrentUser.Username);
                    }
                    
                    Hide();

                    if (user.RolesActivos.Count > 1)
                    {
                        //Posee mas de un rol activo asignado, debe seleccionar uno solo
                        var chooseRol = new FrmChooseRol();
                        chooseRol.ShowDialog();
                    }
                    else
                    {
                        //Posee un unico rol asignado activo. Lo seteo en sesion.
                        SessionManager.CurrentRol = user.RolesActivos.First();

                        //Muestro el formulario de home
                        var home = new FrmHome();
                        home.ShowDialog();
                    }

                    Close();
                }
                else
                    throw new Exception("El usuario no cuenta con roles que se encuentren activos.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }

        private void LblEntrar_Click(object sender, EventArgs e)
        {
            DoLogin(TxtUsuario.Text, TxtContrasena.Text);
        }

        private void LblNuevo_Click(object sender, EventArgs e)
        {
            Hide();
            var frmRegistroUsuario = new FrmRegistroUsuario();
            frmRegistroUsuario.ShowDialog();
        }

        private void TxtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Cuando presiona la tecla 'Enter', realizo el login
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                DoLogin(TxtUsuario.Text, TxtContrasena.Text);
            }
        }
    }
}
