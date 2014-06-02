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
            ClearDataGridView();
            var rolesDictionary = new Dictionary<int, Rol>();

            #region Get the dictionary of visibilities

            //The datasource must be all the roles record from the database
            if (roles == null)
            {
                CleanFiltersUI();
                _roles = RolPersistance.GetAll();
                LstFuncionalidades.DataSource = _roles[0].Funcionalidades;
                rolesDictionary = _roles.ToDictionary(a => a.ID, a => a);
            }
            else
            {
                //The datasource must be the list of roles received as parameter
                LstFuncionalidades.DataSource = roles[0].Funcionalidades;
                rolesDictionary = roles.ToDictionary(a => a.ID, a => a);
            }

            #endregion

            var bind = rolesDictionary.Values.Select(a => new
            {
                Descripcion = a.Descripcion,
                Activo = a.Activo
            });

            DgvRol.DataSource = bind.ToList();
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
                    var rol = RolPersistance.GetByName(TxtDescripcion.Text);
                    if (rol != null)
                        roles = _roles = new List<Rol>{rol};
                }
                else
                    roles = _roles = RolPersistance.GetByNameLike(TxtDescripcion.Text);

                if (roles == null || roles.Count == 0)
                    throw new Exception("No se encontraron roles según los filtros informados.");

                RefreshSources(roles);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
                Close();
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
            //Only works when user clicks one of the rows (not the header)
            if (e.RowIndex == -1)
                return;

            var selectedRole = _roles.Find(role => role.Descripcion == (string)DgvRol.Rows[e.RowIndex].Cells[0].Value);

            if (selectedRole != null)
            {
                LstFuncionalidades.DataSource = selectedRole.Funcionalidades;

                //User clicked update button
                if (e.ColumnIndex == 2)
                {
                    var insertUpdateVisibility = new FrmABMInsertUpdateRol(selectedRole);
                    insertUpdateVisibility.ShowDialog();

                    if (insertUpdateVisibility.CompleteAction)
                        RefreshSources(null);
                }
                else if (e.ColumnIndex == 3)
                {
                    //User clicked delete button
                    if (!selectedRole.Activo)
                    {
                        MessageBox.Show("No se puede eliminar la funcionalidad ya que ya se encuentra desactivada", "Atencion");
                        return;
                    }

                    var dialogAnswer = MessageBox.Show(string.Format("Esta seguro que quiere desactivar el rol {0}?", selectedRole.Descripcion), "Atención", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        selectedRole.Activo = false;
                        RolPersistance.UpdateRole(selectedRole, null);

                        RefreshSources(null);
                    }
                }
            }
        }
    }
}
