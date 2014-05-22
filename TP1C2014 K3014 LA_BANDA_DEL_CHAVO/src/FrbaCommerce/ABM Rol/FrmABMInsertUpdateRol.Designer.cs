namespace FrbaCommerce.ABM_Rol
{
    partial class FrmABMInsertUpdateRol
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
            this.TxtRol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LblGrabar = new System.Windows.Forms.Label();
            this.LblCancelar = new System.Windows.Forms.Label();
            this.LstFuncionalidades = new System.Windows.Forms.CheckedListBox();
            this.ChkActivo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "NOMBRE DEL ROL";
            // 
            // TxtRol
            // 
            this.TxtRol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtRol.Location = new System.Drawing.Point(22, 38);
            this.TxtRol.Name = "TxtRol";
            this.TxtRol.Size = new System.Drawing.Size(296, 20);
            this.TxtRol.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "ELIJA LAS FUNCIONALIDADES ASOCIADAS";
            // 
            // LblGrabar
            // 
            this.LblGrabar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblGrabar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblGrabar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblGrabar.ForeColor = System.Drawing.Color.White;
            this.LblGrabar.Location = new System.Drawing.Point(23, 395);
            this.LblGrabar.Name = "LblGrabar";
            this.LblGrabar.Size = new System.Drawing.Size(140, 32);
            this.LblGrabar.TabIndex = 23;
            this.LblGrabar.Text = "GRABAR";
            this.LblGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblGrabar.Click += new System.EventHandler(this.LblGrabar_Click);
            // 
            // LblCancelar
            // 
            this.LblCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblCancelar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblCancelar.ForeColor = System.Drawing.Color.White;
            this.LblCancelar.Location = new System.Drawing.Point(178, 395);
            this.LblCancelar.Name = "LblCancelar";
            this.LblCancelar.Size = new System.Drawing.Size(138, 32);
            this.LblCancelar.TabIndex = 24;
            this.LblCancelar.Text = "CANCELAR";
            this.LblCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblCancelar.Click += new System.EventHandler(this.LblCancelar_Click);
            // 
            // LstFuncionalidades
            // 
            this.LstFuncionalidades.FormattingEnabled = true;
            this.LstFuncionalidades.Location = new System.Drawing.Point(22, 120);
            this.LstFuncionalidades.Name = "LstFuncionalidades";
            this.LstFuncionalidades.Size = new System.Drawing.Size(295, 259);
            this.LstFuncionalidades.TabIndex = 26;
            // 
            // ChkActivo
            // 
            this.ChkActivo.AutoSize = true;
            this.ChkActivo.Location = new System.Drawing.Point(22, 70);
            this.ChkActivo.Name = "ChkActivo";
            this.ChkActivo.Size = new System.Drawing.Size(65, 17);
            this.ChkActivo.TabIndex = 27;
            this.ChkActivo.Text = "ACTIVO";
            this.ChkActivo.UseVisualStyleBackColor = true;
            // 
            // FrmInsertUpdateRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(340, 442);
            this.Controls.Add(this.ChkActivo);
            this.Controls.Add(this.LstFuncionalidades);
            this.Controls.Add(this.LblCancelar);
            this.Controls.Add(this.LblGrabar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtRol);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(356, 480);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(356, 480);
            this.Name = "FrmInsertUpdateRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrbaCommerce";
            this.Load += new System.EventHandler(this.FrmInsertUpdateRol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtRol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblGrabar;
        private System.Windows.Forms.Label LblCancelar;
        private System.Windows.Forms.CheckedListBox LstFuncionalidades;
        private System.Windows.Forms.CheckBox ChkActivo;
    }
}