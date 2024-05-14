using DAL;
using DTO;
namespace BLL
{
    public class TaiKhoanBLL
    {
        public string checkLogic(TaiKhoan taikhoan)
        {
            TaiKhoanAccess tk = new TaiKhoanAccess();
            {
                if (taikhoan.TenDangNhap == "")
                {
                    return "required_tdn";
                }
                if (taikhoan.MatKhau == "")
                {
                    return "required_mk";
                }
            }
            string info = tk.checkLogic(taikhoan);
            return info;
        }
        public string GetMaDinhDanhFromTenDangNhap(string tenDangNhap)
        {
            return TaiKhoanAccess.GetMaDinhDanhFromTenDangNhap(tenDangNhap);
        }
        public string GetFullNameFromMaDinhDanh(string maDinhDanh)
        {
            return TaiKhoanAccess.GetFullNameFromMaDinhDanh(maDinhDanh);
        }

        public bool CheckMatKhau(TaiKhoan taiKhoan)
        {
            return TaiKhoanAccess.CheckMatKhau(taiKhoan);
        }
        // doi mat khau
        public bool DoiMatKhau(string tenDangNhap, string matKhauMoi)
        {
            return TaiKhoanAccess.DoiMatKhau(tenDangNhap, matKhauMoi);
        }
    }
}
