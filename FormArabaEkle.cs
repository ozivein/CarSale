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
    public partial class FormArabaEkle : Form
    {
        public FormArabaEkle()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        private void iconButton1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Insert into Arac_Tablosu (AracMarka,AracModel,AracRenk,AracFiyat)values (@p1,@p2,@p3,@p4) ", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", txtMarka.Text);
            cmd.Parameters.AddWithValue("@p2", txtModel.Text);
            cmd.Parameters.AddWithValue("@p3", txtRenk.Text);
            cmd.Parameters.AddWithValue("@p4", txtFiyat.Text);
          
            cmd.ExecuteNonQuery();
            MessageBox.Show("Araba Basariyla Eklenmmistir");
            bgl.baglanti().Close();
        }
    }
}
