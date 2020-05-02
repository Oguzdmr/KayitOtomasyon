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
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=0ĞUZ\\SQLEXPRESS;Initial Catalog=Giris;Integrated Security=True");

        private void kayıt()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Insert into Bilgiler (Adsoyad,Tcno,Telno,Tarih) Values('" +textBox1.Text.ToString()+ "' , '" + maskedTextBox1.Text + "' ,'" + maskedTextBox2.Text.ToString() + "' ,'" + dateTimePicker1.Value.ToString("M/d/yyyy") + "' )", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            textBox1.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            kayıt();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
