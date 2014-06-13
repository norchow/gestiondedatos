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
    }
}
