namespace FrbaCommerce.ABM_Rol
{
    partial class FrmABMRol
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
            this.LblNuevo = new System.Windows.Forms.Label();
            this.LblListo = new System.Windows.Forms.Label();
            this.LstFuncionalidades = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.LblLimpiar = new System.Windows.Forms.Label();
            this.LblBuscar = new System.Windows.Forms.Label();
            this.ChkExacta = new System.Windows.Forms.CheckBox();
            this.DgvRol = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRol)).BeginInit();
            this.SuspendLayout();
            // 
            // LblNuevo
            // 
            this.LblNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblNuevo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblNuevo.ForeColor = System.Drawing.Color.White;
            this.LblNuevo.Location = new System.Drawing.Point(559, 437);
            this.LblNuevo.Name = "LblNuevo";
            this.LblNuevo.Size = new System.Drawing.Size(112, 32);
            this.LblNuevo.TabIndex = 16;
            this.LblNuevo.Text = "NUEVO ROL";
            this.LblNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblNuevo.Click += new System.EventHandler(this.LblNuevo_Click);
            // 
            // LblListo
            // 
            this.LblListo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblListo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblListo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblListo.ForeColor = System.Drawing.Color.White;
            this.LblListo.Location = new System.Drawing.Point(26, 437);
            this.LblListo.Name = "LblListo";
            this.LblListo.Size = new System.Drawing.Size(88, 32);
            this.LblListo.TabIndex = 19;
            this.LblListo.Text = "LISTO";
            this.LblListo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblListo.Click += new System.EventHandler(this.LblListo_Click);
            // 
            // LstFuncionalidades
            // 
            this.LstFuncionalidades.FormattingEnabled = true;
            this.LstFuncionalidades.Location = new System.Drawing.Point(457, 130);
            this.LstFuncionalidades.Name = "LstFuncionalidades";
            this.LstFuncionalidades.Size = new System.Drawing.Size(214, 290);
            this.LstFuncionalidades.TabIndex = 20;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtDescripcion);
            this.groupBox2.Controls.Add(this.LblLimpiar);
            this.groupBox2.Controls.Add(this.LblBuscar);
            this.groupBox2.Controls.Add(this.ChkExacta);
            this.groupBox2.Location = new System.Drawing.Point(26, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(413, 77);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BUSCAR UN ROL";
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Location = new System.Drawing.Point(15, 19);
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(171, 20);
            this.TxtDescripcion.TabIndex = 26;
            // 
            // LblLimpiar
            // 
            this.LblLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblLimpiar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblLimpiar.ForeColor = System.Drawing.Color.White;
            this.LblLimpiar.Location = new System.Drawing.Point(314, 23);
            this.LblLimpiar.Name = "LblLimpiar";
            this.LblLimpiar.Size = new System.Drawing.Size(84, 32);
            this.LblLimpiar.TabIndex = 25;
            this.LblLimpiar.Text = "LIMPIAR";
            this.LblLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblLimpiar.Click += new System.EventHandler(this.LblLimpiar_Click);
            // 
            // LblBuscar
            // 
            this.LblBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblBuscar.ForeColor = System.Drawing.Color.White;
            this.LblBuscar.Location = new System.Drawing.Point(208, 23);
            this.LblBuscar.Name = "LblBuscar";
            this.LblBuscar.Size = new System.Drawing.Size(88, 32);
            this.LblBuscar.TabIndex = 24;
            this.LblBuscar.Text = "BUSCAR";
            this.LblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblBuscar.Click += new System.EventHandler(this.LblBuscar_Click);
            // 
            // ChkExacta
            // 
            this.ChkExacta.AutoSize = true;
            this.ChkExacta.Location = new System.Drawing.Point(55, 45);
            this.ChkExacta.Name = "ChkExacta";
            this.ChkExacta.Size = new System.Drawing.Size(131, 17);
            this.ChkExacta.TabIndex = 24;
            this.ChkExacta.Text = "BUSQUEDA EXACTA";
            this.ChkExacta.UseVisualStyleBackColor = true;
            // 
            // DgvRol
            // 
            this.DgvRol.AllowUserToAddRows = false;
            this.DgvRol.AllowUserToDeleteRows = false;
            this.DgvRol.AllowUserToResizeColumns = false;
            this.DgvRol.AllowUserToResizeRows = false;
            this.DgvRol.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DgvRol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvRol.Location = new System.Drawing.Point(26, 104);
            this.DgvRol.MultiSelect = false;
            this.DgvRol.Name = "DgvRol";
            this.DgvRol.RowHeadersVisible = false;
            this.DgvRol.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvRol.Size = new System.Drawing.Size(413, 317);
            this.DgvRol.TabIndex = 33;
            this.DgvRol.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRol_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(457, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "FUNCIONALIDADES ASOCIADAS";
            // 
            // FrmABMRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(691, 490);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LstFuncionalidades);
            this.Controls.Add(this.DgvRol);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.LblListo);
            this.Controls.Add(this.LblNuevo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmABMRol";
            this.Text = "FrbaCommerce - Administracion de Roles";
            this.Load += new System.EventHandler(this.FrmABMRol_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblNuevo;
        private System.Windows.Forms.Label LblListo;
        private System.Windows.Forms.ListBox LstFuncionalidades;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Label LblLimpiar;
        private System.Windows.Forms.Label LblBuscar;
        private System.Windows.Forms.CheckBox ChkExacta;
        private System.Windows.Forms.DataGridView DgvRol;
        private System.Windows.Forms.Label label1;
    }
}