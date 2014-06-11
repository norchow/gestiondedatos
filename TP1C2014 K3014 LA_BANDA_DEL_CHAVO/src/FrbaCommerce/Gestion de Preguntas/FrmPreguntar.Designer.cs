namespace FrbaCommerce.Gestion_de_Preguntas
{
    partial class FrmPreguntar
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblPublicacion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPregunta = new System.Windows.Forms.TextBox();
            this.LblCancelar = new System.Windows.Forms.Label();
            this.LblPreguntar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PUBLICACION";
            // 
            // lblPublicacion
            // 
            this.lblPublicacion.AutoSize = true;
            this.lblPublicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPublicacion.Location = new System.Drawing.Point(137, 27);
            this.lblPublicacion.Name = "lblPublicacion";
            this.lblPublicacion.Size = new System.Drawing.Size(0, 13);
            this.lblPublicacion.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "PREGUNTA";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtPregunta
            // 
            this.txtPregunta.Location = new System.Drawing.Point(32, 103);
            this.txtPregunta.Multiline = true;
            this.txtPregunta.Name = "txtPregunta";
            this.txtPregunta.Size = new System.Drawing.Size(446, 166);
            this.txtPregunta.TabIndex = 3;
            // 
            // LblCancelar
            // 
            this.LblCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblCancelar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblCancelar.ForeColor = System.Drawing.Color.White;
            this.LblCancelar.Location = new System.Drawing.Point(317, 307);
            this.LblCancelar.Name = "LblCancelar";
            this.LblCancelar.Size = new System.Drawing.Size(88, 32);
            this.LblCancelar.TabIndex = 43;
            this.LblCancelar.Text = "CANCELAR";
            this.LblCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblCancelar.Click += new System.EventHandler(this.LblCancelar_Click);
            // 
            // LblPreguntar
            // 
            this.LblPreguntar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblPreguntar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblPreguntar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblPreguntar.ForeColor = System.Drawing.Color.White;
            this.LblPreguntar.Location = new System.Drawing.Point(96, 307);
            this.LblPreguntar.Name = "LblPreguntar";
            this.LblPreguntar.Size = new System.Drawing.Size(88, 32);
            this.LblPreguntar.TabIndex = 42;
            this.LblPreguntar.Text = "PREGUNTAR";
            this.LblPreguntar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblPreguntar.Click += new System.EventHandler(this.LblPreguntar_Click);
            // 
            // FrmPreguntar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 370);
            this.Controls.Add(this.LblCancelar);
            this.Controls.Add(this.LblPreguntar);
            this.Controls.Add(this.txtPregunta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPublicacion);
            this.Controls.Add(this.label1);
            this.Name = "FrmPreguntar";
            this.Text = "FrbaCommerce - Pregunta";
            this.Load += new System.EventHandler(this.FrmPreguntar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPublicacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPregunta;
        private System.Windows.Forms.Label LblCancelar;
        private System.Windows.Forms.Label LblPreguntar;
    }
}