using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Proje
{
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        public string tc;

        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            LblTc.Text = tc;
            SqlCommand command = new SqlCommand("Select SekreterAdSoyad from Tbl_Sekreterler where SekreterTC=@s1", bgl.baglanti());
            command.Parameters.AddWithValue("@s1", LblTc.Text);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();


            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select BransAd from Tbl_Branslar", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select (DoktorAd + ' ' + DoktorSoyad) as 'Doktorlar',DoktorBrans from Tbl_Doktorlar",bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;


            SqlCommand command2 = new SqlCommand("Select BransAd from Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr2 = command2.ExecuteReader();
            while (dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand savecommand = new SqlCommand("insert into Tbl_Randevular(RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values(@p1,@p2,@p3,@p4)", bgl.baglanti());
            savecommand.Parameters.AddWithValue("@p1", MskTarih.Text);
            savecommand.Parameters.AddWithValue("@p2",MskSaat.Text);
            savecommand.Parameters.AddWithValue("@p3",CmbBrans.Text);
            savecommand.Parameters.AddWithValue("@p4",CmbDoktor.Text);
           savecommand.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Başarı ile oluşturuldu.");
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoktor.Items.Clear();
            SqlCommand command = new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorBrans=@a1",bgl.baglanti());
            command.Parameters.AddWithValue("@a1", CmbBrans.Text);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                CmbDoktor.Items.Add(reader[0] + " " + reader[1]);
            }
            bgl.baglanti().Close();
            
        }

        private void BtnOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("insert into Tbl_Duyurular(Duyuru)values(@d1)", bgl.baglanti());
            command.Parameters.AddWithValue("@d1",RchDuyuru.Text);
            command.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Başarı ile oluşturuldu");
        }

        private void BtnDoktorPanel_Click(object sender, EventArgs e)
        {
            FrmDoktorPanel frmdoktorpanel = new FrmDoktorPanel();
            frmdoktorpanel.Show();
        }

        private void BtnBransPanel_Click(object sender, EventArgs e)
        {
            FrmBransPaneli frmbranspanel = new FrmBransPaneli();
            frmbranspanel.Show();
        }

        private void BtnRandevuListesi_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi frmrandevuliste=new FrmRandevuListesi();
            frmrandevuliste.Show();
            
        }

       
    }
}
