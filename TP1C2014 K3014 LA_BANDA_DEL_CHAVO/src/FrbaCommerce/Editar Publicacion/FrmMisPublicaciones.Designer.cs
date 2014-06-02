namespace FrbaCommerce.Editar_Publicacion
{
    partial class FrmMisPublicaciones
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
            this.DgvPublicacion = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblListo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPublicacion)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvPublicacion
            // 
            this.DgvPublicacion.AllowUserToAddRows = false;
            this.DgvPublicacion.AllowUserToDeleteRows = false;
            this.DgvPublicacion.AllowUserToResizeColumns = false;
            this.DgvPublicacion.AllowUserToResizeRows = false;
            this.DgvPublicacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DgvPublicacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPublicacion.Location = new System.Drawing.Point(12, 118);
            this.DgvPublicacion.MultiSelect = false;
            this.DgvPublicacion.Name = "DgvPublicacion";
            this.DgvPublicacion.RowHeadersVisible = false;
            this.DgvPublicacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPublicacion.Size = new System.Drawing.Size(868, 323);
            this.DgvPublicacion.TabIndex = 33;
            this.DgvPublicacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPublicacion_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(868, 87);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTROS DE BUSQUEDA";
            // 
            // LblListo
            // 
            this.LblListo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblListo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblListo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblListo.ForeColor = System.Drawing.Color.White;
            this.LblListo.Location = new System.Drawing.Point(402, 455);
            this.LblListo.Name = "LblListo";
            this.LblListo.Size = new System.Drawing.Size(88, 32);
            this.LblListo.TabIndex = 35;
            this.LblListo.Text = "LISTO";
            this.LblListo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblListo.Click += new System.EventHandler(this.LblListo_Click);
            // 
            // FrmMisPublicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(896, 501);
            this.Controls.Add(this.LblListo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DgvPublicacion);
            this.Name = "FrmMisPublicaciones";
            this.Text = "FrbaCommerce - Mis publicaciones";
            this.Load += new System.EventHandler(this.MisPublicaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPublicacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvPublicacion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LblListo;
    }
}