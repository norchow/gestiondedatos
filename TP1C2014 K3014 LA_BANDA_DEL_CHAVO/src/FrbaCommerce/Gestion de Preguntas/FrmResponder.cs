using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Persistance.Entities;
using Persistance;

namespace FrbaCommerce.Gestion_de_Preguntas
{
    public partial class FrmResponder : Form
    {
        private PublicacionPregunta CurrentPublicationQuestion = new PublicacionPregunta();
        public Boolean CompleteAction = false;

        public FrmResponder()
        {
            InitializeComponent();
        }

        public FrmResponder(PublicacionPregunta publicationQuestion)
        {
            InitializeComponent();
            CurrentPublicationQuestion = publicationQuestion;
            lblPublicacion.Text = CurrentPublicationQuestion.Descripcion;
            LblPregunta.Text = CurrentPublicationQuestion.Texto;
        }

        private void LblCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LblResponder_Click(object sender, EventArgs e)
        {
            if (txtRespuesta.Text != "")
            {
                var dialogAnswer = MessageBox.Show("Esta seguro que quiere enviar la respuesta?", "Atencion", MessageBoxButtons.YesNo);
                if (dialogAnswer == DialogResult.Yes)
                {
                    //Inserto la respuesta
                    Respuesta respuestaNueva = new Respuesta();
                    respuestaNueva.IdPregunta = CurrentPublicationQuestion.ID_Pregunta;
                    respuestaNueva.Texto = txtRespuesta.Text;
                    RespuestaPersistance.InsertAnswer(respuestaNueva, null);
                    CompleteAction = true;
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un texto en la pregunta", "Atención");
            }
        }
    }
}
