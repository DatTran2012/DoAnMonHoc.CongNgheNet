using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLShopQuanAo.Object;
namespace QLShopQuanAo
{
    partial class fInHoaDon : Form
    {
        public int MaHD { get; set; }
        public fInHoaDon()
        {
            InitializeComponent();
        }

        private void fInHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                DataProvider pro = new DataProvider();
                string jquery = "InHoaDon " +MaHD.ToString();
                SqlDataAdapter da = new SqlDataAdapter(jquery, pro.Connect);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                    MessageBox.Show("Không có dữu liệu");
                RPHoaDon rphd = new RPHoaDon();
                rphd.SetDataSource(dt);
                crystalReportViewer1.ReportSource = rphd;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi!");
            }
        }
    }
}
