namespace FrbaCommerce.Historial_Cliente
{
    partial class FrmHistorialCalificacionesOtorgadas
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LblLimpiar = new System.Windows.Forms.Label();
            this.LblBuscar = new System.Windows.Forms.Label();
            this.cBExact = new System.Windows.Forms.CheckBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // LblListo
            // 
            this.LblListo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblListo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblListo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblListo.ForeColor = System.Drawing.Color.White;
            this.LblListo.Location = new System.Drawing.Point(12, 307);
            this.LblListo.Name = "LblListo";
            this.LblListo.Size = new System.Drawing.Size(88, 32);
            this.LblListo.TabIndex = 59;
            this.LblListo.Text = "LISTO";
            this.LblListo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblListo.Click += new System.EventHandler(this.LblListo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCantidad);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.LblLimpiar);
            this.groupBox1.Controls.Add(this.LblBuscar);
            this.groupBox1.Controls.Add(this.cBExact);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 100);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BUSQUEDA AVANZADA";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(176, 46);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(74, 20);
            this.txtCantidad.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(181, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "CANTIDAD";
            // 
            // LblLimpiar
            // 
            this.LblLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblLimpiar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblLimpiar.ForeColor = System.Drawing.Color.White;
            this.LblLimpiar.Location = new System.Drawing.Point(335, 62);
            this.LblLimpiar.Name = "LblLimpiar";
            this.LblLimpiar.Size = new System.Drawing.Size(88, 32);
            this.LblLimpiar.TabIndex = 37;
            this.LblLimpiar.Text = "LIMPIAR";
            this.LblLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblBuscar
            // 
            this.LblBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblBuscar.ForeColor = System.Drawing.Color.White;
            this.LblBuscar.Location = new System.Drawing.Point(335, 20);
            this.LblBuscar.Name = "LblBuscar";
            this.LblBuscar.Size = new System.Drawing.Size(88, 32);
            this.LblBuscar.TabIndex = 36;
            this.LblBuscar.Text = "BUSCAR";
            this.LblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblBuscar.Click += new System.EventHandler(this.LblBuscar_Click);
            // 
            // cBExact
            // 
            this.cBExact.AutoSize = true;
            this.cBExact.Location = new System.Drawing.Point(198, 77);
            this.cBExact.Name = "cBExact";
            this.cBExact.Size = new System.Drawing.Size(131, 17);
            this.cBExact.TabIndex = 17;
            this.cBExact.Text = "BUSQUEDA EXACTA";
            this.cBExact.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(255, 46);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(74, 20);
            this.txtNombre.TabIndex = 15;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(96, 46);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(74, 20);
            this.txtDesc.TabIndex = 14;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(16, 46);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(74, 20);
            this.txtCodigo.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "CODIGO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(259, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "NOMBRE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "DESCRIPCION";
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.AllowUserToResizeColumns = false;
            this.dgvHistory.AllowUserToResizeRows = false;
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Location = new System.Drawing.Point(12, 134);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.RowHeadersWidth = 20;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new System.Drawing.Size(443, 159);
            this.dgvHistory.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 16);
            this.label1.TabIndex = 56;
            this.label1.Text = "CALIFICACIONES OTORGADAS";
            // 
            // FrmHistorialCalificacionesOtorgadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 354);
            this.Controls.Add(this.LblListo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.label1);
            this.Name = "FrmHistorialCalificacionesOtorgadas";
            this.Text = "CALIFICACIONES OTORGADAS";
            this.Load += new System.EventHandler(this.FrmHistorialCalificacionesOtorgadas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblListo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblLimpiar;
        private System.Windows.Forms.Label LblBuscar;
        private System.Windows.Forms.CheckBox cBExact;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Label label1;
    }
}