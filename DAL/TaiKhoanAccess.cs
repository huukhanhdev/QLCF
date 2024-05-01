using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class TaiKhoanAccess : DBAccess
    {
        public string checkLogic(TaiKhoan taikhoan)
        {
            string info = checkLogicDTO(taikhoan);
            return info;
        }
        public static string GetMaDinhDanhFromTenDangNhap(string tenDangNhap)
        {
            string maDinhDanh = null;

            // Triển khai logic để truy xuất mã định danh từ tên đăng nhập trong cơ sở dữ liệu
            // Ví dụ:
            // Sử dụng câu truy vấn SQL để lấy mã định danh từ bảng Tài khoản
            // Đảm bảo sử dụng tham số để tránh các vấn đề bảo mật và chuỗi SQL Injection
            string query = "SELECT MaDinhDanh FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";

            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);

                conn.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    maDinhDanh = result.ToString();
                }
            }

            return maDinhDanh;
        }

        public static string GetFullNameFromMaDinhDanh(string maDinhDanh)
        {
            string hoTen = null;

            // Triển khai logic để truy xuất họ tên từ mã định danh trong cơ sở dữ liệu
            // Ví dụ:
            // Sử dụng câu truy vấn SQL để lấy họ tên từ bảng Nhân viên
            // Đảm bảo sử dụng tham số để tránh các vấn đề bảo mật và chuỗi SQL Injection
            string query = "SELECT TenNV FROM NhanVien WHERE MaDinhDanh = @MaDinhDanh";

            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@MaDinhDanh", maDinhDanh);

                conn.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    hoTen = result.ToString();
                }
            }

            return hoTen;
        }
        //đổi mật khẩu với tham số là tendangnhap, matkhaumoi
            public static bool DoiMatKhau(string tenDangNhap, string matKhauMoi)
        {
            // Triển khai logic để cập nhật mật khẩu mới vào cơ sở dữ liệu
            string query = "UPDATE TaiKhoan SET MatKhau = @MatKhauMoi WHERE TenDangNhap = @TenDangNhap";

            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                command.Parameters.AddWithValue("@MatKhauMoi", matKhauMoi);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
     
        public static bool CheckMatKhau(TaiKhoan taikhoan)
        {
            SqlConnection conn = SqlConnectionData.Connect();
            SqlCommand command = new SqlCommand("proc_logic", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@TenDangNhap", taikhoan.TenDangNhap);
            command.Parameters.AddWithValue("@MatKhau", taikhoan.MatKhau);
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool isValidPassword = false;
            if (reader.HasRows)
            {
                isValidPassword = true;
            }
            reader.Close();
            conn.Close();
            return isValidPassword;
        }

    }
}
