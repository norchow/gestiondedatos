namespace FrbaCommerce.Facturar_Publicaciones
{
    partial class FrmFacturarPublicaciones
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtCantidad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LstPublicaciones = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CboFormaPago = new System.Windows.Forms.ComboBox();
            this.LblLimpiar = new System.Windows.Forms.Label();
            this.LblCancelar = new System.Windows.Forms.Label();
            this.LblFacturar = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LblLimpiar);
            this.groupBox2.Controls.Add(this.CboFormaPago);
            this.groupBox2.Controls.Add(this.LblCancelar);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.LblFacturar);
            this.groupBox2.Controls.Add(this.LstPublicaciones);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.TxtCantidad);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(22, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(633, 299);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FACTURACIÓN";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "PUBLICACIONES A RENDIR";
            // 
            // TxtCantidad
            // 
            this.TxtCantidad.Location = new System.Drawing.Point(447, 57);
            this.TxtCantidad.Name = "TxtCantidad";
            this.TxtCantidad.Size = new System.Drawing.Size(152, 20);
            this.TxtCantidad.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(374, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "CANTIDAD";
            // 
            // LstPublicaciones
            // 
            this.LstPublicaciones.FormattingEnabled = true;
            this.LstPublicaciones.Location = new System.Drawing.Point(26, 56);
            this.LstPublicaciones.Name = "LstPublicaciones";
            this.LstPublicaciones.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.LstPublicaciones.Size = new System.Drawing.Size(309, 212);
            this.LstPublicaciones.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(373, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "FORMA DE PAGO";
            // 
            // CboFormaPago
            // 
            this.CboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboFormaPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboFormaPago.FormattingEnabled = true;
            this.CboFormaPago.Items.AddRange(new object[] {
            "Borrador",
            "Activa",
            "Pausada",
            "Finalizada"});
            this.CboFormaPago.Location = new System.Drawing.Point(475, 99);
            this.CboFormaPago.Name = "CboFormaPago";
            this.CboFormaPago.Size = new System.Drawing.Size(124, 21);
            this.CboFormaPago.TabIndex = 43;
            // 
            // LblLimpiar
            // 
            this.LblLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblLimpiar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblLimpiar.ForeColor = System.Drawing.Color.White;
            this.LblLimpiar.Location = new System.Drawing.Point(377, 236);
            this.LblLimpiar.Name = "LblLimpiar";
            this.LblLimpiar.Size = new System.Drawing.Size(95, 32);
            this.LblLimpiar.TabIndex = 46;
            this.LblLimpiar.Text = "LIMPIAR";
            this.LblLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblCancelar
            // 
            this.LblCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblCancelar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblCancelar.ForeColor = System.Drawing.Color.White;
            this.LblCancelar.Location = new System.Drawing.Point(517, 236);
            this.LblCancelar.Name = "LblCancelar";
            this.LblCancelar.Size = new System.Drawing.Size(95, 32);
            this.LblCancelar.TabIndex = 45;
            this.LblCancelar.Text = "CANCELAR";
            this.LblCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblCancelar.Click += new System.EventHandler(this.LblCancelar_Click);
            // 
            // LblFacturar
            // 
            this.LblFacturar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblFacturar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblFacturar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblFacturar.ForeColor = System.Drawing.Color.White;
            this.LblFacturar.Location = new System.Drawing.Point(377, 140);
            this.LblFacturar.Name = "LblFacturar";
            this.LblFacturar.Size = new System.Drawing.Size(95, 32);
            this.LblFacturar.TabIndex = 44;
            this.LblFacturar.Text = "FACTURAR";
            this.LblFacturar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 362);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmFacturarPublicaciones";
            this.Text = "FrbaCommerce - Facturar publicaciones";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtCantidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox LstPublicaciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CboFormaPago;
        private System.Windows.Forms.Label LblLimpiar;
        private System.Windows.Forms.Label LblCancelar;
        private System.Windows.Forms.Label LblFacturar;
    }
}