using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using StokTakibi.BLL.Business_Operations;

namespace StokTakipUygulamasi.Forms.Stok_Hareketleri
{
    public partial class frmStokHareketleri : DevExpress.XtraEditors.XtraForm
    {
        StokHareketleriBLL stokHareketleriBLL;

        public frmStokHareketleri()
        {
            InitializeComponent();
            stokHareketleriBLL = new StokHareketleriBLL();
            StokHareketleriniGetir();
        }
        private void StokHareketleriniGetir()
        {
            grdStokHareketleri.DataSource = stokHareketleriBLL.StokHareketleriniGetir().ToList();
        }

        private void hareketEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStokHareketEkleDuzenle frmStokHareket = new frmStokHareketEkleDuzenle();
            frmStokHareket.Show();
        }
    }
}