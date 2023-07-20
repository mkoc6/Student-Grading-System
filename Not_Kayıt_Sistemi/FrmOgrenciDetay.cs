using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Not_Kayıt_Sistemi
{
    //Data Source=DESKTOP-1DQCP20\SQLEXPRESS;Initial Catalog=DbNotKayıt;Integrated Security=True
    public partial class FrmOgrenciDetay : Form
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-1DQCP20\SQLEXPRESS;Initial Catalog=DbNotKayıt;Integrated Security=True");
        public int Numara;
        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        { 
            string a;
            LblNumara.Text = Numara.ToString();
            baglanti.Open();
            SqlCommand trt = new SqlCommand("select * from  TBLDERS WHERE OGRNUMARA = @P1",baglanti);
            trt.Parameters.AddWithValue("@P1", LblNumara.Text);
            SqlDataReader DR = trt.ExecuteReader();
            while (DR.Read())
            { 
                LblAdSoyad.Text = DR[2] + " " + DR[3];
                LblSınav1.Text = DR[4].ToString();
                LblSınav2.Text = DR[5].ToString();
                LblSınav3.Text = DR[6].ToString();
                LblOrtalama.Text = DR[7].ToString();
                a = DR[8].ToString();
                if (a == "True")
                {
                    LblDurum.Text = "passed";
                }
                else
                {
                    LblDurum.Text = "left";
                }
            }
            baglanti.Close();

        }

        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmGİris trer = new FrmGİris();
            trer.Show();
            this.Hide();
        }
    }
}
