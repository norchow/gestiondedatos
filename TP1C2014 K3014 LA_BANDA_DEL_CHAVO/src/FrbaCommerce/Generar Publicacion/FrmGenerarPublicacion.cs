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
using System.Data.SqlClient;

namespace FrbaCommerce.Generar_Publicacion
{
    public partial class FrmGenerarPublicacion : Form
    {
        public bool Auction { get; set; }

        public bool CompleteAction = false;

        private bool insertMode { get; set; }

        private Publicacion CurrentPublication { get; set; }

        public FrmGenerarPublicacion(Publicacion publication)
        {
            InitializeComponent();
            //Trabaja en modo alta cuando se le pasa NULL como parametro
            insertMode = publication == null;

            if (!insertMode)
                CurrentPublication = publication;
        }

        private void FrmGenerarPublicacion_Load(object sender, EventArgs e)
        {
            #region Display all sources

            var publicationTypes = TipoPublicacionPersistance.GetAll();
            CboTipoPublicacion.DisplayMember = "Descripcion";
            CboTipoPublicacion.ValueMember = "ID";
            CboTipoPublicacion.DataSource = publicationTypes;

            var publicationStates = EstadoPublicacionPersistance.GetAll();
            CboEstadoPublicacion.DisplayMember = "Descripcion";
            CboEstadoPublicacion.ValueMember = "ID";
            CboEstadoPublicacion.DataSource = publicationStates;

            var visibilities = VisibilidadPersistance.GetAll();
            CboVisibilidad.DisplayMember = "Descripcion";
            CboVisibilidad.ValueMember = "ID";
            CboVisibilidad.DataSource = visibilities;

            var rubros = RubroPersistance.GetAll();
            LstRubro.DataSource = rubros;
            LstRubro.DisplayMember = "Descripcion";
            LstRubro.ValueMember = "ID";

            #endregion

            if (!insertMode)
            {
                #region Load updating publication data

                CurrentPublication.GetObjectsById();

                CboEstadoPublicacion.Text = CurrentPublication.EstadoPublicacion.Descripcion;
                CboTipoPublicacion.Text = CurrentPublication.TipoPublicacion.Descripcion;
                CboVisibilidad.Text = CurrentPublication.Visibilidad.Descripcion;
                TxtDescripcion.Text = CurrentPublication.Descripcion;

                if (CurrentPublication.TipoPublicacion.Descripcion == "Subasta")
                {
                    TxtPrecio.Enabled = false;
                    TxtValorInicioSubasta.Text = CurrentPublication.Precio.ToString();
                }
                else
                {
                    TxtValorInicioSubasta.Enabled = false;
                    TxtPrecio.Text = CurrentPublication.Precio.ToString();
                }

                TxtStock.Text = CurrentPublication.Stock.ToString();
                ChkRecibirPreguntas.Checked = CurrentPublication.RecibirPreguntas;

                //Marco como chequeados los rubros que ya posee la publicación
                for (int j = 0; j < LstRubro.Items.Count; j++)
                {
                    var checkboxListItem = (Rubro)LstRubro.Items[j];

                    if (CurrentPublication.Rubros.Any(p => p.Descripcion == checkboxListItem.Descripcion))
                        LstRubro.SetItemChecked(j, true);
                    else
                        LstRubro.SetItemChecked(j, false);
                }

                #endregion

                #region Habilito los controles dependiendo del estado de la publicacion

                switch (CurrentPublication.EstadoPublicacion.Descripcion)
                {
                    case "Publicada":
                        #region Publicada

                        DisableUIControls();
                        TxtDescripcion.Enabled = true;
                        CboEstadoPublicacion.Enabled = true;
                        TxtStock.Enabled = (CurrentPublication.TipoPublicacion.Descripcion != "Subasta");

                        break;

                        #endregion
                        
                    case "Pausada":
                    case "Finalizada":
                        #region Pausada y Finalizada

                        LblLimpiar.Enabled = false;
                        DisableUIControls();

                        break;
                        #endregion
                }

                #endregion
            }
        }

        private void DisableUIControls()
        {
            CboEstadoPublicacion.Enabled = false;
            CboTipoPublicacion.Enabled = false;
            CboVisibilidad.Enabled = false;
            TxtPrecio.Enabled = false;
            TxtValorInicioSubasta.Enabled = false;
            LstRubro.Enabled = false;
            ChkRecibirPreguntas.Enabled = false;
            TxtStock.Enabled = false;
            TxtDescripcion.Enabled = false;
        }

        private void LblListo_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validations

