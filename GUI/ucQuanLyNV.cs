using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucQuanLyNV : UserControl
    {
        private DataTable dataTableTimKiem;
        private DataTable dataTableNV;
        private string connectionString = @"Data Source=DESKTOP-LDAF2V1\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;";

        public ucQuanLyNV()
        {
            InitializeComponent();
            dataTableNV = new DataTable();
            dataTableNV.Columns.Add("MaDinhDanh", typeof(string));
            dataTableNV.Columns.Add("TenNV", typeof(string));
            dataTableNV.Columns.Add("GioiTinh", typeof(string));
            dataTableNV.Columns.Add("SDT", typeof(string));
            dataTableNV.Columns.Add("NgaySinh", typeof(DateTime));
            dataTableNV.Columns.Add("ChucVu", typeof(string));
            dataTableNV.Columns.Add("DiaChi", typeof(string));
            dataGridViewNV.DataSource = dataTableNV;
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
                        adapter.Fill(dataTableNV);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu từ cơ sở dữ liệu: " + ex.Message);
                    }
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                Search(keyword);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
            }
        }
        // khởi tạo tự động mã định danh NV00x bằng cách tìm mã định danh lớn nhất trong database và tăng lên 1
        private string AutoGenerateMaDinhDanh()
        {
            string maDinhDanh = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MAX(MaDinhDanh) FROM NhanVien";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            string lastMaDinhDanh = result.ToString();
                            int number = int.Parse(lastMaDinhDanh.Substring(2));
                            number++;
                            maDinhDanh = "NV" + number.ToString("D3");
                        }
                        else
                        {
                            maDinhDanh = "NV001";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi tạo mã định danh mới: " + ex.Message);
                    }
                }
            }
            return maDinhDanh;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            // mở vô hiệu hóa các textbox
            txtMaDinhDanh.Enabled = true;
            txtTenNV.Enabled = true;
            txtGioiTinh.Enabled = true;
            txtSDT.Enabled = true;
            dtpNgaySinh.Enabled = true;
            txtChucVu.Enabled = true;
            txtDiaChi.Enabled = true;
            txtMaDinhDanh.Text = AutoGenerateMaDinhDanh();



        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // mở vô hiệu hóa các textbox
            txtMaDinhDanh.Enabled = false;
            txtTenNV.Enabled = true;
            txtGioiTinh.Enabled = true;
            txtSDT.Enabled = true;
            dtpNgaySinh.Enabled = true;
            txtChucVu.Enabled = true;
            txtDiaChi.Enabled = true;

            // Xử lý sửa thông tin nhân viên
            if (dataGridViewNV.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewNV.SelectedRows[0];
                // Lấy thông tin từ DataGridView và hiển thị lên các TextBox
                txtMaDinhDanh.Text = selectedRow.Cells["MaDinhDanh"].Value.ToString();
                txtTenNV.Text = selectedRow.Cells["TenNV"].Value.ToString();
                txtGioiTinh.Text = selectedRow.Cells["GioiTinh"].Value.ToString();
                txtSDT.Text = selectedRow.Cells["SDT"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(selectedRow.Cells["NgaySinh"].Value);
                txtChucVu.Text = selectedRow.Cells["ChucVu"].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells["DiaChi"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa từ danh sách.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Xử lý xóa nhân viên
            if (dataGridViewNV.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewNV.SelectedRows[0];
                string maDinhDanh = selectedRow.Cells["MaDinhDanh"].Value.ToString();

                // Xóa nhân viên từ cơ sở dữ liệu
                DeleteNhanVien(maDinhDanh);

                // Xóa dòng tương ứng từ DataTable và cập nhật lại DataGridView
                DataRow[] rowsToDelete = dataTableNV.Select($"MaDinhDanh = '{maDinhDanh}'");
                foreach (DataRow row in rowsToDelete)
                {
                    dataTableNV.Rows.Remove(row);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa từ danh sách.");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Xử lý lưu thông tin nhân viên
            string maDinhDanh = txtMaDinhDanh.Text;
            string tenNV = txtTenNV.Text;
            string gioiTinh = txtGioiTinh.Text;
            string sdt = txtSDT.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;
            string chucVu = txtChucVu.Text;
            string diaChi = txtDiaChi.Text;

            // kiểm tra madinhdanh đã tồn tại chưa, nếu có thì update, không thì insert
            DataRow[] rows = dataTableNV.Select($"MaDinhDanh = '{maDinhDanh}'");
            if (rows.Length > 0)
            {
                // Sửa thông tin nhân viên
                UpdateNhanVien(maDinhDanh, tenNV, gioiTinh, sdt, ngaySinh, chucVu, diaChi);
            }
            else
            {
                // Thêm nhân viên mới
                InsertNhanVien(maDinhDanh, tenNV, gioiTinh, sdt, ngaySinh, chucVu, diaChi);
            }
        }

        private void InsertNhanVien(string maDinhDanh, string tenNV, string gioiTinh, string sdt, DateTime ngaySinh, string chucVu, string diaChi)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO NhanVien (MaDinhDanh, TenNV, GioiTinh, SDT, NgaySinh, ChucVu, DiaChi) VALUES (@MaDinhDanh, @TenNV, @GioiTinh, @SDT, @NgaySinh, @ChucVu, @DiaChi)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaDinhDanh", maDinhDanh);
                    command.Parameters.AddWithValue("@TenNV", tenNV);
                    command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    command.Parameters.AddWithValue("@SDT", sdt);
                    command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    command.Parameters.AddWithValue("@ChucVu", chucVu);
                    command.Parameters.AddWithValue("@DiaChi", diaChi);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm nhân viên mới thành công.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi thêm nhân viên mới: " + ex.Message);
                    }
                }
            }
        }

        private void UpdateNhanVien(string maDinhDanh, string tenNV, string gioiTinh, string sdt, DateTime ngaySinh, string chucVu, string diaChi)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE NhanVien SET TenNV = @TenNV, GioiTinh = @GioiTinh, SDT = @SDT, NgaySinh = @NgaySinh, ChucVu = @ChucVu, DiaChi = @DiaChi WHERE MaDinhDanh = @MaDinhDanh";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaDinhDanh", maDinhDanh);
                    command.Parameters.AddWithValue("@TenNV", tenNV);
                    command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    command.Parameters.AddWithValue("@SDT", sdt);
                    command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    command.Parameters.AddWithValue("@ChucVu", chucVu);
                    command.Parameters.AddWithValue("@DiaChi", diaChi);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật thông tin nhân viên thành công.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi cập nhật thông tin nhân viên: " + ex.Message);
                    }
                }
            }
        }

        private void DeleteNhanVien(string maDinhDanh)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM NhanVien WHERE MaDinhDanh = @MaDinhDanh";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaDinhDanh", maDinhDanh);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa nhân viên thành công.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi xóa nhân viên: " + ex.Message);
                    }
                }
            }
        }

        private void ClearTextBoxes()
        {
            txtMaDinhDanh.Text = "";
            txtTenNV.Text = "";
            txtGioiTinh.Text = "";
            txtSDT.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            txtChucVu.Text = "";
            txtDiaChi.Text = "";
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

        private void ucQuanLyNV_Click(object sender, EventArgs e)
        {
            dataGridViewNV.ClearSelection();
        }

        private void kryptonGroupBox1_Panel_Click(object sender, EventArgs e)
        {
            dataGridViewNV.ClearSelection();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();

            // Kiểm tra xem TextBox tìm kiếm có rỗng không
            if (string.IsNullOrWhiteSpace(keyword))
            {
                // Nếu TextBox tìm kiếm rỗng, hiển thị tất cả các hàng trong DataGridView
                ShowAllRows();
            }
            else
            {
                // Nếu TextBox tìm kiếm không rỗng, thực hiện tìm kiếm
                Search(keyword);
            }
        }

        private void ShowAllRows()
        {
            // Hiển thị tất cả các hàng trong DataGridView
            foreach (DataGridViewRow row in dataGridViewNV.Rows)
            {
                row.Visible = true;
            }
        }

        private void Search(string keyword)
        {
            dataTableTimKiem = new DataTable();
            foreach (DataColumn column in dataTableNV.Columns)
            {
                dataTableTimKiem.Columns.Add(column.ColumnName, column.DataType);
            }

            foreach (DataRow row in dataTableNV.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    if (item.ToString().ToLower().Contains(keyword))
                    {
                        dataTableTimKiem.ImportRow(row);
                        break;
                    }
                }
            }

            dataGridViewNV.DataSource = dataTableTimKiem;
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Load lại dữ liệu từ cơ sở dữ liệu và đặt lại DataSource cho dataGridViewNV
            dataTableNV.Clear();
            LoadDataFromDatabase();
            dataGridViewNV.DataSource = dataTableNV;

            // Xóa nội dung trong TextBox tìm kiếm
            txtTimKiem.Text = "";
        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            //clear textbox
            txtTimKiem.Text = "";

        }

        private void ucQuanLyNV_Load(object sender, EventArgs e)
        {
            //vô hiệu hóa all textbox
            txtMaDinhDanh.Enabled = false;
            txtTenNV.Enabled = false;
            txtGioiTinh.Enabled = false;

            txtSDT.Enabled = false;
            dtpNgaySinh.Enabled = false;
            txtChucVu.Enabled = false;
            txtDiaChi.Enabled = false;

        }
    }
}
