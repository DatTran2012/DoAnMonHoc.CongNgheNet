using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace QLShopQuanAo.Object
{
    class DataProvider
    {
        private SqlConnection cn;
        public SqlConnection Connect { get => cn; }

        public DataProvider()
        {
            cn = new SqlConnection("Data Source=DESKTOP-D2OFQU7\\SQLEXPRESS;Initial Catalog=QLShopQuanAo;Integrated Security=True");
        }
        //Lấy dữu liệu từ các bảng đổ lên DataSet
        
        //Thực thi câu select
        public DataTable ExecuteQuery(string jquery)
        {
            try
            {
                if (Connect.State == ConnectionState.Closed)
                    Connect.Open();
                SqlCommand cmd = new SqlCommand(jquery, Connect);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (Connect.State == ConnectionState.Open)
                    Connect.Close();
                return dt;
            }
            catch
            {
                return null;
            }
        }
        //Thực thi câu lệnh Count,Sum,Max
        public object ExecuteScalar(string jquery)
        {
            try
            {
                if (Connect.State == ConnectionState.Closed)
                    Connect.Open();
                SqlCommand cmd = new SqlCommand(jquery, Connect);
                object dt = cmd.ExecuteScalar();
                if (Connect.State == ConnectionState.Open)
                    Connect.Close();
                return dt;
            }
            catch
            {
                return null;
            }
        }

    }
}
