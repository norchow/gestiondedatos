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
            #region Precargar elementos

            //Cargar el combobox FormaPago
            var paymentMethod = FormaPagoPersistance.GetAll();
            CboFormaPago.DisplayMember = "Descripcion";
            CboFormaPago.ValueMember = "ID";
            CboFormaPago.DataSource = paymentMethod;

            //Cargar la lista con las Publicaciones a rendir del usuario
            var publicationsList = PublicacionPersistance.GetPublicacionesARendirByUser(Session.SessionManager.CurrentUser.ID);
            if (publicationsList != null && publicationsList.Count > 0)
            {
                if (publicationsList.Count < 10)
                {
                    var listaItems = new List<string>();
                    foreach (Publicacion item in publicationsList)
                    {
                        listaItems.Add("Descripción: " + item.Descripcion + " - " +
                                       "Fecha Venc: " + item.FechaVencimiento.ToShortDateString() + " - " +
                                       "Precio: " + String.Format("{0:$0.00}", item.Precio));
                    }
                    LstPublicaciones.DataSource = listaItems;
                }
                else
                {
                    var user = SessionManager.CurrentUser ;
                    UsuarioPersistance.InhabilitarUser(user);
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
            this.Hide();
            var frmHome = new FrmHome();
            frmHome.ShowDialog();
        }

        private void LblFacturar_Click(object sender, EventArgs e)
        {
            int cant;
            bool isNum = int.TryParse(TxtCantidad.Text.Trim(), out cant);
            if (TxtCantidad.Text == "" || !isNum)
            {
                MessageBox.Show("Ingrese una cantidad correcta de publicaciones a facturar", "Error!");
                TxtCantidad.Clear();
            }
            else
            {
                #region Facturar Publicación

                if (cant > LstPublicaciones.Items.Count)
                    cant = LstPublicaciones.Items.Count;

                var listaPublicacionesAFacturar = PublicacionPersistance.GetPublicacionesMasAntiguasARendirByUser(Session.SessionManager.CurrentUser.ID, cant);
                foreach (var publicacion in listaPublicacionesAFacturar)
                {
                    publicacion.GetObjectsById();

                    //Armado de Items de la Factura con respecto a las comisiones por la visibilidad de la Publicación
                    var listItemsFactura = new List<ItemFactura>();
                    var itemsFactura = CompraPersistance.GetCantidadComprasByPublicationIdGroupByClient(publicacion.ID, this.currentTransaction);
                    for (var a = 0; a <= itemsFactura.Count - 1; a++)
                    {
                        var item = new ItemFactura(); 
                        item.Publicacion = publicacion;
                        item.Monto = publicacion.Precio * publicacion.Visibilidad.PorcentajeVenta * itemsFactura[a];
                        item.Cantidad = itemsFactura[a];
                        listItemsFactura.Add(item);
                    }

                    //Armado del Item de la Factura de la publicación en si misma
                    var itemPorPublicar = new ItemFactura();
                    itemPorPublicar.Publicacion = publicacion;
                    itemPorPublicar.Monto = publicacion.Visibilidad.PrecioPublicar;
                    itemPorPublicar.Cantidad = 1;
                    listItemsFactura.Add(itemPorPublicar);

                    //Armado de la Factura
                    var factura = new Factura();
                    factura.Numero = FacturaPersistance.GetUltimoNumeroFactura() + 1;
                    factura.Fecha = Configuration.ConfigurationVariables.FechaSistema;
                    factura.Total = listItemsFactura.Sum(x => x.Monto * x.Cantidad);
                    factura.FormaPago = FormaPagoPersistance.GetById((int)CboFormaPago.SelectedValue);
                    factura.Usuario = SessionManager.CurrentUser;

                    var dialogAnswer = MessageBox.Show("¿Está seguro que quiere facturar " + cant + " publicacion/es?", "Atención", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        //Creación de la Factura
                        FacturaPersistance.InsertFactura(factura, this.currentTransaction);

                        //Creación de los Items de la Factura
                        foreach (var item in listItemsFactura)
                        {
                            item.Factura = FacturaPersistance.GetFacturaByNumero(factura.Numero);
                            ItemFacturaPersistance.InsertItemFactura(item, this.currentTransaction);
                        }

                        MessageBox.Show("Se facturaron satisfactoriamente las publicaciones", "Atencion");
                        CompleteAction = true;
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
