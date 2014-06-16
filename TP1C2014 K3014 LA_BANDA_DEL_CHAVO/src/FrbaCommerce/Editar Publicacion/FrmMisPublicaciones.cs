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
                if (_publications != null)
                    publicationsDictionary = _publications.ToDictionary(a => a.ID, a => a);
                else
                    publicationsDictionary = null;
            }
            else
            {
                //The datasource must be the list of visibilities received as parameter
                publicationsDictionary = publications.ToDictionary(a => a.ID, a => a);
            }

            #endregion
            if (publicationsDictionary != null)
            {
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
            TxtDescripcion.Text = string.Empty;
            TxtPrecio.Text = string.Empty;
            TxtStock.Text = string.Empty;
            MtbInicio.Text = MtbVencimiento.Text = "__/__/____";
            ChkBusquedaExacta.Checked = false;
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
                var editPublication = new FrmGenerarPublicacion(selectedPublication);
                editPublication.ShowDialog();

                if (editPublication.CompleteAction)
                    RefreshSources(null);
            }
        }

        private void ChkBusquedaExacta_CheckedChanged(object sender, EventArgs e)
        {
            TxtStock.Enabled = TxtPrecio.Enabled = MtbInicio.Enabled = MtbVencimiento.Enabled = ChkBusquedaExacta.Checked;
        }

        private void LblBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime? fechaInicio = null;
                DateTime? fechaVencimiento = null;

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

                if (getFromMaskedTextBox(MtbInicio.Text) != string.Empty)
                {
                    filtersSetted = true;
                    if (!TypesHelper.IsDateTime(MtbInicio.Text))
                        exceptionMessage += Environment.NewLine + "La fecha de inicio de la publicacion debe ser una fecha.";
                    else
                        fechaInicio = DateTime.ParseExact(MtbInicio.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                if (getFromMaskedTextBox(MtbVencimiento.Text) != string.Empty)
                {
                    filtersSetted = true;
                    if (!TypesHelper.IsDateTime(MtbVencimiento.Text))
                        exceptionMessage += Environment.NewLine + "La fecha de vencimiento de la publicacion debe ser una fecha.";
                    else
                        fechaVencimiento = DateTime.ParseExact(MtbVencimiento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                if (!filtersSetted)
                    exceptionMessage = "No se puede realizar la busqueda ya que no se informó ningún filtro";

                if (!TypesHelper.IsEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);

                #endregion

                var filters = new PublicacionFilters
                {
                    IdUsuario = SessionManager.CurrentUser.ID,
                    Descripcion = (!TypesHelper.IsEmpty(TxtDescripcion.Text)) ? TxtDescripcion.Text : null,
                    Stock = (!TypesHelper.IsEmpty(TxtStock.Text) && ChkBusquedaExacta.Checked) ? Convert.ToInt32(TxtStock.Text) : (int?)null,
                    Precio = (!TypesHelper.IsEmpty(TxtPrecio.Text) && ChkBusquedaExacta.Checked) ? Convert.ToDouble(TxtPrecio.Text) : (double?)null,
                    FechaInicio = (ChkBusquedaExacta.Checked && fechaInicio != null) ? fechaInicio : (DateTime?)null,
                    FechaVencimiento = (ChkBusquedaExacta.Checked && fechaVencimiento != null) ? fechaVencimiento : (DateTime?)null,
                };


                var publications = (ChkBusquedaExacta.Checked) ? PublicacionPersistance.GetAllByParameters(filters) : PublicacionPersistance.GetAllByParametersLike(filters);

                if (publications == null || publications.Count == 0)
                    throw new Exception("No se encontraron publicaciones según los filtros informados.");

                RefreshSources(publications);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }

        private string getFromMaskedTextBox(string input)
        {
            return input.Replace("/", string.Empty).Trim();
        }

        private void LblLimpiar_Click(object sender, EventArgs e)
        {
            RefreshSources(null);
            CleanFiltersUI();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
