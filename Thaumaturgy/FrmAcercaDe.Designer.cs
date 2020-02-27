namespace Thaumaturgy
{
    partial class FrmAcercaDe
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
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.LblNombre = new System.Windows.Forms.Label();
            this.LblCopyright = new System.Windows.Forms.Label();
            this.LblVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(197, 125);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(75, 23);
            this.BtnAceptar.TabIndex = 0;
            this.BtnAceptar.Text = "&Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // LblNombre
            // 
            this.LblNombre.AutoSize = true;
            this.LblNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombre.Location = new System.Drawing.Point(12, 9);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(104, 30);
            this.LblNombre.TabIndex = 1;
            this.LblNombre.Text = "Producto";
            // 
            // LblCopyright
            // 
            this.LblCopyright.AutoSize = true;
            this.LblCopyright.Location = new System.Drawing.Point(14, 54);
            this.LblCopyright.Name = "LblCopyright";
            this.LblCopyright.Size = new System.Drawing.Size(51, 13);
            this.LblCopyright.TabIndex = 2;
            this.LblCopyright.Text = "Copyright";
            // 
            // LblVersion
            // 
            this.LblVersion.AutoSize = true;
            this.LblVersion.Location = new System.Drawing.Point(14, 77);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(42, 13);
            this.LblVersion.TabIndex = 3;
            this.LblVersion.Text = "Versión";
            // 
            // FrmAcercaDe
            // 
            this.AcceptButton = this.BtnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 160);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.LblCopyright);
            this.Controls.Add(this.LblNombre);
            this.Controls.Add(this.BtnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAcercaDe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Acerca de";
            this.Load += new System.EventHandler(this.FrmAcercaDe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Label LblNombre;
        private System.Windows.Forms.Label LblCopyright;
        private System.Windows.Forms.Label LblVersion;
    }
}