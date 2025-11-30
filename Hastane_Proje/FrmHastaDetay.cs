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
using System.Data.SqlClient;
using System.Data.Common;
namespace Hastane_Proje
{
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi(); 
        public string tc;
        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            LblTc.Text = tc;

            SqlCommand komut = new SqlCommand("Select HastaAd,HastaSoyad from Tbl_Hastalar where HastaTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",LblTc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevular where HastaTC=" + tc,bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource= dt;

            SqlCommand komut2 = new SqlCommand("Select BransAd from Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr2 =komut2.ExecuteReader();
            while (dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();

         

        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoktor.Items.Clear();
            SqlCommand komut3 =new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorBrans=@d1",bgl.baglanti());   
            komut3.Parameters.AddWithValue("@d1",CmbBrans.Text);
            SqlDataReader dr3= komut3.ExecuteReader();
            while (dr3.Read())
            {
                CmbDoktor.Items.Add(dr3[0] + " " + dr3[1]);
            }
            bgl.baglanti().Close(); 
            }

        private void CmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da =new SqlDataAdapter("Select * from Tbl_Randevular where RandevuBrans='" + CmbBrans.Text + "'" + "and RandevuDoktor='" + CmbDoktor.Text + "'" + "and RandevuDurum=0",bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void LnkBilgiDuzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDuzenle frmbilgiduzenle=new FrmBilgiDuzenle();
            frmbilgiduzenle.TCno = LblTc.Text;
            frmbilgiduzenle.Show();
            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            Txtİd.Text=dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        private void BtnRandevuAl_Click(object sender, EventArgs e)
        {
            SqlCommand command =new SqlCommand("Update Tbl_Randevular set RandevuDurum=1,HastaTC=@p1,Sikayet=@p2 where Randevuid=@p3",bgl.baglanti());
            command.Parameters.AddWithValue("@p1",LblTc.Text);
            command.Parameters.AddWithValue("@p2",RchSikayet.Text);
            command.Parameters.AddWithValue("@p3",Txtİd.Text);
            command.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Oluşturuldu","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
