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

namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class FrmABMInsertUpdateVisibilidad : Form
    {
        public bool insertMode { get; set; }

        public Visibilidad CurrentVisibility { get; set; }

        public bool RealizoOperacion = false;

        public FrmABMInsertUpdateVisibilidad(Visibilidad visibility)
        {
            InitializeComponent();
            insertMode = visibility == null;

            if (!insertMode)
                CurrentVisibility = visibility;
        }

        public FrmABMInsertUpdateVisibilidad()
        {
            InitializeComponent();
        }

        private void FrmABMInsertUpdateVisibilidad_Load(object sender, EventArgs e)
        {
            this.Text = (insertMode) ? string.Format("{0} - {1}", "FrbaCommerce", "Nueva funcionalidad") : string.Format("{0} - {1}", "FrbaCommerce", "Modificar funcionalidad");
            TxtCodigo.Enabled = insertMode;
            ChkActivo.Checked = true;

            if (!insertMode)
            {
                TxtCodigo.Text = CurrentVisibility.ID.ToString();
                TxtDescripcion.Text = CurrentVisibility.Descripcion;
                TxtDuracion.Text = CurrentVisibility.Duracion.ToString();
                TxtPorcentajeVenta.Text = CurrentVisibility.PorcentajeVenta.ToString();
                TxtPrecioPublicar.Text = CurrentVisibility.PrecioPublicar.ToString();
                ChkActivo.Checked = CurrentVisibility.Activo;
            }
        }

        private void LblGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validations

                var exceptionMessage = string.Empty;

                if (TypesHelper.IsEmpty(TxtCodigo.Text))
                    exceptionMessage += Environment.NewLine + "El codigo de la visibilidad no puede ser vacío.";

                if (!TypesHelper.IsNumeric(TxtCodigo.Text))
                    exceptionMessage += Environment.NewLine + "El codigo de la visibilidad debe ser numérico.";

                if (TypesHelper.IsEmpty(TxtDescripcion.Text))
                    exceptionMessage += Environment.NewLine + "La descripción de la visibilidad no puede ser vacía.";

                if (TypesHelper.IsEmpty(TxtDuracion.Text))
                    exceptionMessage += Environment.NewLine + "La duración de la visibilidad no puede ser vacía.";

                if (!TypesHelper.IsNumeric(TxtDuracion.Text))
                    exceptionMessage += Environment.NewLine + "La duración de la visibilidad debe ser numérica.";

                if (TypesHelper.IsEmpty(TxtPorcentajeVenta.Text))
                    exceptionMessage += Environment.NewLine + "El porcentaje de la venta de la visibilidad no puede ser vacío.";

                if (!TypesHelper.IsDecimal(TxtPorcentajeVenta.Text))
                    exceptionMessage += Environment.NewLine + "El porcentaje de la venta de la visibilidad debe ser decimal (o numérico).";

                if (TypesHelper.IsEmpty(TxtPrecioPublicar.Text))
                    exceptionMessage += Environment.NewLine + "El precio por publicar de la visibilidad no puede ser vacío.";

                if (!TypesHelper.IsDecimal(TxtPrecioPublicar.Text))
                    exceptionMessage += Environment.NewLine + "El precio por publicar de la visibilidad debe ser decimal (o numérico).";

                if (!TypesHelper.IsEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);

                #endregion

                if (insertMode)
                {
                    if (VisibilidadPersistance.GetVisibilityById(Convert.ToInt32(TxtCodigo.Text)) != null)
                        throw new Exception("Ya existe una visibilidad con dicho codigo");

                    #region Insert the new visibility

                    var visibility = new Visibilidad();
                    visibility.ID = Convert.ToInt32(TxtCodigo.Text);
                    visibility.Descripcion = TxtDescripcion.Text;
                    visibility.Duracion = Convert.ToInt32(TxtDuracion.Text);
                    visibility.PrecioPublicar = Convert.ToDouble(TxtPrecioPublicar.Text);
                    visibility.PorcentajeVenta = Convert.ToDouble(TxtPorcentajeVenta.Text);
                    visibility.Activo = ChkActivo.Checked;

                    var dialogAnswer = MessageBox.Show("Esta seguro que quiere insertar la nueva visibilidad?", "Atencion", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        if (VisibilidadPersistance.InsertVisibility(visibility) == 1)
                        {
                            MessageBox.Show("Se inserto satisfactoriamente la nueva visibilidad", "Atencion");
                            RealizoOperacion = true;
                            Close();
                        }
                    }

                    RealizoOperacion = false;

                    #endregion
                }
                else
                {
                    #region Update an existing visibility

                    CurrentVisibility.Descripcion = TxtDescripcion.Text;
                    CurrentVisibility.Duracion = Convert.ToInt32(TxtDuracion.Text);
                    CurrentVisibility.PrecioPublicar = Convert.ToDouble(TxtPrecioPublicar.Text);
                    CurrentVisibility.PorcentajeVenta = Convert.ToDouble(TxtPorcentajeVenta.Text);
                    CurrentVisibility.Activo = ChkActivo.Checked;

                    var dialogAnswer = MessageBox.Show(string.Format("Esta seguro que quiere modificar la visibilidad {0}?", CurrentVisibility.Descripcion), "Atencion", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        if (VisibilidadPersistance.UpdateVisibility(CurrentVisibility) == 1)
                        {
                            MessageBox.Show("Se modifico satisfactoriamente la visibilidad", "Atencion");
                            RealizoOperacion = true;
                            Close();
                        }
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }

        private void LblCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LblLimpiar_Click(object sender, EventArgs e)
        {
            if (insertMode)
                TxtCodigo.Text = string.Empty;

            TxtDescripcion.Text = string.Empty;
            TxtDuracion.Text = string.Empty;
            TxtPorcentajeVenta.Text = string.Empty;
            TxtPrecioPublicar.Text = string.Empty;
        }
    }
}
