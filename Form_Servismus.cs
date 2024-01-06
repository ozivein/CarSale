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
    public partial class Form_Servismus : Form
    {
        

        public Form_Servismus()
        {
            InitializeComponent();
        }
          sqlbaglanti bgl = new sqlbaglanti();
        FormMainMenu user = new FormMainMenu();
        private void Form_Servismus_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT AracMarka FROM Arac_Tablosu", bgl.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string marka = dr[0].ToString();
                cmbMarka.Items.Add(marka);
            }
            




        }
       
        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = bgl.baglanti())
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    // AracID al
                    int aracID;
                    using (SqlCommand cmdAracID = new SqlCommand("SELECT AracID FROM Arac_Tablosu WHERE AracMarka = @p7 AND AracModel = @p8 AND AracRenk = @p9", connection))
                    {
                        cmdAracID.Parameters.AddWithValue("@p7", cmbMarka.Text);
                        cmdAracID.Parameters.AddWithValue("@p8", cmbModel.Text);
                        cmdAracID.Parameters.AddWithValue("@p9", cmbRenk.Text);
                        aracID = Convert.ToInt32(cmdAracID.ExecuteScalar());
                    }

                    // MusteriID al
                    int musteriID;
                    using (SqlCommand cmdMusteriID = new SqlCommand("SELECT MusteriID FROM MusteriTablosu WHERE MusteriKullanıcıadı = @p115", connection))
                    {
                        cmdMusteriID.Parameters.AddWithValue("@p115", txtuser.Text);
                        musteriID = Convert.ToInt32(cmdMusteriID.ExecuteScalar());
                    }

                    // ServisID al
                    int servisID;
                    using (SqlCommand cmdServisID = new SqlCommand("SELECT ServisTipiID FROM TabloServisTipleri WHERE ServisTipleri = @p1", connection))
                    {
                        cmdServisID.Parameters.AddWithValue("@p1", cmbServis.Text);
                        servisID = Convert.ToInt32(cmdServisID.ExecuteScalar());
                    }

                    // SatisTablosu'na ekleme yap
                    using (SqlCommand command = new SqlCommand("INSERT INTO Servis_Tablosu(AracID, ServisTipiID, MusteriID) VALUES(@p17, @p18, @p19)", connection))
                    {
                        command.Parameters.AddWithValue("@p17", aracID);
                        command.Parameters.AddWithValue("@p18", servisID);
                        command.Parameters.AddWithValue("@p19", musteriID);

                        command.ExecuteNonQuery(); // Sorguyu çalıştır
                    }
                }
                MessageBox.Show("Talebiniz Basariyla Alinmistir En Kisa Zamanda Arac Alinip Gerekli Kontroller Yapilacaktir Aracinizin Durumunu Sag Taraftaki Panelden Sorgulayabilirsiniz");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }



        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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
        }

        private void cmbRenk_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbServis.Items.Clear();

            SqlCommand cmd2 = new SqlCommand("SELECT ServisTipleri FROM TabloServisTipleri", bgl.baglanti());
            cmd2.Parameters.AddWithValue("@p12", cmbMarka.Text);
            SqlDataReader dr2 = cmd2.ExecuteReader();

            while (dr2.Read())
            {
                string model = dr2[0].ToString();


                if (!cmbServis.Items.Contains(model))
                {
                    cmbServis.Items.Add(model);
                }
            }

            
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = bgl.baglanti())
                {
                    // Müşteri ID'yi Musteri_Tablosu'ndan çek
                    SqlCommand cmdMusteriID = new SqlCommand("SELECT MusteriID FROM MusteriTablosu WHERE MusteriKullanıcıadı = @p1", connection);
                    cmdMusteriID.Parameters.AddWithValue("@p1", txtadd.Text);

                    // Müşteri ID'yi al
                    int musteriID = Convert.ToInt32(cmdMusteriID.ExecuteScalar());

                    // ServisTablosu'ndan belirli müşteri ID'sine ait servis verilerini, AracMarka ve AracModel bilgilerini al
                    SqlCommand cmdServisVerileri = new SqlCommand("SELECT at.AracMarka, at.AracModel, st.ServisTarihi, st.ServisFiyatı, st.ServisSonuc  FROM Servis_Tablosu st INNER JOIN Arac_Tablosu at ON st.AracID = at.AracID WHERE st.MusteriID = @p2", connection);
                    cmdServisVerileri.Parameters.AddWithValue("@p2", musteriID);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmdServisVerileri);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // DataGridView'e verileri yükle
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
