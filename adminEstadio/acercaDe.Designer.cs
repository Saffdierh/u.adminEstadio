namespace adminEstadio
{
    partial class acercaDe
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.productName = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.Label();
            this.copyright = new System.Windows.Forms.Label();
            this.companyName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::adminEstadio.Properties.Resources._112481;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 193);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // productName
            // 
            this.productName.AutoSize = true;
            this.productName.Location = new System.Drawing.Point(239, 32);
            this.productName.Name = "productName";
            this.productName.Size = new System.Drawing.Size(93, 13);
            this.productName.TabIndex = 1;
            this.productName.Text = "Control de Estadio";
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Location = new System.Drawing.Point(239, 74);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(60, 13);
            this.version.TabIndex = 1;
            this.version.Text = "Versión 1,0";
            // 
            // copyright
            // 
            this.copyright.AutoSize = true;
            this.copyright.Location = new System.Drawing.Point(239, 116);
            this.copyright.Name = "copyright";
            this.copyright.Size = new System.Drawing.Size(51, 13);
            this.copyright.TabIndex = 1;
            this.copyright.Text = "Copyright";
            // 
            // companyName
            // 
            this.companyName.AutoSize = true;
            this.companyName.Location = new System.Drawing.Point(239, 159);
            this.companyName.Name = "companyName";
            this.companyName.Size = new System.Drawing.Size(74, 13);
            this.companyName.TabIndex = 1;
            this.companyName.Text = "Estadio Hogar";
            // 
            // acercaDe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 213);
            this.Controls.Add(this.companyName);
            this.Controls.Add(this.copyright);
            this.Controls.Add(this.version);
            this.Controls.Add(this.productName);
            this.Controls.Add(this.pictureBox1);
            this.Name = "acercaDe";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label productName;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.Label copyright;
        private System.Windows.Forms.Label companyName;
    }
}