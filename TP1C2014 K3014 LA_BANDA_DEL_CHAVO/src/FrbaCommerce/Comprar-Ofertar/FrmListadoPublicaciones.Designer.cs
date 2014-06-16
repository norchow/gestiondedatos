namespace FrbaCommerce.Comprar_Ofertar
{
    partial class FrmListadoPublicaciones
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
            this.DgvPublicacion = new System.Windows.Forms.DataGridView();
            this.LblListo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LstRubro = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ChkBusquedaExacta = new System.Windows.Forms.CheckBox();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.LblLimpiar = new System.Windows.Forms.Label();
            this.LblBuscar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPublicacion)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvPublicacion
            // 
            this.DgvPublicacion.AllowUserToAddRows = false;
            this.DgvPublicacion.AllowUserToDeleteRows = false;
            this.DgvPublicacion.AllowUserToResizeColumns = false;
            this.DgvPublicacion.AllowUserToResizeRows = false;
            this.DgvPublicacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DgvPublicacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPublicacion.Location = new System.Drawing.Point(12, 132);
            this.DgvPublicacion.MultiSelect = false;
            this.DgvPublicacion.Name = "DgvPublicacion";
            this.DgvPublicacion.RowHeadersVisible = false;
            this.DgvPublicacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPublicacion.Size = new System.Drawing.Size(868, 290);
            this.DgvPublicacion.TabIndex = 34;
            this.DgvPublicacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPublicacion_CellContentClick);
            // 
            // LblListo
            // 
            this.LblListo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblListo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblListo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblListo.ForeColor = System.Drawing.Color.White;
            this.LblListo.Location = new System.Drawing.Point(405, 440);
            this.LblListo.Name = "LblListo";
            this.LblListo.Size = new System.Drawing.Size(88, 32);
            this.LblListo.TabIndex = 36;
            this.LblListo.Text = "LISTO";
            this.LblListo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblListo.Click += new System.EventHandler(this.LblListo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LstRubro);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ChkBusquedaExacta);
            this.groupBox1.Controls.Add(this.TxtDescripcion);
            this.groupBox1.Controls.Add(this.LblLimpiar);
            this.groupBox1.Controls.Add(this.LblBuscar);
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(868, 87);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTROS DE BUSQUEDA";
            // 
            // LstRubro
            // 
            this.LstRubro.FormattingEnabled = true;
            this.LstRubro.Location = new System.Drawing.Point(309, 14);
            this.LstRubro.Name = "LstRubro";
            this.LstRubro.Size = new System.Drawing.Size(261, 64);
            this.LstRubro.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "DESCRIPCION";
            // 
            // ChkBusquedaExacta
            // 
            this.ChkBusquedaExacta.AutoSize = true;
            this.ChkBusquedaExacta.Location = new System.Drawing.Point(663, 21);
            this.ChkBusquedaExacta.Name = "ChkBusquedaExacta";
            this.ChkBusquedaExacta.Size = new System.Drawing.Size(131, 17);
            this.ChkBusquedaExacta.TabIndex = 43;
            this.ChkBusquedaExacta.Text = "BUSQUEDA EXACTA";
            this.ChkBusquedaExacta.UseVisualStyleBackColor = true;
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Location = new System.Drawing.Point(107, 24);
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(118, 20);
            this.TxtDescripcion.TabIndex = 40;
            // 
            // LblLimpiar
            // 
            this.LblLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblLimpiar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblLimpiar.ForeColor = System.Drawing.Color.White;
            this.LblLimpiar.Location = new System.Drawing.Point(767, 40);
            this.LblLimpiar.Name = "LblLimpiar";
            this.LblLimpiar.Size = new System.Drawing.Size(88, 32);
            this.LblLimpiar.TabIndex = 42;
            this.LblLimpiar.Text = "LIMPIAR";
            this.LblLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblBuscar
            // 
            this.LblBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblBuscar.ForeColor = System.Drawing.Color.White;
            this.LblBuscar.Location = new System.Drawing.Point(663, 40);
            this.LblBuscar.Name = "LblBuscar";
            this.LblBuscar.Size = new System.Drawing.Size(88, 32);
            this.LblBuscar.TabIndex = 41;
            this.LblBuscar.Text = "BUSCAR";
            this.LblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmListadoPublicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 494);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LblListo);
            this.Controls.Add(this.DgvPublicacion);
            this.Name = "FrmListadoPublicaciones";
            this.Text = "FrbaCommerce - Publicaciones";
            this.Load += new System.EventHandler(this.FrmListadoPublicaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPublicacion)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvPublicacion;
        private System.Windows.Forms.Label LblListo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ChkBusquedaExacta;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Label LblLimpiar;
        private System.Windows.Forms.Label LblBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox LstRubro;
    }
}