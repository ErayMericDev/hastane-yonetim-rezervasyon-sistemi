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
    public partial class FrmBransPaneli : Form
    {
        public FrmBransPaneli()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl=new SqlBaglantisi();
        private void FrmBransPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Branslar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("insert into Tbl_Branslar(BransAd)values(@p1)",bgl.baglanti());
            command.Parameters.AddWithValue("@p1",TxtAd.Text);
            command.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Başarı ile eklendi","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from Tbl_Branslar where Bransid=@b1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@b1",Txtİd.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş silindi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            Txtİd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand command2 = new SqlCommand("Update from Tbl_Branslar BransAd=@p1 where Bransid=@p2", bgl.baglanti());
            command2.Parameters.AddWithValue("@p1",TxtAd.Text);
            command2.Parameters.AddWithValue("@p2", Txtİd.Text);
            command2.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
