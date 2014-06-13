namespace FrbaCommerce.Home
{
    partial class FrmHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MsHome = new System.Windows.Forms.MenuStrip();
            this.holaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administracionDeRolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administracionDeVisibilidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administracionDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.juliaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calificarVendedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarPublicacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarMisPublicacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDePublicacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadisticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.responderPreguntasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MsHome.SuspendLayout();
            this.SuspendLayout();
            // 
            // MsHome
            // 
            this.MsHome.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.holaToolStripMenuItem,
            this.juliaToolStripMenuItem,
            this.estadisticasToolStripMenuItem});
            this.MsHome.Location = new System.Drawing.Point(0, 0);
            this.MsHome.Name = "MsHome";
            this.MsHome.Size = new System.Drawing.Size(671, 24);
            this.MsHome.TabIndex = 1;
            this.MsHome.Text = "MsHome";
            // 
            // holaToolStripMenuItem
            // 
            this.holaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administracionDeRolesToolStripMenuItem,
            this.administracionDeVisibilidadesToolStripMenuItem,
            this.administracionDeUsuariosToolStripMenuItem});
            this.holaToolStripMenuItem.Name = "holaToolStripMenuItem";
            this.holaToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.holaToolStripMenuItem.Text = "Administracion";
            // 
            // administracionDeRolesToolStripMenuItem
            // 
            this.administracionDeRolesToolStripMenuItem.Name = "administracionDeRolesToolStripMenuItem";
            this.administracionDeRolesToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.administracionDeRolesToolStripMenuItem.Text = "Administracion de roles";
            this.administracionDeRolesToolStripMenuItem.Click += new System.EventHandler(this.administracionDeRolesToolStripMenuItem_Click);
            // 
            // administracionDeVisibilidadesToolStripMenuItem
            // 
            this.administracionDeVisibilidadesToolStripMenuItem.Name = "administracionDeVisibilidadesToolStripMenuItem";
            this.administracionDeVisibilidadesToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.administracionDeVisibilidadesToolStripMenuItem.Text = "Administracion de visibilidades";
            this.administracionDeVisibilidadesToolStripMenuItem.Click += new System.EventHandler(this.administracionDeVisibilidadesToolStripMenuItem_Click);
            // 
            // administracionDeUsuariosToolStripMenuItem
            // 
            this.administracionDeUsuariosToolStripMenuItem.Name = "administracionDeUsuariosToolStripMenuItem";
            this.administracionDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.administracionDeUsuariosToolStripMenuItem.Text = "Administracion de usuarios";
            this.administracionDeUsuariosToolStripMenuItem.Click += new System.EventHandler(this.administracionDeUsuariosToolStripMenuItem_Click);
            // 
            // juliaToolStripMenuItem
            // 
            this.juliaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calificarVendedorToolStripMenuItem,
            this.generarPublicacionesToolStripMenuItem,
            this.editarMisPublicacionesToolStripMenuItem,
            this.listadoDePublicacionesToolStripMenuItem,
            this.responderPreguntasToolStripMenuItem});
            this.juliaToolStripMenuItem.Name = "juliaToolStripMenuItem";
            this.juliaToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.juliaToolStripMenuItem.Text = "Publicaciones";
            this.juliaToolStripMenuItem.Click += new System.EventHandler(this.juliaToolStripMenuItem_Click);
            // 
            // calificarVendedorToolStripMenuItem
            // 
            this.calificarVendedorToolStripMenuItem.Name = "calificarVendedorToolStripMenuItem";
            this.calificarVendedorToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.calificarVendedorToolStripMenuItem.Text = "Calificar Vendedor";
            this.calificarVendedorToolStripMenuItem.Click += new System.EventHandler(this.calificarVendedorToolStripMenuItem_Click);
            // 
            // generarPublicacionesToolStripMenuItem
            // 
            this.generarPublicacionesToolStripMenuItem.Name = "generarPublicacionesToolStripMenuItem";
            this.generarPublicacionesToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.generarPublicacionesToolStripMenuItem.Text = "Generar Publicaciones";
            this.generarPublicacionesToolStripMenuItem.Click += new System.EventHandler(this.generarPublicacionesToolStripMenuItem_Click);
            // 
            // editarMisPublicacionesToolStripMenuItem
            // 
            this.editarMisPublicacionesToolStripMenuItem.Name = "editarMisPublicacionesToolStripMenuItem";
            this.editarMisPublicacionesToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.editarMisPublicacionesToolStripMenuItem.Text = "Editar mis publicaciones";
            this.editarMisPublicacionesToolStripMenuItem.Click += new System.EventHandler(this.editarMisPublicacionesToolStripMenuItem_Click);
            // 
            // listadoDePublicacionesToolStripMenuItem
            // 
            this.listadoDePublicacionesToolStripMenuItem.Name = "listadoDePublicacionesToolStripMenuItem";
            this.listadoDePublicacionesToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.listadoDePublicacionesToolStripMenuItem.Text = "Listado de publicaciones";
            this.listadoDePublicacionesToolStripMenuItem.Click += new System.EventHandler(this.listadoDePublicacionesToolStripMenuItem_Click);
            // 
            // estadisticasToolStripMenuItem
            // 
            this.estadisticasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historialClienteToolStripMenuItem});
            this.estadisticasToolStripMenuItem.Name = "estadisticasToolStripMenuItem";
            this.estadisticasToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.estadisticasToolStripMenuItem.Text = "Estadisticas";
            // 
            // historialClienteToolStripMenuItem
            // 
            this.historialClienteToolStripMenuItem.Name = "historialClienteToolStripMenuItem";
            this.historialClienteToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.historialClienteToolStripMenuItem.Text = "Historial Cliente";
            this.historialClienteToolStripMenuItem.Click += new System.EventHandler(this.historialClienteToolStripMenuItem_Click);
            // 
            // responderPreguntasToolStripMenuItem
            // 
            this.responderPreguntasToolStripMenuItem.Name = "responderPreguntasToolStripMenuItem";
            this.responderPreguntasToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.responderPreguntasToolStripMenuItem.Text = "Responder preguntas";
            this.responderPreguntasToolStripMenuItem.Click += new System.EventHandler(this.responderPreguntasToolStripMenuItem_Click);
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 389);
            this.Controls.Add(this.MsHome);
            this.MainMenuStrip = this.MsHome;
            this.Name = "FrmHome";
            this.Text = "FrbaCommerce - Home";
            this.MsHome.ResumeLayout(false);
            this.MsHome.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MsHome;
        private System.Windows.Forms.ToolStripMenuItem holaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administracionDeRolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administracionDeVisibilidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem juliaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calificarVendedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administracionDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarPublicacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarMisPublicacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoDePublicacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadisticasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem responderPreguntasToolStripMenuItem;


    }
}