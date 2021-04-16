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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=kantin;Integrated Security=True;MultipleActiveResultSets=True");

        private void button1_Click(object sender, EventArgs e)
        {
            //string yetki = "";

            if (textBox1.Text == "")
            {
                label1.ForeColor = Color.Red;
            }
            else
                label1.ForeColor = Color.Black;

            if (textBox2.Text == "")
                label2.ForeColor = Color.Red;
            else
                label2.ForeColor = Color.Black;
            if (textBox3.Text == "" || textBox2.Text != textBox3.Text)
            {
                label3.ForeColor = Color.Red;
            }
            else
                label3.ForeColor = Color.Black;

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox3.Text==textBox2.Text)
            {
                try
                {
                    baglanti.Open();
                    SqlCommand guncelle = new SqlCommand("Update tbluser set sifre='" + textBox2.Text + "' where kullanici_adi='"+textBox1.Text+"'", baglanti);
                    guncelle.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Şifre Başarıyla Güncellendi!", "Kantin Şifre Değişikliği", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    this.Close();
                }
                catch (Exception hatamesaji)
                {
                    MessageBox.Show(hatamesaji.Message,"Kantin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglanti.Close();
                }
            }
            else
            {
                MessageBox.Show("Kırmızı renkli alanları tekrar gözden geçiriniz!", "Kantin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool kayit_durumu = false;
            baglanti.Open();
            SqlCommand sorgu = new SqlCommand("select * from tbluser where kullanici_adi='" + textBox1.Text + "'", baglanti);
            SqlDataReader kullanici = sorgu.ExecuteReader();
            while (kullanici.Read())
            {
                kayit_durumu = true;
                SqlCommand silislemi = new SqlCommand("delete from tbluser where kullanici_adi='" + textBox1.Text + "'", baglanti);
                silislemi.ExecuteNonQuery();
                MessageBox.Show("Kullanıcı Kaydı Silindi", "Kantin: Kullanıcı işlemleri", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                baglanti.Close();
                textBox1.Clear();
                this.Close();
                break;
            }
            if(kayit_durumu==false)
                MessageBox.Show("Kullanıcı Kaydı Bulunamadı", "Kantin: Kullanıcı işlemleri", MessageBoxButtons.OK, MessageBoxIcon.Error);

            baglanti.Close();
            textBox1.Clear();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form1.kullanici_adi;
            this.Text = "Kantin: Şifre Güncelleme Merkezi";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }
    }
}
