namespace FrbaCommerce.Historial_Cliente
{
    partial class FrmHistorialCliente
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
            this.lblReputacion = new System.Windows.Forms.Label();
            this.lblCalificaciones = new System.Windows.Forms.Label();
            this.lblOfertas = new System.Windows.Forms.Label();
            this.lblCompras = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblListo
            // 
            this.LblListo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblListo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblListo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblListo.ForeColor = System.Drawing.Color.White;
            this.LblListo.Location = new System.Drawing.Point(13, 251);
            this.LblListo.Name = "LblListo";
            this.LblListo.Size = new System.Drawing.Size(61, 32);
            this.LblListo.TabIndex = 40;
            this.LblListo.Text = "LISTO";
            this.LblListo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblListo.Click += new System.EventHandler(this.LblListo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblReputacion);
            this.groupBox1.Controls.Add(this.lblCalificaciones);
            this.groupBox1.Controls.Add(this.lblOfertas);
            this.groupBox1.Controls.Add(this.lblCompras);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 227);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HISTORIAL DE";
            // 
            // lblReputacion
            // 
            this.lblReputacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblReputacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReputacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblReputacion.ForeColor = System.Drawing.Color.White;
            this.lblReputacion.Location = new System.Drawing.Point(16, 178);
            this.lblReputacion.Name = "lblReputacion";
            this.lblReputacion.Size = new System.Drawing.Size(145, 32);
            this.lblReputacion.TabIndex = 44;
            this.lblReputacion.Text = "REPUTACION";
            this.lblReputacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblReputacion.Click += new System.EventHandler(this.lblReputacion_Click);
            // 
            // lblCalificaciones
            // 
            this.lblCalificaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblCalificaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCalificaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCalificaciones.ForeColor = System.Drawing.Color.White;
            this.lblCalificaciones.Location = new System.Drawing.Point(16, 129);
            this.lblCalificaciones.Name = "lblCalificaciones";
            this.lblCalificaciones.Size = new System.Drawing.Size(145, 32);
            this.lblCalificaciones.TabIndex = 43;
            this.lblCalificaciones.Text = "CALIFICACIONES OTORGADAS";
            this.lblCalificaciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCalificaciones.Click += new System.EventHandler(this.lblCalificaciones_Click);
            // 
            // lblOfertas
            // 
            this.lblOfertas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblOfertas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOfertas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOfertas.ForeColor = System.Drawing.Color.White;
            this.lblOfertas.Location = new System.Drawing.Point(16, 79);
            this.lblOfertas.Name = "lblOfertas";
            this.lblOfertas.Size = new System.Drawing.Size(145, 32);
            this.lblOfertas.TabIndex = 42;
            this.lblOfertas.Text = "OFERTAS";
            this.lblOfertas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOfertas.Click += new System.EventHandler(this.lblOfertas_Click);
            // 
            // lblCompras
            // 
            this.lblCompras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblCompras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCompras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCompras.ForeColor = System.Drawing.Color.White;
            this.lblCompras.Location = new System.Drawing.Point(16, 31);
            this.lblCompras.Name = "lblCompras";
            this.lblCompras.Size = new System.Drawing.Size(145, 32);
            this.lblCompras.TabIndex = 41;
            this.lblCompras.Text = "COMPRAS";
            this.lblCompras.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCompras.Click += new System.EventHandler(this.lblCompras_Click);
            // 
            // FrmHistorialCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 292);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LblListo);
            this.Name = "FrmHistorialCliente";
            this.Text = "CLIENTE";
            this.Load += new System.EventHandler(this.FrmHistorialCliemte_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblListo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCompras;
        private System.Windows.Forms.Label lblReputacion;
        private System.Windows.Forms.Label lblCalificaciones;
        private System.Windows.Forms.Label lblOfertas;
    }
}