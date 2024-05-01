namespace GUI
{
    partial class ucQuanLyNV
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
            this.dataGridViewNV = new Krypton.Toolkit.KryptonDataGridView();
            this.txtMaDinhDanh = new Krypton.Toolkit.KryptonTextBox();
            this.dtpNgaySinh = new Krypton.Toolkit.KryptonDateTimePicker();
            this.txtTenNV = new Krypton.Toolkit.KryptonTextBox();
            this.txtGioiTinh = new Krypton.Toolkit.KryptonTextBox();
            this.txtDiaChi = new Krypton.Toolkit.KryptonTextBox();
            this.txtSDT = new Krypton.Toolkit.KryptonTextBox();
            this.txtChucVu = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.btnThem = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewNV
            // 
            this.dataGridViewNV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewNV.ColumnHeadersHeight = 36;
            this.dataGridViewNV.Location = new System.Drawing.Point(3, 203);
            this.dataGridViewNV.Name = "dataGridViewNV";
            this.dataGridViewNV.RowHeadersWidth = 51;
            this.dataGridViewNV.RowTemplate.Height = 24;
            this.dataGridViewNV.Size = new System.Drawing.Size(1242, 207);
            this.dataGridViewNV.TabIndex = 0;
            this.dataGridViewNV.SelectionChanged += new System.EventHandler(this.dataGridViewNV_SelectionChanged);
            // 
            // txtMaDinhDanh
            // 
            this.txtMaDinhDanh.Location = new System.Drawing.Point(3, 18);
            this.txtMaDinhDanh.Name = "txtMaDinhDanh";
            this.txtMaDinhDanh.Size = new System.Drawing.Size(100, 27);
            this.txtMaDinhDanh.TabIndex = 8;
            this.txtMaDinhDanh.Text = "kryptonTextBox1";
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.CalendarTodayDate = new System.DateTime(2024, 4, 23, 0, 0, 0, 0);
            this.dtpNgaySinh.Location = new System.Drawing.Point(214, 20);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(276, 25);
            this.dtpNgaySinh.TabIndex = 12;
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(3, 69);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(100, 27);
            this.txtTenNV.TabIndex = 9;
            this.txtTenNV.Text = "txtTenNV";
            // 
            // txtGioiTinh
            // 
            this.txtGioiTinh.Location = new System.Drawing.Point(3, 121);
            this.txtGioiTinh.Name = "txtGioiTinh";
            this.txtGioiTinh.Size = new System.Drawing.Size(100, 27);
            this.txtGioiTinh.TabIndex = 10;
            this.txtGioiTinh.Text = "txtGioiTinh";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(241, 121);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(311, 27);
            this.txtDiaChi.TabIndex = 14;
            this.txtDiaChi.Text = "txtDiaChi";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(241, 69);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(142, 27);
            this.txtSDT.TabIndex = 13;
            this.txtSDT.Text = "txtSDT";
            // 
            // txtChucVu
            // 
            this.txtChucVu.Location = new System.Drawing.Point(3, 204);
            this.txtChucVu.Name = "txtChucVu";
            this.txtChucVu.Size = new System.Drawing.Size(100, 27);
            this.txtChucVu.TabIndex = 11;
            this.txtChucVu.Text = "txtChucVu";
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(20, 12);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtMaDinhDanh);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtDiaChi);
            this.kryptonGroupBox1.Panel.Controls.Add(this.dtpNgaySinh);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtSDT);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtTenNV);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtGioiTinh);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtChucVu);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(641, 185);
            this.kryptonGroupBox1.TabIndex = 15;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(760, 67);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 25);
            this.btnThem.TabIndex = 16;
            this.btnThem.Values.Text = "kryptonButton1";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // ucQuanLyNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.kryptonGroupBox1);
            this.Controls.Add(this.dataGridViewNV);
            this.Name = "ucQuanLyNV";
            this.Size = new System.Drawing.Size(1239, 410);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonDataGridView dataGridViewNV;
        private Krypton.Toolkit.KryptonTextBox txtMaDinhDanh;
        private Krypton.Toolkit.KryptonDateTimePicker dtpNgaySinh;
        private Krypton.Toolkit.KryptonTextBox txtTenNV;
        private Krypton.Toolkit.KryptonTextBox txtGioiTinh;
        private Krypton.Toolkit.KryptonTextBox txtDiaChi;
        private Krypton.Toolkit.KryptonTextBox txtSDT;
        private Krypton.Toolkit.KryptonTextBox txtChucVu;
        private Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private Krypton.Toolkit.KryptonButton btnThem;
    }
}
