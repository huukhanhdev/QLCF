using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucQuanLyNV : UserControl
    {
        private DataTable dataTableNV; // DataTable để lưu trữ dữ liệu nhân viên
        private string connectionString = @"Data Source=DESKTOP-LDAF2V1\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;";
        public ucQuanLyNV()
        {
            InitializeComponent();

            // Khởi tạo DataTable
            dataTableNV = new DataTable();

            // Định nghĩa cấu trúc cho DataTable
            dataTableNV.Columns.Add("MaDinhDanh", typeof(string));
            dataTableNV.Columns.Add("TenNV", typeof(string));
            dataTableNV.Columns.Add("GioiTinh", typeof(string));
            dataTableNV.Columns.Add("SDT", typeof(string));
            dataTableNV.Columns.Add("NgaySinh", typeof(DateTime));
            dataTableNV.Columns.Add("ChucVu", typeof(string));
            dataTableNV.Columns.Add("DiaChi", typeof(string));
           

            // Gán DataTable làm DataSource cho DataGridView
            dataGridViewNV.DataSource = dataTableNV;

            // Load dữ liệu nhân viên từ cơ sở dữ liệu
            LoadDataFromDatabase();
        }

        private void LoadDataFromDatabase()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MaDinhDanh, TenNV, GioiTinh, SDT, NgaySinh, ChucVu, DiaChi FROM NhanVien";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTableNV); // Đổ dữ liệu từ SqlDataAdapter vào DataTable
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu từ cơ sở dữ liệu: " + ex.Message);
                    }
                }
            }
        }

        private void dataGridViewNV_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewNV.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dataGridViewNV.SelectedRows[0];
                // check xem có phải select vào header không
                if (selectedRow.Cells["MaDinhDanh"].Value == null)
                {
                    return;
                }
                // Hiển thị thông tin từ dòng được chọn lên các TextBox
                txtMaDinhDanh.Text = selectedRow.Cells["MaDinhDanh"].Value.ToString();
                
                txtTenNV.Text = selectedRow.Cells["TenNV"].Value.ToString();
                txtGioiTinh.Text = selectedRow.Cells["GioiTinh"].Value.ToString();
                txtSDT.Text = selectedRow.Cells["SDT"].Value.ToString();
                // ngay sinh datatimepicker
                dtpNgaySinh.Value = Convert.ToDateTime(selectedRow.Cells["NgaySinh"].Value);
                txtChucVu.Text = selectedRow.Cells["ChucVu"].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells["DiaChi"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }
    }
}
