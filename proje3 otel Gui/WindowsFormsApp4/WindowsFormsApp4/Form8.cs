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
    public partial class Form8 : Form
    {
        public Form8(admin add)
        {
			this.kişi =new Label();
			InitializeComponent();
			this.kişi.Text = add.Kullanıcı_adı;
		}

        private void çokluRezerveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ağaçGörüntülemeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form fv = new Form9();

            fv.Show();
        }

        private void sizeÖzelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fv = new Form10();

            fv.Show();
        }
    }
}
