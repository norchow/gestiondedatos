namespace FrbaCommerce.Gestion_de_Preguntas
{
    partial class FrmResponderPreguntas
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
            this.DgvPreguntas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPreguntas)).BeginInit();
            this.SuspendLayout();
            // 
            // LblListo
            // 
            this.LblListo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblListo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblListo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblListo.ForeColor = System.Drawing.Color.White;
            this.LblListo.Location = new System.Drawing.Point(394, 348);
            this.LblListo.Name = "LblListo";
            this.LblListo.Size = new System.Drawing.Size(88, 32);
            this.LblListo.TabIndex = 37;
            this.LblListo.Text = "LISTO";
            this.LblListo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblListo.Click += new System.EventHandler(this.LblListo_Click);
            // 
            // DgvPreguntas
            // 
            this.DgvPreguntas.AllowUserToAddRows = false;
            this.DgvPreguntas.AllowUserToDeleteRows = false;
            this.DgvPreguntas.AllowUserToResizeColumns = false;
            this.DgvPreguntas.AllowUserToResizeRows = false;
            this.DgvPreguntas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DgvPreguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPreguntas.Location = new System.Drawing.Point(12, 12);
            this.DgvPreguntas.MultiSelect = false;
            this.DgvPreguntas.Name = "DgvPreguntas";
            this.DgvPreguntas.RowHeadersVisible = false;
            this.DgvPreguntas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPreguntas.Size = new System.Drawing.Size(868, 323);
            this.DgvPreguntas.TabIndex = 36;
            this.DgvPreguntas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPreguntas_CellContentClick);
            // 
            // FrmResponderPreguntas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 396);
            this.Controls.Add(this.LblListo);
            this.Controls.Add(this.DgvPreguntas);
            this.Name = "FrmResponderPreguntas";
            this.Text = "FrbaCommerce - Responder preguntas";
            this.Load += new System.EventHandler(this.FrmResponderPreguntas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPreguntas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblListo;
        private System.Windows.Forms.DataGridView DgvPreguntas;
    }
}