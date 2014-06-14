using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Persistance;
using System.Data.SqlClient;
using Persistance.Entities;
using Session;
using FrbaCommerce.Home;
using System.Configuration;

namespace FrbaCommerce.Facturar_Publicaciones
{
    public partial class FrmFacturarPublicaciones : Form
    {
        public bool CompleteAction = false;
        public bool insertMode { get; set; }
        public SqlTransaction currentTransaction { get; set; }

        public FrmFacturarPublicaciones()
        {
            InitializeComponent();
        }

        public FrmFacturarPublicaciones(SqlTransaction transaction)
        {
            InitializeComponent();
            insertMode = transaction != null;

            this.currentTransaction = transaction;
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
                #region Facturar Publicación

                var listaPublicacionesAFacturar = PublicacionPersistance.GetPublicacionesMasAntiguasARendirByUser(Session.SessionManager.CurrentUser.ID, cant);
                foreach (var publicacion in listaPublicacionesAFacturar)
                {
                    //Items de la Factura con respecto a las comisiones por la visibilidad de la Publicación
                    var listItemsFactura = new List<ItemFactura>();
                    var itemsFactura = CompraPersistance.GetCantidadComprasByPublicationIdGroupByClient(publicacion.ID, this.currentTransaction);
                    for (var a = 0; a <= itemsFactura.Count - 1; a++)
                    {
                        var item = new ItemFactura();
                        item.Factura = FacturaPersistance.GetFacturaByPublicationId(publicacion.ID);
                        item.Publicacion = publicacion;
                        item.Monto = publicacion.Precio * publicacion.Visibilidad.PorcentajeVenta * itemsFactura[a];
                        item.Cantidad = itemsFactura[a];
                        listItemsFactura.Add(item);
                        ItemFacturaPersistance.InsertItemFactura(item, this.currentTransaction);
                    }

                    //Item de la Factura de la publicación en si misma
                    var itemPorPublicar = new ItemFactura();
                    itemPorPublicar.Factura = FacturaPersistance.GetFacturaByPublicationId(publicacion.ID);
                    itemPorPublicar.Publicacion = publicacion;
                    itemPorPublicar.Monto = publicacion.Visibilidad.PrecioPublicar;
                    itemPorPublicar.Cantidad = 1;
                    listItemsFactura.Add(itemPorPublicar);
                    ItemFacturaPersistance.InsertItemFactura(itemPorPublicar, this.currentTransaction);

                    //Armado de la Factura
                    var factura = new Factura();
                    factura.Numero = FacturaPersistance.GetUltimoNumeroFactura() + 1;
                    factura.Fecha = Convert.ToDateTime(ConfigurationSettings.AppSettings["FechaSistema"]);
                    factura.Total = listItemsFactura.Sum(x => x.Monto * x.Cantidad);
                    factura.FormaPago = FormaPagoPersistance.GetById((int)CboFormaPago.SelectedValue);

                    var dialogAnswer = MessageBox.Show("Esta seguro que quiere facturar estas " + cant + " publicaciones?", "Atencion", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        FacturaPersistance.InsertFactura(factura, this.currentTransaction);
                        MessageBox.Show("Se facturaron satisfactoriamente las publicaciones", "Atencion");
                        CompleteAction = true;
                        this.currentTransaction.Commit();
                        this.Hide();
                        var frmHome = new FrmHome();
                        frmHome.ShowDialog();
                    }
                }

                #endregion
            }
        }
    }
}
