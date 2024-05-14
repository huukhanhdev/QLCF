namespace DTO
{
    public class Menu
    {
        // Các thuộc tính tương ứng với các cột trong bảng Menu
        public string MaMon { get; set; }
        public string TenMon { get; set; }
        public float GiaTien { get; set; }
        public byte[] HinhAnh { get; set; } // Đối với hình ảnh, sử dụng byte array

        // Constructor và các phương thức khác...
    }

}
