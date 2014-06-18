namespace FrbaCommerce.Registro_de_Usuario
{
    partial class FrmAdministrarUsuarios
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
            this.cboUsuarios = new System.Windows.Forms.ComboBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.lblCambiarPassword = new System.Windows.Forms.Label();
            this.lblVolver = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboUsuarios
            // 
            this.cboUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsuarios.FormattingEnabled = true;
            this.cboUsuarios.Location = new System.Drawing.Point(27, 29);
            this.cboUsuarios.Name = "cboUsuarios";
            this.cboUsuarios.Size = new System.Drawing.Size(225, 21);
            this.cboUsuarios.TabIndex = 0;
            this.cboUsuarios.SelectedIndexChanged += new System.EventHandler(this.cboUsuarios_SelectedIndexChanged);
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Location = new System.Drawing.Point(269, 31);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(56, 17);
            this.chkActivo.TabIndex = 1;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            this.chkActivo.CheckedChanged += new System.EventHandler(this.chkActivo_CheckedChanged);
            // 
            // lblCambiarPassword
            // 
            this.lblCambiarPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblCambiarPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCambiarPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCambiarPassword.ForeColor = System.Drawing.Color.White;
            this.lblCambiarPassword.Location = new System.Drawing.Point(38, 85);
            this.lblCambiarPassword.Name = "lblCambiarPassword";
            this.lblCambiarPassword.Size = new System.Drawing.Size(141, 32);
            this.lblCambiarPassword.TabIndex = 7;
            this.lblCambiarPassword.Text = "CAMBIAR CONTRASEÑA";
            this.lblCambiarPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCambiarPassword.Click += new System.EventHandler(this.lblCambiarPassword_Click);
            // 
            // lblVolver
            // 
            this.lblVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblVolver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblVolver.ForeColor = System.Drawing.Color.White;
            this.lblVolver.Location = new System.Drawing.Point(237, 85);
            this.lblVolver.Name = "lblVolver";
            this.lblVolver.Size = new System.Drawing.Size(68, 32);
            this.lblVolver.TabIndex = 8;
            this.lblVolver.Text = "VOLVER";
            this.lblVolver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVolver.Click += new System.EventHandler(this.lblVolver_Click);
            // 
            // FrmAdministrarUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 154);
            this.Controls.Add(this.lblVolver);
            this.Controls.Add(this.lblCambiarPassword);
            this.Controls.Add(this.chkActivo);
            this.Controls.Add(this.cboUsuarios);
            this.Name = "FrmAdministrarUsuarios";
            this.Text = "FrbaCommerce";
            this.Load += new System.EventHandler(this.FrmAdministrarUsuarios_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboUsuarios;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Label lblCambiarPassword;
        private System.Windows.Forms.Label lblVolver;
    }
}