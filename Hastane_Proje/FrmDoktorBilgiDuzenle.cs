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

namespace Hastane_Proje
{
    public partial class FrmDoktorBilgiDuzenle : Form
    {
        public FrmDoktorBilgiDuzenle()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        public string tc;
        private void FrmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            MskTc.Text = tc;
            SqlCommand command = new SqlCommand("Select * from Tbl_Doktorlar where DoktorTC=@p1", bgl.baglanti());
            command.Parameters.AddWithValue("@p1",tc);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TxtAd.Text = reader[1].ToString();
                TxtSoyad.Text = reader[2].ToString();
                CmbBranslar.Text = reader[3].ToString();
                TxtSifre.Text += reader[5].ToString();
            }
            bgl.baglanti().Close();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand command2=new SqlCommand("Update Tbl_Doktorlar set DoktorAd=@d1,DoktorSoyad=@d2,DoktorSifre=@d3,DoktorBrans=@d4 where DoktorTC=@d5",bgl.baglanti());
            command2.Parameters.AddWithValue("@d1",TxtAd.Text);
            command2.Parameters.AddWithValue("@d2",TxtSoyad.Text);
            command2.Parameters.AddWithValue("@d3", TxtSifre.Text);
            command2.Parameters.AddWithValue("@d4",CmbBranslar.Text);
            command2.Parameters.AddWithValue("@d5",MskTc.Text);
            command2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgiler Güncellendi","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
