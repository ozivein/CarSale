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
    public partial class FormAdminServis : Form
    {
        public FormAdminServis()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        private void FormAdminServis_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = bgl.baglanti())
                {
                    
                   


                    // ServisTablosu'ndan belirli müşteri ID'sine ait servis verilerini, AracMarka ve AracModel bilgilerini al
                    SqlCommand cmdServisVerileri = new SqlCommand("SELECT at.AracMarka, at.AracModel, st.ServisID , st.ServisTarihi, st.ServisFiyatı, st.ServisSonuc ,ft.ServisTipleri, mt.MusteriAd ,mt.MusteriSoyad FROM Servis_Tablosu st INNER JOIN Arac_Tablosu at ON st.AracID = at.AracID INNER JOIN  MusteriTablosu mt ON st.MusteriID = mt.MusteriID INNER JOIN TabloServisTipleri ft ON st.ServisTipiID = ft.ServisTipiID", connection);
                   

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = bgl.baglanti())
                {
                    // Bağlantıyı açmadan önce kontrol edin
                    if (connection.State == System.Data.ConnectionState.Closed)
                        connection.Open();

                  
                   

                    // Güncelleme sorgusu
                    string updateQuery = "UPDATE Servis_Tablosu " +
                                         "SET ServisTarihi = @ServisTarihi, ServisFiyatı = @ServisFiyati, ServisSonuc = @ServisSonuc " +
                                         "WHERE ServisID = @ServisID";

                    using (SqlCommand cmdUpdate = new SqlCommand(updateQuery, connection))
                    {
                        // Parametreleri ekleme
                        cmdUpdate.Parameters.AddWithValue("@ServisTarihi", dateTimePicker1.Value);
                        cmdUpdate.Parameters.AddWithValue("@ServisFiyati", decimal.Parse(txtFiyat.Text));
                        cmdUpdate.Parameters.AddWithValue("@ServisSonuc", txtSonuc.Text);
                        cmdUpdate.Parameters.AddWithValue("@ServisID", textBox1.Text);

                        // Sorguyu çalıştırma
                        int affectedRows = cmdUpdate.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Servis bilgileri başarıyla güncellendi.");
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
