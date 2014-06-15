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

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class FrmListadoPublicaciones : Form
    {
        private List<Publicacion> _publications = new List<Publicacion>();

        public FrmListadoPublicaciones()
        {
            InitializeComponent();
        }

        private void FrmListadoPublicaciones_Load(object sender, EventArgs e)
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
                _publications = PublicacionPersistance.GetAllActive();
                if(_publications!=null)
                    publicationsDictionary = _publications.ToDictionary(a => a.ID, a => a);
            }
            else
            {
                //The datasource must be the list of visibilities received as parameter
                publicationsDictionary = _publications.ToDictionary(a => a.ID, a => a);
            }

            #endregion

            #region Load publications in the datagrid
            var bind = publicationsDictionary.Values.Select(a => new
            {
                Codigo = a.ID,
                Descripcion = a.Descripcion,
                FechaInicio = a.FechaInicio,
                FechaVencimiento = a.FechaVencimiento,
                Stock = a.Stock,
                Precio = (OfertaPersistance.GetLastOfertaByPublication(a.ID) != null) ? OfertaPersistance.GetLastOfertaByPublication(a.ID).Monto: a.Precio,
                RecibirPreguntas = a.RecibirPreguntas,
            });

            DgvPublicacion.DataSource = bind.ToList();
            DgvPublicacion.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            AddButtonsColumns();
            #endregion

            var rubros = RubroPersistance.GetAll();
            LstRubro.DataSource = rubros;
            LstRubro.DisplayMember = "Descripcion";
            LstRubro.ValueMember = "ID";
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
                Text = "Ver detalle",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            DgvPublicacion.Columns.Add(updateColumn);
        }

        private void LblListo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DgvPublicacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Only works when user clicks one of the buttons (column index 8)
            if (e.ColumnIndex < 7 || e.RowIndex == -1)
                return;

            var selectedPublication = _publications.Find(publication => publication.ID == (int)DgvPublicacion.Rows[e.RowIndex].Cells[0].Value);

            if (selectedPublication != null)
            {
                var editPublication = new FrmDetallePublicacion(selectedPublication);
                editPublication.ShowDialog();

                RefreshSources(null);
            }
        }
    }
}
