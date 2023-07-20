using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Not_Kayıt_Sistemi
{
    public partial class FrmOgretmenDetay : Form
    {
        public FrmOgretmenDetay()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmAnaFrom trer = new FrmAnaFrom();
            trer.Show();
            this.Hide();
        }

        private void FrmOgretmenDetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbNotKayıtDataSet.TBLDERS' table. You can move, or remove it, as needed.
            baglanti.Open();
            SqlCommand TRS = new SqlCommand("select COUNT(DURUM) FROM TBLDERS WHERE DURUM ='True' GROUP BY DURUM", baglanti);
            SqlDataReader DT = TRS.ExecuteReader();

            if (DT.Read())
            {
                LblGecenSayisi.Text = DT[0].ToString();
            }
            DT.Close();
            SqlCommand TR = new SqlCommand("select COUNT(DURUM) FROM TBLDERS WHERE DURUM =0 GROUP BY DURUM", baglanti);
            SqlDataReader DM = TR.ExecuteReader();
            if (DM.Read())
            {
                LblKalanSayisi.Text = DM[0].ToString();
            }
            DM.Close();
            baglanti.Close();

            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-1DQCP20\SQLEXPRESS;Initial Catalog=DbNotKayıt;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut9 = new SqlCommand("insert into TBLDERS (OGRNUMARA, OGRAD, OGRSOYAD) VALUES (@P1, @P2, @P3) ", baglanti);
            komut9.Parameters.AddWithValue("@P1", MskNumara.Text);
            komut9.Parameters.AddWithValue("@P2", TxtAd.Text);
            komut9.Parameters.AddWithValue("@P3", TxtSoyad.Text);
            komut9.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Student Record Added", "RECORD", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secile = dataGridView1.SelectedCells[0].RowIndex;
            MskNumara.Text = dataGridView1.Rows[secile].Cells[1].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secile].Cells[2].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secile].Cells[3].Value.ToString();
            TxtSinav1.Text = dataGridView1.Rows[secile].Cells[4].Value.ToString();
            TxtSinav2.Text = dataGridView1.Rows[secile].Cells[5].Value.ToString();
            TxtSinav3.Text = dataGridView1.Rows[secile].Cells[6].Value.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            double ortalama, s1,s2,s3;
            string durum;
            
            s1 = Convert.ToDouble(TxtSinav1.Text);
            s2 = Convert.ToDouble(TxtSinav2.Text);
            s3 = Convert.ToDouble(TxtSinav3.Text);
            ortalama = (s1 + s2 + s3) / 3;
            LblOrtalama.Text = ortalama.ToString();
            if (ortalama >= 50)
            {
                durum = "True";
            }
            else
            {
                durum = "False";
            }
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE TBLDERS SET OGRS1=@P1, OGRS2=@P2, OGRS3=@P3, ORTALAMA=@P4, DURUM=@P5 WHERE OGRNUMARA=@P6 ",baglanti);
            komut.Parameters.AddWithValue("@p1", TxtSinav1.Text);
            komut.Parameters.AddWithValue("@p2", TxtSinav2.Text);
            komut.Parameters.AddWithValue("@p3", TxtSinav3.Text);
            komut.Parameters.AddWithValue("@p4", decimal.Parse(LblOrtalama.Text));
            komut.Parameters.AddWithValue("@p5", durum);
            komut.Parameters.AddWithValue("@p6", MskNumara.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Student Grades Updated");
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);

        }
    }
    }
