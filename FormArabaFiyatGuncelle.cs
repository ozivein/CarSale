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
    public partial class FormArabaFiyatGuncelle : Form
    {
        public FormArabaFiyatGuncelle()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        private void FormArabaFiyatGuncelle_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT AracMarka FROM Arac_Tablosu", bgl.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string marka = dr[0].ToString();
                cmbMarka.Items.Add(marka);
            }



            bgl.baglanti().Close();
        }

        private void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {

            cmbRenk.Items.Clear();

            SqlCommand cmd3 = new SqlCommand("SELECT DISTINCT AracRenk FROM Arac_Tablosu WHERE AracModel=@p1", bgl.baglanti());
            cmd3.Parameters.AddWithValue("@p1", cmbModel.Text);
            SqlDataReader dr3 = cmd3.ExecuteReader();

            while (dr3.Read())
            {
                string renk = dr3[0].ToString();


                if (!cmbRenk.Items.Contains(renk))
                {
                    cmbRenk.Items.Add(renk);
                }
            }


            bgl.baglanti().Close();
        }

        private void cmbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbModel.Items.Clear();

            SqlCommand cmd2 = new SqlCommand("SELECT DISTINCT AracModel FROM Arac_Tablosu WHERE AracMarka=@p12", bgl.baglanti());
            cmd2.Parameters.AddWithValue("@p12", cmbMarka.Text);
            SqlDataReader dr2 = cmd2.ExecuteReader();

            while (dr2.Read())
            {
                string model = dr2[0].ToString();


                if (!cmbModel.Items.Contains(model))
                {
                    cmbModel.Items.Add(model);
                }
            }

            bgl.baglanti().Close();

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = bgl.baglanti())
                {
                    // Bağlantıyı açmadan önce kontrol edin
                    if (connection.State == System.Data.ConnectionState.Closed)
                        connection.Open();




                    // Güncelleme sorgusu
                    string updateQuery = "UPDATE Arac_Tablosu " +
                                         "SET AracFiyat = @AracFiyat " +
                                         "WHERE AracID = @AracID";


                    using (SqlCommand cmdUpdate = new SqlCommand(updateQuery, connection))
                    {

                        SqlCommand cmdAracID = new SqlCommand("SELECT AracID FROM Arac_Tablosu WHERE AracMarka = @p7 AND AracModel = @p8 AND AracRenk = @p9", bgl.baglanti());
                        cmdAracID.Parameters.AddWithValue("@p7", cmbMarka.Text);
                        cmdAracID.Parameters.AddWithValue("@p8", cmbModel.Text);
                        cmdAracID.Parameters.AddWithValue("@p9", cmbRenk.Text);

                        int aracID = Convert.ToInt32(cmdAracID.ExecuteScalar()); // AracID değerini al
                        // Parametreleri ekleme
                        cmdUpdate.Parameters.AddWithValue("@AracFiyat", textBox1.Text);
                        cmdUpdate.Parameters.AddWithValue("@AracID", aracID);

                        // Sorguyu çalıştırma
                        int affectedRows = cmdUpdate.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Fiyat bilgileri başarıyla güncellendi.");
                        }
                        else
                        {
                            MessageBox.Show("Güncelleme başarısız oldu. Lütfen tekrar deneyin.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }

        
    }
    }
}
