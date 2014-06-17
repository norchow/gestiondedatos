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
using Tools;
using Filters;
using System.Globalization;

namespace FrbaCommerce.Editar_Publicacion
{
    public partial class FrmMisPublicaciones : Form
    {
        private List<Publicacion> _publications = new List<Publicacion>();
        private List<TipoPublicacion> _publicationTypes = new List<TipoPublicacion>();
        private List<Visibilidad> _visibilities = new List<Visibilidad>();
        private List<EstadoPublicacion> _publicationStatus = new List<EstadoPublicacion>();

        public FrmMisPublicaciones()
        {
            InitializeComponent();
        }

        private void MisPublicaciones_Load(object sender, EventArgs e)
        {
            RefreshComboBoxSources();

            //Traigo la lista de todas las publicaciones de usuario logueado
            RefreshSources(null);
        }

        private void RefreshComboBoxSources()
        {
            //Lleno los combobox
            CboTipoPublicacion.DisplayMember = "Descripcion";
            CboTipoPublicacion.ValueMember = "ID";
            CboTipoPublicacion.DataSource = _publicationTypes = TipoPublicacionPersistance.GetAll();

            CboVisibilidad.DisplayMember = "Descripcion";
            CboVisibilidad.ValueMember = "ID";
            CboVisibilidad.DataSource = _visibilities = VisibilidadPersistance.GetAllActive();

            CboEstadoPublicacion.DisplayMember = "Descripcion";
            CboEstadoPublicacion.ValueMember = "ID";
            CboEstadoPublicacion.DataSource = _publicationStatus = EstadoPublicacionPersistance.GetAll();
        }

        private void RefreshSources(List<Publicacion> publications)
        {
            //Borro lo que tiene la grilla
            ClearDataGridView();
            var publicationsDictionary = new Dictionary<int, Publicacion>();

            #region Get the dictionary of publications

            if (publications == null)
            {
                //El datasource debe ser todas las publicaciones del usuario almacenadas en la base de datos
                CleanFiltersUI();

                //Obtengo las publicaciones del usuario
                _publications = PublicacionPersistance.GetAllByUserId(SessionManager.CurrentUser.ID);

                if (_publications != null)
                    publicationsDictionary = _publications.ToDictionary(a => a.ID, a => a);
                else
                    publicationsDictionary = null;
            }
            else
            {
                //El datasource debe ser una lista de publicaciones recibida por parametro
                //Armo un diccionario con entradas de la forma (ID, Objeto)
                publicationsDictionary = publications.ToDictionary(a => a.ID, a => a);
            }

            #endregion

            if (publicationsDictionary != null)
            {
                //Armo un bind con las entradas del diccionario
                var bind = publicationsDictionary.Values.Select(a => new
                {
                    Codigo = a.ID,
                    Descripcion = a.Descripcion,
                    EstadoPublicacion = _publicationStatus.First(status => status.ID == a.GetStatusID()).Descripcion,
                    Visibilidad = _visibilities.First(visibility => visibility.ID == a.GetVisibilityId()).Descripcion,
                    TipoPublicacion = _publicationTypes.First(type => type.ID == a.GetTipoPublicacionId()).Descripcion,
                    Stock = a.Stock,
                    Precio = a.Precio
                });

                DgvPublicacion.DataSource = bind.ToList();
                DgvPublicacion.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //Agrego la columna de modificar
                AddButtonsColumns();
            }
        }

        private void ClearDataGridView()
        {
            DgvPublicacion.DataSource = null;
            DgvPublicacion.Columns.Clear();
        }

