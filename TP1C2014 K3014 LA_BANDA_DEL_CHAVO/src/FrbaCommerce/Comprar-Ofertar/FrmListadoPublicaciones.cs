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

            UpdateFinishedAuctions();
        }

        private void UpdateFinishedAuctions()
        {
            List<Publicacion> list = PublicacionPersistance.GetFinishedAuctions();
            foreach(Publicacion publication in list)
            {
                Oferta lastOffer = OfertaPersistance.GetLastOfertaByPublication(publication.ID);
                //Si tuvo al menos una oferta, genero la nueva compra correspondiente a esta subasta
                if (lastOffer != null)
                {
                    var purchase = new Compra();
                    purchase.IdPublicacion = publication.ID;
                    purchase.IdUsuario = lastOffer.IdUsuario;
                    purchase.Fecha = lastOffer.Fecha;
                    purchase.Cantidad = 1;
                    CompraPersistance.Insert(purchase, null);
                }

                //Finalizo la publicacion
                publication.EstadoPublicacion = EstadoPublicacionPersistance.GetById(4); //finalizada
                PublicacionPersistance.Update(publication);
            }
        }

        private void RefreshSources(List<Publicacion> publications)
        {
            ClearDataGridView();
            var publicationsDictionary = new Dictionary<int, Publicacion>();

            #region Get the dictionary of visibilities

            if (publications == null)
            {
                //El datasource debe contener a todos los registros de publicaciones activas
                _publications = PublicacionPersistance.GetAllActive();
                if(_publications!=null)
                    publicationsDictionary = _publications.ToDictionary(a => a.ID, a => a);
            }
            else
            {
                //El datasource debe ser la lista de publicaciones recibida por parámetro
                publicationsDictionary = _publications.ToDictionary(a => a.ID, a => a);
            }

            #endregion

            #region Cargar publicaciones en la grilla
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
                CalificacionVendedor = CalificacionPersistance.GetByUserId(a.UsuarioCreador)
            });

            var bindlist = bind.ToList();
            if(bindlist.Count - _offset > 10)
                DgvPublicacion.DataSource = bindlist.GetRange(_offset, 10); //paginas de a 10 contenidos
            else
                DgvPublicacion.DataSource = bindlist.GetRange(_offset, bindlist.Count - _offset);
            DgvPublicacion.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            AddButtonsColumns();
            #endregion

            if (bindlist.Count < 10) //si tiene menos de 10 registros no debe paginar
            {
                lblFirst.Visible = false;
                lblPrevious.Visible = false;
                lblNext.Visible = false;
                lblLast.Visible = false;
            }

            //Cargo los rubros
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
            //Solo ejecutarla si es la columna de botones 
            if (e.ColumnIndex < 11 || e.RowIndex == -1)
                return;

            var selectedPublication = _publications.Find(publication => publication.ID == (int)DgvPublicacion.Rows[e.RowIndex].Cells[0].Value);

            if (selectedPublication != null)
            {
                //Abro el formulario de detalle de la publicación
                var editPublication = new FrmDetallePublicacion(selectedPublication);
                editPublication.ShowDialog();

                RefreshSources(null);
            }
        }

        private void LblLimpiar_Click(object sender, EventArgs e)
        {
            TxtDescripcion.Text = string.Empty;
            //Borro todos los rubros checkeados
            foreach (var checkedIndex in LstRubro.CheckedIndices)
                LstRubro.SetItemCheckState((int)checkedIndex, CheckState.Unchecked);

            RefreshSources(null);
        }

        private void LblBuscar_Click(object sender, EventArgs e)
        {
            _offset = 0;
            //Obtengo los rubros por los que voy a filtrar
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

        //Paginacion
        private void lblFirst_Click(object sender, EventArgs e)
        {
            _offset = 0;
            RefreshSources(_publications);
            lblPrevious.Visible = false;
            lblNext.Visible = true;
        }

        //Paginacion
        private void lblLast_Click(object sender, EventArgs e)
        {
            _offset = _publications.Count - (_publications.Count % 10);
            RefreshSources(_publications);
            lblPrevious.Visible = true;
            lblNext.Visible = false;
        }

        //Paginacion
        private void lblNext_Click(object sender, EventArgs e)
        {
            _offset += 10;
            RefreshSources(_publications);
            lblPrevious.Visible = true;
            if (_publications.Count - _offset < 10)
                lblNext.Visible = false;
        }

        //Paginacion
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
