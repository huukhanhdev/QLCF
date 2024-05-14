using BLL;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class DangNhap : Form

    {
        public static string TenDangNhap1;
        TaiKhoan taikhoan = new TaiKhoan();
        TaiKhoanBLL taikhoanBLL = new TaiKhoanBLL();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            taikhoan.TenDangNhap = txtTenDangNhap.Text;
            TenDangNhap1 = txtTenDangNhap.Text;
            taikhoan.MatKhau = txtMatKhau.Text;
            string info = taikhoanBLL.checkLogic(taikhoan);
            

            switch (info)
            {
                case "required_tdn":
                    MessageBox.Show("Tài khoản không được để trống");
                    return;

                case "required_mk":
                    MessageBox.Show("Mật khẩu không được để trống");
                    return;

                case "wrong_info":
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.");
                    return;
            }
            MessageBox.Show("Đăng nhập thành công");

            // show the main form
            string maDinhDanh = taikhoanBLL.GetMaDinhDanhFromTenDangNhap(taikhoan.TenDangNhap);
            string hoTen = taikhoanBLL.GetFullNameFromMaDinhDanh(maDinhDanh);

            // Ẩn form đăng nhập
            this.Hide();

            // Hiển thị form chính và truyền họ tên qua constructor
            TrangChinh trangChinh = new TrangChinh(hoTen);
            trangChinh.ShowDialog();

            // lấy họ tên từ tên đăng nhập của người dùng sau khi đăng nhập thành công để hiện label1 chào mừng + họ tên




            // close the login form
            this.Close();

        }
        public string GetTenDangNhap()
        {
            return TenDangNhap1;
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Gọi phương thức xử lý đăng nhập
                buttonDangNhap_Click(sender, e);
            }
        }

        private void txtTenDangNhap_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            // mở form đăng kí
            DangKy dangKy = new DangKy();
            dangKy.ShowDialog();


        }
    }
}