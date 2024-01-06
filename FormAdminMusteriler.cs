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
using TheArtOfDev.HtmlRenderer.Adapters;

namespace ArabaSatis
{
    public partial class FormAdminMusteriler : Form
    {
        public FormAdminMusteriler()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Ad'a Göre")
            {
                using (SqlConnection connection = bgl.baglanti())
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    using (SqlCommand command = new SqlCommand("SearchByName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Ad", txtAd.Text);
                        DataTable dataTable = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);

                        // DataGridView'e veriyi bağlama
                        dataGridView1.DataSource = dataTable;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        // Diğer işlemler...
                    }
                }
            }
            else if (comboBox1.Text == "Tüm Müşteriler")
            {
                DataTable dt2 = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * From MusteriTablosu", bgl.baglanti());
                da.Fill(dt2);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dataGridView1.DataSource = dt2;
            }
            

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

    }
}

