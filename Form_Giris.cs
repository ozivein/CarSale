using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArabaSatis
{
    public partial class Form_Giris : Form
    {
        public Form_Giris()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Form_GirisMusteri fr = new Form_GirisMusteri();
            fr.Show();
            this.Hide();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void lblKayıt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormMusteriKayıt fr = new FormMusteriKayıt();
            fr.Show();
        }
    }
}
