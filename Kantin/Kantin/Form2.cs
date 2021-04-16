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
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;


namespace Kantin
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=kantin;Integrated Security=True");
        public string user;

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();timer2.Stop();timer3.Stop();
            baglanti.Open();
            SqlCommand sureekle = new SqlCommand("insert into kronometre values('"+Form1.girisid+"','"+ label11.Text + "','" + label10.Text + "','" + label9.Text+"')",baglanti);
            sureekle.ExecuteNonQuery();
            baglanti.Close();
            Form6 f6 = new Form6();
            f6.Show();
        }

        //private void toolStripButton1_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog exesec = new OpenFileDialog();
        //    exesec.Title = "Uygulamayı Seçiniz...";
        //    exesec.Filter = "Exe Dosyalar | *.exe";
        //    if (exesec.ShowDialog() == DialogResult.OK)
        //    {
        //        //this.pictureBox2.Image = new Bitmap(exesec.OpenFile());
        //        this.label2.Text = new (exesec.OpenFile());
        //    }
        //}

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        int saat = 1, saniye = 1, dakika = 1;
        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = "Kantin";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            baglanti.Open();
            string sorgu = "select*from kronometre where kullaniciid='" + Form1.girisid + "'";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            

            pictureBox1.Height = 100;
            pictureBox1.Width = 100;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            label1.Text = Form1.kullanici_adi;
            label1.ForeColor = Color.DarkBlue;
            

            try
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\kullanicifoto\\" + Form1.girisid + ".jpg");
            }
            catch
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\kullanicifoto\\fotoyok.jpg");
            }

            timer2.Interval = 60000;
            timer1.Interval = 1000;
            timer3.Interval = 3600000;
            timer1.Start();timer2.Start(); timer3.Start();
            label11.Text = "0";label10.Text = "0";label9.Text = "0";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        //string exeyolu = Application.StartupPath.ToString();
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr child, IntPtr newParent);
        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int IParam);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindowVisible(IntPtr hWnd);
        


        private void button5_Click(object sender, EventArgs e)
        {
            string exeyolu = "msedge.exe";
            Process calistir = Process.Start(exeyolu);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string exeyolu = "chrome.exe";
            Process calistir = Process.Start(exeyolu);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string exeyolu = "word.exe";
            Process calistir = Process.Start(exeyolu);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\ugulamalar\\launcher.exe";
            Process.Start(path);
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            string exeyolu = "AcroRd32.exe";
            Process calistir = Process.Start(exeyolu);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string exeyolu = "devenv.exe";
            Process calistir = Process.Start(exeyolu);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //string exeyolu = "Discord.exe";
            //Process calistir = Process.Start(exeyolu);
            string path = Application.StartupPath + "\\ugulamalar\\Discord.exe";
            Process.Start(path);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\ugulamalar\\steam.exe";
            Process.Start(path);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\ugulamalar\\EpicGamesLauncher.exe";
            Process.Start(path);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\ugulamalar\\FL64.exe";
            Process.Start(path);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\ugulamalar\\Uplay.exe";
            Process.Start(path);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\ugulamalar\\Unity.exe";
            Process.Start(path);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\ugulamalar\\UE4Editor.exe";
            Process.Start(path);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            string exeyolu = "Ssms.exe";
            Process calistir = Process.Start(exeyolu);
        }

        private void button7_Click_1(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            string exeyolu = "excel.exe";
            Process calistir = Process.Start(exeyolu);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            saat++;
            label11.Text = Convert.ToString(saat);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (dakika == 60)
            {
                dakika = 0;
            }
            label10.Text = Convert.ToString(dakika);
            dakika++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (saniye == 60)
            {
                saniye = 0;
            }
            saniye++;
            label9.Text = Convert.ToString(saniye);
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }
    }
}
