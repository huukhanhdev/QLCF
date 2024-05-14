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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucThemMon));
            this.bunifuGradientPanel1 = new Bunifu.UI.WinForms.BunifuGradientPanel();
            this.bunifuGroupBox2 = new Bunifu.UI.WinForms.BunifuGroupBox();
            this.pictureHA = new Krypton.Toolkit.KryptonPictureBox();
            this.btnChonHA = new Krypton.Toolkit.KryptonButton();
            this.btnHuy = new Krypton.Toolkit.KryptonButton();
            this.labelHinhAnh = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.txtGiaTien = new System.Windows.Forms.TextBox();
            this.btnLuu = new Krypton.Toolkit.KryptonButton();
            this.txtTenMon = new Krypton.Toolkit.KryptonTextBox();
            this.txtMaMon = new Krypton.Toolkit.KryptonTextBox();
            this.bunifuGroupBox1 = new Bunifu.UI.WinForms.BunifuGroupBox();
            this.bunifuGradientPanel1.SuspendLayout();
            this.bunifuGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHA)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.BorderRadius = 1;
            this.bunifuGradientPanel1.Controls.Add(this.bunifuGroupBox2);
            this.bunifuGradientPanel1.Controls.Add(this.btnHuy);
            this.bunifuGradientPanel1.Controls.Add(this.labelHinhAnh);
            this.bunifuGradientPanel1.Controls.Add(this.kryptonLabel3);
            this.bunifuGradientPanel1.Controls.Add(this.kryptonLabel2);
            this.bunifuGradientPanel1.Controls.Add(this.kryptonLabel1);
            this.bunifuGradientPanel1.Controls.Add(this.txtGiaTien);
            this.bunifuGradientPanel1.Controls.Add(this.btnLuu);
            this.bunifuGradientPanel1.Controls.Add(this.txtTenMon);
            this.bunifuGradientPanel1.Controls.Add(this.txtMaMon);
            this.bunifuGradientPanel1.Controls.Add(this.bunifuGroupBox1);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(92)))), ((int)(((byte)(188)))));
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.DeepPink;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.DodgerBlue;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(60)))), ((int)(((byte)(212)))));
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(871, 509);
            this.bunifuGradientPanel1.TabIndex = 0;
            // 
            // bunifuGroupBox2
            // 
            this.bunifuGroupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bunifuGroupBox2.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.bunifuGroupBox2.BorderRadius = 1;
            this.bunifuGroupBox2.BorderThickness = 1;
            this.bunifuGroupBox2.Controls.Add(this.pictureHA);
            this.bunifuGroupBox2.Controls.Add(this.btnChonHA);
            this.bunifuGroupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuGroupBox2.LabelAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuGroupBox2.LabelIndent = 10;
            this.bunifuGroupBox2.LineStyle = Bunifu.UI.WinForms.BunifuGroupBox.LineStyles.Solid;
            this.bunifuGroupBox2.Location = new System.Drawing.Point(396, 36);
            this.bunifuGroupBox2.Name = "bunifuGroupBox2";
            this.bunifuGroupBox2.Size = new System.Drawing.Size(457, 444);
            this.bunifuGroupBox2.TabIndex = 45;
            this.bunifuGroupBox2.TabStop = false;
            // 
            // pictureHA
            // 
            this.pictureHA.Location = new System.Drawing.Point(20, 81);
            this.pictureHA.Name = "pictureHA";
            this.pictureHA.Size = new System.Drawing.Size(413, 245);
            this.pictureHA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureHA.TabIndex = 36;
            this.pictureHA.TabStop = false;
            // 
            // btnChonHA
            // 
            this.btnChonHA.Location = new System.Drawing.Point(173, 363);
            this.btnChonHA.Name = "btnChonHA";
            this.btnChonHA.Size = new System.Drawing.Size(90, 25);
            this.btnChonHA.TabIndex = 37;
            this.btnChonHA.Values.Text = "Tải ảnh lên";
            this.btnChonHA.Click += new System.EventHandler(this.btnChonHA_Click_1);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(222, 418);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(118, 30);
            this.btnHuy.TabIndex = 44;
            this.btnHuy.Values.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // labelHinhAnh
            // 
            this.labelHinhAnh.Location = new System.Drawing.Point(446, 61);
            this.labelHinhAnh.Name = "labelHinhAnh";
            this.labelHinhAnh.Size = new System.Drawing.Size(172, 27);
            this.labelHinhAnh.StateCommon.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHinhAnh.TabIndex = 43;
            this.labelHinhAnh.Values.Text = "Hình ảnh minh họa";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(33, 277);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(64, 24);
            this.kryptonLabel3.TabIndex = 42;
            this.kryptonLabel3.Values.Text = "Giá tiền";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(33, 209);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(72, 24);
            this.kryptonLabel2.TabIndex = 41;
            this.kryptonLabel2.Values.Text = "Tên món";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(33, 138);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(104, 24);
            this.kryptonLabel1.TabIndex = 40;
            this.kryptonLabel1.Values.Text = "Mã sản phẩm";
            // 
            // txtGiaTien
            // 
            this.txtGiaTien.Location = new System.Drawing.Point(171, 277);
            this.txtGiaTien.Name = "txtGiaTien";
            this.txtGiaTien.Size = new System.Drawing.Size(100, 22);
            this.txtGiaTien.TabIndex = 39;
            this.txtGiaTien.TextChanged += new System.EventHandler(this.txtGiaTien_TextChanged);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(73, 418);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(118, 30);
            this.btnLuu.TabIndex = 38;
            this.btnLuu.Values.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click_1);
            // 
            // txtTenMon
            // 
            this.txtTenMon.Location = new System.Drawing.Point(171, 209);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(100, 27);
            this.txtTenMon.TabIndex = 35;
            // 
            // txtMaMon
            // 
            this.txtMaMon.Location = new System.Drawing.Point(171, 138);
            this.txtMaMon.Name = "txtMaMon";
            this.txtMaMon.Size = new System.Drawing.Size(100, 27);
            this.txtMaMon.TabIndex = 34;
            // 
            // bunifuGroupBox1
            // 
            this.bunifuGroupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bunifuGroupBox1.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.bunifuGroupBox1.BorderRadius = 1;
            this.bunifuGroupBox1.BorderThickness = 1;
            this.bunifuGroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuGroupBox1.LabelAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuGroupBox1.LabelIndent = 10;
            this.bunifuGroupBox1.LineStyle = Bunifu.UI.WinForms.BunifuGroupBox.LineStyles.Solid;
            this.bunifuGroupBox1.Location = new System.Drawing.Point(14, 36);
            this.bunifuGroupBox1.Name = "bunifuGroupBox1";
            this.bunifuGroupBox1.Size = new System.Drawing.Size(396, 444);
            this.bunifuGroupBox1.TabIndex = 0;
            this.bunifuGroupBox1.TabStop = false;
            this.bunifuGroupBox1.Text = "Thông tin sản phẩm";
            // 
            // ucThemMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bunifuGradientPanel1);
            this.Name = "ucThemMon";
            this.Size = new System.Drawing.Size(871, 509);
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            this.bunifuGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureHA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuGradientPanel bunifuGradientPanel1;
        private Bunifu.UI.WinForms.BunifuGroupBox bunifuGroupBox2;
        private Krypton.Toolkit.KryptonPictureBox pictureHA;
        private Krypton.Toolkit.KryptonButton btnChonHA;
        private Krypton.Toolkit.KryptonButton btnHuy;
        private Krypton.Toolkit.KryptonLabel labelHinhAnh;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.TextBox txtGiaTien;
        private Krypton.Toolkit.KryptonButton btnLuu;
        private Krypton.Toolkit.KryptonTextBox txtTenMon;
        private Krypton.Toolkit.KryptonTextBox txtMaMon;
        private Bunifu.UI.WinForms.BunifuGroupBox bunifuGroupBox1;
    }
}
