using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArabaSatis
{
    public partial class Form_GirisMusteri : Form
    {   
        

        public Form_GirisMusteri()
        {
            InitializeComponent();
            
        }

        

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public string kullaniciAd;
        private void iconButton2_Click(object sender, EventArgs e)
        {
            Form_Giris form = new Form_Giris();
            form.Show();
            this.Hide();
        }
             sqlbaglanti bgl = new sqlbaglanti();
        public void iconButton1_Click(object sender, EventArgs e)
        {
            if (txtAd.Text=="admin")
            {

                if (txtSoyad.Text=="admin")
                {
                    FormAdmin form = new FormAdmin();
                    form.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Yanlis Admin Sifre");
                }



            }
            else
            {
                SqlCommand cmd = new SqlCommand("Select * From MusteriTablosu Where MusteriKullanıcıadı=@p1 and MusteriSifre=@p2", bgl.baglanti());
                cmd.Parameters.AddWithValue("@p1", txtAd.Text);
                cmd.Parameters.AddWithValue("@p2", txtSoyad.Text);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    FormMainMenu menu = new FormMainMenu();
                    menu.userid = txtAd.Text;


                    menu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatali Bilgi Girdiniz");
                }
                bgl.baglanti().Close();
            }
        }
        

        private void lblKayıt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormMusteriKayıt fr = new FormMusteriKayıt();
            fr.Show();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        

       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form_GirisMusteri_Load(object sender, EventArgs e)
        {

        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {
            kullaniciAd=txtAd.Text;
        }
    }
}
