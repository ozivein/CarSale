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
    public partial class FormMusteriKayıt : Form
    {
        public FormMusteriKayıt()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        private void iconButton1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Insert into MusteriTablosu (MusteriAd,MusteriSoyad,MusteriKullanıcıadı,MusteriTel,MusteriSifre,MusteriAdres)values (@p1,@p2,@p3,@p4,@p5,@p6) ", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", txtAd.Text);
            cmd.Parameters.AddWithValue("@p2", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", txtKullanıcıAd.Text);
            cmd.Parameters.AddWithValue("@p4", txtTel.Text);
            cmd.Parameters.AddWithValue("@p5", txtSifre.Text);
            cmd.Parameters.AddWithValue("@p6", txtAdres.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydiniz Yapilmistir Sayin " + txtAd.Text + " " + txtSoyad.Text, "Kayit Basarili", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMusteriKayıt_Load(object sender, EventArgs e)
        {

        }
    }
}
