namespace FrbaCommerce.Listado_Estadistico
{
    partial class FrmListadoEstadistico
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
            this.GroupFiltros = new System.Windows.Forms.GroupBox();
            this.CboVisibilidad = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CboListado = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CboTrimestre = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CboAño = new System.Windows.Forms.ComboBox();
            this.LblLimpiar = new System.Windows.Forms.Label();
            this.LblFiltrar = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DgvListado = new System.Windows.Forms.DataGridView();
            this.LblCerrar = new System.Windows.Forms.Label();
            this.GroupFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupFiltros
            // 
            this.GroupFiltros.Controls.Add(this.CboVisibilidad);
            this.GroupFiltros.Controls.Add(this.label3);
            this.GroupFiltros.Controls.Add(this.CboListado);
            this.GroupFiltros.Controls.Add(this.label4);
            this.GroupFiltros.Controls.Add(this.CboTrimestre);
            this.GroupFiltros.Controls.Add(this.label1);
            this.GroupFiltros.Controls.Add(this.CboAño);
            this.GroupFiltros.Controls.Add(this.LblLimpiar);
            this.GroupFiltros.Controls.Add(this.LblFiltrar);
            this.GroupFiltros.Controls.Add(this.label2);
            this.GroupFiltros.Location = new System.Drawing.Point(21, 9);
            this.GroupFiltros.Name = "GroupFiltros";
            this.GroupFiltros.Size = new System.Drawing.Size(888, 89);
            this.GroupFiltros.TabIndex = 44;
            this.GroupFiltros.TabStop = false;
            this.GroupFiltros.Text = "FILTROS DE ESTADÍSTICAS";
            // 
            // CboVisibilidad
            // 
            this.CboVisibilidad.FormattingEnabled = true;
            this.CboVisibilidad.Location = new System.Drawing.Point(406, 57);
            this.CboVisibilidad.Name = "CboVisibilidad";
            this.CboVisibilidad.Size = new System.Drawing.Size(300, 21);
            this.CboVisibilidad.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(331, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "VISIBILIDAD";
            // 
            // CboListado
            // 
            this.CboListado.FormattingEnabled = true;
            this.CboListado.Location = new System.Drawing.Point(406, 30);
            this.CboListado.Name = "CboListado";
            this.CboListado.Size = new System.Drawing.Size(300, 21);
            this.CboListado.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(301, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "TIPO DE LISTADO";
            // 
            // CboTrimestre
            // 
            this.CboTrimestre.FormattingEnabled = true;
            this.CboTrimestre.Location = new System.Drawing.Point(114, 57);
            this.CboTrimestre.Name = "CboTrimestre";
            this.CboTrimestre.Size = new System.Drawing.Size(169, 21);
            this.CboTrimestre.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "TRIMESTRE";
            // 
            // CboAño
            // 
            this.CboAño.FormattingEnabled = true;
            this.CboAño.Location = new System.Drawing.Point(114, 30);
            this.CboAño.Name = "CboAño";
            this.CboAño.Size = new System.Drawing.Size(169, 21);
            this.CboAño.TabIndex = 41;
            // 
            // LblLimpiar
            // 
            this.LblLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblLimpiar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblLimpiar.ForeColor = System.Drawing.Color.White;
            this.LblLimpiar.Location = new System.Drawing.Point(752, 50);
            this.LblLimpiar.Name = "LblLimpiar";
            this.LblLimpiar.Size = new System.Drawing.Size(124, 32);
            this.LblLimpiar.TabIndex = 35;
            this.LblLimpiar.Text = "LIMPIAR/REFRESCAR";
            this.LblLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblLimpiar.Click += new System.EventHandler(this.LblLimpiar_Click);
            // 
            // LblFiltrar
            // 
            this.LblFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblFiltrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblFiltrar.ForeColor = System.Drawing.Color.White;
            this.LblFiltrar.Location = new System.Drawing.Point(752, 11);
            this.LblFiltrar.Name = "LblFiltrar";
            this.LblFiltrar.Size = new System.Drawing.Size(124, 32);
            this.LblFiltrar.TabIndex = 34;
            this.LblFiltrar.Text = "OBTENER ESTADÍSTICA";
            this.LblFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblFiltrar.Click += new System.EventHandler(this.LblFiltrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "AÑO";
            // 
            // DgvListado
            // 
            this.DgvListado.AllowUserToAddRows = false;
            this.DgvListado.AllowUserToDeleteRows = false;
            this.DgvListado.AllowUserToResizeColumns = false;
            this.DgvListado.AllowUserToResizeRows = false;
            this.DgvListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListado.Location = new System.Drawing.Point(21, 112);
            this.DgvListado.MultiSelect = false;
            this.DgvListado.Name = "DgvListado";
            this.DgvListado.RowHeadersVisible = false;
            this.DgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvListado.Size = new System.Drawing.Size(888, 219);
            this.DgvListado.TabIndex = 43;
            // 
            // LblCerrar
            // 
            this.LblCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblCerrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblCerrar.ForeColor = System.Drawing.Color.White;
            this.LblCerrar.Location = new System.Drawing.Point(21, 348);
            this.LblCerrar.Name = "LblCerrar";
            this.LblCerrar.Size = new System.Drawing.Size(88, 32);
            this.LblCerrar.TabIndex = 46;
            this.LblCerrar.Text = "CERRAR";
            this.LblCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblCerrar.Click += new System.EventHandler(this.LblCerrar_Click);
            // 
            // FrmListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 400);
            this.Controls.Add(this.LblCerrar);
            this.Controls.Add(this.GroupFiltros);
            this.Controls.Add(this.DgvListado);
            this.Name = "FrmListadoEstadistico";
            this.Text = "FrbaCommerce - Listado Estadístico";
            this.Load += new System.EventHandler(this.FrmListadoEstadistico_Load);
            this.GroupFiltros.ResumeLayout(false);
            this.GroupFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupFiltros;
        private System.Windows.Forms.ComboBox CboAño;
        private System.Windows.Forms.Label LblLimpiar;
        private System.Windows.Forms.Label LblFiltrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DgvListado;
        private System.Windows.Forms.ComboBox CboVisibilidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CboListado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CboTrimestre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblCerrar;
    }
}