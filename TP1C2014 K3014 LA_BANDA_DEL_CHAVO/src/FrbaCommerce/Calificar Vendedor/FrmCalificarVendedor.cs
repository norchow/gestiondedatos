using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Persistance.Entities;
using Persistance;
using Session;
using FrbaCommerce.Properties;
using Tools;
using Filters;

namespace FrbaCommerce.Calificar_Vendedor
{
    public partial class FrmCalificarVendedor : Form
    {
        private int calification;
        private int publicationSelected;
        private List<PublicacionNotCalified> _publicationsNotCalified = new List<PublicacionNotCalified>();

        public FrmCalificarVendedor()
        {
            InitializeComponent();
            calification = 0;
        }

        private void ClearDataGridView()
        {
            dgvPublicaciones.DataSource = null;
            dgvPublicaciones.Columns.Clear();
        }

        private void RefreshSources(List<PublicacionNotCalified> publicationNotCalified)
        {
            ClearDataGridView();
            var publicationNotCalifiedDictionary = new Dictionary<int, PublicacionNotCalified>();

            if (publicationNotCalified == null)
            {
                //The datasource must be all the publications not calified records stored in the database
                _publicationsNotCalified = CalificacionPersistance.GetAllPubicacionNotCalified(SessionManager.CurrentUser);
                publicationNotCalifiedDictionary = _publicationsNotCalified.ToDictionary(a => a.ID, a => a); ;
            }
            else
            {
                //The datasource must be the list of publications not calified received as parameter
                publicationNotCalifiedDictionary = publicationNotCalified.ToDictionary(a => a.ID, a => a);
            }

            var bind = publicationNotCalifiedDictionary.Values.Select(a => new
            {
                Codigo = a.ID,
                Descripcion = a.Descripcion,
                Precio = a.Precio
            });

            dgvPublicaciones.DataSource = bind.ToList();
            dgvPublicaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPublicaciones.CurrentCell = null; 
            ShowStars();
        }

        private void ShowStars()
        {
            pbStar1.Visible = true;
            pbStar2.Visible = true;
            pbStar3.Visible = true;
            pbStar4.Visible = true;
            pbStar5.Visible = true;
            lblCalificar.Visible = true;
        }

        private Image getYellowStar()
        {
            return Resources.YellowStar;
        }

        private Image getWhiteStar()
        {
            return Resources.WhiteStar;
        }

        private void drawStars(int calification)
        {
            pbStar1.Image = getWhiteStar();
            pbStar2.Image = getWhiteStar();
            pbStar3.Image = getWhiteStar();
            pbStar4.Image = getWhiteStar();
            pbStar5.Image = getWhiteStar();

            switch (calification)
            {
                case 1:
                    pbStar1.Image = getYellowStar();
                    break;

                case 2:
                    pbStar1.Image = getYellowStar();
                    pbStar2.Image = getYellowStar();
                    break;

                case 3:
                    pbStar1.Image = getYellowStar();
                    pbStar2.Image = getYellowStar();
                    pbStar3.Image = getYellowStar();
                    break;

                case 4:
                    pbStar1.Image = getYellowStar();
                    pbStar2.Image = getYellowStar();
                    pbStar3.Image = getYellowStar();
                    pbStar4.Image = getYellowStar();
                    break;

                case 5:
                    pbStar1.Image = getYellowStar();
                    pbStar2.Image = getYellowStar();
                    pbStar3.Image = getYellowStar();
                    pbStar4.Image = getYellowStar();
                    pbStar5.Image = getYellowStar();
                    break;

                default:
                    break;
            }

        }

        private void pbStar1_MouseHover(object sender, EventArgs e)
        {
            drawStars(1);
        }

        private void pbStar1_MouseLeave(object sender, EventArgs e)
        {
            drawStars(calification);
        }

        private void pbStar2_MouseHover(object sender, EventArgs e)
        {
            drawStars(2);
        }

        private void pbStar2_MouseLeave(object sender, EventArgs e)
        {
            drawStars(calification);
        }

        private void pbStar3_MouseHover(object sender, EventArgs e)
        {
            drawStars(3);
        }

        private void pbStar3_MouseLeave(object sender, EventArgs e)
        {
            drawStars(calification);
        }

        private void pbStar4_MouseHover(object sender, EventArgs e)
        {
            drawStars(4);
        }

        private void pbStar4_MouseLeave(object sender, EventArgs e)
        {
            drawStars(calification);
        }

        private void pbStar5_MouseHover(object sender, EventArgs e)
        {
            drawStars(5);
        }

        private void pbStar5_MouseLeave(object sender, EventArgs e)
        {
            drawStars(calification);
        }

        private void pbStar1_Click(object sender, EventArgs e)
        {
            calification = 1;
        }

        private void pbStar2_Click(object sender, EventArgs e)
        {
            calification = 2;
        }

