using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArabaSatis
{
    public partial class FormMainMenu : Form
    {
        public FormMainMenu()
        {
            InitializeComponent();
        }

        private void bntMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Form_Arabalarmus child = new Form_Arabalarmus();
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            panelform.Controls.Add(child);
            child.BringToFront();
            child.Show();

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Form_Servismus a = new Form_Servismus();
            a.TopLevel = false;
            a.FormBorderStyle = FormBorderStyle.None;
            panelform.Controls.Add(a);
            a.BringToFront();
            a.Show();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            Form_Giris df= new Form_Giris();
            df.Show();
            this.Close();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        public string userid;
        private void FormMainMenu_Load(object sender, EventArgs e)
        {
           
            lbluser.Text = userid;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
