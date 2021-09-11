using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLShopQuanAo
{
    partial class fThongBaoYesNo : Form
    {
        public String Message_ThongBao { get; set; }
        public string Check { get; set; }
        public fThongBaoYesNo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Check = "Có";
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Check = "Không";
            this.Hide();
        }

        private void ThongBaoYesNo_Load(object sender, EventArgs e)
        {
            lblThongBao.Text = Message_ThongBao;
            
        }
    }
}
