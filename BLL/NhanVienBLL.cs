using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhanVienBLL
    {
        private NhanVienAccess nhanVienAccess;

        public NhanVienBLL()
        {
            nhanVienAccess = new NhanVienAccess();
        }

        public NhanVien LayThongTinNhanVien(string maDinhDanh)
        {
            return nhanVienAccess.LayThongTinNhanVien(maDinhDanh);
        }
        public bool CapNhatThongTinNhanVien(NhanVien nhanVien)
        {
            NhanVienAccess nhanVienAccess = new NhanVienAccess();
            return nhanVienAccess.CapNhatThongTinNhanVien(nhanVien);
        }
    }
}
