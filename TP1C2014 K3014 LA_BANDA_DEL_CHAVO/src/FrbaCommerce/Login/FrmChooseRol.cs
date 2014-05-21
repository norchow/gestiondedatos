using System;
using System.Windows.Forms;
using FrbaCommerce.Home;
using Persistance.Entities;
using Session;

namespace FrbaCommerce.Login
{
    public partial class FrmChooseRol : Form
    {
        public FrmChooseRol()
        {
            InitializeComponent();
        }

        private void FrmChooseRol_Load(object sender, EventArgs e)
        {
            CboRoles.DisplayMember = "Descripcion";
            CboRoles.ValueMember = "ID_Rol";
            CboRoles.DataSource = SessionManager.CurrentUser.RolesActivos;
        }

        private void LblEntrar_Click(object sender, EventArgs e)
        {
            var selectedRole = (Rol)CboRoles.SelectedItem;

            if (selectedRole != null)
            {
                var dialogAnswer = MessageBox.Show(string.Format("Se procederá a logear con el siguiente rol: {0}. Esta seguro?", selectedRole.Descripcion), "Atención", MessageBoxButtons.YesNo);
                if (dialogAnswer == DialogResult.Yes)
                {
                    Hide();

                    SessionManager.CurrentRol = selectedRole;

                    var home = new FrmHome();
                    home.ShowDialog();

                    Close();
                }
            }
            else
            {
                MessageBox.Show("Primero debe seleccionar un rol.", "Atención");
            }
        }
    }
}
