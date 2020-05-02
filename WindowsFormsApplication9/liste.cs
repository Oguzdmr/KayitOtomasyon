using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication9
{
    public partial class liste : Form
    {
        public liste()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=0ĞUZ\\SQLEXPRESS;Initial Catalog=Giris;Integrated Security=True");

        private void listele()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from Bilgiler", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Adsoyad"].ToString();
                ekle.SubItems.Add(oku["Tcno"].ToString());
                ekle.SubItems.Add(oku["Telno"].ToString());
                ekle.SubItems.Add(oku["Tarih"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }
        private void adarama()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from Bilgiler where Adsoyad=@Adsoyad", baglan);
            komut.Parameters.AddWithValue("@Adsoyad", textBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Adsoyad"].ToString();
                ekle.SubItems.Add(oku["Tcno"].ToString());
                ekle.SubItems.Add(oku["Telno"].ToString());
                ekle.SubItems.Add(oku["Tarih"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }
        private void tarihara()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from Bilgiler where Tarih=@Tarih", baglan);
            komut.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value.ToString("M/d/yyyy"));
            SqlDataAdapter da = new SqlDataAdapter(komut);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Adsoyad"].ToString();
                ekle.SubItems.Add(oku["Tcno"].ToString());
                ekle.SubItems.Add(oku["Telno"].ToString());
                ekle.SubItems.Add(oku["Tarih"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            adarama();
            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tarihara();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            dateTimePicker1.Value = DateTime.Now;

        }
    }
}
