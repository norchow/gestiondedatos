namespace FrbaCommerce.Registro_de_Usuario
{
    partial class FrmRegistroUsuario
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
            this.label2 = new System.Windows.Forms.Label();
            this.TxtContrasena = new System.Windows.Forms.TextBox();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.CboRoles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LblCancelar = new System.Windows.Forms.Label();
            this.LblGrabar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "USUARIO *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "CONTRASEÑA *";
            // 
            // TxtContrasena
            // 
            this.TxtContrasena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtContrasena.Location = new System.Drawing.Point(12, 81);
            this.TxtContrasena.Name = "TxtContrasena";
            this.TxtContrasena.PasswordChar = '*';
            this.TxtContrasena.Size = new System.Drawing.Size(296, 20);
            this.TxtContrasena.TabIndex = 8;
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUsuario.Location = new System.Drawing.Point(12, 30);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(296, 20);
            this.TxtUsuario.TabIndex = 7;
            // 
            // CboRoles
            // 
            this.CboRoles.FormattingEnabled = true;
            this.CboRoles.Location = new System.Drawing.Point(12, 132);
            this.CboRoles.Name = "CboRoles";
            this.CboRoles.Size = new System.Drawing.Size(296, 21);
            this.CboRoles.TabIndex = 12;
            this.CboRoles.SelectedIndexChanged += new System.EventHandler(this.CboRoles_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "ROL *";
            // 
            // LblCancelar
            // 
            this.LblCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblCancelar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblCancelar.ForeColor = System.Drawing.Color.White;
            this.LblCancelar.Location = new System.Drawing.Point(170, 184);
            this.LblCancelar.Name = "LblCancelar";
            this.LblCancelar.Size = new System.Drawing.Size(138, 32);
            this.LblCancelar.TabIndex = 60;
            this.LblCancelar.Text = "CANCELAR";
            this.LblCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblCancelar.Click += new System.EventHandler(this.LblCancelar_Click);
            // 
            // LblGrabar
            // 
            this.LblGrabar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblGrabar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblGrabar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblGrabar.ForeColor = System.Drawing.Color.White;
            this.LblGrabar.Location = new System.Drawing.Point(15, 184);
            this.LblGrabar.Name = "LblGrabar";
            this.LblGrabar.Size = new System.Drawing.Size(140, 32);
            this.LblGrabar.TabIndex = 59;
            this.LblGrabar.Text = "GRABAR";
            this.LblGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblGrabar.Click += new System.EventHandler(this.LblGrabar_Click);
            // 
            // FrmRegistroUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 241);
            this.Controls.Add(this.LblCancelar);
            this.Controls.Add(this.LblGrabar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CboRoles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtContrasena);
            this.Controls.Add(this.TxtUsuario);
            this.Name = "FrmRegistroUsuario";
            this.Text = "FrbaCommerce - Registro de usuario";
            this.Load += new System.EventHandler(this.FrmRegistroUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtContrasena;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.ComboBox CboRoles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblCancelar;
        private System.Windows.Forms.Label LblGrabar;
    }
}