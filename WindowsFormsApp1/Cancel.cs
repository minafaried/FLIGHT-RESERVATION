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
    public partial class Cancel : Form
    {
        static string sql = "Data Source=DESKTOP-JTEDAE2;Initial Catalog = flight; Integrated Security = True";
        SqlConnection con = new SqlConnection(sql);

        public Cancel()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                string fid2;
                SqlCommand getfid2 = new SqlCommand("select FLIGHTID from TICKET where TICKET_ID='" + textBox1.Text + "'", con);
                {
                    fid2 = getfid2.ExecuteScalar().ToString();
                }

                string pid;
                SqlCommand getpid = new SqlCommand("select P_ID from TICKET where TICKET_ID='" + textBox1.Text + "'", con);
                {
                    pid = getpid.ExecuteScalar().ToString();
                }
                string avs2 = "";
                int availble_seats2;
                using (SqlCommand get_availble_seats2 = new SqlCommand("select AVAILABLE_SEATS from FLIGHT_DETAILS where FLIGHTID = '" + fid2.ToString() + "'", con))
                {
                    avs2 = get_availble_seats2.ExecuteScalar().ToString();
                }
                availble_seats2 = Int32.Parse(avs2) + 0;
                int new_availble_seats2 = availble_seats2 + 1;

                SqlCommand delettid = new SqlCommand("DELETE from TICKET where TICKET_ID='" + textBox1.Text + "'", con);
                delettid.ExecuteNonQuery();

                SqlCommand deletCREDIT_CARD_DETAILS = new SqlCommand("DELETE FROM  CREDIT_CARD_DETAILS where P_ID='" + pid.ToString() + "'", con);
                deletCREDIT_CARD_DETAILS.ExecuteNonQuery();

                SqlCommand deletpid = new SqlCommand("DELETE FROM PASSENGER where P_ID='" + pid.ToString() + "'", con);
                deletpid.ExecuteNonQuery();



                SqlCommand update_availble_seats2 = new SqlCommand("UPDATE FLIGHT_DETAILS SET AVAILABLE_SEATS = '" + new_availble_seats2.ToString() + "'" +
                                                                   " WHERE FLIGHTID = '" + fid2 + "'", con);
                update_availble_seats2.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Cancelled");
                this.Hide();
            }
            catch (Exception)
            {
                con.Close();
                MessageBox.Show("Cancel fail");
                this.Hide();
                throw;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
