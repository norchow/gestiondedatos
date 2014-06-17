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
            //No se le pasa ningun usuario por parametro, toma el que esta logueado en sesion
            InitializeComponent();
            this.currentUser = SessionManager.CurrentUser;
        }

        public FrmResetPassword(Usuario user)
        {
            //Se le pasa el usuario por parametro
            InitializeComponent();
            this.currentUser = user;
        }

        private void LblAceptar_Click(object sender, EventArgs e)
        {
            //Valido que las contraseñas coincidan
            if (TxtContrasena.Text != TxtContrasenaRepetida.Text)
            {
                MessageBox.Show("Las contrasenas informadas no coinciden.", "Atención");
            }
            else
            {
                //Encripto la nueva contraseña
                var hashedPassword = SHA256Helper.Encode(TxtContrasena.Text);

                //Impacto el cambio en la base de datos
                UsuarioPersistance.ChangePassword(this.currentUser, hashedPassword);
                //Vuelvo a traer el usuario porque cambió
                SessionManager.CurrentUser = UsuarioPersistance.GetByUsername(this.currentUser.Username);
                
                Close();
            }
        }
    }
}
