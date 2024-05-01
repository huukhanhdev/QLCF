using DTO;
using System.Data.SqlClient;
namespace DAL
{
    public class SqlConnectionData
    {
        public static SqlConnection Connect()
        {
            string strConnect = @"Data Source=DESKTOP-LDAF2V1\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(strConnect);
            return conn;
        }
    }
    public class DBAccess
    {
        public static string checkLogicDTO(TaiKhoan taikhoan)
        {
            string TenDangNhap = null;
            SqlConnection conn = SqlConnectionData.Connect();
            SqlCommand command = new SqlCommand("proc_Logic", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@TenDangNhap", taikhoan.TenDangNhap);
            command.Parameters.AddWithValue("@MatKhau", taikhoan.MatKhau);
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TenDangNhap = reader.GetString(0);
                }

                reader.Close();
                conn.Close();
            }
            else
            {
                return "wrong_info";
            }
            return TenDangNhap;
        }
    }
}
