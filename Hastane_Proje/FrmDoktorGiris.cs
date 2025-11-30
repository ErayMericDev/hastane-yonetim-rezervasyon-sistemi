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
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl=new SqlBaglantisi();

        private void FrmDoktorGiris_Load(object sender, EventArgs e)
        {

        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * from Tbl_Doktorlar where DoktorTC=@p1 and DoktorSifre=@p2", bgl.baglanti());
            command.Parameters.AddWithValue("@p1",MskTc.Text);
            command.Parameters.AddWithValue("@p2",TxtSifre.Text);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                FrmDoktorDetay frmdoktordetay = new FrmDoktorDetay();
                frmdoktordetay.tc = MskTc.Text;
                this.Hide();
                frmdoktordetay.Show();
            }
            else
            {
                MessageBox.Show("TC veya şifre hatalı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            }
    }
}
