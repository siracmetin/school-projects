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


namespace Kantin
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=kantin;Integrated Security=True");
        
        DataTable tbl = new DataTable();
       
       

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Close();
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Text = "Kantin: Şifre Merkezi";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool sifre_getir = false;
            baglanti.Open();
            SqlCommand listele = new SqlCommand("select * from tbluser where kullanici_adi='" + textBox1.Text + "'", baglanti);
            SqlDataReader sifre_okuma = listele.ExecuteReader();
            while (sifre_okuma.Read())
            {
                sifre_getir = true;
                textBox2.Text = sifre_okuma.GetValue(2).ToString();
                break;
            }
            if (sifre_getir == false)
            {
                MessageBox.Show("Bu kullanıcı bulunmamaktadır!", "Kantin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            baglanti.Close();
        }
    }
}
