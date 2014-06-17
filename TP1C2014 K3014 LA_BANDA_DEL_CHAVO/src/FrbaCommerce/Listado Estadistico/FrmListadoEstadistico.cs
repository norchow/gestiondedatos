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

namespace FrbaCommerce.Listado_Estadistico
{
    public partial class FrmListadoEstadistico : Form
    {
        private List<Estadistica> _estadisticas = new List<Estadistica>();

        public FrmListadoEstadistico()
        {
            InitializeComponent();
        }

        private void LblCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LblLimpiar_Click(object sender, EventArgs e)
        {
            RefreshSources(null);
            CleanFiltersUI();
        }

        private void CleanFiltersUI()
        {
            CboAño.Text = string.Empty;
            CboTrimestre.Text = string.Empty;
            CboListado.Text = string.Empty;
            CboVisibilidad.Text = string.Empty;
        }

        private void ClearDataGridView()
        {
            DgvListado.DataSource = null;
            DgvListado.Columns.Clear();
        }

        private void RefreshSources(List<Estadistica> estadisticas)
        {
            #region Load sources

            //Cargo el combo de años
            var dataSourceAño = new List<object>();
            for (var i = 1980; i <= Convert.ToInt32(Configuration.ConfigurationVariables.FechaSistema.Year); i++)
                dataSourceAño.Add(new { Name = i.ToString(), Value = i });
            CboAño.DataSource = dataSourceAño;
            CboAño.ValueMember = "Value";
            CboAño.DisplayMember = "Name";

            //Cargo el combo de trimestres
            var dataSourceTrimestre = new List<object>();
            dataSourceTrimestre.Add(new { Name = "Enero - Marzo", Value = 1 });
            dataSourceTrimestre.Add(new { Name = "Abril - Junio", Value = 2 });
            dataSourceTrimestre.Add(new { Name = "Julio - Septiembre", Value = 3 });
            dataSourceTrimestre.Add(new { Name = "Octubre - Diciembre", Value = 4 });
            CboTrimestre.ValueMember = "Value";
            CboTrimestre.DisplayMember = "Name";
            CboTrimestre.DataSource = dataSourceTrimestre;

            //Cargo el combo con los posibles listados a pedir
            var dataSourceListado = new List<object>();
            dataSourceListado.Add(new { Name = "[Vendedores] Mayor cant. de productos no vendidos", Value = 1 });
            dataSourceListado.Add(new { Name = "[Vendedores] Mayor facturación", Value = 2 });
            dataSourceListado.Add(new { Name = "[Vendedores] Mayores calificaciones", Value = 3 });
            dataSourceListado.Add(new { Name = "[Clientes] Mayor cant. de publicaciones sin calificar", Value = 4 });
            CboListado.DataSource = dataSourceListado;
            CboListado.ValueMember = "Value";
            CboListado.DisplayMember = "Name";

            //Cargo las visibilidades para los filtros de la primera estadística
            var dataSourceVisibilidad = VisibilidadPersistance.GetAll();
            var visibilidadTodos = new Visibilidad();
            visibilidadTodos.ID = 0;
            visibilidadTodos.Descripcion = "Todos";
            dataSourceVisibilidad.Add(visibilidadTodos);
            CboVisibilidad.DataSource = dataSourceVisibilidad;
            CboVisibilidad.ValueMember = "ID";
            CboVisibilidad.DisplayMember = "Descripcion";

            #endregion

            ClearDataGridView();
        }

        private void FrmListadoEstadistico_Load(object sender, EventArgs e)
        {
            RefreshSources(null);
        }

        private void LblFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validaciones

                var filtersSetted = false;
                var exceptionMessage = string.Empty;

                if (!TypesHelper.IsEmpty(CboAño.Text))
                    filtersSetted = true;

                if (!TypesHelper.IsEmpty(CboTrimestre.Text))
                    filtersSetted = true;

                if (!TypesHelper.IsEmpty(CboListado.Text))
                    filtersSetted = true;

                if ((int)CboListado.SelectedValue == 1 && !TypesHelper.IsEmpty(CboVisibilidad.Text))
                    filtersSetted = true;

                if (!filtersSetted)
                    exceptionMessage = "No se puede obtener el listado estadístico. Verifique que haya ingresado los filtros correctamente.";

                if (!TypesHelper.IsEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);

                #endregion

                var monthDesde = "";
                var dayHasta = "";
                var monthHasta = "";

                //Si es la primera estadística, puede que esté filtrada por mes, si está en 00, filtro por trimestre
                if ((string)cboMes.SelectedValue == "00" || (int)CboListado.SelectedValue != 1)
                {
                    switch ((int)CboTrimestre.SelectedValue)
                    {
                        case 1: monthDesde = "01"; monthHasta = "03"; break;
                        case 2: monthDesde = "04"; monthHasta = "06"; break;
                        case 3: monthDesde = "07"; monthHasta = "09"; break;
                        case 4: monthDesde = "10"; monthHasta = "12"; break;
                    }
                }
                else
                {
                    monthDesde = monthHasta = (string)cboMes.SelectedValue;
                }

                switch (monthHasta)
                {
                    case "01": case "03": case "05": case "07": case "08": case "10": case "12": dayHasta = "31"; break;
                    case "04": case "06": case "09": case "11": dayHasta = "30"; break;
                    case "02": dayHasta = "28"; break;
                }

