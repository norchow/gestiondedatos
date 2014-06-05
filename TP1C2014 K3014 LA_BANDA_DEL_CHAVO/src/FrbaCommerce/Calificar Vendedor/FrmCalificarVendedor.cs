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

namespace FrbaCommerce.Calificar_Vendedor
{
    public partial class FrmCalificarVendedor : Form
    {
        private int calification;
        private List<PublicacionNotCalified> _publicacionNotCalified = new List<PublicacionNotCalified>();
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

        private void RefreshSources(List<PublicacionNotCalified> publicacionNotCalified)        
        {
            ClearDataGridView();
             var publicationNotCalifiedDictionary = new Dictionary<int, PublicacionNotCalified>();


             if (publicacionNotCalified == null)
            {
                //The datasource must be all the visibilities records stored in the database
                Usuario myUser = SessionManager.CurrentUser;
                _publicacionNotCalified =  CalificacionesPersistance.GetAllPubicacionNotCalified(myUser);
                publicationNotCalifiedDictionary = _publicacionNotCalified.ToDictionary(a => a.ID, a => a); ;
            }
            else
            {
                //The datasource must be the list of visibilities received as parameter
                publicationNotCalifiedDictionary = publicacionNotCalified.ToDictionary(a => a.ID, a => a);
            }


            var bind = publicationNotCalifiedDictionary.Values.Select(a => new
            {
                Codigo = a.ID,
                Descripcion = a.Descripcion,
                Precio = a.Precio,
                Vendedor = a.NombreVendedor
            });
            dgvPublicaciones.DataSource = bind.ToList();
            ShowStars();
        }

        private void ShowStars()
        {
            pbStar1.Visible = true;
            pbStar2.Visible = true;
            pbStar3.Visible = true;
            pbStar4.Visible = true;
            pbStar5.Visible = true;
            btnSend.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshSources(null);
        }

        private Image getYellowStar()
        {
            return FrbaCommerce.Properties.Resources.YellowStar;
        }

        private Image getWhiteStar()
        {
            return FrbaCommerce.Properties.Resources.WhiteStar;
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

                if (calification > 0)
                {
                    btnSend.Enabled = true;
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
    }
}
