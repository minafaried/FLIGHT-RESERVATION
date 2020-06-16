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

namespace WindowsFormsApp1
{
    public partial class CreditCard : Form
    {
        static string sql = "Data Source=DESKTOP-JTEDAE2;Initial Catalog = flight; Integrated Security = True";
        SqlConnection con = new SqlConnection(sql);
       public string pid;
        public CreditCard()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

			con.Open();
			try
            {
				SqlCommand cmd = new SqlCommand("insert into CREDIT_CARD_DETAILS (p_id,CARD_NUM,CARD_TYPE,EXPIRATION_MONTH,EXPIRATION_YEAR)" + 
                    " VALUES ('"+pid.ToString()+"','" + textBox1.Text + "','" + textBox7.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", con);
				cmd.ExecuteNonQuery();
                con.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Reservation whas refused try agian......");
				con.Close();

				throw;
			}

            MessageBox.Show("Done....");
            this.Close();
        }
    }
}
