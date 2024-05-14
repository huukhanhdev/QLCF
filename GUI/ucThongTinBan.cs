using DTO;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucThongTinBan : UserControl
    {        //lấy mã định danh của nhân viên đang đăng nhập


        public ucThongTinBan(string maBan, bool trangThai)
        {
            InitializeComponent();
            this.listView1.View = System.Windows.Forms.View.Details;
            listView1.Columns.Add("Tên Món", 200);
            listView1.Columns.Add("Số Lượng", 100);
            listView1.Columns.Add("Xóa", 50);
            if (trangThai == true)
            {
                HienThiChiTietHoaDon(maBan);
            }

        }
        private void HienThiChiTietHoaDon(string maBan)
        {
            string maHoaDon = LayMaHoaDonGanNhatTheoMaBan(maBan); // Lấy mã hóa đơn mới nhất của bàn

            if (!string.IsNullOrEmpty(maHoaDon))
            {
                // Nếu có mã hóa đơn, hiển thị chi tiết hóa đơn lên ListView
                HienThiChiTietHoaDonLenListView(maHoaDon);
            }
            else
            {
                MessageBox.Show("Bàn chưa có hóa đơn");
            }
        }

        private string LayMaHoaDonGanNhatTheoMaBan(string maBan)
        {
            string maHoaDon = "";

            string connectionString = "Data Source=DESKTOP-LDAF2V1\\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;";
            string query = "SELECT TOP 1 MaHoaDon FROM HoaDon WHERE MaBan = @MaBan ORDER BY MaHoaDon DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaBan", maBan);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        maHoaDon = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi truy vấn dữ liệu: " + ex.Message);
                }
            }

            return maHoaDon;
        }

        private void HienThiChiTietHoaDonLenListView(string maHoaDon)
        {
            listView1.Items.Clear();

            string connectionString = "Data Source=DESKTOP-LDAF2V1\\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;";
            string query = "SELECT TenMon, SoLuong FROM CTHD WHERE MaHoaDon = @MaHoaDon";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string tenMon = reader["TenMon"].ToString();
                        int soLuong = Convert.ToInt32(reader["SoLuong"]);

                        ListViewItem item = new ListViewItem(tenMon);
                        item.SubItems.Add(soLuong.ToString());
                        item.ImageIndex = 0; // Sử dụng hình ảnh có index là 0

                        // Thêm dấu X màu đỏ vào cột thứ 3
                        item.SubItems.Add("X").ForeColor = Color.Red;

                        listView1.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi truy vấn dữ liệu: " + ex.Message);
                }
            }
        }


        public void UpdateDetails(string maBan, string tenBan, bool trangThai)
        {
            txtMaBan.Text = maBan;
            txtTenBan.Text = tenBan;
            if (trangThai == true)
            {
                txtTrangThai.Text = "Đã đặt";
                pictureBox1.Image = Properties.Resources.ON_Click;
            }
            else
            {
                txtTrangThai.Text = "Trống";
                pictureBox1.Image = Properties.Resources.OFF_click1;
            }
            LoadMenuFromDatabase();
        }

        //thêm tên các món ăn ở database vào thanh combobox để lựa chọn
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
                                // Thêm tên món vào combobox
                                cboMonAn.Items.Add(reader["TenMon"].ToString());
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

        //khi nhấn btnThem, thêm món ăn và số lượng vào row trong listview tương ứng
        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenMon = cboMonAn.Text;
            string soLuong = txtSoLuong.Text;

            if (string.IsNullOrEmpty(tenMon) || string.IsNullOrEmpty(soLuong))
            {
                MessageBox.Show("Vui lòng chọn món ăn và nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem sản phẩm đã tồn tại trong listview chưa
            ListViewItem existingItem = TimMonTrongListView(tenMon);
            if (existingItem != null)
            {
                // Nếu sản phẩm đã tồn tại, tăng số lượng của sản phẩm
                int currentQuantity = int.Parse(existingItem.SubItems[1].Text);
                currentQuantity += int.Parse(soLuong);
                existingItem.SubItems[1].Text = currentQuantity.ToString();
            }
            else
            {
                // Nếu sản phẩm chưa tồn tại, thêm sản phẩm vào listview
                ListViewItem item = new ListViewItem(tenMon);
                item.SubItems.Add(soLuong);
                item.ImageIndex = 0; // Sử dụng hình ảnh có index là 0
                item.SubItems.Add("X").ForeColor = Color.Red; // Thêm dấu X màu đỏ vào cột thứ 3

                listView1.Items.Add(item);
            }


        }
        private ListViewItem TimMonTrongListView(string tenMon)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[0].Text.Equals(tenMon))
                {
                    return item; // Trả về item nếu tìm thấy sản phẩm có tên tương tự trong listview
                }
            }
            return null; // Trả về null nếu không tìm thấy sản phẩm
        }
        // Vẽ dấu X màu đỏ cho mỗi subitem trong cột thứ 3
        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Item != null)
            {
                e.DrawDefault = true; // Vẽ nội dung mặc định của ListViewItem

                // Lấy kích thước của dấu X
                Size textSize = TextRenderer.MeasureText("X", e.Item.Font);

                // Tính toán vị trí để vẽ dấu X giữa subitem
                int x = e.Bounds.Left + (e.Bounds.Width - textSize.Width) / 2;
                int y = e.Bounds.Top + (e.Bounds.Height - textSize.Height) / 2;

                // Vẽ dấu X màu đỏ
                e.Graphics.DrawString("X", e.Item.Font, Brushes.Red, x, y);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        // Xóa mục khi nhấp chuột vào dấu X
        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hitTest = listView1.HitTest(e.Location);
            if (hitTest.SubItem != null && hitTest.SubItem.Bounds.Contains(e.Location) && hitTest.SubItem == hitTest.Item.SubItems[2])
            {
                // Click vào cột thứ 3 của một hàng
                // Thực hiện xử lý xóa hàng tương ứng
                MessageBox.Show("Xóa món ăn " + hitTest.Item.Text);
                listView1.Items.Remove(hitTest.Item);
            }
        }
        //tạo hóa đơn mới 

        private void ThemSanPhamVaoCTHD(string maHD)
        {
            string connectionString = "Data Source=DESKTOP-LDAF2V1\\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;";
            string query = "INSERT INTO CTHD (MaHoaDon, TenMon, SoLuong, ThanhTien) VALUES (@MaHoaDon, @TenMon, @SoLuong, @ThanhTien)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (ListViewItem item in listView1.Items)
                {
                    string tenMon = item.SubItems[0].Text;
                    int soLuong = int.Parse(item.SubItems[1].Text);

                    float gia = LayGiaSanPham(tenMon);
                    float thanhTien = gia * soLuong;

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaHoaDon", maHD);
                    command.Parameters.AddWithValue("@TenMon", tenMon);
                    command.Parameters.AddWithValue("@SoLuong", soLuong);
                    command.Parameters.AddWithValue("@ThanhTien", thanhTien);

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Đã thêm sản phẩm vào chi tiết hóa đơn thành công");
        }

        private string GenerateMaHoaDon()
        {
            // Kiểm tra mã hóa đơn lớn nhất trong cơ sở dữ liệu
            string maxMaHoaDon = GetMaxMaHoaDonFromDatabase();

            // Sinh mã hóa đơn mới dựa trên mã hóa đơn lớn nhất đã tồn tại
            string newMaHoaDon = "";

            if (!string.IsNullOrEmpty(maxMaHoaDon))
            {
                int number = int.Parse(maxMaHoaDon.Substring(2)) + 1;
                newMaHoaDon = "HD" + number.ToString("0000");
            }
            else
            {
                newMaHoaDon = "HD0001"; // Nếu không có hóa đơn nào trong cơ sở dữ liệu
            }

            return newMaHoaDon;
        }
        private string GetMaxMaHoaDonFromDatabase()
        {
            string connectionString = "Data Source=DESKTOP-LDAF2V1\\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;";
            string query = "SELECT MAX(MaHoaDon) FROM HoaDon";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    return result.ToString();
                }
            }

            return "";
        }
        private float LayGiaSanPham(string tenMon)
        {

            // Triển khai logic để lấy giá của sản phẩm từ CSDL
            // Ví dụ:
            // Sử dụng câu truy vấn SQL để lấy giá của sản phẩm từ bảng Menu
            // Đảm bảo sử dụng tham số để tránh các vấn đề bảo mật và chuỗi SQL Injection
            string connectionString = "Data Source=DESKTOP-LDAF2V1\\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;";
            string query = "SELECT GiaTien FROM Menu WHERE TenMon = @TenMon";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenMon", tenMon);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    return float.Parse(result.ToString());
                }
            }

            return 0;

        }

        private void ucThongTinBan_Load(object sender, EventArgs e)
        {
            listView1.Columns[0].Width = 200;
            listView1.Columns[1].Width = 100;
            listView1.Columns[2].Width = 50;
        }

        private bool LuuHoaDonVaoCSDL(string maHoaDon, string maBan, string maDinhDanh, float tongTien, DateTime NgayLap)
        {
            string connectionString = "Data Source=DESKTOP-LDAF2V1\\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;";
            string query = "INSERT INTO HoaDon (MaHoaDon, MaBan, MaDinhDanh, TongTien, NgayLap) VALUES (@MaHoaDon, @MaBan, @MaDinhDanh, @TongTien, @NgayLap)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                command.Parameters.AddWithValue("@MaBan", maBan);
                command.Parameters.AddWithValue("@MaDinhDanh", maDinhDanh);
                command.Parameters.AddWithValue("@TongTien", tongTien);
                command.Parameters.AddWithValue("@NgayLap", NgayLap);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu có ít nhất một hàng được thêm vào cơ sở dữ liệu
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu hóa đơn vào cơ sở dữ liệu: " + ex.Message);
                    return false;
                }
            }
        }

        // Phương thức để lưu hóa đơn vào cơ sở dữ liệu
        private bool LuuHoaDonVaoCSDL(HoaDon hoaDon)
        {
            string connectionString = "Data Source=DESKTOP-LDAF2V1\\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;";
            string query = "INSERT INTO HoaDon (MaHoaDon, MaBan, MaDinhDanh, TongTien, NgayLapHoaDon) VALUES (@MaHoaDon, @MaBan, @MaDinhDanh, @TongTien, @NgayLapHoaDon)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaHoaDon", hoaDon.MaHoaDon);
                command.Parameters.AddWithValue("@MaBan", hoaDon.MaBan);
                command.Parameters.AddWithValue("@MaDinhDanh", hoaDon.MaDinhDanh);
                command.Parameters.AddWithValue("@TongTien", hoaDon.TongTien);
                command.Parameters.AddWithValue("@NgayLapHoaDon", hoaDon.NgayLapHoaDon); // Thêm tham số cho ngày lập hóa đơn

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu có ít nhất một hàng được thêm vào cơ sở dữ liệu
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu hóa đơn vào cơ sở dữ liệu: " + ex.Message);
                    return false;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // check trạng thái bàn đã đặt hay chưa, nếu đã đặt rồi thì không thể nhấn btnLuu
            if (txtTrangThai.Text == "Đã đặt")
            {
                MessageBox.Show("Bàn đã đặt, không thể tạo mới hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maHoaDon = GenerateMaHoaDon(); // Tạo mã hóa đơn mới

            // Lấy ngày giờ hiện tại
            DateTime ngayLapHoaDon = DateTime.Now;

            // Tạo đối tượng HoaDon mới
            HoaDon hoaDon = new HoaDon
            (
                maHoaDon,
                txtMaBan.Text,
                txtMaDinhDanh.Text,
                TinhTongTien(),
                ngayLapHoaDon // Gán ngày giờ hiện tại cho trường NgayLapHoaDon
            );

            // Lưu hóa đơn vào cơ sở dữ liệu
            if (LuuHoaDonVaoCSDL(hoaDon))
            {
                // Nếu lưu hóa đơn thành công, tiếp tục lưu các chi tiết hóa đơn (CTHD)
                ThemSanPhamVaoCTHD(maHoaDon);
                MessageBox.Show("Đã thêm sản phẩm vào hóa đơn thành công");
                CapNhatTrangThaiBan(txtMaBan.Text, true);
            }
            else
            {
                MessageBox.Show("Lỗi khi lưu hóa đơn vào cơ sở dữ liệu");
            }
        }

        private float TinhTongTien()
        {
            float tongTien = 0;

            foreach (ListViewItem item in listView1.Items)
            {
                string tenMon = item.SubItems[0].Text;
                int soLuong = int.Parse(item.SubItems[1].Text);
                float giaTien = LayGiaSanPham(tenMon);

                tongTien += giaTien * soLuong;
            }

            return tongTien;
        }
        private bool KiemTraMonTonTaiTrongCTHD(string maBan, string tenMon)
        {
            string maHoaDon = LayMaHoaDonGanNhatTheoMaBan(maBan);

            if (string.IsNullOrEmpty(maHoaDon))
            {
                return false; // Không có hóa đơn nào cho số bàn này
            }

            string connectionString = "Data Source=DESKTOP-LDAF2V1\\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;";
            string query = "SELECT COUNT(*) FROM CTHD WHERE MaHoaDon = @MaHoaDon AND TenMon = @TenMon";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                command.Parameters.AddWithValue("@TenMon", tenMon);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0; // Trả về true nếu món đã tồn tại trong CTHD
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kiểm tra món tồn tại trong chi tiết hóa đơn: " + ex.Message);
                    return false;
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string maBan = txtMaBan.Text;
            // nếu trạng thái bàn là trống thì không thể cập nhật
            if (txtTrangThai.Text == "Trống")
            {
                MessageBox.Show("Bàn trống, không thể cập nhật hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra xem listview có thay đổi gì không
            if (listView1.Items.Count >= 0)
            {
                // Nếu có thay đổi, kiểm tra từng món trong listview
                foreach (ListViewItem item in listView1.Items)
                {
                    string tenMon = item.SubItems[0].Text;
                    int soLuong = int.Parse(item.SubItems[1].Text);

                    if (!KiemTraMonTonTaiTrongCTHD(maBan, tenMon))
                    {
                        // Nếu món mới được thêm vào, thêm tất cả các món mới vào CTHD
                        ThemSanPhamVaoCTHD(maBan, tenMon, soLuong);
                    }
                    else
                    {
                        // Nếu món đã tồn tại, cập nhật số lượng của món trong CTHD
                        CapNhatSoLuongMonTrongCTHD(maBan, tenMon, soLuong);
                    }
                }

                // Sau khi thêm hoặc cập nhật các món trong CTHD, cập nhật tổng tiền hóa đơn
                CapNhatTongTienHoaDon(maBan);
            }
            else
            {
                MessageBox.Show("Vui lòng thêm món vào hóa đơn trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void XoaSanPhamKhoiCTHD(string maHoaDon, string maBan, string tenMon)
        {
            string connectionString = "Data Source=DESKTOP-LDAF2V1\\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;";
            string query = "DELETE FROM CTHD WHERE MaHoaDon = @MaHoaDon AND TenMon = @TenMon";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    command.Parameters.AddWithValue("@TenMon", tenMon);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Cập nhật tổng tiền hóa đơn sau khi xóa sản phẩm
                            CapNhatTongTienHoaDon(maBan);
                            MessageBox.Show("Đã xóa sản phẩm khỏi CTHD thành công");
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sản phẩm trong CTHD để xóa");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa sản phẩm khỏi CTHD: " + ex.Message);
                    }
                }
            }
        }


        private void ThemSanPhamVaoCTHD(string maBan, string tenMon, int soLuong)
        {
            string maHoaDon = LayMaHoaDonGanNhatTheoMaBan(maBan);
            float gia = LayGiaSanPham(tenMon);
            float thanhTien = gia * soLuong;

            string connectionString = "Data Source=DESKTOP-LDAF2V1\\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;";
            string query = "INSERT INTO CTHD (MaHoaDon, TenMon, SoLuong, ThanhTien) VALUES (@MaHoaDon, @TenMon, @SoLuong, @ThanhTien)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                command.Parameters.AddWithValue("@TenMon", tenMon);
                command.Parameters.AddWithValue("@SoLuong", soLuong);
                command.Parameters.AddWithValue("@ThanhTien", thanhTien);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm sản phẩm vào chi tiết hóa đơn: " + ex.Message);
                }
            }
        }

        private void CapNhatSoLuongMonTrongCTHD(string maBan, string tenMon, int soLuong)
        {
            string maHoaDon = LayMaHoaDonGanNhatTheoMaBan(maBan);
            float gia = LayGiaSanPham(tenMon);
            float thanhTien = gia * soLuong;

            string connectionString = "Data Source=DESKTOP-LDAF2V1\\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;";
            string query = "UPDATE CTHD SET SoLuong = @SoLuong, ThanhTien = @ThanhTien WHERE MaHoaDon = @MaHoaDon AND TenMon = @TenMon";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SoLuong", soLuong);
                command.Parameters.AddWithValue("@ThanhTien", thanhTien);
                command.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                command.Parameters.AddWithValue("@TenMon", tenMon);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật số lượng món trong chi tiết hóa đơn: " + ex.Message);
                }
            }
        }

        private void CapNhatTongTienHoaDon(string maBan)
        {
            string maHoaDon = LayMaHoaDonGanNhatTheoMaBan(maBan);
            float tongTien = TinhTongTien();

            string connectionString = "Data Source=DESKTOP-LDAF2V1\\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;";
            string query = "UPDATE HoaDon SET TongTien = @TongTien WHERE MaHoaDon = @MaHoaDon";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TongTien", tongTien);
                command.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Đã cập nhật tổng tiền hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật tổng tiền hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (txtTrangThai.Text == "Đã đặt")
            {
                pictureBox1.Image = Properties.Resources.ON_Click1;
                txtTrangThai.Text = "Trống";
                CapNhatTrangThaiBan(txtMaBan.Text, false);

            }

            else if (txtTrangThai.Text == "Trống")
            {
                pictureBox1.Image = Properties.Resources.OFF_click1;
                txtTrangThai.Text = "Đã đặt";
                CapNhatTrangThaiBan(txtMaBan.Text, true);
            }
        }
        private void CapNhatTrangThaiBan(string maBan, bool trangThai)
        {
            string connectionString = "Data Source=DESKTOP-LDAF2V1\\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;";
            string query = "UPDATE Ban SET TrangThai = @TrangThai WHERE MaBan = @MaBan";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TrangThai", trangThai);
                command.Parameters.AddWithValue("@MaBan", maBan);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Đã cập nhật trạng thái bàn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy bàn để cập nhật trạng thái", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật trạng thái bàn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // cài đặt nhấn F5 tải dữ liệu bàn lên lại
        private void ucThongTinBan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                LoadMenuFromDatabase();
            }
        }
        // khi nhấn btnThanhToan, mở form thanh toán lên
        private void btnThanhToan_Click(object sender, EventArgs e)
        {

            string maHoaDon = LayMaHoaDonGanNhatTheoMaBan(txtMaBan.Text);
            //check trạng thái bàn đã đặt hay chưa, nếu chưa đặt thì không thể thanh toán
            if (txtTrangThai.Text == "Trống")
            {
                MessageBox.Show("Bàn trống, không thể thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(maHoaDon))
            {
                MessageBox.Show("Bàn chưa có hóa đơn, không thể thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // check xem pttt của hóa đơn này là null hay không, nếu null thì cho phép thanh toán, còn không hiện thông báo hóa đơn đã thanh toán
            string ptThanhToan = LayPhuongThucThanhToan(maHoaDon);
            if (string.IsNullOrEmpty(ptThanhToan))
            {
                ThanhToan frmThanhToan = new ThanhToan(maHoaDon, TinhTongTien());
                frmThanhToan.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hóa đơn đã được thanh toán, không cần thanh toán nữa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
        private string LayPhuongThucThanhToan(string maHoaDon)
        {
            string ptThanhToan = "";
            string connectionString = "Data Source=DESKTOP-LDAF2V1\\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;";
            string query = "SELECT PhuongThucThanhToan FROM HoaDon WHERE MaHoaDon = @MaHoaDon";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        ptThanhToan = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi truy vấn dữ liệu: " + ex.Message);
                }
            }

            return ptThanhToan;
        }

        private void cboMonAn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}




