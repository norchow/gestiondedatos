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
using System.Data.SqlClient;

namespace FrbaCommerce.ABM_Rol
{
    public partial class FrmABMInsertUpdateRol : Form
    {
        public bool insertMode { get; set; }

        public Rol CurrentRole { get; set; }

        public bool CompleteAction = false;

        public FrmABMInsertUpdateRol(Rol role)
        {
            InitializeComponent();
            insertMode = role == null;

            if (!insertMode)
                CurrentRole = role;
        }

        private void LblCancelar_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que quiere cancelar la operacion?", "Atencion", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialogAnswer)
            {
                Close();
            }
        }

        private void LblGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validations

                var exceptionMessage = string.Empty;

                if (string.IsNullOrEmpty(TxtRol.Text))
                    exceptionMessage += "El nombre del rol no puede ser vacío.";

                if (LstFuncionalidades.CheckedItems.Count == 0)
                    exceptionMessage += Environment.NewLine +  "Debe seleccionar por lo menos una funcionalidad.";

                if (!string.IsNullOrEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);

                #endregion

                if (insertMode)
                {
                    if (RolPersistance.GetByName(TxtRol.Text) != null)
                        throw new Exception("Ya existe un rol con el nombre ingresado.");

                    #region Insert the new role with its features

                    var role = new Rol();
                    role.Activo = ChkActivo.Checked;
                    role.Descripcion = TxtRol.Text;

                    foreach (var checkedItem in LstFuncionalidades.CheckedItems)
                    {
                        var feature = (Funcionalidad)checkedItem;
                        role.Funcionalidades.Add(feature);
                    }

                    var dialogAnswer = MessageBox.Show("Esta seguro que quiere insertar el nuevo rol?", "Atencion", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        RolPersistance.InsertRolAndFeatures(role);
                        CompleteAction = true;
                        Close();
                    }

                    #endregion
                }
                else
                {
                    #region Update an existing role and its features

                    CurrentRole.Activo = ChkActivo.Checked;
                    CurrentRole.Descripcion = TxtRol.Text;
                    CurrentRole.Funcionalidades = new List<Funcionalidad>();

                    foreach (var checkedItem in LstFuncionalidades.CheckedItems)
                    {
                        var feature = (Funcionalidad)checkedItem;
                        CurrentRole.Funcionalidades.Add(feature);
                    }

                    var dialogAnswer = MessageBox.Show(string.Format("Esta seguro que quiere modificar el rol {0}?", CurrentRole.Descripcion), "Atencion", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        RolPersistance.UpdateRoleAndFeatures(CurrentRole);
                        CompleteAction = true;
                        Close();
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
                Close();
            }
        }

        private void FrmInsertUpdateRol_Load(object sender, EventArgs e)
        {
            this.Text = (insertMode) ? string.Format("{0} - {1}", "FrbaCommerce", "Nuevo rol") : string.Format("{0} - {1}", "FrbaCommerce", "Modificar rol");

            LstFuncionalidades.DataSource = FuncionalidadPersistance.GetAll();
            LstFuncionalidades.ValueMember = "ID";
            LstFuncionalidades.DisplayMember = "Descripcion";

            ChkActivo.Checked = true;

            if (!insertMode)
            {
                TxtRol.Text = CurrentRole.Descripcion;
                ChkActivo.Checked = CurrentRole.Activo;

                var featuresRol = FuncionalidadPersistance.GetByRole(CurrentRole);

                for (int j = 0; j < LstFuncionalidades.Items.Count; j++)
                {
                    var checkboxListItem = (Funcionalidad)LstFuncionalidades.Items[j];

                    if (featuresRol.Any(p => p.Descripcion == checkboxListItem.Descripcion))
                        LstFuncionalidades.SetItemChecked(j, true);
                    else
                        LstFuncionalidades.SetItemChecked(j, false);
                }
                    
            }
        }
    }
}
