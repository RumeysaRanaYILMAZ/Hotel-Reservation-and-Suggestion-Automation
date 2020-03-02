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
	public partial class Form11 : Form
	{
		public Form11(List<otel> sonuclar)
		{
			if(sonuclar==null){
				MessageBox.Show("Bu Aramaya Uygun Hiç Otel Bulunamadı.");
			}else{
				foreach(otel i in sonuclar){
					string bilg = "";
					foreach(string a in i.bilgiler){
						bilg += a + ",";
					}
					listView1 = new ListView();
					ListViewItem otellik = new ListViewItem();
					otellik.Text = i.isim;
					otellik.SubItems.Add(i.yer_isim);
					otellik.SubItems.Add(bilg);
					listView1.Items.Add(otellik);
					listView1.Update();
				}
			}
			InitializeComponent();
			this.Show();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			listView1.Items.Clear();
			List<otel> sonuclar = test.arama(textBox1.Text);
			if (sonuclar == null)
			{
				MessageBox.Show("Bu Aramaya Uygun Hiç Otel Bulunamadı.");
			}
			else
			{
				foreach (otel i in sonuclar)
				{
					string bilg = "";
					foreach (string a in i.bilgiler)
					{
						bilg += a + ",";
					}
					listView1 = new ListView();
					ListViewItem otellik = new ListViewItem();
					otellik.Text = i.isim;
					otellik.SubItems.Add(i.yer_isim);
					otellik.SubItems.Add(bilg);
					listView1.Items.Add(otellik);
					listView1.Update();
				}
			}
		}
	}
}
