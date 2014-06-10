using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Persistance;
using Tools;
using Persistance.Entities;
using Configuration;
using Session;

namespace FrbaCommerce.Facturar_Publicaciones
{
    public partial class FrmFacturarPublicaciones : Form
    {
        public FrmFacturarPublicaciones()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region Display Forma de Pago source

            var paymentMethod = FormaPagoPersistance.GetAll();
            CboFormaPago.DisplayMember = "Descripcion";
            CboFormaPago.ValueMember = "ID";
            CboFormaPago.DataSource = paymentMethod;

            #endregion
        }

        private void LblCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
