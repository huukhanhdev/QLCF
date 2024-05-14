using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucBanHang : UserControl
    {
        public ucBanHang()
        {
            InitializeComponent();
            LoadTablesFromDatabase();
        }

        private void LoadTablesFromDatabase()
        {
            string connectionString = "Data Source=DESKTOP-LDAF2V1\\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MaBan, TenBan, TrangThai FROM Ban";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string maBan = reader.GetString(0);
                            string tenBan = reader.GetString(1);
                            bool trangThai = reader.GetBoolean(2);

                            AssignTableInfoToPictureBox(maBan, tenBan, trangThai);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu từ cơ sở dữ liệu: " + ex.Message);
                    }
                }
            }
        }

        private void AssignTableInfoToPictureBox(string maBan, string tenBan, bool trangThai)
        {
            PictureBox pictureBox = null;
            switch (maBan)
            {
                case "ban01":
                    pictureBox = Ban01;
                    break;
                case "ban02":
                    pictureBox = Ban02;
                    break;
                case "ban03":
                    pictureBox = Ban03;
                    break;
                case "ban04":
                    pictureBox = Ban04;
                    break;
                case "ban05":
                    pictureBox = Ban05;
                    break;
                //code từ bàn 06 tới 20
                case "ban06":
                    pictureBox = Ban06;
                    break;
                case "ban07":
                    pictureBox = Ban07;
                    break;
                case "ban08":
                    pictureBox = Ban08;
                    break;
                case "ban09":
                    pictureBox = Ban09;
                    break;
                case "ban10":
                    pictureBox = Ban10;
                    break;
                case "ban11":
                    pictureBox = Ban11;
                    break;
                case "ban12":
                    pictureBox = Ban12;
                    break;
                case "ban13":
                    pictureBox = Ban13;
                    break;
                case "ban14":
                    pictureBox = Ban14;
                    break;
                case "ban15":
                    pictureBox = Ban15;
                    break;
                case "ban16":
                    pictureBox = Ban16;
                    break;
                case "ban17":
                    pictureBox = Ban17;
                    break;
                case "ban18":
                    pictureBox = Ban18;
                    break;
                case "ban19":
                    pictureBox = Ban19;
                    break;
                case "ban20":
                    pictureBox = Ban20;
                    break;


                default:
                    return;
            }

            pictureBox.Tag = maBan;
            pictureBox.AccessibleName = tenBan;
            //picturebox màu là xanh nếu trạng thái true và trắng nếu false
            pictureBox.BackColor = trangThai ? Color.Blue : Color.White;


            if (trangThai == true)
            {
                pictureBox.Image = Properties.Resources.cf_dadat2;
            }
            else
            {
                pictureBox.Image = Properties.Resources.cf_trong;
            }

        }

        private void Ban_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            string maBan = pictureBox.Tag.ToString();
            string tenBan = pictureBox.AccessibleName;
            bool trangThai = pictureBox.BackColor == Color.Blue;
            // trạng thái bàn là true nếu pictureBox.Image là cf_dadat2 và ngược lại



            ucThongTinBan ucTTBan = new ucThongTinBan(maBan, trangThai);
            ucTTBan.UpdateDetails(maBan, tenBan, trangThai);

            panelDetails.Controls.Clear();
            panelDetails.Controls.Add(ucTTBan);
        }

        private void ucBanHang_Load(object sender, EventArgs e)
        {
            LoadTablesFromDatabase();
        }

        private void ucBanHang_KeyPress(object sender, KeyPressEventArgs e)
        {               //nếu nhấn phím F5 thì load lại dữ liệu từ cơ sở dữ liệu
            if (e.KeyChar == (char)Keys.F5)
            {
                LoadTablesFromDatabase();
            }

        }


    }
}