                var fechaDesde = DateTime.Parse("01/" + monthDesde + "/" + CboAño.SelectedValue.ToString());
                var fechaHasta = DateTime.Parse(dayHasta + "/" + monthHasta + "/" + CboAño.SelectedValue.ToString());

                //Creo los filtros con los que se ejecuta la consulta.
                var filters = new EstadisticaFilters
                {
                    FechaDesde = fechaDesde,
                    FechaHasta = fechaHasta,
                    Visibilidad = (!TypesHelper.IsEmpty(CboVisibilidad.Text) && (int)CboVisibilidad.SelectedValue != 0) ? (int)CboVisibilidad.SelectedValue : (int?)null
                };

                var listado = new List<Estadistica>();
                switch ((int)CboListado.SelectedValue)
                {
                    case 1:
                        listado = EstadisticaPersistance.GetSellersWithMoreProductsNotSold(filters);
                        break;

                    case 2:
                        listado = EstadisticaPersistance.GetSellersWithMoreBilling(filters);
                        break;

                    case 3:
                        listado = EstadisticaPersistance.GetSellersWithBetterQualifications(filters);
                        break;

                    case 4:
                        listado = EstadisticaPersistance.GetClientsWithMoreNotQualifiedPublications(filters);
                        break;
                }

                if (listado == null || listado.Count == 0)
                    throw new Exception("No se encontraron estadísticas según los filtros informados.");

                LoadGrid(listado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
                ClearDataGridView();
            }
        }

        private void LoadGrid(List<Estadistica> listado)
        {
            
            #region Generar el diccionario con las estadísticas
            var statisticsDictionary = new Dictionary<string, Estadistica>();
            if (listado == null)
            {
                //El datasource debe estar vacío
                DgvListado.DataSource = null;
            }
            else
            {
                //El datasource debe ser la lista de los usuarios y sus metricas que recibió por parametro
                statisticsDictionary = listado.ToDictionary(a => a.Usuario, a => a);
            }

            #endregion

            if (statisticsDictionary != null)
            {
                //Parseo el diccionario y muestro en la grilla según el listado pedido
                switch ((int)CboListado.SelectedValue)
                {
                    case 1:
                        var bind1 = statisticsDictionary.Values.Select(a => new
                        {
                            Vendedor = a.Usuario,
                            Cantidad = a.Valor
                        });
                        DgvListado.DataSource = bind1.ToList();
                        break;

                    case 2:
                        var bind2 = statisticsDictionary.Values.Select(a => new
                        {
                            Vendedor = a.Usuario,
                            Total = a.Valor
                        });
                        DgvListado.DataSource = bind2.ToList();
                        break;
                    case 3:
                        var bind3 = statisticsDictionary.Values.Select(a => new
                        {
                            Vendedor = a.Usuario,
                            Calificacion = a.Valor
                        });
                        DgvListado.DataSource = bind3.ToList();
                        break;
                    case 4:
                        var bind4 = statisticsDictionary.Values.Select(a => new
                        {
                            Cliente = a.Usuario,
                            Cantidad = a.Valor
                        });
                        DgvListado.DataSource = bind4.ToList();
                        break;
                }

                DgvListado.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            DgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CboListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Muestro/oculto los filtros según el listado seleccionado (solo los muestro si es el primero)
            if (CboListado.SelectedIndex == 0)
            {
                lblVisibilidadText.Visible = true;
                CboVisibilidad.Visible = true;
                lblMesText.Visible = true;
                cboMes.Visible = true;
            }
            else
            {
                lblVisibilidadText.Visible = false;
                CboVisibilidad.Visible = false;
                lblMesText.Visible = false;
                cboMes.Visible = false;
            }
        }

        private void LoadMonthsByTrimester()
        {
            var dataSourceMes = new List<object>();
            switch ((int)CboTrimestre.SelectedValue)
            { 
                case 1:
                    dataSourceMes.Add(new { Name = "Enero", Value = "01" });
                    dataSourceMes.Add(new { Name = "Febrero", Value = "02" });
                    dataSourceMes.Add(new { Name = "Marzo", Value = "03" });
                    dataSourceMes.Add(new { Name = "Todos", Value = "00" });
                break;
                case 2:
                    dataSourceMes.Add(new { Name = "Abril", Value = "04" });
                    dataSourceMes.Add(new { Name = "Mayo", Value = "05" });
                    dataSourceMes.Add(new { Name = "Junio", Value = "06" });
                    dataSourceMes.Add(new { Name = "Todos", Value = "00" });
                break;
                case 3:
                    dataSourceMes.Add(new { Name = "Julio", Value = "07" });
                    dataSourceMes.Add(new { Name = "Agosto", Value = "08" });
                    dataSourceMes.Add(new { Name = "Septiembre", Value = "09" });
                    dataSourceMes.Add(new { Name = "Todos", Value = "00" });
                break;
                case 4:
                    dataSourceMes.Add(new { Name = "Octubre", Value = "10" });
                    dataSourceMes.Add(new { Name = "Noviembre", Value = "11" });
                    dataSourceMes.Add(new { Name = "Diciembre", Value = "12" });
                    dataSourceMes.Add(new { Name = "Todos", Value = "00" });
                break;
            }
            cboMes.DataSource = dataSourceMes;
            cboMes.ValueMember = "Value";
            cboMes.DisplayMember = "Name";
        }

        private void CboTrimestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMonthsByTrimester();
        }

        private void GroupFiltros_Enter(object sender, EventArgs e)
        {

        }
    }
}