        private void pbStar3_Click(object sender, EventArgs e)
        {
            calification = 3;
        }

        private void pbStar4_Click(object sender, EventArgs e)
        {
            calification = 4;
        }

        private void pbStar5_Click(object sender, EventArgs e)
        {
            calification = 5;
        }

        private void FrmCalificarVendedor_Load(object sender, EventArgs e)
        {
            ClearFiltersAndTable();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }

        private void LblBuscar_Click(object sender, EventArgs e)
        {

        }


        private void ClearFiltersAndTable()
        {
            txtCodigo.Text = "";
            txtDesc.Text = "";
            txtPrecio.Text = "";
            RefreshSources(null);
        }

        private void LblLimpiar_Click(object sender, EventArgs e)
        {
            ClearFiltersAndTable();
        }

        private void LblBuscar_Click_1(object sender, EventArgs e)
        {
            try
            {
                #region Validations

                var filtersSetted = false;
                var exceptionMessage = string.Empty;

                if (!TypesHelper.IsEmpty(txtCodigo.Text))
                {
                    filtersSetted = true;
                    if (!TypesHelper.IsNumeric(txtCodigo.Text))
                        exceptionMessage += Environment.NewLine + "El código debe ser numérico.";
                }
                if (!TypesHelper.IsEmpty(txtDesc.Text))
                {
                    filtersSetted = true;
                }

                if (!TypesHelper.IsEmpty(txtPrecio.Text))
                {
                    filtersSetted = true;
                    if (!TypesHelper.IsDecimal(txtPrecio.Text))
                        exceptionMessage += Environment.NewLine + "El precio de la publicacion ser decimal (o numérico).";
                }


                if (!filtersSetted)
                    exceptionMessage = "No se puede realizar la busqueda ya que no se informó ningún filtro";

                if (!TypesHelper.IsEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);

                #endregion

                var filters = new PublicacionNotCalifiedFilters
                {
                    Codigo = (!TypesHelper.IsEmpty(txtCodigo.Text)) ? Convert.ToInt32(txtCodigo.Text) : (int?) null,
                    Descripcion = (!TypesHelper.IsEmpty(txtDesc.Text)) ? txtDesc.Text : null,
                    Precio = (!TypesHelper.IsEmpty(txtPrecio.Text)) ? Convert.ToDouble(txtPrecio.Text) : (double?)null,
                    };

                var pubNotCalified = (cBExact.Checked) ? CalificacionPersistance.GetAllPubicacionNotCalifiedByParameters(filters, SessionManager.CurrentUser) : CalificacionPersistance.GetAllPubicacionNotCalifiedByParametersLike(filters, SessionManager.CurrentUser);

                if (pubNotCalified == null || pubNotCalified.Count == 0)
                    throw new Exception("No se encontraron publicaciones no calificadas según los filtros informados.");

                RefreshSources(pubNotCalified);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
                ClearFiltersAndTable();
            }
        }

        private void lblCalificar_Click(object sender, EventArgs e)
        {
            bool validations = true;

            if (calification == 0)
                validations = false;

            if (txtDescripcion.Text == "")
                validations = false;

            if (publicationSelected == 0)
                validations = false;

            if (validations)
            { 
                Calificacion califObject = new Calificacion();
                califObject.ID_Comprador = ((Usuario)SessionManager.CurrentUser).ID;
                califObject.ID_Publicacion = publicationSelected;
                califObject.stars = calification;
                califObject.description = txtDescripcion.Text;
                if (califObject.ID_Publicacion != 0)
                {
                    int califId = CalificacionPersistance.InsertCalification(califObject);
                    if (califId != 0)
                    {
                        ClearFiltersAndTable();
                        publicationSelected = 0;
                        txtDescripcion.Text = "";
                        calification = 0;
                        drawStars(0);

                        MessageBox.Show("La publicación " + califObject.ID_Publicacion + " fué calificada con " + califObject.stars + " estrellas. Descripción: " + califObject.description, "Éxito");
                    }
                }
            }
            else
                MessageBox.Show("Por favor, verifique Calificacion, Descripción y Publicacion seleccionada.", "Atencion");
        }

        private void LblListo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvPublicaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //var publicationSelectedObject = _publicationsNotCalified.Find(publication => publication.ID == (int)dgvPublicaciones.Rows[e.RowIndex].Cells[0].Value);
            //publicationSelected = publicationSelectedObject.ID;
        }

        private void dgvPublicaciones_SelectionChanged(object sender, EventArgs e)
        {
            var publicationSelectedObject = _publicationsNotCalified.Find(publication => publication.ID == (int)dgvPublicaciones.Rows[dgvPublicaciones.CurrentCell.RowIndex].Cells[0].Value);
            publicationSelected = publicationSelectedObject.ID;
        }
    }
}
