using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLShopQuanAo.Object;
using System.Data.SqlClient;
namespace QLShopQuanAo
{
    public partial class fInPhieuNhap : Form
    {
        public int MaPN { get; set; }
        public fInPhieuNhap()
        {
            InitializeComponent();
        }

        private void fInPhieuNhap_Load(object sender, EventArgs e)
        {
            RPPhieuNhap rppn = new RPPhieuNhap();
            rppn.SetParameterValue(0, MaPN);
            crystalReportViewer1.ReportSource = rppn;
        }
    }
}
