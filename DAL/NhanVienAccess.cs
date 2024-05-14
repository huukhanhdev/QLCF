using DTO;
using System.Data.SqlClient;



namespace DAL
{
    public class NhanVienAccess
    {
        public NhanVien LayThongTinNhanVien(string maDinhDanh)
        {
            NhanVien nhanVien = null;

            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "SELECT * FROM NhanVien WHERE MaDinhDanh = @MaDinhDanh";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@MaDinhDanh", maDinhDanh);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    nhanVien = new NhanVien
                    {
                        MaDinhDanh = reader.GetString(reader.GetOrdinal("MaDinhDanh")),
                        TenNV = reader.GetString(reader.GetOrdinal("TenNV")),
                        GioiTinh = reader.GetString(reader.GetOrdinal("GioiTinh")),
                        SDT = reader.GetString(reader.GetOrdinal("SDT")),
                        NgaySinh = reader.GetDateTime(reader.GetOrdinal("NgaySinh")),
                        ChucVu = reader.GetString(reader.GetOrdinal("ChucVu")),
                        DiaChi = reader.GetString(reader.GetOrdinal("DiaChi"))
                    };
                }
                reader.Close();
            }

            return nhanVien;
        }
        public bool CapNhatThongTinNhanVien(NhanVien nhanVien)
        {
            // Triển khai logic để cập nhật thông tin nhân viên vào cơ sở dữ liệu
            string query = "UPDATE NhanVien SET TenNV = @TenNV, GioiTinh = @GioiTinh, SDT = @SDT, NgaySinh = @NgaySinh, ChucVu = @ChucVu, DiaChi = @DiaChi WHERE MaDinhDanh = @MaDinhDanh";

            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@MaDinhDanh", nhanVien.MaDinhDanh);
                command.Parameters.AddWithValue("@TenNV", nhanVien.TenNV);
                command.Parameters.AddWithValue("@GioiTinh", nhanVien.GioiTinh);
                command.Parameters.AddWithValue("@SDT", nhanVien.SDT);
                command.Parameters.AddWithValue("@NgaySinh", nhanVien.NgaySinh);
                command.Parameters.AddWithValue("@ChucVu", nhanVien.ChucVu);
                command.Parameters.AddWithValue("@DiaChi", nhanVien.DiaChi);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}

