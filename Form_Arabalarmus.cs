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
    public partial class Form_Arabalarmus : Form
    {
        public Form_Arabalarmus()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        List<string> eklenenMarkalar = new List<string>();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
        FormMainMenu user = new FormMainMenu();
        private void Form_Arabalarmus_Load(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select (AracMarka + ' ' + AracModel) as 'Arabalar',AracFiyat From Arac_Tablosu",bgl.baglanti());
            da.Fill(dt2);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.DataSource = dt2;
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

        private void cmbRenk_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public int fiyat;
        private void iconButton1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd4 = new SqlCommand("Select AracFiyat From Arac_Tablosu Where AracMarka=@p2 AND AracModel=@p3 AND AracRenk=@p4", bgl.baglanti());
            cmd4.Parameters.AddWithValue("@p2", cmbMarka.Text);
            cmd4.Parameters.AddWithValue("@p3", cmbModel.Text);
            cmd4.Parameters.AddWithValue("@p4", cmbRenk.Text);
            SqlDataReader r4 = cmd4.ExecuteReader();
            while (r4.Read())
            {
                MessageBox.Show("Siparisiniz " + r4[0] + " Tutari Karsilinda Olusmustur Bizi Tercih Ettiginiz Icin Tesekkur Ederiz");
                fiyat = Convert.ToInt32(r4[0]);
            }
            // Siparişi SatisTablosu'na ekle
            SqlCommand cmdSatisEkle = new SqlCommand("INSERT INTO SatisTablosu (AracID, MusteriID,SatisFiyati) VALUES (@p5, @p6,@p15)", bgl.baglanti());

            // AracID değerini almak için yeni bir SqlCommand oluştur
            SqlCommand cmdAracID = new SqlCommand("SELECT AracID FROM Arac_Tablosu WHERE AracMarka = @p7 AND AracModel = @p8 AND AracRenk = @p9", bgl.baglanti());
            cmdAracID.Parameters.AddWithValue("@p7", cmbMarka.Text);
            cmdAracID.Parameters.AddWithValue("@p8", cmbModel.Text);
            cmdAracID.Parameters.AddWithValue("@p9", cmbRenk.Text);

            int aracID = Convert.ToInt32(cmdAracID.ExecuteScalar()); // AracID değerini al

            SqlCommand cmdMusteriID = new SqlCommand("SELECT MusteriID FROM MusteriTablosu WHERE MusteriKullanıcıadı = @p115", bgl.baglanti());
            
            cmdMusteriID.Parameters.AddWithValue("@p115", txtuser.Text); 
            
            int musteriID = Convert.ToInt32(cmdMusteriID.ExecuteScalar()); // MusteriID değerini al



            // Diğer parametreleri ekle
            cmdSatisEkle.Parameters.AddWithValue("@p5", aracID);
            cmdSatisEkle.Parameters.AddWithValue("@p6", musteriID);
            cmdSatisEkle.Parameters.AddWithValue("@p15", fiyat);
            cmdSatisEkle.ExecuteNonQuery(); // Sorguyu çalıştır



            bgl.baglanti().Close(); // Bağlantıyı kapat

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = bgl.baglanti())
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand("SearchByMarka", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Ad", textBox1.Text);
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);

                    // DataGridView'e veriyi bağlama
                    dataGridView1.DataSource = dataTable;

                    // Diğer işlemler...
                }
            }
        }
    }
}
