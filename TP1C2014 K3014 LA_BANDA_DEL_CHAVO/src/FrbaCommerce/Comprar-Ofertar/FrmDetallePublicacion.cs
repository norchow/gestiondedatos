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
            if (CurrentPublication.RecibirPreguntas && CurrentPublication.UsuarioCreador.ID!=SessionManager.CurrentUser.ID)
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
