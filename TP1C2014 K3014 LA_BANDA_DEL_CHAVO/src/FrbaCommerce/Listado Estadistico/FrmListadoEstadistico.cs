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

            var dataSourceAño = new List<object>();
            for (var i = 1980; i <= Convert.ToInt32(Configuration.ConfigurationVariables.FechaSistema.Year); i++)
                dataSourceAño.Add(new { Name = i, Value = i });
            CboAño.DataSource = dataSourceAño;
            CboAño.ValueMember = "Value";
            CboAño.DisplayMember = "Name";

            var dataSourceTrimestre = new List<object>();
            dataSourceTrimestre.Add(new { Name = "Enero - Marzo", Value = 1 });
            dataSourceTrimestre.Add(new { Name = "Abril - Junio", Value = 2 });
            dataSourceTrimestre.Add(new { Name = "Julio - Septiembre", Value = 3 });
            dataSourceTrimestre.Add(new { Name = "Octubre - Diciembre", Value = 4 });
            CboTrimestre.DataSource = dataSourceTrimestre;
            CboTrimestre.ValueMember = "Value";
            CboTrimestre.DisplayMember = "Name";

            var dataSourceListado = new List<object>();
            dataSourceListado.Add(new { Name = "[Vendedores] Mayor cant. de productos no vendidos", Value = 1 });
            dataSourceListado.Add(new { Name = "[Vendedores] Mayor facturación", Value = 2 });
            dataSourceListado.Add(new { Name = "[Vendedores] Mayores calificaciones", Value = 3 });
            dataSourceListado.Add(new { Name = "[Clientes] Mayor cant. de publicaciones sin calificar", Value = 4 });
            CboListado.DataSource = dataSourceListado;
            CboListado.ValueMember = "Value";
            CboListado.DisplayMember = "Name";

            CboVisibilidad.DataSource = VisibilidadPersistance.GetAll();
            CboVisibilidad.ValueMember = "ID";
            CboVisibilidad.DisplayMember = "Descripcion";

            #endregion

            ClearDataGridView();
            var estadisticasList = new List<Estadistica>();

            #region Get the dictionary of visibilities

            if (estadisticas == null)
            {
                //The datasource must be empty
                CleanFiltersUI();
                DgvListado.DataSource = null;
            }
            else
            {
                //The datasource must be the list of visibilities received as parameter
                estadisticasList = estadisticas.ToList();
            }

            #endregion

            //var bind = new List<object>();
            //switch ((int)CboListado.SelectedValue)
            //{
            //    case 1:
            //        bind = estadisticasList.Select(a => new
            //        {
            //            Vendedor = a.Usuario,
            //            Cantidad = a.Valor
            //        });
            //        break;

            //    case 2:
            //        bind = estadisticasList.Select(a => new
            //        {
            //            Vendedor = a.Usuario,
            //            Total = a.Valor
            //        });
            //        break;
            //    case 3:
            //        bind = estadisticasList.Select(a => new
            //        {
            //            Vendedor = a.Usuario,
            //            Calificacion = a.Valor
            //        });
            //        break;
            //    case 4:
            //        bind = estadisticasList.Select(a => new
            //        {
            //            Cliente = a.Usuario,
            //            Cantidad = a.Valor
            //        });
            //        break;
            //}
            

            //DgvListado.DataSource = bind.ToList();

            DgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void FrmListadoEstadistico_Load(object sender, EventArgs e)
        {
            RefreshSources(null);
        }

        private void LblFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validations

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

                var monthDesde = 0;
                var dayHasta = 0;
                var monthHasta = 0;
                switch ((int)CboTrimestre.SelectedValue)
                {
                    case 1: monthDesde = 1; monthHasta = 3; break;
                    case 2: monthDesde = 4; monthHasta = 6; break;
                    case 3: monthDesde = 7; monthHasta = 9; break;
                    case 4: monthDesde = 10; monthHasta = 12; break;
                }

                switch (monthHasta)
                {
                    case 1: case 3: case 5: case 7: case 8: case 10: case 12: dayHasta = 31; break;
                    case 4: case 6: case 9: case 11: dayHasta = 30; break;
                    case 2: dayHasta = 28; break;
                }

                var fechaDesde = "01/" + monthDesde.ToString("00") + "/" + CboAño.SelectedText;
                var fechaHasta = dayHasta.ToString("00") + "/" + monthHasta.ToString("00") + "/" + CboAño.SelectedText;

                var filters = new EstadisticaFilters
                {
                    FechaDesde = (!TypesHelper.IsEmpty(CboAño.Text) && !TypesHelper.IsEmpty(CboTrimestre.Text)) ? fechaDesde : null,
                    FechaHasta = (!TypesHelper.IsEmpty(CboAño.Text) && !TypesHelper.IsEmpty(CboTrimestre.Text)) ? fechaHasta : null,
                    Visibilidad = (!TypesHelper.IsEmpty(CboVisibilidad.Text)) ? (int)CboVisibilidad.SelectedValue : (int?)null
                };

                //var listado;
                //switch ((int)CboListado.SelectedValue)
                //{
                //    case 1:
                //        listado = EstadisticaPersistance.GetEstadistica1(filters);
                //        break;

                //    case 2:
                //        listado = EstadisticaPersistance.GetEstadistica2(filters);
                //        break;

                //    case 3:
                //        listado = EstadisticaPersistance.GetEstadistica3(filters);
                //        break;

                //    case 4:
                //        listado = EstadisticaPersistance.GetEstadistica4(filters);
                //        break;
                //}

                //if (listado == null || listado.Count == 0)
                //    throw new Exception("No se encontraron estadísticas según los filtros informados.");

                //RefreshSources(listado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }
    }
}
