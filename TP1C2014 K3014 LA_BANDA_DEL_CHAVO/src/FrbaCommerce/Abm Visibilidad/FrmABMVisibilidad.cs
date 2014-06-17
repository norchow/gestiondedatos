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
            //Borro lo que esta actualmente en la grilla
            ClearDataGridView();
            var visibilitiesDictionary = new Dictionary<int, Visibilidad>();

            #region Get the dictionary of visibilities

            if (visibilities == null)
            {
                //El datasource debe ser todos los registros de visibilidades almacenados en la base de datos
                CleanFiltersUI();
                _visibilities = VisibilidadPersistance.GetAll();
                //Convierto todas las visibilidades a un diccionario con entradas de la forma: (ID, Objeto)
                visibilitiesDictionary = _visibilities.ToDictionary(a => a.ID, a => a);
            }
            else
            {
                //El datasource debe ser una lista de visibilidades obtenidas por parametro
                //Convierto la lista de visibilidades a un diccionario con entradas de la forma: (ID, Objeto)
                visibilitiesDictionary = visibilities.ToDictionary(a => a.ID, a => a);
            }

            #endregion

            //Creo un bind para luego setearselo directamente a la DataGridView
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

            //Agrego los botones a cada fila para poder modificar/borrar cada rol
            AddButtonsColumns();
        }

        private void ClearDataGridView()
        {
            DgvVisibilidad.DataSource = null;
            DgvVisibilidad.Columns.Clear();
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
            //Creo la columna de borrar
            var deleteColumn = new DataGridViewButtonColumn
            {
                Text = "Eliminar",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            //Agrego las columnas nuevas
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

            //Paso NULL para volver a obtener todos los registros de la base
            if (insertUpdateVisibility.CompleteAction)
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
                //El usuario tocó el botón de modificar
                if (e.ColumnIndex == 6)
                {
                    var insertUpdateVisibility = new FrmABMInsertUpdateVisibilidad(selectedVisibility);
                    insertUpdateVisibility.ShowDialog();

                    //Si modificó satisfactoriamante la visibilidad, actualizo la grilla
                    if (insertUpdateVisibility.CompleteAction)
                        RefreshSources(null);
                }
                else
                {
                    //El usuario tocó el botón de eliminar

                    //El rol seleccionado ya se encuentra eliminado (baja lógica)
                    if (!selectedVisibility.Activo)
                    {
                        MessageBox.Show("No se puede eliminar la funcionalidad ya que ya se encuentra desactivada", "Atencion");
                        return;
                    }

                    var dialogAnswer = MessageBox.Show(string.Format("Esta seguro que quiere desactivar la visibilidad {0}?", selectedVisibility.Descripcion), "Atención", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        selectedVisibility.Activo = false;
                        VisibilidadPersistance.Update(selectedVisibility);

                        //Vuelvo a cargar la lista de roles
                        RefreshSources(null);
                    }
                }
            }
        }

        private void LblLimpiar_Click(object sender, EventArgs e)
        {
            RefreshSources(null);
            CleanFiltersUI();
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

                //Armo el objeto que representa a los filtros a partir de los valores de los controles
                var filters = new VisibilidadFilters 
                { 
                    Descripcion = (!TypesHelper.IsEmpty(TxtDescripcion.Text)) ? TxtDescripcion.Text : null,
                    PrecioPublicar = (!TypesHelper.IsEmpty(TxtPrecioPublicar.Text) && ChkBusquedaExacta.Checked) ? Convert.ToDouble(TxtPrecioPublicar.Text) : (double?)null,
                    PorcentajeVenta = (!TypesHelper.IsEmpty(TxtPorcentajeVenta.Text) && ChkBusquedaExacta.Checked) ? Convert.ToDouble(TxtPorcentajeVenta.Text) : (double?)null,
                    Duracion = (!TypesHelper.IsEmpty(TxtDuracion.Text) && ChkBusquedaExacta.Checked) ? Convert.ToInt32(TxtDuracion.Text) : (int?)null
                };

                var visibilities = (ChkBusquedaExacta.Checked) ? VisibilidadPersistance.GetAllByParameters(filters) : VisibilidadPersistance.GetAllByParametersLike(filters);

                if (visibilities == null || visibilities.Count == 0)
                    throw new Exception("No se encontraron visibilidades según los filtros informados.");

                //Cargo la grilla a partir de los registros obtenidos en la busqueda
                RefreshSources(visibilities);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }

        private void ChkBusquedaExacta_CheckedChanged(object sender, EventArgs e)
        {
            TxtDuracion.Enabled = TxtPorcentajeVenta.Enabled = TxtPrecioPublicar.Enabled = ChkBusquedaExacta.Checked;
        }
    }
}