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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=kantin;Integrated Security=True");
        SqlCommand sorgu;
        SqlDataReader oku;
        

        public static string kullanici_adi, sifre, girisid;

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sorgu = new SqlCommand("SELECT * FROM tbluser where kullanici_adi='" + textuser.Text + "' AND sifre='" + textpass.Text + "'", baglanti);
            baglanti.Open();
            oku = sorgu.ExecuteReader();

            if (oku.Read())
            {
                girisid = oku.GetValue(0).ToString();
                kullanici_adi = oku.GetValue(1).ToString();
                sifre = oku.GetValue(2).ToString();

                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
                baglanti.Close();
            }
            else if (textuser.Text == "" || textpass.Text == "" || textuser.Text == "" || textpass.Text == "" || textpass.Text == "" || textpass.Text == "")
            {
                MessageBox.Show("Herhangi Bir Alan Boş Bırakılamaz!","Kantin",MessageBoxButtons.OK,MessageBoxIcon.Error);
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız! Tekrar Deneyiniz!", "Kantin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();
                textuser.Clear();
                textpass.Clear();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Close();
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Kullanıcı Giriş Sayfası";
            this.AcceptButton = button1;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }
    }
}
