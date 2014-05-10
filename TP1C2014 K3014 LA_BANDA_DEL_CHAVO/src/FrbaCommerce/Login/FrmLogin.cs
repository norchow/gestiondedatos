using System;
using System.Linq;
using System.Windows.Forms;
using FrbaCommerce.Home;
using Logic;
using Session;

namespace FrbaCommerce.Login
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void DoLogin(string user, string pass)
        {
            try
            {
                if (string.IsNullOrEmpty(user))
                    throw new Exception("El usuario no puede ser vacío.");

                if (string.IsNullOrEmpty(pass))
                    throw new Exception("La contraseña no puede ser vacía.");

                var usuario = new UsuarioLogic().Login(user, pass);

                if (usuario.RolesActivos != null)
                {
                    SessionManager.CurrentUser = usuario;
                    while (SessionManager.CurrentUser.PassTemporal)
                    {
                        MessageBox.Show("Posee una contraseña temporal. Debera cambiarla a continuacion.", "Atención");

                        var resetPassword = new FrmResetPassword();
                        resetPassword.ShowDialog();
                    }
                    
                    Hide();

                    if (usuario.RolesActivos.Count > 1)
                    {
                        var chooseRol = new FrmChooseRol();
                        chooseRol.ShowDialog();
                    }
                    else
                    {
                        SessionManager.CurrentRol = usuario.RolesActivos.First();

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

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            TxtContrasena.Height = TxtUsuario.Height = 20;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void TxtContrasena_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