        private void AddButtonsColumns()
        {
            //Creo la columna de modificar
            var updateColumn = new DataGridViewButtonColumn
            {
                Text = "Modificar",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            //Agrego la nueva columna
            DgvPublicacion.Columns.Add(updateColumn);
        }

        private void CleanFiltersUI()
        {
            TxtDescripcion.Text = string.Empty;
            TxtPrecio.Text = string.Empty;
            TxtStock.Text = string.Empty;
            ChkBusquedaExacta.Checked = false;
        }

        private void LblListo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DgvPublicacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Funciona solo cuando el usuario cliquea el boton de modificar (indice de columna 8)
            if (e.ColumnIndex < 7 || e.RowIndex == -1)
                return;

            //Obtengo la publicacion seleccionada a partir del ID (valor almacenado en la primer columna)
            var selectedPublication = _publications.Find(publication => publication.ID == (int)DgvPublicacion.Rows[e.RowIndex].Cells[0].Value);

            if (selectedPublication != null)
            {
                //Creo un nuevo formulario de "Generar Publicacion", pasandole por parametro la seleccionada, para que trabaje en modo modificacion
                var editPublication = new FrmGenerarPublicacion(selectedPublication);
                editPublication.ShowDialog();

                //Si la editó satisfactoriamente, refresco los registros
                if (editPublication.CompleteAction)
                    RefreshSources(null);
            }
        }

        private void ChkBusquedaExacta_CheckedChanged(object sender, EventArgs e)
        {
            TxtStock.Enabled = CboTipoPublicacion.Enabled = CboEstadoPublicacion.Enabled = CboVisibilidad.Enabled = TxtPrecio.Enabled = ChkBusquedaExacta.Checked;
        }

        private void LblBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validations

                var filtersSetted = false;
                var exceptionMessage = string.Empty;

                if (!TypesHelper.IsEmpty(TxtDescripcion.Text))
                    filtersSetted = true;

                if (!TypesHelper.IsEmpty(TxtStock.Text))
                {
                    filtersSetted = true;
                    if (!TypesHelper.IsNumeric(TxtStock.Text))
                        exceptionMessage += Environment.NewLine + "El stock de la publicacion debe ser numérico.";
                }

                if (!TypesHelper.IsEmpty(TxtPrecio.Text))
                {
                    filtersSetted = true;
                    if (!TypesHelper.IsDecimal(TxtPrecio.Text))
                        exceptionMessage += Environment.NewLine + "El precio de la publicacion debe ser decimal (o numérico).";
                }

                if (!TypesHelper.IsEmpty(CboEstadoPublicacion.Text))
                    filtersSetted = true;

                if (!TypesHelper.IsEmpty(CboVisibilidad.Text))
                    filtersSetted = true;

                if (!TypesHelper.IsEmpty(CboTipoPublicacion.Text))
                    filtersSetted = true;

                if (!filtersSetted)
                    exceptionMessage = "No se puede realizar la busqueda ya que no se informó ningún filtro";

                if (!TypesHelper.IsEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);

                #endregion

                //Armo el objeto que representa a los filtros
                var filters = new PublicacionFilters
                {
                    IdUsuario = SessionManager.CurrentUser.ID,
                    Descripcion = (!TypesHelper.IsEmpty(TxtDescripcion.Text)) ? TxtDescripcion.Text : null,
                    Stock = (!TypesHelper.IsEmpty(TxtStock.Text) && ChkBusquedaExacta.Checked) ? Convert.ToInt32(TxtStock.Text) : (int?)null,
                    Precio = (!TypesHelper.IsEmpty(TxtPrecio.Text) && ChkBusquedaExacta.Checked) ? Convert.ToDouble(TxtPrecio.Text) : (double?)null,
                    IdEstadoPublicacion = (ChkBusquedaExacta.Checked) ? ((EstadoPublicacion)CboEstadoPublicacion.SelectedItem).ID : (int?)null,
                    IdVisibilidad = (ChkBusquedaExacta.Checked) ? ((Visibilidad)CboVisibilidad.SelectedItem).ID : (int?)null,
                    IdTipoPublicacion = (ChkBusquedaExacta.Checked) ? ((TipoPublicacion)CboTipoPublicacion.SelectedItem).ID : (int?)null
                };

                //Obtengo las publicaciones que cumplen con la busqueda
                var publications = (ChkBusquedaExacta.Checked) ? PublicacionPersistance.GetAllByParameters(filters) : PublicacionPersistance.GetAllByParametersLike(filters);

                if (publications == null || publications.Count == 0)
                    throw new Exception("No se encontraron publicaciones según los filtros informados.");

                //Cargo el resultado en la grilla
                RefreshSources(publications);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }

        private void LblLimpiar_Click(object sender, EventArgs e)
        {
            RefreshSources(null);
            CleanFiltersUI();
        }
    }
}