                var exceptionMessage = string.Empty;

                if (Auction)
                {
                    if (TypesHelper.IsEmpty(TxtValorInicioSubasta.Text))
                        exceptionMessage += Environment.NewLine + "El valor de inicio de la subasta no puede ser vacío.";

                    if (!TypesHelper.IsDecimal(TxtValorInicioSubasta.Text))
                        exceptionMessage += Environment.NewLine + "El valor de inicio de la subasta debe ser decimal (o numérico).";
                }
                else
                {
                    if (TypesHelper.IsEmpty(TxtPrecio.Text))
                        exceptionMessage += Environment.NewLine + "El precio del articulo no puede ser vacío.";

                    if (!TypesHelper.IsDecimal(TxtPrecio.Text))
                        exceptionMessage += Environment.NewLine + "El precio del articulo debe ser decimal (o numérico).";
                }

                if (TypesHelper.IsEmpty(TxtDescripcion.Text))
                    exceptionMessage += Environment.NewLine + "La descripcion del articulo no puede ser vacío.";

                if (TypesHelper.IsEmpty(TxtStock.Text))
                    exceptionMessage += Environment.NewLine + "El stock del articulo no puede ser vacío.";

                if (!TypesHelper.IsNumeric(TxtStock.Text))
                    exceptionMessage += Environment.NewLine + "El stock del articulo debe ser numérico.";

                if (LstRubro.CheckedItems.Count == 0)
                    exceptionMessage += Environment.NewLine + "Debe informar por lo menos un rubro.";

                if (!TypesHelper.IsEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);

                #endregion

