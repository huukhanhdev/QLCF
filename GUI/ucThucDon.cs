using Krypton.Toolkit;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace GUI
{
    public partial class ucThucDon : UserControl
    {
        private ucThemMon ucThemMonInstance;

        public ucThucDon()
        {
            InitializeComponent();
            LoadMenuFromDatabase();
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            this.listView1.View = System.Windows.Forms.View.Details;
            // ẩn panel details
            panelDetails.Visible = false;
            // Đảm bảo cột "Tên món" tự động điều chỉnh kích thước
            listView1.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void LoadMenuFromDatabase()
        {
            string connectionString = "Data Source=DESKTOP-LDAF2V1\\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;";
            string query = "SELECT TenMon FROM Menu";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Thêm tên món vào KryptonListView
                                ListViewItem item = new ListViewItem(reader["TenMon"].ToString());

                                // Thêm ListViewItem vào ListView
                                listView1.Items.Add(item);
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string selectedTenMon = listView1.SelectedItems[0].Text;
                // hiển thị panel details
                panelDetails.Visible = true;
                // Thực hiện truy vấn để lấy thông tin của món, bao gồm đường dẫn đến hình ảnh
                string connectionString = "Data Source=DESKTOP-LDAF2V1\\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;";
                string query = "SELECT MaMon, GiaTien, HinhAnh FROM Menu WHERE TenMon = @TenMon";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@TenMon", selectedTenMon);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string maMon = reader["MaMon"].ToString();
                                    string giaTien = reader["GiaTien"].ToString();
                                    // Hiển thị thông tin món trong panelDetails
                                    labelTenMon.Text = "Tên món: " + selectedTenMon;
                                    labelMaMon.Text = "Mã món: " + maMon;
                                    labelGiaTien.Text = "Giá tiền: " + giaTien;

                                    // Hiển thị hình ảnh
                                    if (reader["HinhAnh"] != DBNull.Value)
                                    {
                                        byte[] imageBytes = (byte[])reader["HinhAnh"];
                                        pictureBoxHA.Image = ByteArrayToImage(imageBytes);
                                    }
                                    else
                                    {
                                        pictureBoxHA.Image = null; // Xóa hình ảnh nếu không có dữ liệu
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
        }

        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (var ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (ucThemMonInstance == null)
            {
                ucThemMonInstance = new ucThemMon();
                ucThemMonInstance.Dock = DockStyle.Fill;
                Controls.Add(ucThemMonInstance);
            }

            // Hiển thị ucThemMon
            ucThemMonInstance.Visible = true;
            ucThemMonInstance.BringToFront();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {   // kiểm tra xem có đang select item nào không, nếu có mới
            string selectItem = listView1.SelectedItems[0].Text;
            
            ucThemMonInstance = new ucThemMon(true, selectItem);

            // Chuyển sang chế độ chỉnh sửa và truyền tên món được chọn
               

                ucThemMonInstance.Dock = DockStyle.Fill;
                 Controls.Add(ucThemMonInstance);
            

            // Hiển thị ucThemMon
            ucThemMonInstance.Visible = true;
            ucThemMonInstance.BringToFront();
        }

        
    }
}
