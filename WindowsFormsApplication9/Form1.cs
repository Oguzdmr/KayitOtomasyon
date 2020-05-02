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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=0ĞUZ\\SQLEXPRESS;Initial Catalog=Giris;Integrated Security=True");
        Form2 frm2=new Form2();
        private void login()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from Kullanıcı",baglan);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                string sqlıd = oku["Id"].ToString();
                string sqlsifre = oku["Sifre"].ToString();


                if (sqlıd == textBox1.Text && sqlsifre == textBox2.Text)
                {
                    frm2.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Hatalı Kullanıcı Adı ve Şifre");
            }
            baglan.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }
    }
}
