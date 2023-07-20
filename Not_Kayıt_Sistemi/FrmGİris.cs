using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Not_Kayıt_Sistemi
{
    public partial class FrmGİris : Form
    {
        public FrmGİris()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            FrmOgrenciDetay frm = new FrmOgrenciDetay();
            
            frm.Numara = Convert.ToInt16(maskedTextBox1.Text);
            frm.Show();
            this.Hide();
            
           
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmAnaFrom trer = new FrmAnaFrom();
            trer.Show();
            this.Hide();
        }
    }
}
