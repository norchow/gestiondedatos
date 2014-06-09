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
using Persistance.Entities;
using Session;

namespace FrbaCommerce.Login
{
    public partial class FrmResetPassword : Form
    {
        public Usuario currentUser { get; set; }
 
        public FrmResetPassword()
        {
            InitializeComponent();
            this.currentUser = SessionManager.CurrentUser;
        }

        public FrmResetPassword(Usuario user)
        {
            InitializeComponent();
            this.currentUser = user;
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

                UsuarioPersistance.ChangePassword(this.currentUser, hashedPassword);
                this.currentUser = UsuarioPersistance.GetByUsername(this.currentUser.Username);
                
                Close();
            }
        }

        private void FrmResetPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
