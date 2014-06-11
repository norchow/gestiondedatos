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
            #region Display Sources

            var paymentMethod = FormaPagoPersistance.GetAll();
            CboFormaPago.DisplayMember = "Descripcion";
            CboFormaPago.ValueMember = "ID";
            CboFormaPago.DataSource = paymentMethod;

            var publicationsList = PublicacionPersistance.GetPublicacionesARendirByUser(Session.SessionManager.CurrentUser.ID);
            if (publicationsList != null && publicationsList.Count > 0)
            {
                foreach (Publicacion item in publicationsList)
                {
                    LstPublicaciones.DisplayMember = item.Descripcion + " - " +
                                                     "Fecha Venc: " + item.FechaVencimiento.ToShortDateString() + " - " +
                                                     String.Format("{0:$0.00}", item.Precio);
                    LstPublicaciones.ValueMember = item.ID.ToString();
                }
            }
            else
            {
                MessageBox.Show("En este momento no tiene niguna publicación para facturar", "Atención!");
                Close();
            }

            #endregion


        }

        private void LblCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LblFacturar_Click(object sender, EventArgs e)
        {
            int cant; 
            if (TxtCantidad.Text == "" || int.TryParse(TxtCantidad.Text, out cant))
            {
                MessageBox.Show("Ingrese una cantidad correcta de publicaciones a facturar", "Error!");
            }
            else
            {
                var listaPublicacionesAFacturar = PublicacionPersistance.GetPublicacionesMasAntiguasARendirByUser(Session.SessionManager.CurrentUser.ID, cant);
                foreach (var publicacion in listaPublicacionesAFacturar)
                {
                    //PublicacionPersistance.FacturarPublicacion(parametros que necesita la factura);
                }
            }
        }
    }
}
