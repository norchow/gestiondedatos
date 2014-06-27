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
            this.CboFormaPago = new System.Windows.Forms.ComboBox();
            this.LblCancelar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblFacturar = new System.Windows.Forms.Label();
            this.LstPublicaciones = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtCantidad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DatosTarjeta = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtTarjeta = new System.Windows.Forms.TextBox();
            this.TxtNroTarjeta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtTitular = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtVencimiento = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtDni = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtCodSeguridad = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.DatosTarjeta.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DatosTarjeta);
            this.groupBox2.Controls.Add(this.CboFormaPago);
            this.groupBox2.Controls.Add(this.LblCancelar);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.LblFacturar);
            this.groupBox2.Controls.Add(this.LstPublicaciones);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.TxtCantidad);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(666, 389);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FACTURACIÓN";
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
            this.CboFormaPago.Location = new System.Drawing.Point(491, 87);
            this.CboFormaPago.Name = "CboFormaPago";
            this.CboFormaPago.Size = new System.Drawing.Size(150, 21);
            this.CboFormaPago.TabIndex = 43;
            this.CboFormaPago.SelectedIndexChanged += new System.EventHandler(this.CboFormaPago_SelectedIndexChanged);
            // 
            // LblCancelar
            // 
            this.LblCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblCancelar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblCancelar.ForeColor = System.Drawing.Color.White;
            this.LblCancelar.Location = new System.Drawing.Point(519, 338);
            this.LblCancelar.Name = "LblCancelar";
            this.LblCancelar.Size = new System.Drawing.Size(122, 32);
            this.LblCancelar.TabIndex = 45;
            this.LblCancelar.Text = "CANCELAR";
            this.LblCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblCancelar.Click += new System.EventHandler(this.LblCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(389, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "FORMA DE PAGO";
            // 
            // LblFacturar
            // 
            this.LblFacturar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblFacturar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblFacturar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblFacturar.ForeColor = System.Drawing.Color.White;
            this.LblFacturar.Location = new System.Drawing.Point(392, 338);
            this.LblFacturar.Name = "LblFacturar";
            this.LblFacturar.Size = new System.Drawing.Size(121, 32);
            this.LblFacturar.TabIndex = 44;
            this.LblFacturar.Text = "FACTURAR";
            this.LblFacturar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblFacturar.Click += new System.EventHandler(this.LblFacturar_Click);
            // 
            // LstPublicaciones
            // 
            this.LstPublicaciones.FormattingEnabled = true;
            this.LstPublicaciones.HorizontalScrollbar = true;
            this.LstPublicaciones.Location = new System.Drawing.Point(26, 56);
            this.LstPublicaciones.Name = "LstPublicaciones";
            this.LstPublicaciones.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.LstPublicaciones.Size = new System.Drawing.Size(343, 316);
            this.LstPublicaciones.TabIndex = 41;
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
            this.TxtCantidad.Location = new System.Drawing.Point(455, 57);
            this.TxtCantidad.Name = "TxtCantidad";
            this.TxtCantidad.Size = new System.Drawing.Size(186, 20);
            this.TxtCantidad.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(389, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "CANTIDAD";
            // 
            // DatosTarjeta
            // 
            this.DatosTarjeta.Controls.Add(this.TxtCodSeguridad);
            this.DatosTarjeta.Controls.Add(this.label8);
            this.DatosTarjeta.Controls.Add(this.TxtDni);
            this.DatosTarjeta.Controls.Add(this.label7);
            this.DatosTarjeta.Controls.Add(this.TxtVencimiento);
            this.DatosTarjeta.Controls.Add(this.label5);
            this.DatosTarjeta.Controls.Add(this.TxtTitular);
            this.DatosTarjeta.Controls.Add(this.label4);
            this.DatosTarjeta.Controls.Add(this.TxtNroTarjeta);
            this.DatosTarjeta.Controls.Add(this.label3);
            this.DatosTarjeta.Controls.Add(this.TxtTarjeta);
            this.DatosTarjeta.Controls.Add(this.label2);
            this.DatosTarjeta.Location = new System.Drawing.Point(392, 122);
            this.DatosTarjeta.Name = "DatosTarjeta";
            this.DatosTarjeta.Size = new System.Drawing.Size(249, 203);
            this.DatosTarjeta.TabIndex = 46;
            this.DatosTarjeta.TabStop = false;
            this.DatosTarjeta.Text = "DATOS DE TARJETA";
            this.DatosTarjeta.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "TARJETA";
            // 
            // TxtTarjeta
            // 
            this.TxtTarjeta.Location = new System.Drawing.Point(86, 30);
            this.TxtTarjeta.Name = "TxtTarjeta";
            this.TxtTarjeta.Size = new System.Drawing.Size(141, 20);
            this.TxtTarjeta.TabIndex = 47;
            // 
            // TxtNroTarjeta
            // 
            this.TxtNroTarjeta.Location = new System.Drawing.Point(116, 56);
            this.TxtNroTarjeta.MaxLength = 16;
            this.TxtNroTarjeta.Name = "TxtNroTarjeta";
            this.TxtNroTarjeta.Size = new System.Drawing.Size(111, 20);
            this.TxtNroTarjeta.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "NRO. TARJETA";
            // 
            // TxtTitular
            // 
            this.TxtTitular.Location = new System.Drawing.Point(86, 82);
            this.TxtTitular.MaxLength = 16;
            this.TxtTitular.Name = "TxtTitular";
            this.TxtTitular.Size = new System.Drawing.Size(141, 20);
            this.TxtTitular.TabIndex = 51;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "TITULAR";
            // 
            // TxtVencimiento
            // 
            this.TxtVencimiento.Location = new System.Drawing.Point(150, 108);
            this.TxtVencimiento.MaxLength = 4;
            this.TxtVencimiento.Name = "TxtVencimiento";
            this.TxtVencimiento.Size = new System.Drawing.Size(77, 20);
            this.TxtVencimiento.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "FECHA VENCIMIENTO";
            // 
            // TxtDni
            // 
            this.TxtDni.Location = new System.Drawing.Point(57, 134);
            this.TxtDni.MaxLength = 8;
            this.TxtDni.Name = "TxtDni";
            this.TxtDni.Size = new System.Drawing.Size(170, 20);
            this.TxtDni.TabIndex = 55;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 54;
            this.label7.Text = "DNI";
            // 
            // TxtCodSeguridad
            // 
            this.TxtCodSeguridad.Location = new System.Drawing.Point(165, 160);
            this.TxtCodSeguridad.MaxLength = 3;
            this.TxtCodSeguridad.Name = "TxtCodSeguridad";
            this.TxtCodSeguridad.Size = new System.Drawing.Size(62, 20);
            this.TxtCodSeguridad.TabIndex = 57;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 13);
            this.label8.TabIndex = 56;
            this.label8.Text = "CODIGO DE SEGURIDAD";
            // 
            // FrmFacturarPublicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 420);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmFacturarPublicaciones";
            this.Text = "FrbaCommerce - Facturar publicaciones";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.DatosTarjeta.ResumeLayout(false);
            this.DatosTarjeta.PerformLayout();
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
        private System.Windows.Forms.Label LblCancelar;
        private System.Windows.Forms.Label LblFacturar;
        private System.Windows.Forms.GroupBox DatosTarjeta;
        private System.Windows.Forms.TextBox TxtTitular;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtNroTarjeta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtTarjeta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtVencimiento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtCodSeguridad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtDni;
        private System.Windows.Forms.Label label7;
    }
}