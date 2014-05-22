using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Calificar_Vendedor;

namespace FrbaCommerce.Home
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void btnCalificarVendedor_Click(object sender, EventArgs e)
        {
            var frmCalificarVendedor = new FrmCalificarVendedor();
            frmCalificarVendedor.Show();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {

        }
    }
}
