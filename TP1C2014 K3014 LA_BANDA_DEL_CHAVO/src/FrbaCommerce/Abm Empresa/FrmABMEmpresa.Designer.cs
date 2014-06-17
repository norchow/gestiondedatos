namespace FrbaCommerce.Abm_Empresa
{
    partial class FrmABMEmpresa
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
            this.ChkBusquedaExacta = new System.Windows.Forms.CheckBox();
            this.LblLimpiar = new System.Windows.Forms.Label();
            this.LblBuscar = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtCuit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtRazonSocial = new System.Windows.Forms.TextBox();
            this.DgvEmpresas = new System.Windows.Forms.DataGridView();
            this.LblListo = new System.Windows.Forms.Label();
            this.LblNuevo = new System.Windows.Forms.Label();
            this.GroupFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEmpresas)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupFiltros
            // 
            this.GroupFiltros.Controls.Add(this.ChkBusquedaExacta);
            this.GroupFiltros.Controls.Add(this.LblLimpiar);
            this.GroupFiltros.Controls.Add(this.LblBuscar);
            this.GroupFiltros.Controls.Add(this.label4);
            this.GroupFiltros.Controls.Add(this.TxtEmail);
            this.GroupFiltros.Controls.Add(this.label2);
            this.GroupFiltros.Controls.Add(this.TxtCuit);
            this.GroupFiltros.Controls.Add(this.label1);
            this.GroupFiltros.Controls.Add(this.TxtRazonSocial);
            this.GroupFiltros.Location = new System.Drawing.Point(25, 12);
            this.GroupFiltros.Name = "GroupFiltros";
            this.GroupFiltros.Size = new System.Drawing.Size(888, 89);
            this.GroupFiltros.TabIndex = 35;
            this.GroupFiltros.TabStop = false;
            this.GroupFiltros.Text = "FILTROS DE BUSQUEDA";
            // 
            // ChkBusquedaExacta
            // 
            this.ChkBusquedaExacta.AutoSize = true;
            this.ChkBusquedaExacta.Location = new System.Drawing.Point(564, 59);
            this.ChkBusquedaExacta.Name = "ChkBusquedaExacta";
            this.ChkBusquedaExacta.Size = new System.Drawing.Size(131, 17);
            this.ChkBusquedaExacta.TabIndex = 36;
            this.ChkBusquedaExacta.Text = "BUSQUEDA EXACTA";
            this.ChkBusquedaExacta.UseVisualStyleBackColor = true;
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
            // LblBuscar
            // 
            this.LblBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblBuscar.ForeColor = System.Drawing.Color.White;
            this.LblBuscar.Location = new System.Drawing.Point(752, 11);
            this.LblBuscar.Name = "LblBuscar";
            this.LblBuscar.Size = new System.Drawing.Size(124, 32);
            this.LblBuscar.TabIndex = 34;
            this.LblBuscar.Text = "BUSCAR";
            this.LblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblBuscar.Click += new System.EventHandler(this.LblBuscar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(519, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "EMAIL";
            // 
            // TxtEmail
            // 
            this.TxtEmail.Location = new System.Drawing.Point(564, 23);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(175, 20);
            this.TxtEmail.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "CUIT";
            // 
            // TxtCuit
            // 
            this.TxtCuit.Location = new System.Drawing.Point(311, 23);
            this.TxtCuit.Name = "TxtCuit";
            this.TxtCuit.Size = new System.Drawing.Size(187, 20);
            this.TxtCuit.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "RAZON SOCIAL";
            // 
            // TxtRazonSocial
            // 
            this.TxtRazonSocial.Location = new System.Drawing.Point(100, 23);
            this.TxtRazonSocial.Name = "TxtRazonSocial";
            this.TxtRazonSocial.Size = new System.Drawing.Size(167, 20);
            this.TxtRazonSocial.TabIndex = 0;
            // 
            // DgvEmpresas
            // 
            this.DgvEmpresas.AllowUserToAddRows = false;
            this.DgvEmpresas.AllowUserToDeleteRows = false;
            this.DgvEmpresas.AllowUserToResizeColumns = false;
            this.DgvEmpresas.AllowUserToResizeRows = false;
            this.DgvEmpresas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DgvEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvEmpresas.Location = new System.Drawing.Point(25, 107);
            this.DgvEmpresas.MultiSelect = false;
            this.DgvEmpresas.Name = "DgvEmpresas";
            this.DgvEmpresas.RowHeadersVisible = false;
            this.DgvEmpresas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvEmpresas.Size = new System.Drawing.Size(888, 336);
            this.DgvEmpresas.TabIndex = 34;
            this.DgvEmpresas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvEmpresas_CellContentClick);
            // 
            // LblListo
            // 
            this.LblListo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblListo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblListo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblListo.ForeColor = System.Drawing.Color.White;
            this.LblListo.Location = new System.Drawing.Point(25, 456);
            this.LblListo.Name = "LblListo";
            this.LblListo.Size = new System.Drawing.Size(88, 32);
            this.LblListo.TabIndex = 38;
            this.LblListo.Text = "LISTO";
            this.LblListo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblListo.Click += new System.EventHandler(this.LblListo_Click);
            // 
            // LblNuevo
            // 
            this.LblNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblNuevo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblNuevo.ForeColor = System.Drawing.Color.White;
            this.LblNuevo.Location = new System.Drawing.Point(781, 456);
            this.LblNuevo.Name = "LblNuevo";
            this.LblNuevo.Size = new System.Drawing.Size(132, 32);
            this.LblNuevo.TabIndex = 37;
            this.LblNuevo.Text = "NUEVA EMPRESA";
            this.LblNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblNuevo.Click += new System.EventHandler(this.LblNuevo_Click);
            // 
            // FrmABMEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 498);
            this.Controls.Add(this.LblListo);
            this.Controls.Add(this.GroupFiltros);
            this.Controls.Add(this.LblNuevo);
            this.Controls.Add(this.DgvEmpresas);
            this.Name = "FrmABMEmpresa";
            this.Text = "ADMINISTRACIÓN DE EMPRESAS";
            this.Load += new System.EventHandler(this.FrmABMEmpresa_Load);
            this.GroupFiltros.ResumeLayout(false);
            this.GroupFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEmpresas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupFiltros;
        private System.Windows.Forms.CheckBox ChkBusquedaExacta;
        private System.Windows.Forms.Label LblLimpiar;
        private System.Windows.Forms.Label LblBuscar;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtCuit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtRazonSocial;
        private System.Windows.Forms.DataGridView DgvEmpresas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblListo;
        private System.Windows.Forms.Label LblNuevo;
    }
}