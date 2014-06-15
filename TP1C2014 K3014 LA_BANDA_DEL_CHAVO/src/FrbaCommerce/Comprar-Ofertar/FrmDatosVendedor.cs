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

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class FrmDatosVendedor : Form
    {
        public FrmDatosVendedor()
        {
            InitializeComponent();
        }

        public FrmDatosVendedor(Usuario user)
        {
            InitializeComponent();
            try
            {
                Cliente userCliente = ClientePersistance.GetByUserId(user.ID);
                if (userCliente != null)
                {
                    lblNombre.Text = userCliente.Nombre + " " + userCliente.Apellido;
                    lblMail.Text = userCliente.Mail;
                    lblDireccion.Text = userCliente.Direccion;
                    lblCodigoPostal.Text = userCliente.CodigoPostal;
                    lblTelefono.Text = userCliente.Telefono;
                }
                else
                {
                    Empresa userEmpresa = EmpresaPersistance.GetByUserId(user.ID);
                    if (userEmpresa != null)
                    {
                        lblNombre.Text = userEmpresa.NombreContacto;
                        lblMail.Text = userEmpresa.Mail;
                        lblDireccion.Text = userEmpresa.Direccion;
                        lblCodigoPostal.Text = userEmpresa.CodigoPostal;
                        lblTelefono.Text = userEmpresa.Telefono;
                    }
                    else
                        throw new Exception("No se pudo encontrar al vendedor");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void LblListo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmDatosVendedor_Load(object sender, EventArgs e)
        {

        }
    }
}
