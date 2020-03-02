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
    public partial class Form1 : Form
    {
        public Form1(Lineer_Hash a,Chain_Hash b)
        {
            InitializeComponent();
        }
        

        private void label4_Click(object sender, EventArgs e)
        {
            Form fv = new Form2(this);

            fv.Show();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form fv = new Form7(this);

            fv.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

		private void button1_Click(object sender, EventArgs e)
		{
			if(textBox1.Text==null ||textBox1.Text.Equals("")){
				MessageBox.Show("Arama Kısmına Birşeyler Yazın");
			}else{
				List<otel> bulunan=test.arama(textBox1.Text);
				Form ff11 = new Form11(bulunan);
				this.Hide();
			}
		}
	}
}
