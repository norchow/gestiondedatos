using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Calificar_Vendedor;
using FrbaCommerce.ABM_Rol;
using FrbaCommerce.Abm_Visibilidad;
using FrbaCommerce.Registro_de_Usuario;
using FrbaCommerce.Generar_Publicacion;
using FrbaCommerce.Editar_Publicacion;
using FrbaCommerce.Comprar_Ofertar;
using FrbaCommerce.Historial_Cliente;
using FrbaCommerce.Gestion_de_Preguntas;
using FrbaCommerce.Abm_Empresa;
using FrbaCommerce.Login;
using Session;
using FrbaCommerce.Facturar_Publicaciones;
using Persistance.Entities;
using FrbaCommerce.Abm_Cliente;
using FrbaCommerce.Facturar_Publicaciones;
namespace FrbaCommerce.Home
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void administracionDeRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmABMRol = new FrmABMRol();
            frmABMRol.ShowDialog();
        }

        private void administracionDeVisibilidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmABMVisibilidades = new FrmABMVisibilidad();
            frmABMVisibilidades.ShowDialog();
        }

        private void calificarVendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmCalificarVendedor = new FrmCalificarVendedor();
            frmCalificarVendedor.ShowDialog();
        }

        private void administracionDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmAdministrarUsuarios = new FrmAdministrarUsuarios();
            frmAdministrarUsuarios.ShowDialog();
        }

        private void juliaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void generarPublicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmGenerarPublicacion = new FrmGenerarPublicacion(null);
            frmGenerarPublicacion.ShowDialog();
        }

        private void editarMisPublicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmMisPublicaciones = new FrmMisPublicaciones();
            frmMisPublicaciones.ShowDialog();
        }

        private void historialClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmHistorialCliemte = new FrmHistorialCliente();
            frmHistorialCliemte.ShowDialog();
        }

        private void responderPreguntasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmResponderPreguntas = new FrmResponderPreguntas();
            frmResponderPreguntas.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogOutCurrentUser();
        }

        private void LogOutCurrentUser()
        {
            SessionManager.ClearCurrentSession();
            Hide();

            FrmLogin formLogin = new FrmLogin();
            formLogin.ShowDialog();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            SetMenuVisibilityByCurrentRole();
        }

        private void SetMenuVisibilityByCurrentRole()
        {
            var administracion = false;
            var publicaciones = false;
            var estadistico = false;

            foreach (var functionality in SessionManager.CurrentRol.Funcionalidades)
            {
                switch (Funcionalidad.GetByName(functionality.Descripcion))
                {
                    case Funcionalidades.ABM_Rol:
                        administracionDeRolesToolStripMenuItem.Visible = true;
                        administracion = true;
                        break;

                    case Funcionalidades.ABM_Cliente:
                        administracionDeClientesToolStripMenuItem.Visible = true;
                        administracion = true;
                        break;

                    case Funcionalidades.ABM_Empresa:
                        administracionDeEmpresasToolStripMenuItem.Visible = true;
                        administracion = true;
                        break;

                    case Funcionalidades.ABM_Usuario:
                        administracionDeUsuariosToolStripMenuItem.Visible = true;
                        administracion = true;
                        break;

                    case Funcionalidades.ABM_Visibilidad:
                        administracionDeVisibilidadesToolStripMenuItem.Visible = true;
                        administracion = true;
                        break;

                    case Funcionalidades.Generar_Publicacion:
                        generarPublicacionesToolStripMenuItem.Visible = true;
                        publicaciones = true;
                        break;

                    case Funcionalidades.Editar_Publicacion:
                        editarMisPublicacionesToolStripMenuItem.Visible = true;
                        publicaciones = true;
                        break;

                    case Funcionalidades.Gestion_Preguntas:
                        responderPreguntasToolStripMenuItem.Visible = true;
                        publicaciones = true;
                        break;

                    case Funcionalidades.Comprar_Ofertar:
                        comprarOfertarToolStripMenuItem.Visible = true;
                        publicaciones = true;
                        break;

                    case Funcionalidades.Historial_Cliente:
                        historialClienteToolStripMenuItem.Visible = true;
                        estadistico = true;
                        break;

                    case Funcionalidades.Calificar_Vendedor:
                        calificarVendedorToolStripMenuItem.Visible = true;
                        publicaciones = true;
                        break;

                    case Funcionalidades.Facturar_Publicaciones:
                        facturarPublicacionesToolStripMenuItem.Visible = true;
                        publicaciones = true;
                        break;

                    case Funcionalidades.Listado_Estadistico:
                        listadoEstadisticoToolStripMenuItem.Visible = true;
                        estadistico = true;
                        break;
                }
            }

            if (!administracion)
                MsHome.Items.Remove(administracionToolStripMenuItem);

            if (!publicaciones)
                MsHome.Items.Remove(publicacionesToolStripMenuItem);

            if (!estadistico)
                MsHome.Items.Remove(estadisticasToolStripMenuItem);
        }

        private void comprarOfertarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmListadoPublicaciones = new FrmListadoPublicaciones();
            frmListadoPublicaciones.ShowDialog();
        }

        private void facturarPublicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmFacturarPublicaciones = new FrmFacturarPublicaciones();
            frmFacturarPublicaciones.ShowDialog();
        }

        private void administracionDeEmpresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmABMEmpresa = new FrmABMEmpresa();
            frmABMEmpresa.ShowDialog();
        }

        private void administracionDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmABMCliente = new FrmABMCliente();
            frmABMCliente.ShowDialog();
        }
    }
}
