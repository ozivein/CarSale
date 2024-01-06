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
    public partial class FormSilinenArabalar : Form
    {
        public FormSilinenArabalar()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl=new sqlbaglanti();
        private void FormSilinenArabalar_Load(object sender, EventArgs e)
        {

            DataTable dt2 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Silinen", bgl.baglanti());
            da.Fill(dt2);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.DataSource = dt2;
        }
    }
}
