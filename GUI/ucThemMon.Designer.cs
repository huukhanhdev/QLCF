namespace GUI
{
    partial class ucThemMon
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMaMon = new Krypton.Toolkit.KryptonTextBox();
            this.txtTenMon = new Krypton.Toolkit.KryptonTextBox();
            this.pictureHA = new Krypton.Toolkit.KryptonPictureBox();
            this.btnChonHA = new Krypton.Toolkit.KryptonButton();
            this.btnLuu = new Krypton.Toolkit.KryptonButton();
            this.txtGiaTien = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHA)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaMon
            // 
            this.txtMaMon.Location = new System.Drawing.Point(62, 52);
            this.txtMaMon.Name = "txtMaMon";
            this.txtMaMon.Size = new System.Drawing.Size(100, 27);
            this.txtMaMon.TabIndex = 0;
            this.txtMaMon.Text = "kryptonTextBox1";
            // 
            // txtTenMon
            // 
            this.txtTenMon.Location = new System.Drawing.Point(42, 126);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(100, 27);
            this.txtTenMon.TabIndex = 2;
            this.txtTenMon.Text = "kryptonTextBox2";
            // 
            // pictureHA
            // 
            this.pictureHA.Location = new System.Drawing.Point(252, 126);
            this.pictureHA.Name = "pictureHA";
            this.pictureHA.Size = new System.Drawing.Size(100, 50);
            this.pictureHA.TabIndex = 5;
            this.pictureHA.TabStop = false;
            // 
            // btnChonHA
            // 
            this.btnChonHA.Location = new System.Drawing.Point(252, 192);
            this.btnChonHA.Name = "btnChonHA";
            this.btnChonHA.Size = new System.Drawing.Size(90, 25);
            this.btnChonHA.TabIndex = 6;
            this.btnChonHA.Values.Text = "kryptonButton1";
            this.btnChonHA.Click += new System.EventHandler(this.btnChonHA_Click_1);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(62, 255);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(118, 30);
            this.btnLuu.TabIndex = 7;
            this.btnLuu.Values.Text = "kryptonButton2";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click_1);
            // 
            // txtGiaTien
            // 
            this.txtGiaTien.Location = new System.Drawing.Point(242, 57);
            this.txtGiaTien.Name = "txtGiaTien";
            this.txtGiaTien.Size = new System.Drawing.Size(100, 22);
            this.txtGiaTien.TabIndex = 8;
            // 
            // ucThemMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtGiaTien);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnChonHA);
            this.Controls.Add(this.pictureHA);
            this.Controls.Add(this.txtTenMon);
            this.Controls.Add(this.txtMaMon);
            this.Name = "ucThemMon";
            this.Size = new System.Drawing.Size(436, 329);
            ((System.ComponentModel.ISupportInitialize)(this.pictureHA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonTextBox txtMaMon;
        private Krypton.Toolkit.KryptonTextBox txtTenMon;
        private Krypton.Toolkit.KryptonPictureBox pictureHA;
        private Krypton.Toolkit.KryptonButton btnChonHA;
        private Krypton.Toolkit.KryptonButton btnLuu;
        private System.Windows.Forms.TextBox txtGiaTien;
    }
}
