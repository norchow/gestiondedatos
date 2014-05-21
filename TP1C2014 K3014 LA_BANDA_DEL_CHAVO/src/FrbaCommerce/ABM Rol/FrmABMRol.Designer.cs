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
            this.CboRoles = new System.Windows.Forms.ComboBox();
            this.LblNuevo = new System.Windows.Forms.Label();
            this.LblEliminar = new System.Windows.Forms.Label();
            this.LblModificar = new System.Windows.Forms.Label();
            this.LblListo = new System.Windows.Forms.Label();
            this.LstFuncionalidades = new System.Windows.Forms.ListBox();
            this.ChkActivo = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LblBuscar = new System.Windows.Forms.Label();
            this.LblLimpiar = new System.Windows.Forms.Label();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.ChkExacta = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CboRoles
            // 
            this.CboRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboRoles.FormattingEnabled = true;
            this.CboRoles.Location = new System.Drawing.Point(24, 120);
            this.CboRoles.Name = "CboRoles";
            this.CboRoles.Size = new System.Drawing.Size(312, 21);
            this.CboRoles.TabIndex = 13;
            this.CboRoles.SelectedIndexChanged += new System.EventHandler(this.CboRoles_SelectedIndexChanged);
            // 
            // LblNuevo
            // 
            this.LblNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.LblNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblNuevo.ForeColor = System.Drawing.Color.White;
            this.LblNuevo.Location = new System.Drawing.Point(23, 490);
            this.LblNuevo.Name = "LblNuevo";
            this.LblNuevo.Size = new System.Drawing.Size(88, 32);
            this.LblNuevo.TabIndex = 16;
            this.LblNuevo.Text = "NUEVO";
            this.LblNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblNuevo.Click += new System.EventHandler(this.LblNuevo_Click);
            // 
            // LblEliminar
            // 
            this.LblEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.LblEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblEliminar.ForeColor = System.Drawing.Color.White;
            this.LblEliminar.Location = new System.Drawing.Point(232, 490);
            this.LblEliminar.Name = "LblEliminar";
            this.LblEliminar.Size = new System.Drawing.Size(88, 32);
            this.LblEliminar.TabIndex = 17;
            this.LblEliminar.Text = "ELIMINAR";
            this.LblEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblEliminar.Click += new System.EventHandler(this.LblEliminar_Click);
            // 
            // LblModificar
            // 
            this.LblModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.LblModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblModificar.ForeColor = System.Drawing.Color.White;
            this.LblModificar.Location = new System.Drawing.Point(128, 490);
            this.LblModificar.Name = "LblModificar";
            this.LblModificar.Size = new System.Drawing.Size(88, 32);
            this.LblModificar.TabIndex = 18;
            this.LblModificar.Text = "MODIFICAR";
            this.LblModificar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblModificar.Click += new System.EventHandler(this.LblModificar_Click);
            // 
            // LblListo
            // 
            this.LblListo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.LblListo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblListo.ForeColor = System.Drawing.Color.White;
            this.LblListo.Location = new System.Drawing.Point(128, 543);
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
            this.LstFuncionalidades.Location = new System.Drawing.Point(18, 22);
            this.LstFuncionalidades.Name = "LstFuncionalidades";
            this.LstFuncionalidades.Size = new System.Drawing.Size(277, 264);
            this.LstFuncionalidades.TabIndex = 20;
            // 
            // ChkActivo
            // 
            this.ChkActivo.AutoSize = true;
            this.ChkActivo.Enabled = false;
            this.ChkActivo.Location = new System.Drawing.Point(24, 149);
            this.ChkActivo.Name = "ChkActivo";
            this.ChkActivo.Size = new System.Drawing.Size(65, 17);
            this.ChkActivo.TabIndex = 21;
            this.ChkActivo.Text = "ACTIVO";
            this.ChkActivo.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LstFuncionalidades);
            this.groupBox1.Location = new System.Drawing.Point(24, 175);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 300);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FUNCIONALIDADES";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtBuscar);
            this.groupBox2.Controls.Add(this.LblLimpiar);
            this.groupBox2.Controls.Add(this.LblBuscar);
            this.groupBox2.Controls.Add(this.ChkExacta);
            this.groupBox2.Location = new System.Drawing.Point(26, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(310, 77);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BUSCAR UN ROL";
            // 
            // LblBuscar
            // 
            this.LblBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.LblBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblBuscar.ForeColor = System.Drawing.Color.White;
            this.LblBuscar.Location = new System.Drawing.Point(60, 47);
            this.LblBuscar.Name = "LblBuscar";
            this.LblBuscar.Size = new System.Drawing.Size(88, 21);
            this.LblBuscar.TabIndex = 24;
            this.LblBuscar.Text = "BUSCAR";
            this.LblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblBuscar.Click += new System.EventHandler(this.LblBuscar_Click);
            // 
            // LblLimpiar
            // 
            this.LblLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.LblLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblLimpiar.ForeColor = System.Drawing.Color.White;
            this.LblLimpiar.Location = new System.Drawing.Point(164, 47);
            this.LblLimpiar.Name = "LblLimpiar";
            this.LblLimpiar.Size = new System.Drawing.Size(88, 21);
            this.LblLimpiar.TabIndex = 25;
            this.LblLimpiar.Text = "LIMPIAR";
            this.LblLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblLimpiar.Click += new System.EventHandler(this.LblLimpiar_Click);
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Location = new System.Drawing.Point(15, 19);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(141, 20);
            this.TxtBuscar.TabIndex = 26;
            // 
            // ChkExacta
            // 
            this.ChkExacta.AutoSize = true;
            this.ChkExacta.Location = new System.Drawing.Point(162, 21);
            this.ChkExacta.Name = "ChkExacta";
            this.ChkExacta.Size = new System.Drawing.Size(131, 17);
            this.ChkExacta.TabIndex = 24;
            this.ChkExacta.Text = "BUSQUEDA EXACTA";
            this.ChkExacta.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "SELECCIONE UN ROL";
            // 
            // FrmABMRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.ClientSize = new System.Drawing.Size(357, 594);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CboRoles);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ChkActivo);
            this.Controls.Add(this.LblListo);
            this.Controls.Add(this.LblModificar);
            this.Controls.Add(this.LblEliminar);
            this.Controls.Add(this.LblNuevo);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(373, 632);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(373, 632);
            this.Name = "FrmABMRol";
            this.Text = "FrbaCommerce - Administracion de Roles";
            this.Load += new System.EventHandler(this.FrmABMRol_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CboRoles;
        private System.Windows.Forms.Label LblNuevo;
        private System.Windows.Forms.Label LblEliminar;
        private System.Windows.Forms.Label LblModificar;
        private System.Windows.Forms.Label LblListo;
        private System.Windows.Forms.ListBox LstFuncionalidades;
        private System.Windows.Forms.CheckBox ChkActivo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.Label LblLimpiar;
        private System.Windows.Forms.Label LblBuscar;
        private System.Windows.Forms.CheckBox ChkExacta;
        private System.Windows.Forms.Label label3;
    }
}