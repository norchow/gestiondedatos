namespace FrbaCommerce.Login
{
    partial class FrmResetPassword
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
            this.TxtContrasenaRepetida = new System.Windows.Forms.TextBox();
            this.TxtContrasena = new System.Windows.Forms.TextBox();
            this.LblAceptar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "NUEVA CONTRASEÑA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "REPETIR NUEVA CONTRASEÑA";
            // 
            // TxtContrasenaRepetida
            // 
            this.TxtContrasenaRepetida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtContrasenaRepetida.Location = new System.Drawing.Point(37, 97);
            this.TxtContrasenaRepetida.Name = "TxtContrasenaRepetida";
            this.TxtContrasenaRepetida.PasswordChar = '*';
            this.TxtContrasenaRepetida.Size = new System.Drawing.Size(296, 20);
            this.TxtContrasenaRepetida.TabIndex = 8;
            // 
            // TxtContrasena
            // 
            this.TxtContrasena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtContrasena.Location = new System.Drawing.Point(37, 46);
            this.TxtContrasena.Name = "TxtContrasena";
            this.TxtContrasena.PasswordChar = '*';
            this.TxtContrasena.Size = new System.Drawing.Size(296, 20);
            this.TxtContrasena.TabIndex = 7;
            // 
            // LblAceptar
            // 
            this.LblAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblAceptar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblAceptar.ForeColor = System.Drawing.Color.White;
            this.LblAceptar.Location = new System.Drawing.Point(132, 144);
            this.LblAceptar.Name = "LblAceptar";
            this.LblAceptar.Size = new System.Drawing.Size(88, 32);
            this.LblAceptar.TabIndex = 6;
            this.LblAceptar.Text = "ACEPTAR";
            this.LblAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblAceptar.Click += new System.EventHandler(this.LblAceptar_Click);
            // 
            // FrmResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(367, 202);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtContrasenaRepetida);
            this.Controls.Add(this.TxtContrasena);
            this.Controls.Add(this.LblAceptar);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(383, 240);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(383, 240);
            this.Name = "FrmResetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrbaCommerce - Resetear contrasena";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtContrasenaRepetida;
        private System.Windows.Forms.TextBox TxtContrasena;
        private System.Windows.Forms.Label LblAceptar;
    }
}