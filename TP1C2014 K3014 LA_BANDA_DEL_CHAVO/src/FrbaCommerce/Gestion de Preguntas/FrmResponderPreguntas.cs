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
using Session;

namespace FrbaCommerce.Gestion_de_Preguntas
{
    public partial class FrmResponderPreguntas : Form
    {
        private List<PublicacionPregunta> _questions = new List<PublicacionPregunta>();

        public FrmResponderPreguntas()
        {
            InitializeComponent();
        }

        private void LblListo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmResponderPreguntas_Load(object sender, EventArgs e)
        {
            RefreshSources();
        }

        private void DgvPreguntas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Only works when user clicks one of the buttons (column index 8)
            if (e.ColumnIndex < 4 || e.RowIndex == -1)
                return;

            var selectedQuestion = _questions.Find(question => question.ID_Pregunta == (int)DgvPreguntas.Rows[e.RowIndex].Cells[2].Value);
            var selectedPublication = _questions.Find(question => question.ID_Publicacion == (int)DgvPreguntas.Rows[e.RowIndex].Cells[2].Value);

            if (selectedQuestion != null)
            {
                var editQuestion = new FrmResponder(selectedQuestion);
                editQuestion.ShowDialog();

                if (editQuestion.CompleteAction)
                    RefreshSources();
            }
        }

        private void AddButtonsColumns()
        {
            var updateColumn = new DataGridViewButtonColumn
            {
                Text = "Responder",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            DgvPreguntas.Columns.Add(updateColumn);
        }

        private void RefreshSources()
        {
            DgvPreguntas.DataSource = null;
            DgvPreguntas.Columns.Clear();

            var questionsDictionary = new Dictionary<int, PublicacionPregunta>();

            _questions = PreguntaPersistance.GetUnansweredQuestionsByUserId(SessionManager.CurrentUser.ID);

            if (_questions != null)
            {
                questionsDictionary = _questions.ToDictionary(a => a.ID_Pregunta, a => a);

                var bind = questionsDictionary.Values.Select(a => new
                {
                    ID_Publicacion = a.ID_Publicacion,
                    Descripcion = a.Descripcion,
                    ID_Pregunta = a.ID_Pregunta,
                    Texto = a.Texto
                });

                DgvPreguntas.DataSource = bind.ToList();
                DgvPreguntas.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                AddButtonsColumns();
            }
        }

    }
}
