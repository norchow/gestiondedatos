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

namespace FrbaCommerce.Abm_Cliente
{
    public partial class FrmABMCliente : Form
    {

        private List<Cliente> _clientes = new List<Cliente>();

        public FrmABMCliente()
        {
            InitializeComponent();
        }

        private void LblListo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LblLimpiar_Click(object sender, EventArgs e)
        {
            //Vaciar grilla y limpiar los filtros
            RefreshSources(null);
            CleanFiltersUI();
        }

        private void CleanFiltersUI()
        {
            TxtNombre.Text = string.Empty;
            TxtApellido.Text = string.Empty;
            CboTipoDocumento.Text = string.Empty;
            TxtDocumento.Text = string.Empty;
            TxtEmail.Text = string.Empty;
        }

        private void ClearDataGridView()
        {
            DgvClientes.DataSource = null;
            DgvClientes.Columns.Clear();
        }

        private void RefreshSources(List<Cliente> clientes)
        {
            #region Load sources

            //Carga el combobox de TipoDocumento
            CboTipoDocumento.DataSource = TipoDocumentoPersistance.GetAll();
            CboTipoDocumento.ValueMember = "ID";
            CboTipoDocumento.DisplayMember = "Descripcion";

            #endregion

            ClearDataGridView();
            var clientesDictionary = new Dictionary<int, Cliente>();

            #region Cargar el diccionario a mostrar en la grilla

            if (clientes == null)
            {
                //El datasource se carga con todos los Clientes de la BD
                CleanFiltersUI();
                _clientes = ClientePersistance.GetAllClients();
                clientesDictionary = _clientes.ToDictionary(a => a.ID, a => a);
            }
            else
            {
                //El datasource se carga con la lista de Clientes recibida por parámetro
                clientesDictionary = clientes.ToDictionary(a => a.ID, a => a);
            }

            #endregion

            //Muestra en la grilla el contenido de los clientes que se encuentran cargados en el diccionario
            var bind = clientesDictionary.Values.Select(a => new
            {
                ID = a.ID,
                ID_Usuario = a.IdUsuario,
                Nombre = a.Nombre,
                Apellido = a.Apellido,
                Tipo_Documento = TipoDocumentoPersistance.GetById(a.TipoDocumento).Descripcion,
                Nro_Documento = a.NroDocumento,
                Mail = a.Mail,
                Telefono = a.Telefono,
                Direccion = a.Direccion,
                Cod_Postal = a.CodigoPostal,
                F_Nacimiento = a.FechaNacimiento,
                CUIL = a.CUIL,
                Habilitado = a.Habilitado
            });

            DgvClientes.DataSource = bind.ToList();
            AddButtonsColumns();

            DgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void FrmABMCliente_Load(object sender, EventArgs e)
        {  
            RefreshSources(null);
        }

        private void AddButtonsColumns()
        {
            //Agregar a la grilla las últimas dos columnas con los botones "Modificar" y "Des/habilitar"
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

            DgvClientes.Columns.Add(updateColumn);
            DgvClientes.Columns.Add(deleteColumn);
        }

        private void LblBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validations

                var filtersSetted = false;
                var exceptionMessage = string.Empty;

                if (!TypesHelper.IsEmpty(TxtNombre.Text))
                    filtersSetted = true;

                if (!TypesHelper.IsEmpty(TxtApellido.Text))
                    filtersSetted = true;

                if (!TypesHelper.IsEmpty(CboTipoDocumento.Text))
                    filtersSetted = true;

                if (!TypesHelper.IsEmpty(TxtDocumento.Text))
                    filtersSetted = true;

                int document;
                if (int.TryParse(TxtDocumento.Text, out document))
                    filtersSetted = true;

                if (!TypesHelper.IsEmpty(TxtEmail.Text))
                    filtersSetted = true;

                if (!filtersSetted)
                    exceptionMessage = "No se puede realizar la búsqueda. Verifique que haya ingresado algún filtro y que los mismos sean válidos.";
                    
                if (!TypesHelper.IsEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);

                #endregion

                //Cargar los filtros ingresados en el objeto de tipo ClienteFilters
                var filters = new ClienteFilters
                {

                    Nombre = (!TypesHelper.IsEmpty(TxtNombre.Text)) ? TxtNombre.Text : null,
                    Apellido = (!TypesHelper.IsEmpty(TxtApellido.Text)) ? TxtApellido.Text : null,
                    TipoDocumento = (!TypesHelper.IsEmpty(CboTipoDocumento.Text)) ? (int)CboTipoDocumento.SelectedValue : (int?)null,
                    NroDocumento = (!TypesHelper.IsEmpty(TxtDocumento.Text)) ? Convert.ToInt32(TxtDocumento.Text) : (int?)null,
                    Email = (!TypesHelper.IsEmpty(TxtEmail.Text)) ? TxtEmail.Text : null
                    };

                var clientes = (ChkBusquedaExacta.Checked) ? ClientePersistance.GetAllClientsByParameters(filters) : ClientePersistance.GetAllClientsByParametersLike(filters);

                if (clientes == null || clientes.Count == 0)
                    throw new Exception("No se encontraron clientes según los filtros informados.");

                //Refrescar la grilla, cargando los Clientes que se obtuvieron como resultado de los filtros
                RefreshSources(clientes);
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
                var frmABMInsertUpdateCliente = new FrmABMInsertUpdateCliente(transaction);
                frmABMInsertUpdateCliente.ShowDialog();
            }
        }

        private void DgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Only works when user clicks one of the buttons (column index 5 and 6)
            if (e.ColumnIndex < 13 || e.RowIndex == -1)
                return;

            var selectedCliente = _clientes.Find(cliente => cliente.ID == (int)DgvClientes.Rows[e.RowIndex].Cells[0].Value);

            if (selectedCliente != null)
            {
                //Click en el botón "Modificar"
                if (e.ColumnIndex == 13)
                {
                    var insertUpdateCliente = new FrmABMInsertUpdateCliente(selectedCliente);
                    insertUpdateCliente.ShowDialog();

                    if (insertUpdateCliente.CompleteAction)
                        RefreshSources(null);
                }
                else
                {
                    //Click en el botón "Des/habilitar"
                    if (selectedCliente.Habilitado == true)
                    {
                        var dialogAnswer = MessageBox.Show(string.Format("¿Está seguro que quiere desactivar el cliente {0} {1}?", selectedCliente.Nombre, selectedCliente.Apellido), "Atención", MessageBoxButtons.YesNo);
                        if (dialogAnswer == DialogResult.Yes)
                        {
                            UsuarioPersistance.UpdateToDisabledById(selectedCliente.IdUsuario);

                            RefreshSources(null);
                        }
                    }
                    else
                    {
                        var dialogAnswer = MessageBox.Show(string.Format("¿Está seguro que quiere activar el cliente {0} {1}?", selectedCliente.Nombre, selectedCliente.Apellido), "Atención", MessageBoxButtons.YesNo);
                        if (dialogAnswer == DialogResult.Yes)
                        {
                            UsuarioPersistance.UpdateToActivateById(selectedCliente.IdUsuario);

                            RefreshSources(null);
                        }
                    }
                }
            }
        }
    }
}
