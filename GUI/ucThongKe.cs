using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucThongKe : UserControl
    {
        public ucThongKe()
        {
            InitializeComponent();
            listView1.View = View.Details;
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            // Lấy ngày bắt đầu và ngày kết thúc từ DateTimePicker
            DateTime startDate1 = startDate.Value.Date;
            DateTime endDate1 = endDate.Value.Date.AddDays(1).AddSeconds(-1); // Thêm một ngày và giảm một giây để lấy đến cuối ngày kết thúc

            // Lấy danh sách hóa đơn trong khoảng thời gian đã chọn
            List<HoaDon> danhSachHoaDon = LayDanhSachHoaDonTheoKhoangThoiGian(startDate1, endDate1);

            // Hiển thị danh sách hóa đơn lên ListView
            HienThiDanhSachHoaDon(danhSachHoaDon);
        }

        private List<HoaDon> LayDanhSachHoaDonTheoKhoangThoiGian(DateTime startDate, DateTime endDate)
        {
            List<HoaDon> danhSachHoaDon = new List<HoaDon>();

            // Duyệt qua tất cả các hóa đơn trong CSDL, so sánh ngayLapHoaDon với khoảng thời gian đã chọn
            // Nếu ngayLapHoaDon nằm trong khoảng thời gian đã chọn thì thêm hóa đơn đó vào danh sách
            // dùng query để lấy dữ liệu từ CSDL
            string query = "SELECT * FROM HoaDon WHERE NgayLapHoaDon >= @startDate AND NgayLapHoaDon <= @endDate";
            string connectionString = "Data Source=DESKTOP-LDAF2V1\\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string maHoaDon = reader.GetString(0);
                            string maBan = reader.GetString(1);
                            string maDinhDanh = reader.GetString(2);
                            float tongTien = (float)reader.GetDouble(3);
                            string ptThanhToan = reader.GetString(4);
                            DateTime ngayLapHoaDon = reader.GetDateTime(5);

                            HoaDon hoaDon = new HoaDon(maHoaDon, maBan, maDinhDanh, tongTien, ptThanhToan, ngayLapHoaDon);
                            danhSachHoaDon.Add(hoaDon);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu từ cơ sở dữ liệu: " + ex.Message);
                    }
                }
            }


            return danhSachHoaDon;
        }
        private void HienThiDanhSachHoaDon(List<HoaDon> danhSachHoaDon)
        {
            // Xóa tất cả các mục trên ListView trước khi hiển thị danh sách mới
            listView1.Items.Clear();

            // Duyệt qua danh sách hóa đơn và thêm từng mục vào ListView
            foreach (HoaDon hoaDon in danhSachHoaDon)
            {
                ListViewItem item = new ListViewItem(hoaDon.MaHoaDon);
                item.SubItems.Add(hoaDon.MaBan);
                item.SubItems.Add(hoaDon.MaDinhDanh);
                item.SubItems.Add(hoaDon.TongTien.ToString());
                item.SubItems.Add(hoaDon.PTTT);
                item.SubItems.Add(hoaDon.NgayLapHoaDon.ToString("dd/MM/yyyy HH:mm:ss")); // Định dạng ngày tháng giờ

                listView1.Items.Add(item);
            }
        }
        private void ucThongKe_Load(object sender, EventArgs e)
        {
            // chỉnh độ rộng của các cột trong ListView
            listView1.Columns[0].Width = 100;
            listView1.Columns[1].Width = 100;
            listView1.Columns[2].Width = 100;
            listView1.Columns[3].Width = 100;
            listView1.Columns[4].Width = 100;
            listView1.Columns[5].Width = 150;
            // Mặc định hiển thị danh sách hóa đơn trong ngày hôm nay
            DateTime startDate = DateTime.Now.Date;
            DateTime endDate = DateTime.Now.Date.AddDays(1).AddSeconds(-1);

            List<HoaDon> danhSachHoaDon = LayDanhSachHoaDonTheoKhoangThoiGian(startDate, endDate);
            HienThiDanhSachHoaDon(danhSachHoaDon);

        }
        //xuất file excel các nội dung trong listview
        private void btnXuat_Click(object sender, EventArgs e)
        {
            // Khởi tạo ứng dụng Excel
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            if (excelApp == null)
            {
                MessageBox.Show("Excel không được cài đặt!");
                return;
            }

            // Tạo một workbook mới và lấy sheet đầu tiên
            excelApp.Visible = false;
            var workbook = excelApp.Workbooks.Add(Type.Missing);
            var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];

            // Xuất tiêu đề cột
            for (int i = 1; i < listView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = listView1.Columns[i - 1].Text;
            }

            // Xuất dữ liệu
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                for (int j = 0; j < listView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = listView1.Items[i].SubItems[j].Text;
                }
            }

            // Mở cửa sổ Save As để người dùng chọn đường dẫn và tên tệp
            workbook.SaveAs(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            workbook.Close(true, Type.Missing, Type.Missing);
            excelApp.Quit();

            MessageBox.Show("Dữ liệu đã được xuất ra file Excel.", "Thông báo");
        }


    }
}
