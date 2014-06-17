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
    public partial class FrmHistorialOfertas : Form
    {
        public FrmHistorialOfertas()
        {
            InitializeComponent();
        }

        private List<HistoryOferta> _history = new List<HistoryOferta>();

        private void LblListo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmHistorialOfertas_Load(object sender, EventArgs e)
        {
            RefreshSources(null);
        }


        private void ClearFiltersAndTable()
        {
            txtCodigo.Text = "";
            txtDesc.Text = "";
            txtFecha.Text = "";
            txtMonto.Text = "";
            txtGanada.Text = "";
            RefreshSources(null);
        }

        private void ClearDataGridView()
        {
            dgvHistory.DataSource = null;
            dgvHistory.Columns.Clear();
        }

        private void RefreshSources(List<HistoryOferta> history)
        {
            ClearDataGridView();
            var historyDictionary = new Dictionary<int, HistoryOferta>();

            if (history == null)
            {
                //The datasource must be all the publications not calified records stored in the database
                _history = OfertaPersistance.GetAllOfertasByUsuario(SessionManager.CurrentUser);
                historyDictionary = _history.ToDictionary(a => a.ID_Oferta, a => a);

            }
            else
            {
                //The datasource must be the list of publications not calified received as parameter
                historyDictionary = history.ToDictionary(a => a.ID_Oferta, a => a);

            }

            var bind = historyDictionary.Values.Select(a => new
            {
                Codigo = a.ID_Oferta,
                Monto = a.Monto,
                Fecha = a.Fecha,
                Descripcion = a.Descripcion,
                Ganada = a.Ganada
            });

            dgvHistory.DataSource = bind.ToList();
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.CurrentCell = null;
        }

        private void LblBuscar_Click(object sender, EventArgs e)
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

                if (!TypesHelper.IsEmpty(txtMonto.Text))
                {
                    filtersSetted = true;
                    if (!TypesHelper.IsDecimal(txtMonto.Text))
                        exceptionMessage += Environment.NewLine + "El precio de la publicacion ser decimal (o numérico).";
                }

                if (!TypesHelper.IsEmpty(txtFecha.Text))
                {
                    filtersSetted = true;
                }

                if (!TypesHelper.IsEmpty(txtGanada.Text))
                {
                    filtersSetted = true;
                }


                if (!filtersSetted)
                    exceptionMessage = "No se puede realizar la busqueda ya que no se informó ningún filtro";

                if (!TypesHelper.IsEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);

                #endregion

                var filters = new HistoryOfertaFilters
                {
                    Codigo = (!TypesHelper.IsEmpty(txtCodigo.Text)) ? Convert.ToInt32(txtCodigo.Text) : (int?)null,
                    Descripcion = (!TypesHelper.IsEmpty(txtDesc.Text)) ? txtDesc.Text : null,
                    Monto = (!TypesHelper.IsEmpty(txtMonto.Text)) ? Convert.ToDouble(txtMonto.Text) : (double?)null,
                    Fecha = (!TypesHelper.IsEmpty(txtFecha.Text)) ? txtFecha.Text : null,
                    Ganada = (!TypesHelper.IsEmpty(txtGanada.Text)) ? txtGanada.Text : null
                };

                var historyCompras = (cBExact.Checked) ? OfertaPersistance.GetAllOfertasByUsuarioByParameters(SessionManager.CurrentUser, filters) : OfertaPersistance.GetAllOfertasByUsuarioByParametersLike(SessionManager.CurrentUser, filters);
                
                if (historyCompras == null || historyCompras.Count == 0)
                    throw new Exception("No se encontraron ofertas según los filtros informados.");

                RefreshSources(historyCompras);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
                ClearFiltersAndTable();
            }
        }

        private void LblLimpiar_Click(object sender, EventArgs e)
        {
            ClearFiltersAndTable();
        }
    }
}