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
namespace Hastane_Proje
{
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl =new SqlBaglantisi();
        public string tc;

        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            LblTc.Text = tc;

            SqlCommand command = new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorTC=@p1", bgl.baglanti());
            command.Parameters.AddWithValue("@p1",LblTc.Text);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                LblAdSoyad.Text = dataReader[0] + " " + dataReader[1];
            }
            bgl.baglanti().Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da=new SqlDataAdapter("Select * from Tbl_Randevular where RandevuDoktor='"+LblAdSoyad.Text + "'",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDuzenle frmdoktorbilgiduzenle =new FrmDoktorBilgiDuzenle();
            frmdoktorbilgiduzenle.tc=LblTc.Text;
            frmdoktorbilgiduzenle.Show();
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular frmduyuru =new FrmDuyurular();
            frmduyuru.Show();
        }

        private void BtnCıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen =dataGridView1.SelectedCells[0].RowIndex;
            RchSikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
