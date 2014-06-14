namespace FrbaCommerce.Abm_Visibilidad
{
    partial class FrmABMVisibilidad
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
            this.LblListo = new System.Windows.Forms.Label();
            this.LblNuevo = new System.Windows.Forms.Label();
            this.DgvVisibilidad = new System.Windows.Forms.DataGridView();
            this.GroupFiltros = new System.Windows.Forms.GroupBox();
            this.ChkBusquedaExacta = new System.Windows.Forms.CheckBox();
            this.LblLimpiar = new System.Windows.Forms.Label();
            this.LblBuscar = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDuracion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtPorcentajeVenta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtPrecioPublicar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvVisibilidad)).BeginInit();
            this.GroupFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblListo
            // 
            this.LblListo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblListo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblListo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblListo.ForeColor = System.Drawing.Color.White;
            this.LblListo.Location = new System.Drawing.Point(12, 465);
            this.LblListo.Name = "LblListo";
            this.LblListo.Size = new System.Drawing.Size(88, 32);
            this.LblListo.TabIndex = 31;
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
            this.LblNuevo.Location = new System.Drawing.Point(560, 465);
            this.LblNuevo.Name = "LblNuevo";
            this.LblNuevo.Size = new System.Drawing.Size(132, 32);
            this.LblNuevo.TabIndex = 28;
            this.LblNuevo.Text = "NUEVA VISIBILIDAD";
            this.LblNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblNuevo.Click += new System.EventHandler(this.LblNuevo_Click);
            // 
            // DgvVisibilidad
            // 
            this.DgvVisibilidad.AllowUserToAddRows = false;
            this.DgvVisibilidad.AllowUserToDeleteRows = false;
            this.DgvVisibilidad.AllowUserToResizeColumns = false;
            this.DgvVisibilidad.AllowUserToResizeRows = false;
            this.DgvVisibilidad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DgvVisibilidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvVisibilidad.Location = new System.Drawing.Point(12, 116);
            this.DgvVisibilidad.MultiSelect = false;
            this.DgvVisibilidad.Name = "DgvVisibilidad";
            this.DgvVisibilidad.RowHeadersVisible = false;
            this.DgvVisibilidad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvVisibilidad.Size = new System.Drawing.Size(680, 336);
            this.DgvVisibilidad.TabIndex = 32;
            this.DgvVisibilidad.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvVisibilidad_CellContentClick);
            // 
            // GroupFiltros
            // 
            this.GroupFiltros.Controls.Add(this.ChkBusquedaExacta);
            this.GroupFiltros.Controls.Add(this.LblLimpiar);
            this.GroupFiltros.Controls.Add(this.LblBuscar);
            this.GroupFiltros.Controls.Add(this.label3);
            this.GroupFiltros.Controls.Add(this.TxtDuracion);
            this.GroupFiltros.Controls.Add(this.label4);
            this.GroupFiltros.Controls.Add(this.TxtPorcentajeVenta);
            this.GroupFiltros.Controls.Add(this.label2);
            this.GroupFiltros.Controls.Add(this.TxtPrecioPublicar);
            this.GroupFiltros.Controls.Add(this.label1);
            this.GroupFiltros.Controls.Add(this.TxtDescripcion);
            this.GroupFiltros.Location = new System.Drawing.Point(12, 13);
            this.GroupFiltros.Name = "GroupFiltros";
            this.GroupFiltros.Size = new System.Drawing.Size(680, 89);
            this.GroupFiltros.TabIndex = 33;
            this.GroupFiltros.TabStop = false;
            this.GroupFiltros.Text = "FILTROS DE BUSQUEDA";
            // 
            // ChkBusquedaExacta
            // 
            this.ChkBusquedaExacta.AutoSize = true;
            this.ChkBusquedaExacta.Location = new System.Drawing.Point(473, 25);
            this.ChkBusquedaExacta.Name = "ChkBusquedaExacta";
            this.ChkBusquedaExacta.Size = new System.Drawing.Size(131, 17);
            this.ChkBusquedaExacta.TabIndex = 36;
            this.ChkBusquedaExacta.Text = "BUSQUEDA EXACTA";
            this.ChkBusquedaExacta.UseVisualStyleBackColor = true;
            this.ChkBusquedaExacta.CheckedChanged += new System.EventHandler(this.ChkBusquedaExacta_CheckedChanged);
            // 
            // LblLimpiar
            // 
            this.LblLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblLimpiar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblLimpiar.ForeColor = System.Drawing.Color.White;
            this.LblLimpiar.Location = new System.Drawing.Point(577, 44);
            this.LblLimpiar.Name = "LblLimpiar";
            this.LblLimpiar.Size = new System.Drawing.Size(88, 32);
            this.LblLimpiar.TabIndex = 35;
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
            this.LblBuscar.Location = new System.Drawing.Point(473, 44);
            this.LblBuscar.Name = "LblBuscar";
            this.LblBuscar.Size = new System.Drawing.Size(88, 32);
            this.LblBuscar.TabIndex = 34;
            this.LblBuscar.Text = "BUSCAR";
            this.LblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblBuscar.Click += new System.EventHandler(this.LblBuscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "DURACION";
            // 
            // TxtDuracion
            // 
            this.TxtDuracion.Enabled = false;
            this.TxtDuracion.Location = new System.Drawing.Point(314, 56);
            this.TxtDuracion.Name = "TxtDuracion";
            this.TxtDuracion.Size = new System.Drawing.Size(134, 20);
            this.TxtDuracion.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "PORCENTAJE DE LA VENTA";
            // 
            // TxtPorcentajeVenta
            // 
            this.TxtPorcentajeVenta.Enabled = false;
            this.TxtPorcentajeVenta.Location = new System.Drawing.Point(401, 23);
            this.TxtPorcentajeVenta.Name = "TxtPorcentajeVenta";
            this.TxtPorcentajeVenta.Size = new System.Drawing.Size(47, 20);
            this.TxtPorcentajeVenta.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "PRECIO POR PUBLICAR";
            // 
            // TxtPrecioPublicar
            // 
            this.TxtPrecioPublicar.Enabled = false;
            this.TxtPrecioPublicar.Location = new System.Drawing.Point(149, 56);
            this.TxtPrecioPublicar.Name = "TxtPrecioPublicar";
            this.TxtPrecioPublicar.Size = new System.Drawing.Size(69, 20);
            this.TxtPrecioPublicar.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "DESCRIPCION";
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Location = new System.Drawing.Point(100, 23);
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(118, 20);
            this.TxtDescripcion.TabIndex = 0;
            // 
            // FrmABMVisibilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(704, 509);
            this.Controls.Add(this.GroupFiltros);
            this.Controls.Add(this.DgvVisibilidad);
            this.Controls.Add(this.LblListo);
            this.Controls.Add(this.LblNuevo);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(720, 547);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(720, 547);
            this.Name = "FrmABMVisibilidad";
            this.Text = "FrbaCommerce - Administracion de visiblidad";
            this.Load += new System.EventHandler(this.FrmABMVisibilidad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvVisibilidad)).EndInit();
            this.GroupFiltros.ResumeLayout(false);
            this.GroupFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblListo;
        private System.Windows.Forms.Label LblNuevo;
        private System.Windows.Forms.DataGridView DgvVisibilidad;
        private System.Windows.Forms.GroupBox GroupFiltros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.CheckBox ChkBusquedaExacta;
        private System.Windows.Forms.Label LblLimpiar;
        private System.Windows.Forms.Label LblBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtDuracion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtPorcentajeVenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtPrecioPublicar;
    }
}