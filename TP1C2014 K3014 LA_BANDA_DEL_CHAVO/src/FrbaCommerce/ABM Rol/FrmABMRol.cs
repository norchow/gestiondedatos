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

namespace FrbaCommerce.ABM_Rol
{
    public partial class FrmABMRol : Form
    {
        public FrmABMRol()
        {
            InitializeComponent();
        }

        private void FrmABMRol_Load(object sender, EventArgs e)
        {
            RefreshSources();
        }

        private void CboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedRol = (Rol)CboRoles.SelectedItem;

            if (selectedRol != null)
            {
                var functionalitiesByRol = FuncionalidadPersistance.GetByRole(selectedRol);
                ChkActivo.Checked = selectedRol.Activo;
                LstFuncionalidades.DataSource = functionalitiesByRol;
            }
        }

        private void LblListo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RefreshSources()
        {
            var roles = RolPersistance.GetAll();

            CboRoles.DisplayMember = "Descripcion";
            CboRoles.ValueMember = "ID";
            CboRoles.DataSource = roles;

            LstFuncionalidades.DisplayMember = "Descripcion";
            LstFuncionalidades.ValueMember = "ID";
        } 
        
        private void LblNuevo_Click(object sender, EventArgs e)
        {
            var insertUpdateForm = new FrmInsertUpdateRol(null);
            insertUpdateForm.ShowDialog();

            RefreshSources();
        }

        private void LblModificar_Click(object sender, EventArgs e)
        {
            if ((Rol)CboRoles.SelectedItem != null)
            {
                var insertUpdateForm = new FrmInsertUpdateRol((Rol)CboRoles.SelectedItem);
                insertUpdateForm.ShowDialog();

                RefreshSources();
            }
        }

        private void LblEliminar_Click(object sender, EventArgs e)
        {
            var selectedRol = (Rol)CboRoles.SelectedItem;
            if (selectedRol != null)
            {
                var dialogAnswer = MessageBox.Show(string.Format("Esta seguro que quiere desactivar el rol {0}", selectedRol.Descripcion), "Atención", MessageBoxButtons.YesNo);
                if (dialogAnswer == DialogResult.Yes)
                {
                    selectedRol.Activo = false;
                    RolPersistance.UpdateRole(selectedRol, null);
                }

                RefreshSources();
            }
        }

        private void LblBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtBuscar.Text))
                    throw new Exception("El nombre de los roles a buscar se encuentra vacio.");

                if (ChkExacta.Checked)
                {
                    var role = RolPersistance.GetByName(TxtBuscar.Text);

                    if (role == null)
                        throw new Exception("No se encontraron roles con dicho nombre.");

                    CboRoles.DataSource = new List<Rol> { role };
                }
                else
                {
                    var rolesLikeName = RolPersistance.GetByNameLike(TxtBuscar.Text);

                    if (rolesLikeName == null)
                        throw new Exception("No se encontraron roles con nombre parecido al ingresado.");

                    CboRoles.DataSource = rolesLikeName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }

        private void LblLimpiar_Click(object sender, EventArgs e)
        {
            TxtBuscar.Text = string.Empty;
            ChkExacta.Checked = false;
            RefreshSources();
        }
    }
}
