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
            //Traigo todos los objetos relacionados con la publicación
            CurrentPublication.GetObjectsById();

            //Si la publicación no es del usuario logeado y el usuario logeado es un cliente le permito 
            //ver las opciones de comprar/ofertar/preguntar (Todas los los controles respectivos a estas funciones
            //tienen enabled=false como default
            if (CurrentPublication.UsuarioCreador.ID != SessionManager.CurrentUser.ID)
            {
                if (CurrentPublication.RecibirPreguntas)
                    lblPreguntar.Enabled = true;
                else
                    lblErrorPreguntar.Visible = true;

                if (CurrentPublication.TipoPublicacion.Descripcion == "Subasta")
                {
                    lblOfertar.Enabled = true;
                    txtMonto.Enabled = true;
                    lblMontoText.Enabled = true;
                }
                else
                {
                    LblComprar.Enabled = true;
                    lblCantidadText.Enabled = true;
                    txtCantidad.Enabled = true;
                }
            }
            else
            {
                lblErrorComprarOfertar.Visible = true;
                lblErrorPreguntar.Visible = true;
            }

            //Oculto los controles que no corresponden
            if (CurrentPublication.TipoPublicacion.Descripcion == "Subasta")
            {
                LblComprar.Visible = false;
                lblCantidadText.Visible = false;
                txtCantidad.Visible = false;
            }
            else
            {
                lblOfertar.Visible = false;
                txtMonto.Visible = false;
                lblMontoText.Visible = false;
            }
        }

        private void FrmDetallePublicacion_Load(object sender, EventArgs e)
        {
            RefreshSources();
        }

        private void lblPreguntar_Click(object sender, EventArgs e)
        {
            try
            {
                if (SessionManager.CurrentRol.Descripcion == "Administrador General")
                    throw new Exception("Siendo un administrador no puede hacer preguntas");

                //Abro el formulario de preguntas
                var frmPreguntar = new FrmPreguntar(CurrentPublication);
                frmPreguntar.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LblVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LblComprar_Click(object sender, EventArgs e)
        {
            try
            {
                if (SessionManager.CurrentRol.Descripcion == "Administrador General")
                    throw new Exception("Siendo un administrador no puede comprar ni ofertar");

                List<PublicacionNotCalified> publications = CalificacionPersistance.GetAllPubicacionNotCalified(SessionManager.CurrentUser);
                if (publications.Count > 5)
                    throw new Exception("Tiene demasiadas compras sin calificar, por favor califíquelas para poder realizar una compra");

                //Valido que ingrese una cantidad válida (mayor a 0 y menor que el stock)
                if (txtCantidad.Text == "" || Int32.Parse(txtCantidad.Text) < 0 || Int32.Parse(txtCantidad.Text) > Int32.Parse(lblStock.Text))
                    throw new Exception("Ingrese una cantidad válida (mayor a 0 y menor que el stock actual)");

                //Creo la nueva compra y la inserto
                Compra newPurchase = new Compra();
                newPurchase.Usuario = SessionManager.CurrentUser;
                newPurchase.Publicacion = CurrentPublication;
                newPurchase.Fecha = ConfigurationVariables.FechaSistema;
                newPurchase.Cantidad = Int32.Parse(txtCantidad.Text);
                newPurchase = CompraPersistance.Insert(newPurchase, null);

                //Resto el stock de la publicación
                CurrentPublication.Stock = CurrentPublication.Stock - newPurchase.Cantidad;
                if (CurrentPublication.Stock == 0)
                    CurrentPublication.EstadoPublicacion = EstadoPublicacionPersistance.GetById(4); //finalizada
                PublicacionPersistance.Update(CurrentPublication);

                //Le muestro al usuario los datos del vendedor
                var frmDatosVendedor = new FrmDatosVendedor(CurrentPublication.UsuarioCreador);
                frmDatosVendedor.ShowDialog();

                RefreshSources();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshSources()
        {
            CurrentPublication.GetObjectsById();

            //Cargo todos los controles con la publicación actual
            lblTipoPublicacion.Text = CurrentPublication.TipoPublicacion.Descripcion;
            lblDescripcion.Text = CurrentPublication.Descripcion;
            if (CurrentPublication.TipoPublicacion.Descripcion == "Subasta")
            {
                //Traigo el monto correspondiente. Si es compra inmediata el precio elegido, y si es subasta
                //la última oferta
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
                //Cargo las preguntas y respuestas
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
            try
            {
                if (SessionManager.CurrentRol.Descripcion == "Administrador General")
                    throw new Exception("Siendo un administrador no puede comprar ni ofertar");

                List<PublicacionNotCalified> publications = CalificacionPersistance.GetAllPubicacionNotCalified(SessionManager.CurrentUser);
                if (publications.Count > 5)
                    throw new Exception("Tiene demasiadas compras sin calificar, por favor califíquelas para poder realizar una compra");

                //Valido que la oferta sea mayor a la última
                if (txtMonto.Text == "" || Int32.Parse(txtMonto.Text) <= Int32.Parse(lblPrecio.Text))
                    throw new Exception("El monto a ofertar debe ser mayor que la oferta actual");

                //Creo la nueva oferta y la inserto
                Oferta newOffer = new Oferta();
                newOffer.IdUsuario = SessionManager.CurrentUser.ID;
                newOffer.IdPublicacion = CurrentPublication.ID;
                newOffer.Fecha = ConfigurationVariables.FechaSistema;
                newOffer.Monto = Int32.Parse(txtMonto.Text);
                newOffer = OfertaPersistance.Insert(newOffer, null);
                MessageBox.Show("Se insertó la oferta correctamente");
                RefreshSources();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
