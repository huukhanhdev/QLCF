using BLL;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class CapNhat : Form
    {

        private NhanVienBLL nhanVienBLL;
        private TaiKhoanBLL taiKhoanBLL;
        private bool isEditing = false;
        public CapNhat(string tenDangNhap)
        {
            InitializeComponent();
            nhanVienBLL = new NhanVienBLL();
            taiKhoanBLL = new TaiKhoanBLL();
            EnableTextBoxes(false); // Vô hiệu hóa các ô textbox

            string maDinhDanh = taiKhoanBLL.GetMaDinhDanhFromTenDangNhap(tenDangNhap);

            // Lấy thông tin nhân viên từ mã định danh
            NhanVien nhanVien = nhanVienBLL.LayThongTinNhanVien(maDinhDanh);

            if (nhanVien != null)
            {
                // Hiển thị thông tin nhân viên trên các control trên form
                txtMaDinhDanh.Text = nhanVien.MaDinhDanh;
                txtTenNV.Text = nhanVien.TenNV;
                txtGioiTinh.Text = nhanVien.GioiTinh;
                txtSDT.Text = nhanVien.SDT;
                dtpNgaySinh.Value = nhanVien.NgaySinh; // Gán giá trị ngày sinh cho DateTimePicker
                txtChucVu.Text = nhanVien.ChucVu;
                txtDiaChi.Text = nhanVien.DiaChi;
            }

        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Khi nhấn nút cập nhật, cho phép chỉnh sửa các ô textbox
            isEditing = true;
            EnableTextBoxes(true);
            txtTenNV.Focus(); // Focus vào ô textbox họ tên
        }
        
        private void EnableTextBoxes(bool enable)
        {
            // Vô hiệu hóa/hủy vô hiệu hóa các ô textbox tùy thuộc vào biến enable
            txtTenNV.Enabled = enable;
            txtGioiTinh.Enabled = enable;
            txtSDT.Enabled = enable;
            dtpNgaySinh.Enabled = enable;
            txtChucVu.Enabled = enable;
            txtDiaChi.Enabled = enable;
        }

        
            private void btnLuu_Click(object sender, EventArgs e)
            {
                if (isEditing)
                {
                    // Lấy thông tin từ các ô textbox
                    string maDinhDanh = txtMaDinhDanh.Text;
                    string tenNV = txtTenNV.Text;
                    string gioiTinh = txtGioiTinh.Text;
                    string sdt = txtSDT.Text;
                    DateTime ngaySinh = dtpNgaySinh.Value;
                    string chucVu = txtChucVu.Text;
                    string diaChi = txtDiaChi.Text;

                    // Tạo đối tượng NhanVien để lưu thông tin mới
                    NhanVien nhanVien = new NhanVien
                    {
                        MaDinhDanh = maDinhDanh,
                        TenNV = tenNV,
                        GioiTinh = gioiTinh,
                        SDT = sdt,
                        NgaySinh = ngaySinh,
                        ChucVu = chucVu,
                        DiaChi = diaChi
                    };

                    // Gọi phương thức BLL hoặc DAL để cập nhật thông tin vào cơ sở dữ liệu
                    NhanVienBLL nhanVienBLL = new NhanVienBLL();
                    bool result = nhanVienBLL.CapNhatThongTinNhanVien(nhanVien);

                    if (result)
                    {
                        // Hiển thị thông báo thành công
                        MessageBox.Show("Cập nhật thông tin thành công.");
                        // Vô hiệu hóa các ô textbox sau khi lưu thành công
                        EnableTextBoxes(false);
                        isEditing = false;
                    }
                    else
                    {
                        // Hiển thị thông báo lỗi nếu cập nhật không thành công
                        MessageBox.Show("Cập nhật thông tin không thành công. Vui lòng thử lại.");
                    }
                }
            
        }
    }
    }
