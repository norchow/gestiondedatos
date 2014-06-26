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
using Session;

namespace FrbaCommerce.Gestion_de_Preguntas
{
    public partial class FrmPreguntar : Form
    {
        Publicacion CurrentPublication = new Publicacion();

        public FrmPreguntar(Publicacion unaPublicacion)
        {
            InitializeComponent();
            CurrentPublication = unaPublicacion;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LblCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmPreguntar_Load(object sender, EventArgs e)
        {
            lblPublicacion.Text = CurrentPublication.Descripcion;
        }

        private void LblPreguntar_Click(object sender, EventArgs e)
        {
            if (txtPregunta.Text != "")
            {
                var dialogAnswer = MessageBox.Show("Esta seguro que quiere insertar la nueva pregunta?", "Atencion", MessageBoxButtons.YesNo);
                if (dialogAnswer == DialogResult.Yes)
                {
                    //Inserto la pregunta
                    Pregunta preguntaNueva = new Pregunta();
                    preguntaNueva.IdPublicacion = CurrentPublication.ID;
                    preguntaNueva.IdUsuario = SessionManager.CurrentUser.ID;
                    preguntaNueva.Texto = txtPregunta.Text;
                    PreguntaPersistance.InsertQuestion(preguntaNueva, null);

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
