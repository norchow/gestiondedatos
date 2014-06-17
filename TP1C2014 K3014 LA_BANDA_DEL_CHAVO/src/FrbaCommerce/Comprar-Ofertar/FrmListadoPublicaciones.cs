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
        private int _offset = 0;

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
                ID = a.ID,
                Descripcion = a.Descripcion,
                Inicio = a.FechaInicio,
                Vencimiento = a.FechaVencimiento,
                Stock = a.Stock,
                Precio = (OfertaPersistance.GetLastOfertaByPublication(a.ID) != null) ? OfertaPersistance.GetLastOfertaByPublication(a.ID).Monto: a.Precio,
                RecibirPreguntas = a.RecibirPreguntas,
                Tipo = a.TipoPublicacion.Descripcion,
                Visibilidad = a.Visibilidad.Descripcion,
                Rubros = a.GetTextRubros(),
                CalificacionVendedor = CalificacionPersistance.getAverageCalificationToMe(a.UsuarioCreador)
            });

            var bindlist = bind.ToList();
            if(bindlist.Count - _offset > 10)
                DgvPublicacion.DataSource = bindlist.GetRange(_offset, 10); //paginas de a 10 contenidos
            else
                DgvPublicacion.DataSource = bindlist.GetRange(_offset, bindlist.Count - _offset);
            DgvPublicacion.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
            if (e.ColumnIndex < 11 || e.RowIndex == -1)
                return;

            var selectedPublication = _publications.Find(publication => publication.ID == (int)DgvPublicacion.Rows[e.RowIndex].Cells[0].Value);

            if (selectedPublication != null)
            {
                var editPublication = new FrmDetallePublicacion(selectedPublication);
                editPublication.ShowDialog();

                RefreshSources(null);
            }
        }

        private void LblLimpiar_Click(object sender, EventArgs e)
        {
            TxtDescripcion.Text = string.Empty;
            foreach (var checkedIndex in LstRubro.CheckedIndices)
                LstRubro.SetItemCheckState((int)checkedIndex, CheckState.Unchecked);
        }

        private void LblBuscar_Click(object sender, EventArgs e)
        {
            _offset = 0;
            var lstRubros = new List<Rubro>();
            foreach (var checkedItem in LstRubro.CheckedItems)
            {
                var category = (Rubro)checkedItem;
                lstRubros.Add(category);
            }

            if (ChkBusquedaExacta.Checked)
            {
                _publications = PublicacionPersistance.GetAllActiveByParameters(TxtDescripcion.Text, lstRubros);
                RefreshSources(_publications);
            }
            else
            {
                _publications = PublicacionPersistance.GetAllActiveByParametersLike(TxtDescripcion.Text, lstRubros);
                RefreshSources(_publications);
            }
        }

        private void lblFirst_Click(object sender, EventArgs e)
        {
            _offset = 0;
            RefreshSources(_publications);
            lblPrevious.Visible = false;
            lblNext.Visible = true;
        }

        private void lblLast_Click(object sender, EventArgs e)
        {
            _offset = _publications.Count - (_publications.Count % 10);
            RefreshSources(_publications);
            lblPrevious.Visible = true;
            lblNext.Visible = false;
        }

        private void lblNext_Click(object sender, EventArgs e)
        {
            _offset += 10;
            RefreshSources(_publications);
            lblPrevious.Visible = true;
            if (_publications.Count - _offset < 10)
                lblNext.Visible = false;
        }

        private void lblPrevious_Click(object sender, EventArgs e)
        {
            _offset -= 10;
            RefreshSources(_publications);
            lblNext.Visible = true;
            if (_offset == 0)
                lblPrevious.Visible = false;
        }
    }
}
