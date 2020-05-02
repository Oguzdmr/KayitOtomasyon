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
    public partial class düzenleme : Form
    {
        public düzenleme()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=0ĞUZ\\SQLEXPRESS;Initial Catalog=Giris;Integrated Security=True");

        private void listeleme()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from Bilgiler", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Sıra"].ToString();
                ekle.SubItems.Add(oku["Adsoyad"].ToString());
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
            komut.Parameters.AddWithValue("@Adsoyad", textBox2.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Sıra"].ToString();
                ekle.SubItems.Add(oku["Adsoyad"].ToString());
                ekle.SubItems.Add(oku["Tcno"].ToString());
                ekle.SubItems.Add(oku["Telno"].ToString());
                ekle.SubItems.Add(oku["Tarih"].ToString());
                listView1.Items.Add(ekle);
            }
            
            baglan.Close();
        }
        private void tcnoarama()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from Bilgiler where Tcno=@Tcno", baglan);
            komut.Parameters.AddWithValue("@Tcno", maskedTextBox3.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Sıra"].ToString();
                ekle.SubItems.Add(oku["Adsoyad"].ToString());
                ekle.SubItems.Add(oku["Tcno"].ToString());
                ekle.SubItems.Add(oku["Telno"].ToString());
                ekle.SubItems.Add(oku["Tarih"].ToString());
                listView1.Items.Add(ekle);
            }
            else
                MessageBox.Show("Kayıtlı Öğe Bulunamadı!!!!!");
            baglan.Close();
        }
        private void güncelle()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Update Bilgiler set Adsoyad=@Adsoyad,Tcno=@Tcno,Telno=@Telno,Tarih=@Tarih where Sıra="+textBox3.Text, baglan);
            komut.Parameters.AddWithValue("@Adsoyad", textBox1.Text);
            komut.Parameters.AddWithValue("@Tcno", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@Telno",maskedTextBox2.Text);
            komut.Parameters.AddWithValue("@Tarih",dateTimePicker1.Value.ToString("M/d/yyyy"));
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Kayıt Bilgileri Güncellendi!!!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listeleme();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adarama();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tcnoarama();
            maskedTextBox3.Clear();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            maskedTextBox1.Text = listView1.SelectedItems[0].SubItems[2].Text;
            maskedTextBox2.Text= listView1.SelectedItems[0].SubItems[3].Text;
            dateTimePicker1.Value =DateTime.Parse(listView1.SelectedItems[0].SubItems[4].Text);
            textBox3.Text = listView1.SelectedItems[0].SubItems[0].Text;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            güncelle();
            listeleme();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }
    }
}
