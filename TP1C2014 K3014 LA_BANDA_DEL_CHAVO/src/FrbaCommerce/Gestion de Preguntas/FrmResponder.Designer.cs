namespace FrbaCommerce.Gestion_de_Preguntas
{
    partial class FrmResponder
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
            this.LblCancelar = new System.Windows.Forms.Label();
            this.LblResponder = new System.Windows.Forms.Label();
            this.txtRespuesta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPublicacion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblPregunta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblCancelar
            // 
            this.LblCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblCancelar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblCancelar.ForeColor = System.Drawing.Color.White;
            this.LblCancelar.Location = new System.Drawing.Point(314, 442);
            this.LblCancelar.Name = "LblCancelar";
            this.LblCancelar.Size = new System.Drawing.Size(88, 32);
            this.LblCancelar.TabIndex = 49;
            this.LblCancelar.Text = "CANCELAR";
            this.LblCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblCancelar.Click += new System.EventHandler(this.LblCancelar_Click);
            // 
            // LblResponder
            // 
            this.LblResponder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblResponder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblResponder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblResponder.ForeColor = System.Drawing.Color.White;
            this.LblResponder.Location = new System.Drawing.Point(93, 442);
            this.LblResponder.Name = "LblResponder";
            this.LblResponder.Size = new System.Drawing.Size(88, 32);
            this.LblResponder.TabIndex = 48;
            this.LblResponder.Text = "RESPONDER";
            this.LblResponder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblResponder.Click += new System.EventHandler(this.LblResponder_Click);
            // 
            // txtRespuesta
            // 
            this.txtRespuesta.Location = new System.Drawing.Point(29, 238);
            this.txtRespuesta.Multiline = true;
            this.txtRespuesta.Name = "txtRespuesta";
            this.txtRespuesta.Size = new System.Drawing.Size(446, 166);
            this.txtRespuesta.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "PREGUNTA";
            // 
            // lblPublicacion
            // 
            this.lblPublicacion.AutoSize = true;
            this.lblPublicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPublicacion.Location = new System.Drawing.Point(134, 27);
            this.lblPublicacion.Name = "lblPublicacion";
            this.lblPublicacion.Size = new System.Drawing.Size(0, 13);
            this.lblPublicacion.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "PUBLICACION";
            // 
            // LblPregunta
            // 
            this.LblPregunta.AutoSize = true;
            this.LblPregunta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPregunta.Location = new System.Drawing.Point(29, 101);
            this.LblPregunta.Name = "LblPregunta";
            this.LblPregunta.Size = new System.Drawing.Size(0, 13);
            this.LblPregunta.TabIndex = 50;
            // 
            // FrmResponder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 497);
            this.Controls.Add(this.LblPregunta);
            this.Controls.Add(this.LblCancelar);
            this.Controls.Add(this.LblResponder);
            this.Controls.Add(this.txtRespuesta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPublicacion);
            this.Controls.Add(this.label1);
            this.Name = "FrmResponder";
            this.Text = "FrbaCommerce - Responder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblCancelar;
        private System.Windows.Forms.Label LblResponder;
        private System.Windows.Forms.TextBox txtRespuesta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPublicacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblPregunta;
    }
}