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
    public partial class FrmSekreter : Form
    {
        public FrmSekreter()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl =new SqlBaglantisi();

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Tbl_Sekreterler where SekreterTC=@p1 and SekreterSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",MskTc.Text);
            komut.Parameters.AddWithValue("@p2",TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmSekreterDetay frmsekreterdetay = new FrmSekreterDetay();
                frmsekreterdetay.tc = MskTc.Text;
                this.Hide();
                frmsekreterdetay.Show();
            }
            else
            {
                MessageBox.Show("Tc veya şifre yanlış","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
