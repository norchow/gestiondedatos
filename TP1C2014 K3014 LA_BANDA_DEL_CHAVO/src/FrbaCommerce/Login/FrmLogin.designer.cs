namespace FrbaCommerce.Login
{
    partial class FrmLogin
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
            this.LblEntrar = new System.Windows.Forms.Label();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.TxtContrasena = new System.Windows.Forms.TextBox();
            this.LblNuevo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblEntrar
            // 
            this.LblEntrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblEntrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblEntrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblEntrar.ForeColor = System.Drawing.Color.White;
            this.LblEntrar.Location = new System.Drawing.Point(97, 134);
            this.LblEntrar.Name = "LblEntrar";
            this.LblEntrar.Size = new System.Drawing.Size(88, 32);
            this.LblEntrar.TabIndex = 0;
            this.LblEntrar.Text = "ENTRAR";
            this.LblEntrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblEntrar.Click += new System.EventHandler(this.LblEntrar_Click);
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUsuario.Location = new System.Drawing.Point(41, 35);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(296, 20);
            this.TxtUsuario.TabIndex = 1;
            // 
            // TxtContrasena
            // 
            this.TxtContrasena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtContrasena.Location = new System.Drawing.Point(41, 86);
            this.TxtContrasena.Name = "TxtContrasena";
            this.TxtContrasena.PasswordChar = '*';
            this.TxtContrasena.Size = new System.Drawing.Size(296, 20);
            this.TxtContrasena.TabIndex = 2;
            this.TxtContrasena.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtContrasena_KeyPress);
            // 
            // LblNuevo
            // 
            this.LblNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblNuevo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblNuevo.ForeColor = System.Drawing.Color.White;
            this.LblNuevo.Location = new System.Drawing.Point(191, 134);
            this.LblNuevo.Name = "LblNuevo";
            this.LblNuevo.Size = new System.Drawing.Size(95, 32);
            this.LblNuevo.TabIndex = 3;
            this.LblNuevo.Text = "REGISTRARME";
            this.LblNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblNuevo.Click += new System.EventHandler(this.LblNuevo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "CONTRASEÑA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "USUARIO";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(372, 186);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblNuevo);
            this.Controls.Add(this.TxtContrasena);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.LblEntrar);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(388, 224);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(388, 224);
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrbaCommerce - Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblEntrar;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.TextBox TxtContrasena;
        private System.Windows.Forms.Label LblNuevo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

