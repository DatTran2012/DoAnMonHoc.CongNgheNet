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
namespace QLShopQuanAo
{
    partial class fThongBao : Form
    {
        public string MessageThongBao { get; set; }
        public fThongBao()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void fThongBao_Load(object sender, EventArgs e)
        {
            lblThongBao.Text = MessageThongBao;
        }
    }
}
