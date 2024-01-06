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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        private void iconButton1_Click(object sender, EventArgs e)
        {
            FormAdminAraba child = new FormAdminAraba();
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            panelform.Controls.Add(child);
            child.BringToFront();
            child.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            SqlConnection connection = null; // SqlConnection nesnesini tanımla

            try
            {
                // Yedek dosyasının adını belirle
                string yedekDosyaAdi = "C:\\Yedekler\\" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_VeritabaniYedegi.bak";

                // SQL bağlantısını al
                connection = bgl.baglanti();

                // Bağlantı açık değilse aç
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                // SQL komutu oluştur (veritabanını yedekle)
                string query = $"BACKUP DATABASE [AracSatis] TO DISK = '{yedekDosyaAdi}'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Komutu çalıştır
                    command.ExecuteNonQuery();

                    MessageBox.Show("Veritabanı başarıyla yedeklendi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
            finally
            {
                // Bağlantıyı kapat
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            FormAdminMusteriler child = new FormAdminMusteriler();
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            panelform.Controls.Add(child);
            child.BringToFront();
            child.Show();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            FormAdminServis child = new FormAdminServis();
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            panelform.Controls.Add(child);
            child.BringToFront();
            child.Show();
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            FormSatislar child = new FormSatislar();
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            panelform.Controls.Add(child);
            child.BringToFront();
            child.Show();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            Form_Giris grs = new Form_Giris();
            grs.Show();
            this.Close();
        }
    }
}