                if (insertMode)
                {
                    #region Insert the new publication

                    if (CboVisibilidad.Text == "Gratis" && CboEstadoPublicacion.Text == "Publicada")
                    {
                        var freePublicationsActive = PublicacionPersistance.GetAllActiveAndFreeByUser(SessionManager.CurrentUser.ID);
                        if (freePublicationsActive > 2)
                            throw new Exception("No se puede generar la publicación, ya que cuenta con tres publicaciones activas con visibilidad 'Gratis'.");
                    }

                    var publication = new Publicacion();

                    LoadObjectFromUIControls(publication);

                    var dialogAnswer = MessageBox.Show("Esta seguro que quiere insertar la nueva publicacion?", "Atencion", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        if (PublicacionPersistance.Insert(publication) == 1)
                        {
                            MessageBox.Show("Se inserto satisfactoriamente la nueva publicacion", "Atencion");
                            CompleteAction = true;
                            Close();
                        }
                    }

                    #endregion
                }
                else
                {
                    #region Update an existing publication

                    #region Validations

                    var messageExceptions = string.Empty;

                    //Realizo la validación solo cuando cambió o el estado o el tipo de publicación
                    if (CurrentPublication.EstadoPublicacion.Descripcion != CboEstadoPublicacion.Text || CurrentPublication.Visibilidad.Descripcion != CboVisibilidad.Text)
                    {
                        if (CboVisibilidad.Text == "Gratis" && CboEstadoPublicacion.Text == "Publicada")
                        {
                            var freePublicationsActive = PublicacionPersistance.GetAllActiveAndFreeByUser(SessionManager.CurrentUser.ID);
                            if (freePublicationsActive > 2)
                                throw new Exception("No se puede generar la publicación, ya que cuenta con tres publicaciones activas con visibilidad 'Gratis'.");
                        }
                    }

                    if (CurrentPublication.EstadoPublicacion.Descripcion == "Publicada" && CboEstadoPublicacion.Text == "Borrador")
                        messageExceptions += "No se puede cambiar el estado de una publicacion 'Publicada' a 'Borrador'.";

                    if (CurrentPublication.EstadoPublicacion.Descripcion == "Publicada" && CurrentPublication.Stock > Convert.ToInt32(TxtStock.Text))
                        messageExceptions += Environment.NewLine + "No se puede decrementar el stock de una publicacion en estado 'Publicada'.";

                    if (!TypesHelper.IsEmpty(messageExceptions))
                        throw new Exception(messageExceptions);

                    #endregion

                    var oldDescription = CurrentPublication.Descripcion;
                    LoadObjectFromUIControls(CurrentPublication);

                    var dialogAnswer = MessageBox.Show(string.Format("Esta seguro que quiere modificar la publicacion {0}?", oldDescription), "Atencion", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        if (CboTipoPublicacion.Text == "Subasta" && CboEstadoPublicacion.Text == "Finalizada")
                        {
                            using (var transaction = DataBaseManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
                            {
                                if (PublicacionPersistance.Update(CurrentPublication, transaction) == 1)
                                {
                                    var lastOffer = OfertaPersistance.GetLastOfertaByPublication(CurrentPublication.ID, transaction);

                                    //No tiene ofertas, no genero ningun registro en la tabla de compras
                                    if (lastOffer == null)
                                    {
                                        CommitTransaction(transaction);
                                        return;
                                    }
                                    
                                    var purchase = CompraPersistance.Insert(lastOffer.ConvertToPurchase(), transaction);

                                    //Commiteo la transaccion solo si pudo insertar la compra en la base de datos
                                    if (purchase.ID != 0)
                                    {
                                        CommitTransaction(transaction);
                                        return;
                                    }
                                    else
                                        transaction.Rollback();
                                }
                                else
                                    transaction.Rollback();
                            }
                        }
                        else if (PublicacionPersistance.Update(CurrentPublication) == 1)
                        {
                            MessageBox.Show("Se modifico satisfactoriamente la publicacion", "Atencion");
                            CompleteAction = true;
                            Close();
                        }
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atencion");
            }
        }

        private void CommitTransaction(SqlTransaction transaction)
        {
            transaction.Commit();
            MessageBox.Show("Se modifico satisfactoriamente la publicacion", "Atencion");
            CompleteAction = true;
            Close();
        }

        private void LoadObjectFromUIControls(Publicacion publication)
        {
            publication.Descripcion = TxtDescripcion.Text;
            publication.Stock = Convert.ToInt32(TxtStock.Text);
            publication.TipoPublicacion = ((TipoPublicacion)CboTipoPublicacion.SelectedItem);
            publication.EstadoPublicacion = ((EstadoPublicacion)CboEstadoPublicacion.SelectedItem);
            publication.Precio = (Auction) ? Convert.ToDouble(TxtValorInicioSubasta.Text) : Convert.ToDouble(TxtPrecio.Text);
            publication.RecibirPreguntas = ChkRecibirPreguntas.Checked;
            publication.Visibilidad = ((Visibilidad)CboVisibilidad.SelectedItem);
            publication.FechaInicio = ConfigurationVariables.FechaSistema;
            publication.FechaVencimiento = ConfigurationVariables.FechaSistema.AddDays(publication.Visibilidad.Duracion);
            publication.UsuarioCreador = SessionManager.CurrentUser;
            
            publication.Rubros = new List<Rubro>();
            foreach (var checkedItem in LstRubro.CheckedItems)
            {
                var category = (Rubro)checkedItem;
                publication.Rubros.Add(category);
            }
        }

        private void CboTipoPublicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            var publicationTypeSelected = (TipoPublicacion)CboTipoPublicacion.SelectedItem;
            if (publicationTypeSelected != null)
                Auction = TxtValorInicioSubasta.Enabled = publicationTypeSelected.Descripcion == "Subasta";

            TxtPrecio.Enabled = !Auction;
            LblRequeridoPrecio.Visible = !Auction;
            LblRequeridoValorInicial.Visible = Auction;
            if (Auction)
            {
                TxtStock.Enabled = false;
                TxtStock.Text = "1";
            }
            else
            {
                TxtStock.Enabled = true;
                TxtStock.Text = string.Empty;
            }
        }

        private void LblLimpiar_Click(object sender, EventArgs e)
        {
            ClearUIControls();
        }

        private void LblCancelar_Click(object sender, EventArgs e)
        {
           Close();
        }

        private void ClearUIControls()
        {
            if (insertMode || CurrentPublication.EstadoPublicacion.Descripcion == "Borrador")
            {
                CboEstadoPublicacion.SelectedIndex = 0;
                CboTipoPublicacion.SelectedIndex = 0;
                CboVisibilidad.SelectedIndex = 0;
                ChkRecibirPreguntas.Checked = false;
                TxtValorInicioSubasta.Text = string.Empty;
                TxtDescripcion.Text = string.Empty;
                TxtPrecio.Text = string.Empty;
                TxtStock.Text = string.Empty;

                if (LstRubro.CheckedIndices != null)
                    foreach (var checkedIndex in LstRubro.CheckedIndices)
                        LstRubro.SetItemCheckState((int)checkedIndex, CheckState.Unchecked);
            }
            else
            {
                if (CurrentPublication.TipoPublicacion.Descripcion != "Subasta")
                {
                    TxtDescripcion.Text = string.Empty;
                    TxtStock.Text = string.Empty;
                    CboEstadoPublicacion.SelectedIndex = 0;
                }
            }
        }
    }
}
