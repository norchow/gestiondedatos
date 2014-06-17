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
using Session;
using Configuration;

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class FrmDetallePublicacion : Form
    {
        private Publicacion CurrentPublication = new Publicacion();

        public FrmDetallePublicacion(Publicacion unaPublicacion)
        {
            InitializeComponent();

            CurrentPublication = unaPublicacion;
            CurrentPublication.GetObjectsById();

            if (CurrentPublication.UsuarioCreador.ID != SessionManager.CurrentUser.ID && ClientePersistance.GetByUserId(SessionManager.CurrentUser.ID)!=null)
            {
                if(CurrentPublication.RecibirPreguntas)
                    lblPreguntar.Visible = true;
                if (CurrentPublication.TipoPublicacion.Descripcion == "Subasta")
                {
                    lblOfertar.Visible = true;
                    txtMonto.Visible = true;
                    lblMontoText.Visible = true;
                }
                else
                {
                    LblComprar.Visible = true;
                    lblCantidadText.Visible = true;
                    txtCantidad.Visible = true;
                }
            }

        }

        private void FrmDetallePublicacion_Load(object sender, EventArgs e)
        {
            RefreshSources();
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

        private void LblComprar_Click(object sender, EventArgs e)
        {
            List<PublicacionNotCalified> publications = CalificacionPersistance.GetAllPubicacionNotCalified(SessionManager.CurrentUser);
            if (publications.Count <= 5)
            {
                Compra newPurchase = new Compra();
                newPurchase.Cliente = ClientePersistance.GetByUserId(SessionManager.CurrentUser.ID);
                newPurchase.Publicacion = CurrentPublication;
                newPurchase.Fecha = ConfigurationVariables.FechaSistema;
                newPurchase.Cantidad = Int32.Parse(txtCantidad.Text);
                newPurchase = CompraPersistance.Insert(newPurchase, null);

                CurrentPublication.Stock = CurrentPublication.Stock - newPurchase.Cantidad;
                PublicacionPersistance.Update(CurrentPublication);

                var frmDatosVendedor = new FrmDatosVendedor(CurrentPublication.UsuarioCreador);
                frmDatosVendedor.ShowDialog();

                RefreshSources();
            }
            else
            {
                MessageBox.Show("Tiene demasiadas compras sin calificar, por favor califíquelas para poder realizar una compra");
            }
        }

        private void RefreshSources()
        {
            CurrentPublication.GetObjectsById();

            lblTipoPublicacion.Text = CurrentPublication.TipoPublicacion.Descripcion;
            lblDescripcion.Text = CurrentPublication.Descripcion;
            if (CurrentPublication.TipoPublicacion.Descripcion == "Subasta")
            {
                Oferta lastOffer = OfertaPersistance.GetLastOfertaByPublication(CurrentPublication.ID);
                if (lastOffer != null)
                    lblPrecio.Text = lastOffer.Monto.ToString();
                else
                    lblPrecio.Text = CurrentPublication.Precio.ToString();
            }
            else
                lblPrecio.Text = CurrentPublication.Precio.ToString();

            lblStock.Text = CurrentPublication.Stock.ToString();

            if (CurrentPublication.RecibirPreguntas)
            {
                var questionAnswerDictionary = new Dictionary<int, PreguntaRespuesta>();

                #region Get the dictionary of questions and answers

                List<PreguntaRespuesta> _questionanswers = PublicacionPersistance.GetQuestionsAndAnswersById(CurrentPublication.ID);
                questionAnswerDictionary = _questionanswers.ToDictionary(a => a.IdPregunta, a => a);

                #endregion

                var bind = questionAnswerDictionary.Values.Select(a => new
                {
                    Pregunta = a.TextoPregunta,
                    Respuesta = a.TextoRespuesta
                });

                DgvPreguntasRespuestas.DataSource = bind.ToList();
                DgvPreguntasRespuestas.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                lblPreguntasText.Visible = false;
                DgvPreguntasRespuestas.Visible = false;
            }
        }

        private void lblOfertar_Click(object sender, EventArgs e)
        {
            List<PublicacionNotCalified> publications = CalificacionPersistance.GetAllPubicacionNotCalified(SessionManager.CurrentUser);
            if (publications.Count <= 5)
            {
                if (Int32.Parse(txtMonto.Text) > Int32.Parse(lblPrecio.Text))
                {
                    Oferta newOffer = new Oferta();
                    newOffer.IdCliente = ClientePersistance.GetByUserId(SessionManager.CurrentUser.ID).ID;
                    newOffer.IdPublicacion = CurrentPublication.ID;
                    newOffer.Fecha = ConfigurationVariables.FechaSistema;
                    newOffer.Monto = Int32.Parse(txtMonto.Text);
                    newOffer = OfertaPersistance.Insert(newOffer, null);
                    MessageBox.Show("Se insertó la oferta correctamente");
                    RefreshSources();
                }
                else
                {
                    MessageBox.Show("El monto a ofertar debe ser mayor que la oferta actual");
                }
            }
            else
            {
                MessageBox.Show("Tiene demasiadas compras sin calificar, por favor califíquelas para poder realizar una compra");
            }
        }
    }
}
