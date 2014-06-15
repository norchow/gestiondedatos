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
using Session;
using FrbaCommerce.Login;

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

        private void listadoDePublicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmListadoPublicaciones = new FrmListadoPublicaciones();
            frmListadoPublicaciones.ShowDialog();
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
    }
}
