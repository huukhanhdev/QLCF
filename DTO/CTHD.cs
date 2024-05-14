namespace DTO
{
    public class CTHD
    {
        public string MaHoaDon { get; set; }
        public string TenMon { get; set; }
        public int SoLuong { get; set; }
        public float ThanhTien { get; set; }

        public CTHD(string maHoaDon, string tenMon, int soLuong, float thanhTien)
        {
            MaHoaDon = maHoaDon;
            TenMon = tenMon;
            SoLuong = soLuong;
            ThanhTien = thanhTien;
        }
    }
}
