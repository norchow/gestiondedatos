using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Calificar_Vendedor;
using FrbaCommerce.ABM_Rol;
using FrbaCommerce.Abm_Visibilidad;


namespace FrbaCommerce.Home
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void administracionDeRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmABMRol = new FrmABMRol();
            frmABMRol.ShowDialog();
        }

        private void administracionDeVisibilidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmABMVisibilidades = new FrmABMVisibilidad();
            frmABMVisibilidades.ShowDialog();
        }

        private void calificarVendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmCalificarVendedor = new FrmCalificarVendedor();
            frmCalificarVendedor.ShowDialog();
        }
    }
}
