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
using System.IO;

namespace Kantin
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=kantin;Integrated Security=True;MultipleActiveResultSets=True");

        

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sorgula = new SqlCommand("select * from tbluser where kullanici_adi = '" + newuser.Text + "'", baglanti);
            SqlDataReader oku = sorgula.ExecuteReader();
            if (oku.Read())
            {
                MessageBox.Show("Aynı Kullanıcı Adı Bulunuyor!", "Kantin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (newpass.Text == passagain.Text && pictureBox1.Image!=null)
            {
                oku.Close();
                SqlCommand sorgu = new SqlCommand("insert into tbluser(kullanici_adi, sifre) values('" + newuser.Text + "', '" + newpass.Text + "')", baglanti);
                sorgu.ExecuteNonQuery();
                SqlCommand foto = new SqlCommand("select*from tbluser");
                baglanti.Close();

                if (!Directory.Exists(Application.StartupPath + "\\kullanicifoto"))
                    Directory.CreateDirectory(Application.StartupPath + "\\kullanicifoto\\");
                else
                    pictureBox1.Image.Save(Application.StartupPath + "\\kullanicifoto\\" + newuser.Text + ".jpg");

                MessageBox.Show("Yeni kullanıcı Eklendi!", "Kantin", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form1 f1 = new Form1();
                f1.Show();
                this.Close();                
            }
            else
            {
                MessageBox.Show("Şifreler aynı değil ya da kayıtta bir eksiğiniz var!", "Kantin: Kullanıcı kayıt sayfası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglanti.Close();


            //foreach (Control item in this.Controls)
            //{
            //    if (item is TextBox)
            //    {
            //        TextBox textbox = (TextBox)item;
            //        textbox.Clear();
            //        pictureBox1.Image = null;
            //    }
            //}
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Width = 125;pictureBox1.Height = 100;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            this.Text = "Kantin: Kullanıcı işlemleri";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog fotosec = new OpenFileDialog();
            fotosec.Title = "Kullınıcı Fotoğrafı Seçiniz...";
            fotosec.Filter = "JPG DOSYALAR (* .jpg) | *.jpg";
            if (fotosec.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.Image = new Bitmap(fotosec.OpenFile());
            }
        }
    }
}
