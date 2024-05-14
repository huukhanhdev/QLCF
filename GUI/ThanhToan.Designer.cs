namespace GUI
{
    partial class ThanhToan
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
            this.picCK = new System.Windows.Forms.PictureBox();
            this.picTM = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTM)).BeginInit();
            this.SuspendLayout();
            // 
            // picCK
            // 
            this.picCK.Image = global::GUI.Properties.Resources.chuyenkhoan;
            this.picCK.Location = new System.Drawing.Point(394, 113);
            this.picCK.Name = "picCK";
            this.picCK.Size = new System.Drawing.Size(330, 132);
            this.picCK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCK.TabIndex = 1;
            this.picCK.TabStop = false;
            this.picCK.Click += new System.EventHandler(this.picCK_Click);
            // 
            // picTM
            // 
            this.picTM.Image = global::GUI.Properties.Resources.tienmat1;
            this.picTM.Location = new System.Drawing.Point(35, 113);
            this.picTM.Name = "picTM";
            this.picTM.Size = new System.Drawing.Size(315, 132);
            this.picTM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTM.TabIndex = 0;
            this.picTM.TabStop = false;
            this.picTM.Click += new System.EventHandler(this.picTM_Click);
            // 
            // ThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 366);
            this.Controls.Add(this.picTM);
            this.Controls.Add(this.picCK);
            this.Name = "ThanhToan";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picCK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCK;
        private System.Windows.Forms.PictureBox picTM;
    }
}