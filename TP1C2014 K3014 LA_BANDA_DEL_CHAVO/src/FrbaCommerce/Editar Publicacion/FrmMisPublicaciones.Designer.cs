namespace FrbaCommerce.Editar_Publicacion
{
    partial class FrmMisPublicaciones
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CboEstadoPublicacion = new System.Windows.Forms.ComboBox();
            this.CboVisibilidad = new System.Windows.Forms.ComboBox();
            this.CboTipoPublicacion = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtPrecio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtStock = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ChkBusquedaExacta = new System.Windows.Forms.CheckBox();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.LblLimpiar = new System.Windows.Forms.Label();
            this.LblBuscar = new System.Windows.Forms.Label();
            this.LblListo = new System.Windows.Forms.Label();
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
            this.DgvPublicacion.Location = new System.Drawing.Point(12, 118);
            this.DgvPublicacion.MultiSelect = false;
            this.DgvPublicacion.Name = "DgvPublicacion";
            this.DgvPublicacion.RowHeadersVisible = false;
            this.DgvPublicacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPublicacion.Size = new System.Drawing.Size(953, 323);
            this.DgvPublicacion.TabIndex = 33;
            this.DgvPublicacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPublicacion_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CboEstadoPublicacion);
            this.groupBox1.Controls.Add(this.CboVisibilidad);
            this.groupBox1.Controls.Add(this.CboTipoPublicacion);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtPrecio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtStock);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ChkBusquedaExacta);
            this.groupBox1.Controls.Add(this.TxtDescripcion);
            this.groupBox1.Controls.Add(this.LblLimpiar);
            this.groupBox1.Controls.Add(this.LblBuscar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(953, 87);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTROS DE BUSQUEDA";
            // 
            // CboEstadoPublicacion
            // 
            this.CboEstadoPublicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboEstadoPublicacion.Enabled = false;
            this.CboEstadoPublicacion.FormattingEnabled = true;
            this.CboEstadoPublicacion.Location = new System.Drawing.Point(601, 23);
            this.CboEstadoPublicacion.Name = "CboEstadoPublicacion";
            this.CboEstadoPublicacion.Size = new System.Drawing.Size(117, 21);
            this.CboEstadoPublicacion.TabIndex = 52;
            // 
            // CboVisibilidad
            // 
            this.CboVisibilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboVisibilidad.Enabled = false;
            this.CboVisibilidad.FormattingEnabled = true;
            this.CboVisibilidad.Location = new System.Drawing.Point(315, 50);
            this.CboVisibilidad.Name = "CboVisibilidad";
            this.CboVisibilidad.Size = new System.Drawing.Size(136, 21);
            this.CboVisibilidad.TabIndex = 51;
            // 
            // CboTipoPublicacion
            // 
            this.CboTipoPublicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboTipoPublicacion.Enabled = false;
            this.CboTipoPublicacion.FormattingEnabled = true;
            this.CboTipoPublicacion.Location = new System.Drawing.Point(582, 50);
            this.CboTipoPublicacion.Name = "CboTipoPublicacion";
            this.CboTipoPublicacion.Size = new System.Drawing.Size(136, 21);
            this.CboTipoPublicacion.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(470, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "TIPO PUBLICACION";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(470, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "ESTADO PUBLICACION";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "VISIBILIDAD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "PRECIO";
            // 
            // TxtPrecio
            // 
            this.TxtPrecio.Enabled = false;
            this.TxtPrecio.Location = new System.Drawing.Point(293, 24);
            this.TxtPrecio.Name = "TxtPrecio";
            this.TxtPrecio.Size = new System.Drawing.Size(158, 20);
            this.TxtPrecio.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "STOCK";
            // 
            // TxtStock
            // 
            this.TxtStock.Enabled = false;
            this.TxtStock.Location = new System.Drawing.Point(105, 50);
            this.TxtStock.Name = "TxtStock";
            this.TxtStock.Size = new System.Drawing.Size(118, 20);
            this.TxtStock.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "DESCRIPCION";
            // 
            // ChkBusquedaExacta
            // 
            this.ChkBusquedaExacta.AutoSize = true;
            this.ChkBusquedaExacta.Location = new System.Drawing.Point(744, 21);
            this.ChkBusquedaExacta.Name = "ChkBusquedaExacta";
            this.ChkBusquedaExacta.Size = new System.Drawing.Size(131, 17);
            this.ChkBusquedaExacta.TabIndex = 39;
            this.ChkBusquedaExacta.Text = "BUSQUEDA EXACTA";
            this.ChkBusquedaExacta.UseVisualStyleBackColor = true;
            this.ChkBusquedaExacta.CheckedChanged += new System.EventHandler(this.ChkBusquedaExacta_CheckedChanged);
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Location = new System.Drawing.Point(105, 24);
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(118, 20);
            this.TxtDescripcion.TabIndex = 36;
            // 
            // LblLimpiar
            // 
            this.LblLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblLimpiar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblLimpiar.ForeColor = System.Drawing.Color.White;
            this.LblLimpiar.Location = new System.Drawing.Point(848, 40);
            this.LblLimpiar.Name = "LblLimpiar";
            this.LblLimpiar.Size = new System.Drawing.Size(88, 32);
            this.LblLimpiar.TabIndex = 38;
            this.LblLimpiar.Text = "LIMPIAR";
            this.LblLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblLimpiar.Click += new System.EventHandler(this.LblLimpiar_Click);
            // 
            // LblBuscar
            // 
            this.LblBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblBuscar.ForeColor = System.Drawing.Color.White;
            this.LblBuscar.Location = new System.Drawing.Point(744, 40);
            this.LblBuscar.Name = "LblBuscar";
            this.LblBuscar.Size = new System.Drawing.Size(88, 32);
            this.LblBuscar.TabIndex = 37;
            this.LblBuscar.Text = "BUSCAR";
            this.LblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblBuscar.Click += new System.EventHandler(this.LblBuscar_Click);
            // 
            // LblListo
            // 
            this.LblListo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblListo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblListo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblListo.ForeColor = System.Drawing.Color.White;
            this.LblListo.Location = new System.Drawing.Point(402, 455);
            this.LblListo.Name = "LblListo";
            this.LblListo.Size = new System.Drawing.Size(88, 32);
            this.LblListo.TabIndex = 35;
            this.LblListo.Text = "LISTO";
            this.LblListo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblListo.Click += new System.EventHandler(this.LblListo_Click);
            // 
            // FrmMisPublicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(978, 501);
            this.Controls.Add(this.LblListo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DgvPublicacion);
            this.Name = "FrmMisPublicaciones";
            this.Text = "FrbaCommerce - Mis publicaciones";
            this.Load += new System.EventHandler(this.MisPublicaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPublicacion)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvPublicacion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LblListo;
        private System.Windows.Forms.CheckBox ChkBusquedaExacta;
        private System.Windows.Forms.Label LblLimpiar;
        private System.Windows.Forms.Label LblBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtStock;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtPrecio;
        private System.Windows.Forms.ComboBox CboTipoPublicacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CboEstadoPublicacion;
        private System.Windows.Forms.ComboBox CboVisibilidad;
    }
}