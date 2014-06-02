using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Persistance;
using Session;
using Persistance.Entities;
using FrbaCommerce.Generar_Publicacion;

namespace FrbaCommerce.Editar_Publicacion
{
    public partial class FrmMisPublicaciones : Form
    {
        private List<Publicacion> _publications = new List<Publicacion>();

        public FrmMisPublicaciones()
        {
            InitializeComponent();
        }

        private void MisPublicaciones_Load(object sender, EventArgs e)
        {
            RefreshSources(null);
        }

        private void RefreshSources(List<Publicacion> publications)
        {
            ClearDataGridView();
            var publicationsDictionary = new Dictionary<int, Publicacion>();

            #region Get the dictionary of visibilities

            if (publications == null)
            {
                //The datasource must be all the publications records from the user stored in the database
                CleanFiltersUI();
                _publications = PublicacionPersistance.GetAllByUserId(SessionManager.CurrentUser.ID);
                publicationsDictionary = _publications.ToDictionary(a => a.ID, a => a);
            }
            else
            {
                //The datasource must be the list of visibilities received as parameter
                publicationsDictionary = _publications.ToDictionary(a => a.ID, a => a);
            }

            #endregion

            var bind = publicationsDictionary.Values.Select(a => new
            {
                Codigo = a.ID,
                Descripcion = a.Descripcion,
                FechaInicio = a.FechaInicio,
                FechaVencimiento = a.FechaVencimiento,
                Stock = a.Stock,
                Precio = a.Precio,
                RecibirPreguntas = a.RecibirPreguntas
            });

            DgvPublicacion.DataSource = bind.ToList();
            DgvPublicacion.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            AddButtonsColumns();
        }

        private void ClearDataGridView()
        {
            DgvPublicacion.DataSource = null;
            DgvPublicacion.Columns.Clear();
        }

        private void AddButtonsColumns()
        {
            var updateColumn = new DataGridViewButtonColumn
            {
                Text = "Modificar",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            DgvPublicacion.Columns.Add(updateColumn);
        }

        private void CleanFiltersUI()
        {
            /*
            TxtDescripcion.Text = string.Empty;
            TxtDuracion.Text = string.Empty;
            TxtPorcentajeVenta.Text = string.Empty;
            TxtPrecioPublicar.Text = string.Empty;
            ChkBusquedaExacta.Checked = false;
             */
        }

        private void LblListo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DgvPublicacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Only works when user clicks one of the buttons (column index 5 and 6)
            if (e.ColumnIndex < 7 || e.RowIndex == -1)
                return;

            var selectedPublication = _publications.Find(publication => publication.ID == (int)DgvPublicacion.Rows[e.RowIndex].Cells[0].Value);

            if (selectedPublication != null)
            {
                var editPublication = new FrmGenerarPublicacion(selectedPublication);
                editPublication.ShowDialog();

                if (editPublication.CompleteAction)
                    RefreshSources(null);
            }
        }
    }
}
