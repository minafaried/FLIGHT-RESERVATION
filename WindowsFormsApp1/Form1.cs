using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FlightReservation : Form
    {
        public FlightReservation()
        {
            InitializeComponent();
        }

        private void FlightReservation_Load(object sender, EventArgs e)
        {

        }

        private void Reserve_Click(object sender, EventArgs e)
        {
            Reservation r = new Reservation();
            r.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Search s = new Search();
            s.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Search1 s1 = new Search1();
            s1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            select s = new select();
            s.ShowDialog();
            
        }
    }
}
