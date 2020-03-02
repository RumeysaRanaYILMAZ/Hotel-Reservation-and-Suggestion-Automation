using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void kişi_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Profilinizi görüntülemek için tıklayınız.",kişi);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void çokluRezerveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form fv = new Form5();

            fv.Show();
        }

        private void ağaçGörüntülemeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form fv = new Form4();

            fv.Show();
        }

        private void bizeBildirinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fv = new Form6();

            fv.Show();
        }
    }
}
