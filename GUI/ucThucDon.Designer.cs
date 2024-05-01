namespace GUI
{
    partial class ucThucDon
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
            this.panelDetails = new Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.pictureBoxHA = new Krypton.Toolkit.KryptonPictureBox();
            this.labelGiaTien = new Krypton.Toolkit.KryptonLabel();
            this.labelTenMon = new Krypton.Toolkit.KryptonLabel();
            this.labelMaMon = new Krypton.Toolkit.KryptonLabel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.TenMon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnThemMon = new Krypton.Toolkit.KryptonButton();
            this.btnSua = new Krypton.Toolkit.KryptonButton();
            this.groupBoxThongTin = new Krypton.Toolkit.KryptonGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelDetails)).BeginInit();
            this.panelDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxThongTin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxThongTin.Panel)).BeginInit();
            this.groupBoxThongTin.Panel.SuspendLayout();
            this.groupBoxThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDetails
            // 
            this.panelDetails.Controls.Add(this.kryptonLabel4);
            this.panelDetails.Controls.Add(this.pictureBoxHA);
            this.panelDetails.Controls.Add(this.labelGiaTien);
            this.panelDetails.Controls.Add(this.labelTenMon);
            this.panelDetails.Controls.Add(this.labelMaMon);
            this.panelDetails.Location = new System.Drawing.Point(-2, 15);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(630, 548);
            this.panelDetails.StateNormal.Color1 = System.Drawing.Color.Transparent;
            this.panelDetails.TabIndex = 1;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.LabelStyle = Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonLabel4.Location = new System.Drawing.Point(29, 177);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(172, 27);
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.TabIndex = 7;
            this.kryptonLabel4.Values.Text = "Hình ảnh minh họa";
            // 
            // pictureBoxHA
            // 
            this.pictureBoxHA.Location = new System.Drawing.Point(29, 223);
            this.pictureBoxHA.Name = "pictureBoxHA";
            this.pictureBoxHA.Size = new System.Drawing.Size(585, 201);
            this.pictureBoxHA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxHA.TabIndex = 3;
            this.pictureBoxHA.TabStop = false;
            // 
            // labelGiaTien
            // 
            this.labelGiaTien.LabelStyle = Krypton.Toolkit.LabelStyle.BoldPanel;
            this.labelGiaTien.Location = new System.Drawing.Point(52, 121);
            this.labelGiaTien.Name = "labelGiaTien";
            this.labelGiaTien.Size = new System.Drawing.Size(79, 27);
            this.labelGiaTien.StateCommon.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGiaTien.TabIndex = 2;
            this.labelGiaTien.Values.Text = "Giá tiền";
            // 
            // labelTenMon
            // 
            this.labelTenMon.LabelStyle = Krypton.Toolkit.LabelStyle.BoldPanel;
            this.labelTenMon.Location = new System.Drawing.Point(52, 79);
            this.labelTenMon.Name = "labelTenMon";
            this.labelTenMon.Size = new System.Drawing.Size(87, 27);
            this.labelTenMon.StateCommon.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenMon.TabIndex = 1;
            this.labelTenMon.Values.Text = "Tên món";
            // 
            // labelMaMon
            // 
            this.labelMaMon.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.labelMaMon.Location = new System.Drawing.Point(52, 36);
            this.labelMaMon.Name = "labelMaMon";
            this.labelMaMon.Size = new System.Drawing.Size(82, 27);
            this.labelMaMon.StateCommon.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaMon.TabIndex = 0;
            this.labelMaMon.Values.Text = "Mã món";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TenMon});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 80);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(480, 231);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // TenMon
            // 
            this.TenMon.Text = "Tên Món";
            this.TenMon.Width = 426;
            // 
            // btnThemMon
            // 
            this.btnThemMon.Location = new System.Drawing.Point(69, 350);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(93, 34);
            this.btnThemMon.TabIndex = 3;
            this.btnThemMon.Values.Text = "Thêm món";
            this.btnThemMon.Click += new System.EventHandler(this.btnThemMon_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(310, 350);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(98, 34);
            this.btnSua.TabIndex = 4;
            this.btnSua.Values.Text = "Chỉnh sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // groupBoxThongTin
            // 
            this.groupBoxThongTin.Location = new System.Drawing.Point(549, 3);
            this.groupBoxThongTin.Name = "groupBoxThongTin";
            // 
            // groupBoxThongTin.Panel
            // 
            this.groupBoxThongTin.Panel.Controls.Add(this.panelDetails);
            this.groupBoxThongTin.Size = new System.Drawing.Size(633, 613);
            this.groupBoxThongTin.TabIndex = 5;
            this.groupBoxThongTin.Values.Heading = "Thông tin sản phẩm";
            // 
            // ucThucDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxThongTin);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThemMon);
            this.Controls.Add(this.listView1);
            this.Name = "ucThucDon";
            this.Size = new System.Drawing.Size(1182, 653);
            ((System.ComponentModel.ISupportInitialize)(this.panelDetails)).EndInit();
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxThongTin.Panel)).EndInit();
            this.groupBoxThongTin.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxThongTin)).EndInit();
            this.groupBoxThongTin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Krypton.Toolkit.KryptonPanel panelDetails;
        private Krypton.Toolkit.KryptonLabel labelTenMon;
        private Krypton.Toolkit.KryptonLabel labelMaMon;
        private Krypton.Toolkit.KryptonLabel labelGiaTien;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader TenMon;
        private Krypton.Toolkit.KryptonButton btnThemMon;
        private Krypton.Toolkit.KryptonPictureBox pictureBoxHA;
        private Krypton.Toolkit.KryptonButton btnSua;
        private Krypton.Toolkit.KryptonGroupBox groupBoxThongTin;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
    }
}
