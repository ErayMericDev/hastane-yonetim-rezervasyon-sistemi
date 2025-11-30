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
    public partial class FrmDoktorPanel : Form
    {
        public FrmDoktorPanel()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl =new SqlBaglantisi();
        private void FrmDoktorPanel_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Doktorlar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            SqlCommand cmd = new SqlCommand("Select BransAd from Tbl_Branslar",bgl.baglanti());
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                CmbBrans.Items.Add(dataReader[0]);
            }
            bgl.baglanti().Close();

        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("insert into Tbl_Doktorlar(DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre)values(@p1,@p2,@p3,@p4,@p5)",bgl.baglanti());
            command.Parameters.AddWithValue("@p1",TxtAd.Text);
            command.Parameters.AddWithValue("@p2",TxtSoyad.Text);
            command.Parameters.AddWithValue("@p3",CmbBrans.Text);
            command.Parameters.AddWithValue("@p4",MskTc.Text);
            command.Parameters.AddWithValue("@p5",TxtSifre.Text);
            command.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Eklendi","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen=dataGridView1.SelectedCells[0].RowIndex;
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            CmbBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            MskTc.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Delete from Tbl_Doktorlar where DoktorTC=@d1",bgl.baglanti());
            command.Parameters.AddWithValue("@d1",MskTc.Text);
            command.ExecuteNonQuery() ;
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Silindi","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand command2 = new SqlCommand("Update from Tbl_Doktorlar set DoktorAd=@p1 , DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p5 where DoktorTC=@p4", bgl.baglanti());
            command2.Parameters.AddWithValue("@p1",TxtAd.Text);
            command2.Parameters.AddWithValue("@p2",TxtSoyad.Text);
            command2.Parameters.AddWithValue("@p3",CmbBrans.Text);
            command2.Parameters.AddWithValue("@p5",TxtSifre.Text);
            command2.Parameters.AddWithValue("@p4",MskTc.Text);
            command2.ExecuteNonQuery() ;
            bgl.baglanti().Close();
        }
    }
}
