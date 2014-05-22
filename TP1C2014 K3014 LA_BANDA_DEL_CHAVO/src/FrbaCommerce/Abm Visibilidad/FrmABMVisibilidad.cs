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
using Tools;
using Filters;

namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class FrmABMVisibilidad : Form
    {
        private List<Visibilidad> _visibilities = new List<Visibilidad>();

        public FrmABMVisibilidad()
        {
            InitializeComponent();
        }

        private void FrmABMVisibilidad_Load(object sender, EventArgs e)
        {
            RefreshSources(null);
        }

        private void RefreshSources(List<Visibilidad> visibilities)
        {
            ClearDataGridView();
            var visibilitiesDictionary = new Dictionary<int, Visibilidad>();

            #region Get the dictionary of visibilities

            //The datasource must be all the visibilities record from the database
            if (visibilities == null)
            {
                CleanFiltersUI();
                _visibilities = VisibilidadPersistance.GetAll();
                visibilitiesDictionary = _visibilities.ToDictionary(a => a.ID, a => a);
            }
            else
            {
                //The datasource must be the list of visibilities received as parameter
                visibilitiesDictionary = visibilities.ToDictionary(a => a.ID, a => a);
            }

            #endregion

            var bind = visibilitiesDictionary.Values.Select(a => new
            {
                Codigo = a.ID,
                Descripcion = a.Descripcion,
                PrecioPorPublicar = string.Format("${0}",a.PrecioPublicar),
                PorcentajeDeVenta = string.Format("{0}%", a.PorcentajeVenta),
                Duracion = string.Format("{0} dias", a.Duracion),
                Activo = a.Activo
            });

            DgvVisibilidad.DataSource = bind.ToList();
            AddButtonsColumns();
        }

        private void ClearDataGridView()
        {
            DgvVisibilidad.DataSource = null;
            DgvVisibilidad.Columns.Clear();
        }

        private void AddButtonsColumns()
        {
            var updateColumn = new DataGridViewButtonColumn
            {
                Text = "Modificar",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            var deleteColumn = new DataGridViewButtonColumn
            {
                Text = "Eliminar",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            DgvVisibilidad.Columns.Add(updateColumn);
            DgvVisibilidad.Columns.Add(deleteColumn);
        }

        private void LblListo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LblNuevo_Click(object sender, EventArgs e)
        {
            var insertUpdateVisibility = new FrmABMInsertUpdateVisibilidad(null);
            insertUpdateVisibility.ShowDialog();

            if (insertUpdateVisibility.RealizoOperacion)
                RefreshSources(null);
        }

        private void DgvVisibilidad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Only works when user clicks one of the buttons (column index 5 and 6)
            if (e.ColumnIndex < 6 || e.RowIndex == -1)
                return;

            var selectedVisibility = _visibilities.Find(visibility => visibility.ID == (int)DgvVisibilidad.Rows[e.RowIndex].Cells[0].Value);

            if (selectedVisibility != null)
            {
                //User clicked update button
                if (e.ColumnIndex == 6)
                {
                    var insertUpdateVisibility = new FrmABMInsertUpdateVisibilidad(selectedVisibility);
                    insertUpdateVisibility.ShowDialog();

                    if (insertUpdateVisibility.RealizoOperacion)
                        RefreshSources(null);
                }
                else
                {
                    //User clicked delete button
                    if (!selectedVisibility.Activo)
                    {
                        MessageBox.Show("No se puede eliminar la funcionalidad ya que ya se encuentra desactivada", "Atencion");
                        return;
                    }

                    var dialogAnswer = MessageBox.Show(string.Format("Esta seguro que quiere desactivar la visibilidad {0}?", selectedVisibility.Descripcion), "Atención", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        selectedVisibility.Activo = false;
                        VisibilidadPersistance.UpdateVisibility(selectedVisibility);

                        RefreshSources(null);
                    }
                }
            }
        }

        private void LblLimpiar_Click(object sender, EventArgs e)
        {
            RefreshSources(null);
        }

        private void CleanFiltersUI()
        {
            TxtDescripcion.Text = string.Empty;
            TxtDuracion.Text = string.Empty;
            TxtPorcentajeVenta.Text = string.Empty;
            TxtPrecioPublicar.Text = string.Empty;
            ChkBusquedaExacta.Checked = false;
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

                if (!TypesHelper.IsEmpty(TxtDuracion.Text))
                {
                    filtersSetted = true;
                    if (!TypesHelper.IsNumeric(TxtDuracion.Text))
                        exceptionMessage += Environment.NewLine + "La duración de la visibilidad debe ser numérica.";
                }

                if (!TypesHelper.IsEmpty(TxtPrecioPublicar.Text))
                {
                    filtersSetted = true;
                    if (!TypesHelper.IsDecimal(TxtPrecioPublicar.Text))
                        exceptionMessage += Environment.NewLine + "El precio por publicar de la visibilidad debe ser decimal (o numérico).";
                }

                if (!TypesHelper.IsEmpty(TxtPorcentajeVenta.Text))
                {
                    filtersSetted = true;
                    if (!TypesHelper.IsDecimal(TxtPorcentajeVenta.Text))
                        exceptionMessage += Environment.NewLine + "El porcentaje de la venta de la visibilidad debe ser decimal (o numérico).";
                }

                if (!filtersSetted)
                    exceptionMessage = "No se puede realizar la busqueda ya que no se informó ningún filtro";

                if (!TypesHelper.IsEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);

                #endregion

                var filters = new VisibilidadFilters 
                { 
                    Descripcion = (!TypesHelper.IsEmpty(TxtDescripcion.Text)) ? TxtDescripcion.Text : null,
                    PrecioPublicar = (!TypesHelper.IsEmpty(TxtPrecioPublicar.Text)) ? Convert.ToDouble(TxtPrecioPublicar.Text) : (double?)null,
                    PorcentajeVenta = (!TypesHelper.IsEmpty(TxtPorcentajeVenta.Text)) ? Convert.ToDouble(TxtPorcentajeVenta.Text) : (double?)null,
                    Duracion = (!TypesHelper.IsEmpty(TxtDuracion.Text)) ? Convert.ToInt32(TxtDuracion.Text) : (int?)null
                };

                var visibilities = (ChkBusquedaExacta.Checked) ? VisibilidadPersistance.GetAllVisibilityByParameters(filters) : VisibilidadPersistance.GetAllVisibilityByParametersLike(filters);

                if (visibilities == null || visibilities.Count == 0)
                    throw new Exception("No se encontraron visibilidades según los filtros informados.");

                RefreshSources(visibilities);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }
    }
}
