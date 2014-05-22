namespace FrbaCommerce.Home
{
    partial class FrmHome
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
            this.btnCalificarVendedor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCalificarVendedor
            // 
            this.btnCalificarVendedor.Location = new System.Drawing.Point(28, 45);
            this.btnCalificarVendedor.Name = "btnCalificarVendedor";
            this.btnCalificarVendedor.Size = new System.Drawing.Size(141, 41);
            this.btnCalificarVendedor.TabIndex = 0;
            this.btnCalificarVendedor.Text = "Calificar Vendedor";
            this.btnCalificarVendedor.UseVisualStyleBackColor = true;
            this.btnCalificarVendedor.Click += new System.EventHandler(this.btnCalificarVendedor_Click);
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnCalificarVendedor);
            this.Name = "FrmHome";
            this.Text = "FrmHome";
            this.Load += new System.EventHandler(this.FrmHome_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCalificarVendedor;
    }
}