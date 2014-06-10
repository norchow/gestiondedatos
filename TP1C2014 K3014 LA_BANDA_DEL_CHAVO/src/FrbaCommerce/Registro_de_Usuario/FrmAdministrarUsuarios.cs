using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Home;
using Persistance;
using Persistance.Entities;
using FrbaCommerce.Login;

namespace FrbaCommerce.Registro_de_Usuario
{
    public partial class FrmAdministrarUsuarios : Form
    {
        public Usuario currentUser { get; set; }

        public FrmAdministrarUsuarios()
        {
            InitializeComponent();
        }

        private void lblVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmAdministrarUsuarios_Load(object sender, EventArgs e)
        {
            cboUsuarios.DataSource = UsuarioPersistance.GetAll();
            cboUsuarios.ValueMember = "ID";
            cboUsuarios.DisplayMember = "Username";
        }

        private void cboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.currentUser = (Usuario)cboUsuarios.SelectedItem;
            chkActivo.Checked = this.currentUser.Activo;
        }

        private void chkActivo_CheckedChanged(object sender, EventArgs e)
        {
            this.currentUser.Activo = chkActivo.Checked;
            UsuarioPersistance.Update(this.currentUser);
        }

        private void lblCambiarPassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frmResetPassword = new FrmResetPassword(this.currentUser);
            frmResetPassword.ShowDialog();
        }
    }
}
