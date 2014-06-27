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
using FrbaCommerce.Registro_de_Usuario;

namespace FrbaCommerce.Abm_Empresa
{
    public partial class FrmABMEmpresa : Form
    {

        private List<Empresa> _empresas = new List<Empresa>();

        public FrmABMEmpresa()
        {
            InitializeComponent();
        }

        private void LblListo_Click(object sender, EventArgs e)
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
            TxtRazonSocial.Text = string.Empty;
            TxtCuit.Text = string.Empty;
            TxtEmail.Text = string.Empty;
        }

        private void ClearDataGridView()
        {
            DgvEmpresas.DataSource = null;
            DgvEmpresas.Columns.Clear();
        }

        private void RefreshSources(List<Empresa> empresas)
        {
            ClearDataGridView();
            var empresasDictionary = new Dictionary<int, Empresa>();

            #region Get the dictionary of visibilities

            if (empresas == null)
            {
                //The datasource must be all the visibilities records stored in the database
                CleanFiltersUI();
                _empresas = EmpresaPersistance.GetAllBusiness();
                empresasDictionary = _empresas.ToDictionary(a => a.ID, a => a);
            }
            else
            {
                //The datasource must be the list of visibilities received as parameter
                empresasDictionary = empresas.ToDictionary(a => a.ID, a => a);
            }

            #endregion

            var bind = empresasDictionary.Values.Select(a => new
            {
                ID = a.ID,
                ID_Usuario = a.IdUsuario,
                Razon_Social = a.RazonSocial,
                Mail = a.Mail,
                Telefono = a.Telefono,
                Direccion = a.Direccion,
                Cod_Postal = a.CodigoPostal,
                Ciudad = a.Ciudad,
                CUIT = a.CUIT,
                Nom_Contacto = a.NombreContacto,
                F_Creacion = a.FechaCreacion,
                Habilitado = a.Habilitado
            });

            DgvEmpresas.DataSource = bind.ToList();
            AddButtonsColumns();

            DgvEmpresas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
           
        }

        private void FrmABMEmpresa_Load(object sender, EventArgs e)
        {
            RefreshSources(null);
        }

        private void AddButtonsColumns()
        {
            var updateColumn = new DataGridViewButtonColumn
            {
                Text = "Modificar",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            var deleteColumn = new DataGridViewButtonColumn
            {
                Text = "Des/Habilitar",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            DgvEmpresas.Columns.Add(updateColumn);
            DgvEmpresas.Columns.Add(deleteColumn);
        }

        private void LblBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validations

                var filtersSetted = false;
                var exceptionMessage = string.Empty;

                if (!TypesHelper.IsEmpty(TxtRazonSocial.Text))
                    filtersSetted = true;

                if (!TypesHelper.IsEmpty(TxtCuit.Text))
                {
                    filtersSetted = true;
                    if (!TypesHelper.IsCUITValid(TxtCuit.Text))
                        exceptionMessage += Environment.NewLine + "El cuit no es un cuit válido.";
                }

                if (!TypesHelper.IsEmpty(TxtEmail.Text))
                {
                    filtersSetted = true;
                }

                if (!filtersSetted)
                    exceptionMessage = "No se puede realizar la busqueda ya que no se informó ningún filtro";

                if (!TypesHelper.IsEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);

                #endregion

                var filters = new EmpresaFilters
                {
                    
                    RazonSocial = (!TypesHelper.IsEmpty(TxtRazonSocial.Text)) ? TxtRazonSocial.Text : null,
                    Cuit = (!TypesHelper.IsEmpty(TxtCuit.Text)) ? TxtCuit.Text : null,
                    Email = (!TypesHelper.IsEmpty(TxtEmail.Text)) ? TxtEmail.Text : null
                    };

                var empresas = (ChkBusquedaExacta.Checked) ? EmpresaPersistance.GetAllBusinessByParameters(filters) : EmpresaPersistance.GetAllBusinessByParametersLike(filters);

                if (empresas == null || empresas.Count == 0)
                    throw new Exception("No se encontraron empresas según los filtros informados.");

                RefreshSources(empresas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }

        private void LblNuevo_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var transaction = DataBaseManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
            {
                var frmABMInsertUpdateEmpresa = new FrmABMInsertUpdateEmpresa(transaction);
                frmABMInsertUpdateEmpresa.ShowDialog();
            }
        }

        private void DgvEmpresas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Only works when user clicks one of the buttons (column index 5 and 6)
            if (e.ColumnIndex < 12 || e.RowIndex == -1)
                return;

            var selectedEmpresa = _empresas.Find(empresa => empresa.ID == (int)DgvEmpresas.Rows[e.RowIndex].Cells[0].Value);

            if (selectedEmpresa != null)
            {
                //User clicked update button
                if (e.ColumnIndex == 12)
                {
                    var insertUpdateEmpresa = new FrmABMInsertUpdateEmpresa(selectedEmpresa);
                    insertUpdateEmpresa.ShowDialog();

                    if (insertUpdateEmpresa.CompleteAction)
                        RefreshSources(null);
                }
                else
                {
                    //User clicked delete button
                    if (selectedEmpresa.Habilitado == true)
                    {
                        var dialogAnswer = MessageBox.Show(string.Format("Esta seguro que quiere desactivar la empresa {0}?", selectedEmpresa.RazonSocial), "Atención", MessageBoxButtons.YesNo);
                        if (dialogAnswer == DialogResult.Yes)
                        {
                            UsuarioPersistance.UpdateToDisabledById(selectedEmpresa.IdUsuario);

                            RefreshSources(null);
                        }
                    }
                    else
                    {
                        var dialogAnswer = MessageBox.Show(string.Format("Esta seguro que quiere activar la empresa {0}?", selectedEmpresa.RazonSocial), "Atención", MessageBoxButtons.YesNo);
                        if (dialogAnswer == DialogResult.Yes)
                        {
                            UsuarioPersistance.UpdateToActivateById(selectedEmpresa.IdUsuario);

                            RefreshSources(null);
                        }
                    }
                }
            }
        }
    }
}
