using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GUI
{

    public partial class ucThemMon : UserControl
    {
        private string connectionString = "Data Source=DESKTOP-LDAF2V1\\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;";


        // Thêm các thuộc tính mới
        public bool IsEdit { get; set; }
        public string SelectedTenMon { get; set; }

        public ucThemMon(bool isEdit, string tenMon)
        {
            InitializeComponent();
            //check giá trị bool isEdit
            IsEdit = isEdit;
            SelectedTenMon = tenMon;
            pictureHA.BringToFront();
            // Kiểm tra nếu đang ở chế độ chỉnh sửa
            if (IsEdit)
            {
                // check is edit
                LoadDataForEdit();
                // ô mã món không cho phép chỉnh sửa
                txtMaMon.Enabled = false;
            }


        }
        public ucThemMon()
        {
            InitializeComponent();


        }
        private void LoadDataForEdit()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Thực hiện truy vấn để lấy thông tin của món
                    string query = "SELECT MaMon, GiaTien, HinhAnh FROM Menu WHERE TenMon = @TenMon";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TenMon", SelectedTenMon);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Hiển thị dữ liệu lên các control
                                txtMaMon.Text = reader["MaMon"].ToString();
                                txtTenMon.Text = SelectedTenMon;
                                txtGiaTien.Text = reader["GiaTien"].ToString();

                                // Hiển thị hình ảnh
                                if (reader["HinhAnh"] != DBNull.Value)
                                {
                                    byte[] imageBytes = (byte[])reader["HinhAnh"];
                                    pictureHA.Image = ByteArrayToImage(imageBytes);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu từ CSDL: " + ex.Message);
            }
        }

        // Các phần còn lại của UserControl
        private void btnChonHA_Click_1(object sender, EventArgs e)
        {
            // Mở hộp thoại để chọn hình ảnh từ máy tính
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Hiển thị hình ảnh được chọn trên PictureBox
                pictureHA.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra nếu đang ở chế độ chỉnh sửa
            if (IsEdit)
            {
                // Thực hiện cập nhật dữ liệu
                UpdateData();
            }
            else
            {
                // Thực hiện thêm mới dữ liệu
                InsertData();
            }
        }

        // Method để cập nhật dữ liệu
        private void UpdateData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Chuyển đổi hình ảnh thành mảng byte
                    byte[] imageData = null;
                    if (pictureHA.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pictureHA.Image.Save(ms, pictureHA.Image.RawFormat);
                            imageData = ms.ToArray();
                        }
                    }

                    // Thực hiện truy vấn để cập nhật món vào cơ sở dữ liệu dựa vào khóa chính mã món và các thông tin mới được thay đổi: tên món, giá tiền, hình ảnh
                    string query = "UPDATE Menu SET TenMon = @TenMon, GiaTien = @GiaTien, HinhAnh = @HinhAnh WHERE MaMon = @MaMon";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TenMon", txtTenMon.Text);
                        command.Parameters.AddWithValue("@GiaTien", decimal.Parse(txtGiaTien.Text));
                        command.Parameters.AddWithValue("@HinhAnh", (object)imageData ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MaMon", txtMaMon.Text);
                        // nếu không cập nhật ảnh mới vào thì vẫn giữ nguyên ảnh cũ
                        if (imageData == null)
                        {
                            command.CommandText = "UPDATE Menu SET TenMon = @TenMon, GiaTien = @GiaTien WHERE MaMon = @MaMon";
                        }
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật món thành công!");
                            ClearFields();
                            this.Visible = false; // Ẩn UserControl khi đã cập nhật thành công
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật món không thành công. Vui lòng thử lại!");
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật món: " + ex.Message);
            }
        }

        // Method để thêm mới dữ liệu
        private void InsertData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Chuyển đổi hình ảnh thành mảng byte
                    byte[] imageData = null;
                    if (pictureHA.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pictureHA.Image.Save(ms, pictureHA.Image.RawFormat);
                            imageData = ms.ToArray();
                        }
                    }

                    // Thực hiện truy vấn để thêm món mới vào cơ sở dữ liệu
                    string query = "INSERT INTO Menu (MaMon, TenMon, GiaTien, HinhAnh) VALUES (@MaMon, @TenMon, @GiaTien, @HinhAnh)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaMon", txtMaMon.Text);
                        command.Parameters.AddWithValue("@TenMon", txtTenMon.Text);
                        command.Parameters.AddWithValue("@GiaTien", decimal.Parse(txtGiaTien.Text));
                        command.Parameters.AddWithValue("@HinhAnh", (object)imageData ?? DBNull.Value);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm món mới thành công!");
                            ClearFields();
                            this.Visible = false; // Ẩn UserControl khi đã thêm thành công
                        }
                        else
                        {
                            MessageBox.Show("Thêm món mới không thành công. Vui lòng thử lại!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm món mới: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            txtMaMon.Clear();
            txtTenMon.Clear();
            txtGiaTien.Clear();
            pictureHA.Image = null;
        }

        private void txtGiaTien_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtGiaTien.Text, out decimal giaTien))
            {
                // Giá trị đã nhập hợp lệ
            }
            else
            {
                // Hiển thị thông báo lỗi khi giá trị nhập vào không hợp lệ
                MessageBox.Show("Giá tiền không hợp lệ. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (var ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Ẩn UserControl
            this.Visible = false;
        }


    }
}
