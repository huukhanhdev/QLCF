using System;

namespace DTO
{
    public class HoaDon
    {
        public string MaHoaDon { get; set; }
        public string MaBan { get; set; }
        public string MaDinhDanh { get; set; }
        public float TongTien { get; set; }
        public string PTTT { get; set; }
        public DateTime NgayLapHoaDon { get; set; } // Thêm trường NgayLapHoaDon vào đây

        public HoaDon(string maHoaDon, string maBan, string maDinhDanh, float tongTien)
        {
            MaHoaDon = maHoaDon;
            MaBan = maBan;
            MaDinhDanh = maDinhDanh;
            TongTien = tongTien;
        }
        public HoaDon(string maHoaDon, string maBan, string maDinhDanh, float tongTien, string ptThanhToan, DateTime ngayLapHoaDon)
        {
            MaHoaDon = maHoaDon;
            MaBan = maBan;
            MaDinhDanh = maDinhDanh;
            TongTien = tongTien;
            PTTT = ptThanhToan;
            NgayLapHoaDon = ngayLapHoaDon;
        }
        public HoaDon(string maHoaDon, string maBan, string maDinhDanh, float tongTien, DateTime ngayLapHoaDon)
        {
            MaHoaDon = maHoaDon;
            MaBan = maBan;
            MaDinhDanh = maDinhDanh;
            TongTien = tongTien;
            NgayLapHoaDon = ngayLapHoaDon;
        }
    }

}
