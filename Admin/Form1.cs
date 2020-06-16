using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin
{
    
    public partial class Form1 : Form
    {
        static string sql = "Data Source=DESKTOP-JTEDAE2;Initial Catalog = flight; Integrated Security = True";
        SqlConnection con = new SqlConnection(sql);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand login = new SqlCommand(" select* from ADMINS where A_NAME='" + textBox2.Text + "' and A_PASSOWRD='" + textBox1.Text + "'", con);

            SqlDataAdapter a = new SqlDataAdapter(login);
            DataSet s = new DataSet();
            a.Fill(s);
            int count = s.Tables[0].Rows.Count;
            if(count>=1)
            {
                operation o = new operation();
                o.ShowDialog();
            }
            else
            {
                MessageBox.Show("invalid");
            }

        }
    }
}
