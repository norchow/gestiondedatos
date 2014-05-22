namespace FrbaCommerce.Login
{
    partial class FrmChooseRol
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
            this.LblEntrar = new System.Windows.Forms.Label();
            this.CboRoles = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "ROL A USAR";
            // 
            // LblEntrar
            // 
            this.LblEntrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.LblEntrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblEntrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblEntrar.ForeColor = System.Drawing.Color.White;
            this.LblEntrar.Location = new System.Drawing.Point(140, 107);
            this.LblEntrar.Name = "LblEntrar";
            this.LblEntrar.Size = new System.Drawing.Size(88, 32);
            this.LblEntrar.TabIndex = 6;
            this.LblEntrar.Text = "LISTO";
            this.LblEntrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblEntrar.Click += new System.EventHandler(this.LblEntrar_Click);
            // 
            // CboRoles
            // 
            this.CboRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboRoles.FormattingEnabled = true;
            this.CboRoles.Location = new System.Drawing.Point(43, 43);
            this.CboRoles.Name = "CboRoles";
            this.CboRoles.Size = new System.Drawing.Size(296, 21);
            this.CboRoles.TabIndex = 12;
            // 
            // FrmChooseRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(372, 168);
            this.Controls.Add(this.CboRoles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblEntrar);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(388, 206);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(388, 206);
            this.Name = "FrmChooseRol";
            this.Text = "FrbaCommerce - Elegir rol";
            this.Load += new System.EventHandler(this.FrmChooseRol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblEntrar;
        private System.Windows.Forms.ComboBox CboRoles;
    }
}