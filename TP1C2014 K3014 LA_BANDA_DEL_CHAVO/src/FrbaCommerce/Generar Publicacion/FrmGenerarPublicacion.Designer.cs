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
            this.LblRequeridoValorInicial = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.LstRubro = new System.Windows.Forms.CheckedListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.LblRequeridoPrecio = new System.Windows.Forms.Label();
            this.LblRequeridoStock = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
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
            this.CboTipoPublicacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboTipoPublicacion.FormattingEnabled = true;
            this.CboTipoPublicacion.Items.AddRange(new object[] {
            "Compra inmediata",
            "Subasta"});
            this.CboTipoPublicacion.Location = new System.Drawing.Point(152, 29);
            this.CboTipoPublicacion.Name = "CboTipoPublicacion";
            this.CboTipoPublicacion.Size = new System.Drawing.Size(177, 21);
            this.CboTipoPublicacion.TabIndex = 18;
            this.CboTipoPublicacion.SelectedIndexChanged += new System.EventHandler(this.CboTipoPublicacion_SelectedIndexChanged);
            // 
            // TxtValorInicioSubasta
            // 
            this.TxtValorInicioSubasta.Enabled = false;
            this.TxtValorInicioSubasta.Location = new System.Drawing.Point(549, 65);
            this.TxtValorInicioSubasta.Name = "TxtValorInicioSubasta";
            this.TxtValorInicioSubasta.Size = new System.Drawing.Size(145, 20);
            this.TxtValorInicioSubasta.TabIndex = 19;
            // 
            // CboEstadoPublicacion
            // 
            this.CboEstadoPublicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboEstadoPublicacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboEstadoPublicacion.FormattingEnabled = true;
            this.CboEstadoPublicacion.Items.AddRange(new object[] {
            "Borrador",
            "Activa",
            "Pausada",
            "Finalizada"});
            this.CboEstadoPublicacion.Location = new System.Drawing.Point(169, 64);
            this.CboEstadoPublicacion.Name = "CboEstadoPublicacion";
            this.CboEstadoPublicacion.Size = new System.Drawing.Size(160, 21);
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
            this.TxtDescripcion.Location = new System.Drawing.Point(14, 53);
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(309, 131);
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
            this.TxtStock.Location = new System.Drawing.Point(64, 201);
            this.TxtStock.Name = "TxtStock";
            this.TxtStock.Size = new System.Drawing.Size(259, 20);
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
            this.TxtPrecio.Location = new System.Drawing.Point(153, 237);
            this.TxtPrecio.Name = "TxtPrecio";
            this.TxtPrecio.Size = new System.Drawing.Size(170, 20);
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
            this.CboVisibilidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboVisibilidad.FormattingEnabled = true;
            this.CboVisibilidad.Items.AddRange(new object[] {
            "Borrador",
            "Activa",
            "Pausada",
            "Finalizada"});
            this.CboVisibilidad.Location = new System.Drawing.Point(554, 28);
            this.CboVisibilidad.Name = "CboVisibilidad";
            this.CboVisibilidad.Size = new System.Drawing.Size(140, 21);
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
            this.groupBox1.Controls.Add(this.CboEstadoPublicacion);
            this.groupBox1.Controls.Add(this.CboVisibilidad);
            this.groupBox1.Controls.Add(this.TxtValorInicioSubasta);
            this.groupBox1.Controls.Add(this.LblRequeridoValorInicial);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.CboTipoPublicacion);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ChkRecibirPreguntas);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(714, 140);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "INFORMACION DE LA PUBLICACION";
            // 
            // LblRequeridoValorInicial
            // 
            this.LblRequeridoValorInicial.AutoSize = true;
            this.LblRequeridoValorInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRequeridoValorInicial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblRequeridoValorInicial.Location = new System.Drawing.Point(531, 66);
            this.LblRequeridoValorInicial.Name = "LblRequeridoValorInicial";
            this.LblRequeridoValorInicial.Size = new System.Drawing.Size(15, 20);
            this.LblRequeridoValorInicial.TabIndex = 45;
            this.LblRequeridoValorInicial.Text = "*";
            this.LblRequeridoValorInicial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.label10.Location = new System.Drawing.Point(536, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 20);
            this.label10.TabIndex = 44;
            this.label10.Text = "*";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.label7.Location = new System.Drawing.Point(152, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 20);
            this.label7.TabIndex = 43;
            this.label7.Text = "*";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.label4.Location = new System.Drawing.Point(134, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 20);
            this.label4.TabIndex = 42;
            this.label4.Text = "*";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.LstRubro);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.LblPrecio);
            this.groupBox2.Controls.Add(this.TxtPrecio);
            this.groupBox2.Controls.Add(this.LblRequeridoPrecio);
            this.groupBox2.Controls.Add(this.LblRequeridoStock);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.TxtDescripcion);
            this.groupBox2.Controls.Add(this.TxtStock);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(714, 277);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "INFORMACION DEL ARTICULO";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.label12.Location = new System.Drawing.Point(178, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 20);
            this.label12.TabIndex = 43;
            this.label12.Text = "*";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LstRubro
            // 
            this.LstRubro.FormattingEnabled = true;
            this.LstRubro.Location = new System.Drawing.Point(383, 46);
            this.LstRubro.Name = "LstRubro";
            this.LstRubro.Size = new System.Drawing.Size(309, 214);
            this.LstRubro.TabIndex = 39;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.label15.Location = new System.Drawing.Point(512, 31);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 20);
            this.label15.TabIndex = 43;
            this.label15.Text = "*";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblRequeridoPrecio
            // 
            this.LblRequeridoPrecio.AutoSize = true;
            this.LblRequeridoPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRequeridoPrecio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblRequeridoPrecio.Location = new System.Drawing.Point(135, 239);
            this.LblRequeridoPrecio.Name = "LblRequeridoPrecio";
            this.LblRequeridoPrecio.Size = new System.Drawing.Size(15, 20);
            this.LblRequeridoPrecio.TabIndex = 45;
            this.LblRequeridoPrecio.Text = "*";
            this.LblRequeridoPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblRequeridoStock
            // 
            this.LblRequeridoStock.AutoSize = true;
            this.LblRequeridoStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRequeridoStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblRequeridoStock.Location = new System.Drawing.Point(49, 204);
            this.LblRequeridoStock.Name = "LblRequeridoStock";
            this.LblRequeridoStock.Size = new System.Drawing.Size(15, 20);
            this.LblRequeridoStock.TabIndex = 44;
            this.LblRequeridoStock.Text = "*";
            this.LblRequeridoStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
        private System.Windows.Forms.Label LblRequeridoValorInicial;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblRequeridoPrecio;
        private System.Windows.Forms.Label LblRequeridoStock;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
    }
}