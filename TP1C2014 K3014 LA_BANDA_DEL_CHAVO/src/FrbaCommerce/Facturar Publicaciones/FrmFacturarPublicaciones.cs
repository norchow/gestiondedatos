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
using Tools;
using Configuration;

namespace FrbaCommerce.Facturar_Publicaciones
{
    public partial class FrmFacturarPublicaciones : Form
    {
        public bool CompleteAction = false;

        public bool PagaConTarjeta = false;

        public List<Publicacion> PublicationsList { get; set; }

        public bool UserInactive = false;

        public FrmFacturarPublicaciones()
        {
            InitializeComponent();
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
            PublicationsList = PublicacionPersistance.GetPublicacionesARendirByUser(Session.SessionManager.CurrentUser.ID);
            if (PublicationsList != null && PublicationsList.Count > 0)
            {
                if (PublicationsList.Count < 10)
                {
                    var listaItems = new List<string>();
                    foreach (Publicacion item in PublicationsList)
                    {
                        listaItems.Add("Descripción: " + item.Descripcion + " - " +
                                       "Fecha Venc: " + item.FechaVencimiento.ToShortDateString() + " - " +
                                       "Precio: " + String.Format("{0:$0.00}", item.Precio));
                    }

                    LstPublicaciones.DataSource = listaItems;
                }
                else
                {
                    MessageBox.Show("Posee 10 o más publicaciones por facturar y por lo tanto se procederá a inhabilitarlo");
                    UsuarioPersistance.InhabilitarUser(SessionManager.CurrentUser);
                    UserInactive = true;
                    Close();
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
            #region Validaciones

            var exceptionMessage = string.Empty;

            if (TypesHelper.IsEmpty(TxtCantidad.Text) || !TypesHelper.IsNumeric(TxtCantidad.Text))
                exceptionMessage = "Ingrese una cantidad correcta de publicaciones a facturar";

            if (PagaConTarjeta)
            {
                #region Validaciones datos tarjeta

                if (TypesHelper.IsEmpty(TxtCodSeguridad.Text))
                    exceptionMessage += Environment.NewLine + "El codigo de seguridad de la tarjeta es obligatorio";

                if (!TypesHelper.IsNumeric(TxtCodSeguridad.Text))
                    exceptionMessage += Environment.NewLine + "El codigo de seguridad de la tarjeta debe ser numerico";

                if (TypesHelper.IsEmpty(TxtDni.Text))
                    exceptionMessage += Environment.NewLine + "El numero de documento del titular de la tarjeta es obligatorio";

                if (!TypesHelper.IsNumeric(TxtDni.Text))
                    exceptionMessage += Environment.NewLine + "El numero de documento del titular de la tarjeta debe ser numerico";

                if (TypesHelper.IsEmpty(TxtNroTarjeta.Text))
                    exceptionMessage += Environment.NewLine + "El numero de la tarjeta es obligatorio";

                if (!TypesHelper.IsNumeric(TxtNroTarjeta.Text))
                    exceptionMessage += Environment.NewLine + "El numero de la tarjeta debe ser numerico";

                if (TypesHelper.IsEmpty(TxtTarjeta.Text))
                    exceptionMessage += Environment.NewLine + "La descripcion de la tarjeta es obligatorio";

                if (TypesHelper.IsEmpty(TxtTitular.Text))
                    exceptionMessage += Environment.NewLine + "El nombre del titular de la tarjeta es obligatorio";

                if (TypesHelper.IsEmpty(TxtVencimiento.Text))
                    exceptionMessage += Environment.NewLine + "La fecha de vencimiento de la tarjeta es obligatorio";

                if (!TypesHelper.IsNumeric(TxtVencimiento.Text))
                    exceptionMessage += Environment.NewLine + "La fecha de vencimiento de la tarjeta debe ser numerico";

                #endregion
            }

            if (!TypesHelper.IsEmpty(exceptionMessage))
            {
                MessageBox.Show(exceptionMessage, "Atencion");
                return;
            }

            #endregion

            #region Obtengo las publicaciones que voy a rendir

            var cant = Convert.ToInt32(TxtCantidad.Text.Trim());
            if (cant > LstPublicaciones.Items.Count)
                cant = LstPublicaciones.Items.Count;

            var listaPublicacionesAFacturar = PublicationsList.GetRange(0, cant);
            var itemsFactura = new List<ItemFactura>();

            #endregion

            #region Obtengo todos los items de la factura

            foreach (var publicacionFacturar in listaPublicacionesAFacturar)
            {
                var comprasPorPublicacion = CompraPersistance.GetByPublicationId(publicacionFacturar.ID);
                if (comprasPorPublicacion != null)
                {
                    //Pueden ser tanto compras inmediatas o subastas, esta hecho de forma polimorfica
                    foreach (var compra in comprasPorPublicacion)
                        itemsFactura.Add(compra.ConvertToItemFactura());
                }

                //Agrego el item factura de la publicacion en si misma (aunque no tenga compras)
                itemsFactura.Add(publicacionFacturar.ConvertToItemFactura());
            }

            #endregion

            using (var transaction = DataBaseManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    var dialogAnswer = MessageBox.Show("¿Está seguro que quiere facturar " + cant + " publicacion/es?", "Atención", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        #region Armo y guardo la factura en si misma

                        var factura = new Factura
                        {
                            Fecha = ConfigurationVariables.FechaSistema,
                            Numero = FacturaPersistance.GetUltimoNumeroFactura(transaction) + 1,
                            FormaPago = FormaPagoPersistance.GetById((int)CboFormaPago.SelectedValue, transaction),
                            Usuario = (Usuario)SessionManager.CurrentUser,
                            Total = itemsFactura.Sum(item => item.Monto)
                        };

                        //Guardo la factura en la base de datos (y me retorna la factura insertada con el ID correspondiente)
                        factura = FacturaPersistance.InsertFactura(factura, transaction);

                        #endregion

                        if (factura.ID != 0)
                        {
                            Dictionary<int, int> visibilidadesPorUsuario = VisibilidadPersistance.GetAllByUser(SessionManager.CurrentUser, transaction);

                            #region Guardo los items en la base

                            //Creación de los Items de la Factura
                            foreach (var item in itemsFactura)
                            { 
                                item.Factura = factura;

                                #region Logica de bonificacion de items

                                /* Realizo la modificacion del contador solo si el item generado surgio a partir
                                de una compra y no es el item de la publicacion en si misma. */
                                if (item.ContadorBonificacion)
                                {
                                    var idVisibilidad = item.Publicacion.Visibilidad.ID;

                                    if (visibilidadesPorUsuario.ContainsKey(idVisibilidad))
                                        visibilidadesPorUsuario[idVisibilidad]++;
                                    else
                                        visibilidadesPorUsuario.Add(idVisibilidad, 1);

                                    if (visibilidadesPorUsuario[idVisibilidad] == 10)
                                        item.Monto = visibilidadesPorUsuario[idVisibilidad] = 0;
                                }

                                #endregion
                            }
                            
                            var insertoCorrectamente = ItemFacturaPersistance.InsertItemsFactura(itemsFactura, transaction);

                            if (!insertoCorrectamente)
                                throw new Exception("Se produjo un error durante la insercion de los items de la factura");

                            #endregion

                            #region Guardo la informacion de las visibilidades

                            insertoCorrectamente = VisibilidadPersistance.InsertVisibilidadesRendidasPorUsuario(visibilidadesPorUsuario, SessionManager.CurrentUser.ID, transaction);
                            if (!insertoCorrectamente)
                                throw new Exception("Se produjo un error durante la insercion de la informacion de las visibilidades rendidas por usuario");

                            #endregion

                            #region Guardo la informacion de la tarjeta de credito

                            if (PagaConTarjeta)
                            {
                                var tarjeta = new TarjetaCredito
                                {
                                    Tarjeta = TxtTarjeta.Text,
                                    NumeroTarjeta = Convert.ToInt32(TxtNroTarjeta.Text),
                                    Vencimiento = Convert.ToInt32(TxtVencimiento.Text),
                                    CodigoSeguridad = Convert.ToInt32(TxtCodSeguridad.Text),
                                    Titular = TxtTitular.Text,
                                    DniTitular = Convert.ToInt32(TxtDni.Text),
                                    Factura = factura
                                };

                                tarjeta = TarjetaCreditoPersistance.Insert(tarjeta, transaction);

                                if (tarjeta.ID == 0)
                                    throw new Exception("Se produjo un error durante la insercion de la informacion de la tarjeta");
                            }

                            #endregion

                            transaction.Commit();

                            MessageBox.Show("Se facturaron satisfactoriamente las publicaciones", "Atencion");
                            CompleteAction = true;

                            Close();
                        }
                        else
                            transaction.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    TxtCantidad.Clear();
                    MessageBox.Show(ex.Message, "Atencion");
                }
            }

        }

        private void CboFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatosTarjeta.Visible = PagaConTarjeta = (CboFormaPago.SelectedIndex != 0);
        }
    }
}
