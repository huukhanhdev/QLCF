using BLL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{

    public partial class TrangChinh : Form
    {
        private string hoTen;
        private Timer timer;
        private string tenDangNhap;
        public TrangChinh(string hoTen)
        {
            InitializeComponent();
            //hiển thị ucTrangChinh khi mở form
            panel1.Controls.Clear(); // Xóa các control cũ trên Panel1
            ucTrangChinh ucTrangChu = new ucTrangChinh(); // Tạo UserControl ucTrangChu
            panel1.Controls.Add(ucTrangChu); // Thêm UserControl vào Panel1
            this.KeyPreview = true;

            //get ten dang nhap from DangNhap.cs
            DangNhap dangNhap = new DangNhap();
            this.tenDangNhap = dangNhap.GetTenDangNhap();
            this.hoTen = hoTen;
            label1.Text = "Chào mừng " + hoTen + " đến với phần mềm quản lý cửa hàng";
            // Khởi tạo và cấu hình Timer
            timer = new Timer();
            timer.Interval = 40; // Đặt thời gian cho mỗi chu kỳ (50 milliseconds ở đây, bạn có thể thay đổi)
            timer.Tick += Timer_Tick;
            timer.Start();
            // Thêm các mục vào menu
            contextMenuStrip1 = new ContextMenuStrip();
            contextMenuStrip1.Items.Add("Cập nhật thông tin", null, MenuItem_Click);
            contextMenuStrip1.Items.Add("Đổi mật khẩu", null, MenuItem_Click);
            contextMenuStrip1.Items.Add("Đăng xuất", null, MenuItem_Click);

            // Gán sự kiện Click cho PictureBox
            pictureBox1.Click += pictureBox1_Click;

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Di chuyển label sang trái mỗi lần timer tick
            label1.Left += 1; // Di chuyển 2 pixel mỗi lần
                              // Nếu label di chuyển hết ra khỏi biên trái của form, đặt lại vị trí của nó
            if (label1.Left > this.Width)
                label1.Left = -label1.Width;
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện khi một mục được chọn từ menu
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem != null)
            {
                string selectedOption = menuItem.Text;
                switch (selectedOption)
                {
                    case "Cập nhật thông tin":
                        DangNhap dangNhap = new DangNhap();
                        this.tenDangNhap = dangNhap.GetTenDangNhap();
                        CapNhat capNhatForm = new CapNhat(tenDangNhap);

                        capNhatForm.Show(); // Hiển thị form CapNhat
                        break;
                    case "Đổi mật khẩu":
                        HienThiDoiMatKhau();

                        break;
                    case "Đăng xuất":
                        DangXuat();
                        break;

                    default:
                        break;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Lấy vị trí của PictureBox trên màn hình
            Point locationOnForm = pictureBox1.PointToScreen(Point.Empty);

            // Hiển thị ContextMenuStrip dưới PictureBox
            contextMenuStrip1.Show(new Point(locationOnForm.X, locationOnForm.Y + pictureBox1.Height));
        }
        private void HienThiDoiMatKhau()
        {
            string matKhauCu = Microsoft.VisualBasic.Interaction.InputBox("Nhập mật khẩu cũ:", "Đổi mật khẩu", "");

            // Kiểm tra nếu người dùng nhấn OK nhưng mật khẩu cũ trống
            if (!string.IsNullOrEmpty(matKhauCu))
            {
                // Hiển thị MessageBox để nhập mật khẩu mới và xác nhận mật khẩu mới
                string matKhauMoi = Microsoft.VisualBasic.Interaction.InputBox("Nhập mật khẩu mới:", "Đổi mật khẩu", "");
                if (string.IsNullOrEmpty(matKhauMoi))
                {
                    MessageBox.Show("Mật khẩu mới không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string xacNhanMatKhauMoi = Microsoft.VisualBasic.Interaction.InputBox("Xác nhận mật khẩu mới:", "Đổi mật khẩu", "");
                if (string.IsNullOrEmpty(xacNhanMatKhauMoi))
                {
                    MessageBox.Show("Xác nhận mật khẩu mới không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (matKhauMoi != xacNhanMatKhauMoi)
                {
                    MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu mới không khớp nhau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra mật khẩu cũ có đúng không và thực hiện đổi mật khẩu trong cơ sở dữ liệu
                TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();
                bool result = taiKhoanBLL.CheckMatKhau(new DTO.TaiKhoan { TenDangNhap = tenDangNhap, MatKhau = matKhauCu });
                //check ten dang nhap va mat khau cu
                MessageBox.Show(tenDangNhap + " " + matKhauCu + " " + result.ToString());
                if (result == true)
                {
                    result = taiKhoanBLL.DoiMatKhau(tenDangNhap, matKhauMoi);
                }
                if (result)
                {
                    MessageBox.Show("Đổi mật khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không đúng. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            // Không làm gì cả nếu người dùng nhấn dấu X hoặc Cancel
        }

        private void DangXuat()
        {
            // Hiển thị hộp thoại xác nhận hoặc đóng form và hiển thị form đăng nhập
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide(); // Đóng form trang chính



                // Hiển thị form đăng nhập
                DangNhap dangNhapForm = new DangNhap();
                dangNhapForm.ShowDialog();
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear(); // Xóa các control cũ trên Panel1
            ucThucDon ucThucDon = new ucThucDon(); // Tạo UserControl ucThucDon
            ucThucDon.Dock = DockStyle.Fill; // Đặt kiểu Fill để UserControl lấp đầy Panel1
            panel1.Controls.Add(ucThucDon); // Thêm UserControl vào Panel1
        }

        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear(); // Xóa các control cũ trên Panel1
            ucQuanLy ucQuanLy = new ucQuanLy(); // Tạo UserControl ucQuanLy
            ucQuanLy.Dock = DockStyle.Fill; // Đặt kiểu Fill để UserControl lấp đầy Panel1
            panel1.Controls.Add(ucQuanLy); // Thêm UserControl vào Panel1
        }
        private void btnBanHang_CLick(object sender, EventArgs e)
        {
            panel1.Controls.Clear(); // Xóa các control cũ trên Panel1
            ucBanHang ucBanHang = new ucBanHang(); // Tạo UserControl ucBanHang
            ucBanHang.Dock = DockStyle.Fill; // Đặt kiểu Fill để UserControl lấp đầy Panel1
            panel1.Controls.Add(ucBanHang); // Thêm UserControl vào Panel1
        }
        // khi nhấn f5, kiểm tra xem đang ở form nào thì nhấn lại vào btn tương ứng
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear(); // Xóa các control cũ trên Panel1
            ucThongKe ucThongKe = new ucThongKe(); // Tạo UserControl ucThongKe
            ucThongKe.Dock = DockStyle.Fill; // Đặt kiểu Fill để UserControl lấp đầy Panel1
            panel1.Controls.Add(ucThongKe); // Thêm UserControl vào Panel1
        }

        private void TrangChinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                if (panel1.Controls.Count == 0)
                {
                    btnMenu_Click(sender, e);
                }
                else
                {
                    if (panel1.Controls[0] is ucThucDon)
                    {
                        btnMenu_Click(sender, e);
                    }
                    else if (panel1.Controls[0] is ucQuanLy)
                    {
                        btnQuanLy_Click(sender, e);
                    }
                    else if (panel1.Controls[0] is ucBanHang)
                    {
                        btnBanHang_CLick(sender, e);
                    }
                }
            }

        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            // mở uc trangchinh
            panel1.Controls.Clear(); // Xóa các control cũ trên Panel1
            ucTrangChinh ucTrangChu = new ucTrangChinh(); // Tạo UserControl ucTrangChu
            panel1.Controls.Add(ucTrangChu); // Thêm UserControl vào Panel1



        }
    }
}