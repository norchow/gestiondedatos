namespace FrbaCommerce.Generar_Publicacion
{
    partial class FrmGenerarPublicacion
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
            this.label3 = new System.Windows.Forms.Label();
            this.CboTipoPublicacion = new System.Windows.Forms.ComboBox();
            this.TxtValorInicioSubasta = new System.Windows.Forms.TextBox();
            this.CboEstadoPublicacion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtStock = new System.Windows.Forms.TextBox();
            this.LblPrecio = new System.Windows.Forms.Label();
            this.TxtPrecio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CboVisibilidad = new System.Windows.Forms.ComboBox();
            this.ChkRecibirPreguntas = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.LstRubro = new System.Windows.Forms.CheckedListBox();
            this.LblCancelar = new System.Windows.Forms.Label();
            this.LblListo = new System.Windows.Forms.Label();
            this.LblLimpiar = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "TIPO DE PUBLICACION";
            // 
            // CboTipoPublicacion
            // 
            this.CboTipoPublicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboTipoPublicacion.FormattingEnabled = true;
            this.CboTipoPublicacion.Items.AddRange(new object[] {
            "Compra inmediata",
            "Subasta"});
            this.CboTipoPublicacion.Location = new System.Drawing.Point(144, 29);
            this.CboTipoPublicacion.Name = "CboTipoPublicacion";
            this.CboTipoPublicacion.Size = new System.Drawing.Size(179, 21);
            this.CboTipoPublicacion.TabIndex = 18;
            this.CboTipoPublicacion.SelectedIndexChanged += new System.EventHandler(this.CboTipoPublicacion_SelectedIndexChanged);
            // 
            // TxtValorInicioSubasta
            // 
            this.TxtValorInicioSubasta.Enabled = false;
            this.TxtValorInicioSubasta.Location = new System.Drawing.Point(543, 65);
            this.TxtValorInicioSubasta.Name = "TxtValorInicioSubasta";
            this.TxtValorInicioSubasta.Size = new System.Drawing.Size(149, 20);
            this.TxtValorInicioSubasta.TabIndex = 19;
            // 
            // CboEstadoPublicacion
            // 
            this.CboEstadoPublicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboEstadoPublicacion.FormattingEnabled = true;
            this.CboEstadoPublicacion.Items.AddRange(new object[] {
            "Borrador",
            "Activa",
            "Pausada",
            "Finalizada"});
            this.CboEstadoPublicacion.Location = new System.Drawing.Point(161, 64);
            this.CboEstadoPublicacion.Name = "CboEstadoPublicacion";
            this.CboEstadoPublicacion.Size = new System.Drawing.Size(162, 21);
            this.CboEstadoPublicacion.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(380, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "VALOR INICIAL DE SUBASTA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "ESTADO DE PUBLICACION";
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Location = new System.Drawing.Point(14, 46);
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(309, 146);
            this.TxtDescripcion.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "DESCRIPCION DEL PRODUCTO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "STOCK";
            // 
            // TxtStock
            // 
            this.TxtStock.Location = new System.Drawing.Point(63, 201);
            this.TxtStock.Name = "TxtStock";
            this.TxtStock.Size = new System.Drawing.Size(260, 20);
            this.TxtStock.TabIndex = 28;
            // 
            // LblPrecio
            // 
            this.LblPrecio.AutoSize = true;
            this.LblPrecio.Location = new System.Drawing.Point(11, 240);
            this.LblPrecio.Name = "LblPrecio";
            this.LblPrecio.Size = new System.Drawing.Size(128, 13);
            this.LblPrecio.TabIndex = 31;
            this.LblPrecio.Text = "PRECIO DEL ARTICULO";
            // 
            // TxtPrecio
            // 
            this.TxtPrecio.Location = new System.Drawing.Point(144, 237);
            this.TxtPrecio.Name = "TxtPrecio";
            this.TxtPrecio.Size = new System.Drawing.Size(179, 20);
            this.TxtPrecio.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(380, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "VISIBILIDAD DE PUBLICACION";
            // 
            // CboVisibilidad
            // 
            this.CboVisibilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboVisibilidad.FormattingEnabled = true;
            this.CboVisibilidad.Items.AddRange(new object[] {
            "Borrador",
            "Activa",
            "Pausada",
            "Finalizada"});
            this.CboVisibilidad.Location = new System.Drawing.Point(543, 28);
            this.CboVisibilidad.Name = "CboVisibilidad";
            this.CboVisibilidad.Size = new System.Drawing.Size(149, 21);
            this.CboVisibilidad.TabIndex = 34;
            // 
            // ChkRecibirPreguntas
            // 
            this.ChkRecibirPreguntas.AutoSize = true;
            this.ChkRecibirPreguntas.Location = new System.Drawing.Point(17, 103);
            this.ChkRecibirPreguntas.Name = "ChkRecibirPreguntas";
            this.ChkRecibirPreguntas.Size = new System.Drawing.Size(178, 17);
            this.ChkRecibirPreguntas.TabIndex = 36;
            this.ChkRecibirPreguntas.Text = "DESEA RECIBIR PREGUNTAS";
            this.ChkRecibirPreguntas.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ChkRecibirPreguntas);
            this.groupBox1.Controls.Add(this.TxtValorInicioSubasta);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CboTipoPublicacion);
            this.groupBox1.Controls.Add(this.CboVisibilidad);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.CboEstadoPublicacion);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(714, 140);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "INFORMACION DE LA PUBLICACION";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.LstRubro);
            this.groupBox2.Controls.Add(this.TxtDescripcion);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TxtPrecio);
            this.groupBox2.Controls.Add(this.LblPrecio);
            this.groupBox2.Controls.Add(this.TxtStock);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(714, 277);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "INFORMACION DEL ARTICULO";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(380, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "RUBROS DEL ARTICULO";
            // 
            // LstRubro
            // 
            this.LstRubro.FormattingEnabled = true;
            this.LstRubro.Location = new System.Drawing.Point(383, 46);
            this.LstRubro.Name = "LstRubro";
            this.LstRubro.Size = new System.Drawing.Size(309, 214);
            this.LstRubro.TabIndex = 39;
            // 
            // LblCancelar
            // 
            this.LblCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblCancelar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblCancelar.ForeColor = System.Drawing.Color.White;
            this.LblCancelar.Location = new System.Drawing.Point(431, 459);
            this.LblCancelar.Name = "LblCancelar";
            this.LblCancelar.Size = new System.Drawing.Size(95, 32);
            this.LblCancelar.TabIndex = 40;
            this.LblCancelar.Text = "CANCELAR";
            this.LblCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblCancelar.Click += new System.EventHandler(this.LblCancelar_Click);
            // 
            // LblListo
            // 
            this.LblListo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblListo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblListo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblListo.ForeColor = System.Drawing.Color.White;
            this.LblListo.Location = new System.Drawing.Point(203, 459);
            this.LblListo.Name = "LblListo";
            this.LblListo.Size = new System.Drawing.Size(95, 32);
            this.LblListo.TabIndex = 39;
            this.LblListo.Text = "LISTO";
            this.LblListo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblListo.Click += new System.EventHandler(this.LblListo_Click);
            // 
            // LblLimpiar
            // 
            this.LblLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblLimpiar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblLimpiar.ForeColor = System.Drawing.Color.White;
            this.LblLimpiar.Location = new System.Drawing.Point(318, 459);
            this.LblLimpiar.Name = "LblLimpiar";
            this.LblLimpiar.Size = new System.Drawing.Size(95, 32);
            this.LblLimpiar.TabIndex = 41;
            this.LblLimpiar.Text = "LIMPIAR";
            this.LblLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblLimpiar.Click += new System.EventHandler(this.LblLimpiar_Click);
            // 
            // FrmGenerarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(743, 507);
            this.Controls.Add(this.LblLimpiar);
            this.Controls.Add(this.LblCancelar);
            this.Controls.Add(this.LblListo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(759, 545);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(759, 545);
            this.Name = "FrmGenerarPublicacion";
            this.Text = "FrbaCommerce - Generar publicacion";
            this.Load += new System.EventHandler(this.FrmGenerarPublicacion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CboTipoPublicacion;
        private System.Windows.Forms.TextBox TxtValorInicioSubasta;
        private System.Windows.Forms.ComboBox CboEstadoPublicacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtStock;
        private System.Windows.Forms.Label LblPrecio;
        private System.Windows.Forms.TextBox TxtPrecio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CboVisibilidad;
        private System.Windows.Forms.CheckBox ChkRecibirPreguntas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox LstRubro;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LblCancelar;
        private System.Windows.Forms.Label LblListo;
        private System.Windows.Forms.Label LblLimpiar;
    }
}