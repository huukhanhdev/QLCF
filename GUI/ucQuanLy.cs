using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucQuanLy : UserControl
    {
        public ucQuanLy()
        {
            InitializeComponent();
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            //panel QL hiển thị user control ucQuanLyNV
            panelQL.Controls.Clear();
            ucQuanLyNV ucQuanLyNV = new ucQuanLyNV();
            panelQL.Controls.Add(ucQuanLyNV);
        }
    }
}
