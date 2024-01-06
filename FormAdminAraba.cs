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
    public partial class FormAdminAraba : Form
    {
        public FormAdminAraba()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormArabaEkle form= new FormArabaEkle();
            form.Show();

        }
        sqlbaglanti bgl = new sqlbaglanti();
        private void FormAdminAraba_Load(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select AracID, AracMarka, AracModel, AracRenk, AracFiyat From Arac_Tablosu", bgl.baglanti());
            da.Fill(dt2);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.DataSource = dt2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormSilinenArabalar form = new FormSilinenArabalar();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Arac_Tablosu WHERE AracID = @AracID", bgl.baglanti());
            cmd.Parameters.AddWithValue("@AracID", txtSil.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Arac Silinmistir");
            bgl.baglanti().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormArabaFiyatGuncelle form = new FormArabaFiyatGuncelle();
            form.Show();
        }
    }
}
