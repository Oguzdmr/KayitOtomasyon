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
    public partial class ara : Form
    {
        public ara()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=0ĞUZ\\SQLEXPRESS;Initial Catalog=Giris;Integrated Security=True");

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from Bilgiler where Tcno=@Tcno", baglan);
            komut.Parameters.AddWithValue("@Tcno", maskedTextBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Adsoyad"].ToString();
                ekle.SubItems.Add(oku["Tcno"].ToString());
                ekle.SubItems.Add(oku["Telno"].ToString());
                ekle.SubItems.Add(oku["Tarih"].ToString());
                listView1.Items.Add(ekle);
            }
            else
                MessageBox.Show("Kayıtlı Öğe Bulunamadı!!!!!");
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }
    }
}
