using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tools;
using Persistance;
using Session;

namespace FrbaCommerce.Login
{
    public partial class FrmResetPassword : Form
    {
        public FrmResetPassword()
        {
            InitializeComponent();
        }

        private void LblAceptar_Click(object sender, EventArgs e)
        {
            if (TxtContrasena.Text != TxtContrasenaRepetida.Text)
            {
                MessageBox.Show("Las contrasenas informadas no coinciden.", "Atención");
            }
            else
            {
                var hashedPassword = SHA256Helper.Encode(TxtContrasena.Text);

                var persitance = new UsuarioPersistance();
                persitance.ChangePassword(SessionManager.CurrentUser, hashedPassword);

                SessionManager.CurrentUser = persitance.GetUserByUsername(SessionManager.CurrentUser.Username);
                
                Close();
            }
        }
    }
}
