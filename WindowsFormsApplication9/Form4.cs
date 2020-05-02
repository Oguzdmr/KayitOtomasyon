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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=0ĞUZ\\SQLEXPRESS;Initial Catalog=Giris;Integrated Security=True");

        public static Boolean dogrumu;
        public static string adsoyad, tc, tel, tarih;
        public static int id;

        private void bulma()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from Bilgiler where Tcno=@Tcno", baglan);
            komut.Parameters.AddWithValue("@Tcno", maskedTextBox1.Text);
            SqlDataAdapter da =new SqlDataAdapter(komut);
            SqlDataReader oku =komut.ExecuteReader();
            if (oku.Read())
            {
                id = int.Parse(oku["Sıra"].ToString());
                adsoyad = oku["Adsoyad"].ToString();
                tc = oku["Tcno"].ToString();
                tel = oku["Telno"].ToString();
                tarih = oku["Tarih"].ToString();
                evethayır kontrl = new evethayır();
                kontrl.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kayıtlı Kişi Bulunamadı!!!");
                maskedTextBox1.Clear();
            }
            baglan.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                bulma(); 
                tc = maskedTextBox1.Text;
           
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Object Tcno = maskedTextBox1.Text;
            

            if (dogrumu)
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("Delete from Bilgiler where Tcno=@Tcno", baglan);
                komut.Parameters.AddWithValue("@Tcno",tc);
                komut.ExecuteNonQuery();
                dogrumu = false;
                baglan.Close();

            }
        }
    }
}





/*private void Form4_Load(object sender, EventArgs e)
       {
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
       }*/