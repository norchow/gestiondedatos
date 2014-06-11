using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Persistance;
using Persistance.Entities;
using FrbaCommerce.Gestion_de_Preguntas;

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class FrmDetallePublicacion : Form
    {
        private Publicacion CurrentPublication = new Publicacion();

        public FrmDetallePublicacion(Publicacion unaPublicacion)
        {
            InitializeComponent();

            CurrentPublication = unaPublicacion;

            if (CurrentPublication.RecibirPreguntas)
                lblPreguntar.Visible = true;
            else
                lblPreguntar.Visible = false;
        }

        private void FrmDetallePublicacion_Load(object sender, EventArgs e)
        {
            CurrentPublication.GetObjectsById();

            lblTipoPublicacion.Text = CurrentPublication.TipoPublicacion.Descripcion;
            lblDescripcion.Text = CurrentPublication.Descripcion;
            lblPrecio.Text = CurrentPublication.Precio.ToString();//LA SUBASTA DEBERÍA TRAER LA ULTIMA OFERTA
            lblStock.Text = CurrentPublication.Stock.ToString();
        }

        private void lblPreguntar_Click(object sender, EventArgs e)
        {
            var frmPreguntar = new FrmPreguntar(CurrentPublication);
            frmPreguntar.ShowDialog();
        }

        private void LblVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
