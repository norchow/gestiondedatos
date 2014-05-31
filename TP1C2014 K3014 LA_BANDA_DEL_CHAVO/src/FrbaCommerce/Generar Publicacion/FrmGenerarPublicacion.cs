using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Persistance;
using Tools;
using Persistance.Entities;
using Configuration;
using Session;

namespace FrbaCommerce.Generar_Publicacion
{
    public partial class FrmGenerarPublicacion : Form
    {
        public bool Auction { get; set; }

        public FrmGenerarPublicacion()
        {
            InitializeComponent();
        }

        private void FrmGenerarPublicacion_Load(object sender, EventArgs e)
        {
            #region Display all sources

            var publicationTypes = TipoPublicacionPersistance.GetAll();
            CboTipoPublicacion.DisplayMember = "Descripcion";
            CboTipoPublicacion.ValueMember = "ID";
            CboTipoPublicacion.DataSource = publicationTypes;

            var publicationStates = EstadoPublicacionPersistance.GetAll();
            CboEstadoPublicacion.DisplayMember = "Descripcion";
            CboEstadoPublicacion.ValueMember = "ID";
            CboEstadoPublicacion.DataSource = publicationStates;

            var visibilities = VisibilidadPersistance.GetAll();
            CboVisibilidad.DisplayMember = "Descripcion";
            CboVisibilidad.ValueMember = "ID";
            CboVisibilidad.DataSource = visibilities;

            var rubros = RubroPersistance.GetAll();
            LstRubro.DataSource = rubros;
            LstRubro.DisplayMember = "Descripcion";
            LstRubro.ValueMember = "ID";

            #endregion
        }

        private void LblListo_Click(object sender, EventArgs e)
        {
            try
            {
                var publication = new Publicacion();

                #region Validations

                var exceptionMessage = string.Empty;

                if (Auction)
                {
                    if (TypesHelper.IsEmpty(TxtValorInicioSubasta.Text))
                        exceptionMessage += Environment.NewLine + "El valor de inicio de la subasta no puede ser vacío.";

                    if (!TypesHelper.IsDecimal(TxtValorInicioSubasta.Text))
                        exceptionMessage += Environment.NewLine + "El valor de inicio de la subasta debe ser decimal (o numérico).";
                }
                else
                {
                    if (TypesHelper.IsEmpty(TxtPrecio.Text))
                        exceptionMessage += Environment.NewLine + "El precio del articulo no puede ser vacío.";

                    if (!TypesHelper.IsDecimal(TxtPrecio.Text))
                        exceptionMessage += Environment.NewLine + "El precio del articulo debe ser decimal (o numérico).";
                }

                if (TypesHelper.IsEmpty(TxtDescripcion.Text))
                    exceptionMessage += Environment.NewLine + "La descripcion del articulo no puede ser vacío.";

                if (TypesHelper.IsEmpty(TxtStock.Text))
                    exceptionMessage += Environment.NewLine + "El stock del articulo no puede ser vacío.";

                if (!TypesHelper.IsNumeric(TxtStock.Text))
                    exceptionMessage += Environment.NewLine + "El stock del articulo debe ser numérico.";

                if (LstRubro.CheckedItems.Count == 0)
                    exceptionMessage += Environment.NewLine + "Debe informar por lo menos un rubro.";

                if (!TypesHelper.IsEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);

                #endregion

                #region Insert the new publication

                publication.Descripcion = TxtDescripcion.Text;
                publication.Stock = Convert.ToInt32(TxtStock.Text);
                publication.TipoPublicacion = ((TipoPublicacion)CboTipoPublicacion.SelectedItem);
                publication.EstadoPublicacion = ((EstadoPublicacion)CboEstadoPublicacion.SelectedItem);
                publication.Precio = (Auction) ? Convert.ToDouble(TxtValorInicioSubasta.Text) : Convert.ToDouble(TxtPrecio.Text);
                publication.RecibirPreguntas = ChkRecibirPreguntas.Checked;
                publication.Visibilidad = ((Visibilidad)CboVisibilidad.SelectedItem);
                publication.FechaInicio = ConfigurationVariables.FechaSistema;
                publication.FechaVencimiento = ConfigurationVariables.FechaSistema.AddDays(publication.Visibilidad.Duracion);
                publication.UsuarioCreador = SessionManager.CurrentUser;

                foreach (var checkedItem in LstRubro.CheckedItems)
                {
                    var category = (Rubro)checkedItem;
                    publication.Rubros.Add(category);
                }

                var dialogAnswer = MessageBox.Show("Esta seguro que quiere insertar la nueva publicacion?", "Atencion", MessageBoxButtons.YesNo);
                if (dialogAnswer == DialogResult.Yes)
                {
                    if (PublicacionPersistance.InsertPublication(publication) == 1)
                    {
                        MessageBox.Show("Se inserto satisfactoriamente la nueva publicacion", "Atencion");
                        Close();
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atencion");
            }
        }

        private void CboTipoPublicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            var publicationTypeSelected = (TipoPublicacion)CboTipoPublicacion.SelectedItem;
            if (publicationTypeSelected != null)
                Auction = TxtValorInicioSubasta.Enabled = publicationTypeSelected.Descripcion == "Subasta";

            TxtPrecio.Enabled = !Auction;
        }

        private void LblLimpiar_Click(object sender, EventArgs e)
        {
            ClearUIControls();
        }

        private void LblCancelar_Click(object sender, EventArgs e)
        {
           Close();
        }

        private void ClearUIControls()
        {
            CboEstadoPublicacion.SelectedIndex = 0;
            CboTipoPublicacion.SelectedIndex = 0;
            CboVisibilidad.SelectedIndex = 0;
            ChkRecibirPreguntas.Checked = false;
            TxtValorInicioSubasta.Text = string.Empty;
            TxtDescripcion.Text = string.Empty;
            TxtPrecio.Text = string.Empty;
            TxtStock.Text = string.Empty;

            if (LstRubro.CheckedIndices != null)
                foreach (var checkedIndex in LstRubro.CheckedIndices)
                    LstRubro.SetItemCheckState((int)checkedIndex, CheckState.Unchecked);
        }
    }
}
