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
    public partial class FormSatislar : Form
    {
        public FormSatislar()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        private void FormSatislar_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = bgl.baglanti())
                {
                    dataGridView1.Columns.Add("Model", "Model");
                    dataGridView1.Columns.Add("TotalSales", "Toplam Satış");
                    // Bağlantıyı açmadan önce kontrol edin
                    if (connection.State == System.Data.ConnectionState.Closed)
                        connection.Open();

                    using (SqlCommand command = new SqlCommand("BestSellingModelsReport", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // DataGridView temizleme
                            dataGridView1.Rows.Clear();

                            while (reader.Read())
                            {
                                // Verileri alın
                                string model = reader["AracModel"].ToString();
                                int totalSales = Convert.ToInt32(reader["TotalSales"]);
                                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                                // DataGridView'e veri ekleme
                                dataGridView1.Rows.Add(model, totalSales);
                            }
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

