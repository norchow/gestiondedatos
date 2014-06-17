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
    public partial class FrmHistorialCompras : Form
    {

        private List<HistoryCompra> _history = new List<HistoryCompra>();

        public FrmHistorialCompras()
        {
            InitializeComponent();
        }

        private void LblListo_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void ClearDataGridView()
        {
            dgvHistory.DataSource = null;
            dgvHistory.Columns.Clear();
        }

        private void RefreshSources(List<HistoryCompra> history)
        {
            ClearDataGridView();
            var historyDictionary = new Dictionary<int, HistoryCompra>();

            if (history == null)
            {
                //The datasource must be all the publications not calified records stored in the database
                _history = CompraPersistance.GetAllCompras(SessionManager.CurrentUser);
                historyDictionary = _history.ToDictionary(a => a.ID_Compra, a => a); ;
            }
            else
            {
                //The datasource must be the list of publications not calified received as parameter
                historyDictionary = history.ToDictionary(a => a.ID_Compra, a => a);
            }

            var bind = historyDictionary.Values.Select(a => new
            {
                Compra = a.ID_Compra,
                Descripcion = a.Descripcion,
                Fecha = a.Compra_Fecha,
                Precio = string.Format("$ {0}",a.Precio ),
                Cantidad = a.Compra_Cantidad

            });

            dgvHistory.DataSource = bind.ToList();
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.CurrentCell = null;
        }

        private void ClearFiltersAndTable()
        {
            txtCodigo.Text = "";
            txtDesc.Text = "";
            txtPrecio.Text = "";
            txtFecha.Text = "";
            txtCantidad.Text = "";
            RefreshSources(null);
        }

        private void LblLimpiar_Click(object sender, EventArgs e)
        {
            ClearFiltersAndTable();
        }

        private void FrmHistorialCompras_Load(object sender, EventArgs e)
        {
            RefreshSources(null);
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

                if (!TypesHelper.IsEmpty(txtPrecio.Text))
                {
                    filtersSetted = true;
                    if (!TypesHelper.IsDecimal(txtPrecio.Text))
                        exceptionMessage += Environment.NewLine + "El precio de la publicacion ser decimal (o numérico).";
                }

                if (!TypesHelper.IsEmpty(txtFecha.Text))
                {
                    filtersSetted = true;
                }

                if (!TypesHelper.IsEmpty(txtCantidad.Text))
                {
                    filtersSetted = true;
                    if (!TypesHelper.IsNumeric(txtCantidad.Text))
                        exceptionMessage += Environment.NewLine + "La cantidad debe ser numérica.";
                
                }


                if (!filtersSetted)
                    exceptionMessage = "No se puede realizar la busqueda ya que no se informó ningún filtro";

                if (!TypesHelper.IsEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);

                #endregion

                var filters = new HistoryCompraFilters
                {
                    Codigo = (!TypesHelper.IsEmpty(txtCodigo.Text)) ? Convert.ToInt32(txtCodigo.Text) : (int?)null,
                    Descripcion = (!TypesHelper.IsEmpty(txtDesc.Text)) ? txtDesc.Text : null,
                    Precio = (!TypesHelper.IsEmpty(txtPrecio.Text)) ? Convert.ToDouble(txtPrecio.Text) : (double?)null,
                    Fecha = (!TypesHelper.IsEmpty(txtFecha.Text)) ? txtFecha.Text : null,
                    Cantidad = (!TypesHelper.IsEmpty(txtCantidad.Text)) ? Convert.ToInt32(txtCantidad.Text) : (int?)null
                };

                var historyCompras = (cBExact.Checked) ? CompraPersistance.GetAllComprasByParameters(SessionManager.CurrentUser, filters) : CompraPersistance.GetAllComprasByParametersLike(SessionManager.CurrentUser, filters);
              
                if (historyCompras == null || historyCompras.Count == 0)
                    throw new Exception("No se encontraron compras según los filtros informados.");

                RefreshSources(historyCompras);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
                ClearFiltersAndTable();
            }
        }
    }
}
