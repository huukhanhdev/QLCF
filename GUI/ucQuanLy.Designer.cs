namespace GUI
{
    partial class ucQuanLy
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
            this.panelQL = new Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.btnQLNV = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelQL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelQL
            // 
            this.panelQL.Location = new System.Drawing.Point(3, 122);
            this.panelQL.Name = "panelQL";
            this.panelQL.Size = new System.Drawing.Size(1279, 410);
            this.panelQL.TabIndex = 0;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonButton2);
            this.kryptonPanel2.Controls.Add(this.btnQLNV);
            this.kryptonPanel2.Location = new System.Drawing.Point(3, 15);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(1279, 101);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Location = new System.Drawing.Point(806, 27);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(172, 45);
            this.kryptonButton2.TabIndex = 1;
            this.kryptonButton2.Values.Text = "Quản lí khách hàng";
            // 
            // btnQLNV
            // 
            this.btnQLNV.Location = new System.Drawing.Point(255, 27);
            this.btnQLNV.Name = "btnQLNV";
            this.btnQLNV.Size = new System.Drawing.Size(172, 45);
            this.btnQLNV.TabIndex = 0;
            this.btnQLNV.Values.Text = "Quản lí nhân viên";
            this.btnQLNV.Click += new System.EventHandler(this.btnQLNV_Click);
            // 
            // ucQuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panelQL);
            this.Name = "ucQuanLy";
            this.Size = new System.Drawing.Size(1282, 532);
            ((System.ComponentModel.ISupportInitialize)(this.panelQL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel panelQL;
        private Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private Krypton.Toolkit.KryptonButton kryptonButton2;
        private Krypton.Toolkit.KryptonButton btnQLNV;
    }
}
