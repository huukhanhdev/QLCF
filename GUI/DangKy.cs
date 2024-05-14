using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            string maDinhDanh = txtMaDinhDanh.Text;
            string tenDangNhap = txtTenDangNhap.Text;
            string matKhau = txtMatKhau.Text;
            string xacNhanMatKhau = txtXacNhanMK.Text;

            // Kiểm tra mã định danh
            if (!KiemTraMaDinhDanh(maDinhDanh))
            {
                MessageBox.Show("Mã định danh không tồn tại.", "Thông báo");
                return;
            }

            // Kiểm tra định dạng tên đăng nhập
            if (!KiemTraDinhDangTenDangNhap(tenDangNhap))
            {
                MessageBox.Show("Tên đăng nhập không đúng định dạng.", "Thông báo");
                return;
            }

            // Kiểm tra tên đăng nhập đã tồn tại chưa
            if (KiemTraTenDangNhapTonTai(tenDangNhap))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại.", "Thông báo");
                return;
            }

            // Kiểm tra mật khẩu và xác nhận mật khẩu
            if (matKhau != xacNhanMatKhau)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp.", "Thông báo");
                return;
            }

            // Tạo mới tài khoản
            TaoMoiTaiKhoan(maDinhDanh, tenDangNhap, matKhau);

            MessageBox.Show("Đăng ký tài khoản thành công.", "Thông báo");
        }

        private bool KiemTraMaDinhDanh(string maDinhDanh)
        {
            string connectionString = "Data Source=DESKTOP-LDAF2V1\\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;";
            string query = "SELECT COUNT(*) FROM NhanVien WHERE MaDinhDanh = @MaDinhDanh";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaDinhDanh", maDinhDanh);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private bool KiemTraDinhDangTenDangNhap(string tenDangNhap)
        {
            // Kiểm tra định dạng tên đăng nhập (ví dụ: chỉ cho phép chữ cái và số, dài từ 5 đến 20 ký tự)
            Regex regex = new Regex("^[a-zA-Z0-9]{5,20}$");
            return regex.IsMatch(tenDangNhap);
        }

        private bool KiemTraTenDangNhapTonTai(string tenDangNhap)
        {
            string connectionString = "Data Source=DESKTOP-LDAF2V1\\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;";
            string query = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void TaoMoiTaiKhoan(string maDinhDanh, string tenDangNhap, string matKhau)
        {
            string connectionString = "Data Source=DESKTOP-LDAF2V1\\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;";
            string query = "INSERT INTO TaiKhoan (MaDinhDanh, TenDangNhap, MatKhau, MaQuyen) VALUES (@MaDinhDanh, @TenDangNhap, @MatKhau, @MaQuyen)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaDinhDanh", maDinhDanh);
                    command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    command.Parameters.AddWithValue("@MatKhau", matKhau);
                    command.Parameters.AddWithValue("@MaQuyen", 1); // Mã quyền mặc định là 1

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        
    }
}
