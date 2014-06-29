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
using Session;

namespace FrbaCommerce.ABM_Rol
{
    public partial class FrmABMRol : Form
    {
        private List<Rol> _roles = new List<Rol>();

        public FrmABMRol()
        {
            InitializeComponent();
        }

        private void FrmABMRol_Load(object sender, EventArgs e)
        {
            RefreshSources(null);
        }

        private void LblListo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RefreshSources(List<Rol> roles)
        {
            //Borro lo que esta actualmente en la grilla
            ClearDataGridView();
            var rolesDictionary = new Dictionary<int, Rol>();

            #region Get the dictionary of visibilities

            //El datasource debe ser todos los registros de roles almacenados en la base de datos
            if (roles == null)
            {
                CleanFiltersUI();
                _roles = RolPersistance.GetAll();
                LstFuncionalidades.DataSource = _roles[0].Funcionalidades;
                //Convierto todos los roles a un diccionario con entradas de la forma: (ID, Objeto)
                rolesDictionary = _roles.ToDictionary(a => a.ID, a => a);
            }
            else
            {
                //El datasource debe ser una lista de roles obtenidas por parametro
                LstFuncionalidades.DataSource = roles[0].Funcionalidades;
                //Convierto la lista de roles a un diccionario con entradas de la forma: (ID, Objeto)
                rolesDictionary = roles.ToDictionary(a => a.ID, a => a);
            }

            #endregion

            //Creo un bind para luego setearselo directamente a la DataGridView
            var bind = rolesDictionary.Values.Select(a => new
            {
                Descripcion = a.Descripcion,
                Activo = a.Activo
            });
            DgvRol.DataSource = bind.ToList();

            //Agrego los botones a cada fila para poder modificar/borrar cada rol
            AddButtonsColumns();

            LstFuncionalidades.DisplayMember = "Descripcion";
            LstFuncionalidades.ValueMember = "ID";
        }

        private void ClearDataGridView()
        {
            DgvRol.DataSource = null;
            DgvRol.Columns.Clear();
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
            DgvRol.Columns.Add(updateColumn);
            DgvRol.Columns.Add(deleteColumn);
        }

        private void CleanFiltersUI()
        {
            TxtDescripcion.Text = string.Empty;
        }
        
        private void LblNuevo_Click(object sender, EventArgs e)
        {
            var insertUpdateForm = new FrmABMInsertUpdateRol(null);
            insertUpdateForm.ShowDialog();

            //Paso NULL para volver a obtener todos los registros de la base
            RefreshSources(null);
        }

        private void LblBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validations

                var exceptionMessage = string.Empty;

                if (TypesHelper.IsEmpty(TxtDescripcion.Text))
                    exceptionMessage = "No se puede realizar la busqueda ya que no se informó ningún filtro";

                if (!TypesHelper.IsEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);

                #endregion

                List<Rol> roles = null;

                if (ChkExacta.Checked)
                {
                    //Se va a realizar una busqueda exacta (=)
                    var rol = RolPersistance.GetByName(TxtDescripcion.Text);
                    if (rol != null)
                        roles = _roles = new List<Rol> { rol };
                }
                else
                {
                    //Se va a realizar una busqueda inexacta (LIKE)
                    roles = _roles = RolPersistance.GetByNameLike(TxtDescripcion.Text);
                }

                if (roles == null || roles.Count == 0)
                    throw new Exception("No se encontraron roles según los filtros informados.");

                //Recargo los valores de la grilla a partir de los resultados obtenidos en la busqueda
                RefreshSources(roles);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }

        private void LblLimpiar_Click(object sender, EventArgs e)
        {
            TxtDescripcion.Text = string.Empty;
            ChkExacta.Checked = false;
            RefreshSources(null);
        }

        private void DgvRol_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Funciona solo cuando el usuario hace click en una fila (no en la cabecera)
            if (e.RowIndex == -1)
                return;

            //Obtengo el rol correspondiente a la fila seleccionada a partir del ID (primer columna de la fila)
            var selectedRole = _roles.Find(role => role.Descripcion == (string)DgvRol.Rows[e.RowIndex].Cells[0].Value);

            if (selectedRole != null)
            {
                //Cargo la lista de funcionalidades del rol
                LstFuncionalidades.DataSource = selectedRole.Funcionalidades;

                //El usuario tocó el botón de modificar
                if (e.ColumnIndex == 2)
                {
                    var insertUpdateVisibility = new FrmABMInsertUpdateRol(selectedRole);
                    insertUpdateVisibility.ShowDialog();

                    //Si modificó satisfactoriamante el rol, actualizo la grilla
                    if (insertUpdateVisibility.CompleteAction)
                        RefreshSources(null);
                }
                else if (e.ColumnIndex == 3)
                {
                    //El usuario tocó el botón de eliminar

                    //El rol seleccionado ya se encuentra eliminado (baja lógica)
                    if (!selectedRole.Activo)
                    {
                        MessageBox.Show("No se puede eliminar la funcionalidad ya que ya se encuentra desactivada", "Atencion");
                        return;
                    }

                    //Esta tratando de eliminar el rol con el que esta logueado (no lo permito)
                    if (selectedRole.ID == SessionManager.CurrentRol.ID)
                    {
                        MessageBox.Show("No se puede eliminar el rol ya que es el rol con el que actualmente se encuentra logueado", "Atencion");
                        return;
                    }

                    var dialogAnswer = MessageBox.Show(string.Format("Esta seguro que quiere desactivar el rol {0}?", selectedRole.Descripcion), "Atención", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        //Defino que ya no este más activo el rol e impacto en la base de datos
                        selectedRole.Activo = false;
                        RolPersistance.Update(selectedRole, null);

                        //Vuelvo a cargar la lista de roles
                        RefreshSources(null);
                    }
                }
            }
        }
    }
}
