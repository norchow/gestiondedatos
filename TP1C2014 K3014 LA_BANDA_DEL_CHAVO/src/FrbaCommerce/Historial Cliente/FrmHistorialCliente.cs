using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Historial_Cliente
{
    public partial class FrmHistorialCliente : Form
    {
        public FrmHistorialCliente()
        {
            InitializeComponent();
        }

        private void FrmHistorialCliemte_Load(object sender, EventArgs e)
        {

        }

        private void LblListo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblCompras_Click(object sender, EventArgs e)
        {
            var frmHistorialCompras = new FrmHistorialCompras();
            frmHistorialCompras.ShowDialog();
        }

        private void lblOfertas_Click(object sender, EventArgs e)
        {
            var frmHistorialOfertas = new FrmHistorialOfertas();
            frmHistorialOfertas.ShowDialog();
        }

        private void lblCalificaciones_Click(object sender, EventArgs e)
        {
            var frmHistorialCalificacionesOtorgadas = new FrmHistorialCalificacionesOtorgadas();
            frmHistorialCalificacionesOtorgadas.ShowDialog();
        }

        private void lblReputacion_Click(object sender, EventArgs e)
        {
            var frmHistorialReputacion = new FrmHistorialReputacion();
            frmHistorialReputacion.ShowDialog();
        }
    }
}
