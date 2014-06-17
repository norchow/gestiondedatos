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
using FrbaCommerce.Properties;
using Tools;
using Filters;

namespace FrbaCommerce.Historial_Cliente
{
    public partial class FrmHistorialCalificacionesOtorgadas : Form
    {
        private List<HistoryReputacion> _history = new List<HistoryReputacion>();
        public FrmHistorialCalificacionesOtorgadas()
        {
            InitializeComponent();
        }

        private void FrmHistorialCalificacionesOtorgadas_Load(object sender, EventArgs e)
        {
            RefreshSources(null);
        }


        private void ClearFiltersAndTable()
        {
            txtCodigo.Text = "";
            txtDesc.Text = "";
            txtNombre.Text = "";
            txtCantidad.Text = "";
            RefreshSources(null);
        }

        private void ClearDataGridView()
        {
            dgvHistory.DataSource = null;
            dgvHistory.Columns.Clear();
        }

        private void RefreshSources(List<HistoryReputacion> history)
        {
            ClearDataGridView();
            var historyDictionary = new Dictionary<int, HistoryReputacion>();

            if (history == null)
            {
                //The datasource must be all the publications not calified records stored in the database
                _history = CalificacionPersistance.getAllCalifiedByMeToOther(SessionManager.CurrentUser);
                historyDictionary = _history.ToDictionary(a => a.Codigo_Calificacion, a => a); ;
            }
            else
            {
                //The datasource must be the list of publications not calified received as parameter
                historyDictionary = history.ToDictionary(a => a.Codigo_Calificacion, a => a);
            }

            var bind = historyDictionary.Values.Select(a => new
            {
                Calificacion = a.Codigo_Calificacion,
                Descripcion = a.Descripcion,
                Cantidad_Estrellas = a.Cantidad_Estrellas,
                Nombre = a.Nombre

            });

            dgvHistory.DataSource = bind.ToList();
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.CurrentCell = null;
        }

        private void LblBuscar_Click(object sender, EventArgs e)
        {


            {
                try
                {
                    #region Validations

                    var filtersSetted = false;
                    var exceptionMessage = string.Empty;

                    if (!TypesHelper.IsEmpty(txtCodigo.Text))
                    {
                        filtersSetted = true;
                        if (!TypesHelper.IsNumeric(txtCodigo.Text))
                            exceptionMessage += Environment.NewLine + "El código debe ser numérico.";
                    }
                    if (!TypesHelper.IsEmpty(txtDesc.Text))
                    {
                        filtersSetted = true;
                    }

                    if (!TypesHelper.IsEmpty(txtCantidad.Text))
                    {
                        filtersSetted = true;
                        if (!TypesHelper.IsNumeric(txtCantidad.Text))
                            exceptionMessage += Environment.NewLine + "La cantidad debe ser numérica.";

                    }

                    if (!TypesHelper.IsEmpty(txtNombre.Text))
                    {
                        filtersSetted = true;
                    }


                    if (!filtersSetted)
                        exceptionMessage = "No se puede realizar la busqueda ya que no se informó ningún filtro";

                    if (!TypesHelper.IsEmpty(exceptionMessage))
                        throw new Exception(exceptionMessage);

                    #endregion

                    var filters = new HistoryReputacionFilters
                    {
                        Codigo = (!TypesHelper.IsEmpty(txtCodigo.Text)) ? Convert.ToInt32(txtCodigo.Text) : (int?)null,
                        Descripcion = (!TypesHelper.IsEmpty(txtDesc.Text)) ? txtDesc.Text : null,
                        Cantidad = (!TypesHelper.IsEmpty(txtCantidad.Text)) ? Convert.ToInt32(txtCantidad.Text) : (int?)null,
                        Nombre = (!TypesHelper.IsEmpty(txtNombre.Text)) ? txtNombre.Text : null
                    };

                    var historyReputacion = (cBExact.Checked) ? CalificacionPersistance.getAllCalifiedByMeToOtherByParameters(SessionManager.CurrentUser, filters) : CalificacionPersistance.getAllCalifiedByMeToOtherByParametersLike(SessionManager.CurrentUser, filters);

                    if (historyReputacion == null || historyReputacion.Count == 0)
                        throw new Exception("No se encontraron calificaciones según los filtros informados.");

                    RefreshSources(historyReputacion);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Atención");
                    ClearFiltersAndTable();
                }
            }


        }

        private void LblListo_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
