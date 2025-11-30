using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Proje
{
    public partial class FrmGirisler : Form
    {
        public FrmGirisler()
        {
            InitializeComponent();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            FrmHastaGiris frmgirishasta = new FrmHastaGiris();
            this.Hide();
            frmgirishasta.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmDoktorGiris frmgirisdoktor = new FrmDoktorGiris();
            this.Hide();
            frmgirisdoktor.ShowDialog();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSekreter frmsekreter = new FrmSekreter();
            this.Hide();
            frmsekreter.ShowDialog();
            
        }

        private void FrmGirisler_Load(object sender, EventArgs e)
        {

        }
    }
}
