using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
namespace GUI
{
    public partial class ThanhToan : Form
    {
        private string maHoaDon;
        private float TongTien;
        public ThanhToan(string maHoaDon, float TongTien)
        {
            InitializeComponent();
            this.maHoaDon = maHoaDon;
            this.TongTien = TongTien;
        }

        private void picCK_Click(object sender, EventArgs e)
        {
            // Thực hiện thanh toán bằng chuyển khoản
            UpdatePaymentMethod("CK");
            // hiển thị dialog có muốn in hóa đơn không
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn in hóa đơn không?", "In hóa đơn", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SavePDF();
                MessageBox.Show("Hóa đơn đã được in.");
            }
            else if (dialogResult == DialogResult.No)
            {
                // không in hóa đơn
            }
            this.Close();
        }
        //lưu hóa đơn thành file pdf để in

        private void SavePDF()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Thiết lập các thuộc tính cho SaveFileDialog
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Lưu hóa đơn dưới dạng PDF";
                saveFileDialog.DefaultExt = "pdf";
                saveFileDialog.AddExtension = true;

                // Hiển thị hộp thoại SaveFileDialog
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn file từ hộp thoại
                    string path = saveFileDialog.FileName;

                    // Tạo và lưu file PDF tại đường dẫn đã chọn
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

                    // Tạo một writer để ghi tài liệu vào file PDF
                    PdfWriter.GetInstance(pdfDoc, new FileStream(path, FileMode.Create));

                    // Mở tài liệu để thêm nội dung
                    pdfDoc.Open();

                    // Thêm nội dung vào tài liệu PDF ở đây
                    // Ví dụ: Thêm một đoạn văn bản
                    pdfDoc.Add(new Paragraph("Quan Ca Phe HK"));
                    pdfDoc.Add(new Paragraph("Ma Hoa Don: " + maHoaDon));
                    pdfDoc.Add(new Paragraph("Ngay Lap Hoa Don: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")));
                    pdfDoc.Add(new Paragraph("Phuong Thuc Thanh Toan: CK"));
                    pdfDoc.Add(new Paragraph("Tong Tien: " + TongTien + " VND"));


                    // Đóng tài liệu
                    pdfDoc.Close();

                    MessageBox.Show("Hóa đơn đã được lưu thành file PDF tại: " + path);

                }
                else
                {
                    MessageBox.Show("Quá trình lưu file đã bị hủy.");
                }
            }
        }

      
        private void picTM_Click(object sender, EventArgs e)
        {
            // Thực hiện thanh toán bằng tiền mặt
            UpdatePaymentMethod("TM");
            // hiển thị dialog có muốn in hóa đơn không
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn in hóa đơn không?", "In hóa đơn", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SavePDF();
                MessageBox.Show("Hóa đơn đã được in.");
            }
            else if (dialogResult == DialogResult.No)
            {
                // không in hóa đơn
            }
            this.Close();
        }

        // Hàm cập nhật phương thức thanh toán vào hóa đơn trong csdl
        private void UpdatePaymentMethod(string paymentMethod)
        {
            try
            {
                // Kết nối đến CSDL và thực hiện cập nhật
                string connectionString = "Data Source=DESKTOP-LDAF2V1\\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE HoaDon SET PhuongThucThanhToan = @PhuongThucThanhToan WHERE MaHoaDon = @MaHoaDon";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PhuongThucThanhToan", paymentMethod);
                        command.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật phương thức thanh toán thành công.");
                        }
                        else
                        {
                            MessageBox.Show("Không có hóa đơn nào được cập nhật.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật phương thức thanh toán: " + ex.Message);
            }
        }

    }
}
