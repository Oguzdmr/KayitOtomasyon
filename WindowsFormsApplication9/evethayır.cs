using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication9
{
    public partial class evethayır : Form
    {
        public static Boolean dogrumu1 = Form4.dogrumu;
        public static string adsoyad1 = Form4.adsoyad, tc1 = Form4.tc, tel1 = Form4.tel, tarih1 = Form4.tarih;
        public static int ıd1 = Form4.id;
        public evethayır()
        {
            InitializeComponent();
        }

        private void evethayır_Load(object sender, EventArgs e)
        {
            ListViewItem ekle = new ListViewItem();
            ekle.Text = ıd1.ToString();
            ekle.SubItems.Add(adsoyad1.ToString());
            ekle.SubItems.Add(tc1.ToString());
            ekle.SubItems.Add(tel1.ToString());
            ekle.SubItems.Add(tarih1.ToString());
            listView1.Items.Add(ekle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dogrumu1 = true;
            Form4.dogrumu = dogrumu1;
            MessageBox.Show("Kayıtlı Kişi Silindi!!!!");
            listView1.Items.Clear();
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Hide();
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Hide();
        }
    }
}
