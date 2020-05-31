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
using StokTakipUygulamasi.Forms.Depo;
using StokTakipUygulamasi.Forms.Stok_Karti;
using StokTakipUygulamasi.Forms.Stok_Hareketleri;

namespace StokTakipUygulamasi.Forms
{
    public partial class frmAna : DevExpress.XtraEditors.XtraForm
    {
        int kullaniciId;
        public frmAna(int _kullaniciId)
        {
            InitializeComponent();
            kullaniciId = _kullaniciId;
        }

        private void depoEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepo depo = new frmDepo();
            depo.ShowDialog();
        }

        private void AnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void stokEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStokKartlari frmStokKartlari = new frmStokKartlari(kullaniciId);
            frmStokKartlari.Show();
        }

        private void stokHareketleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStokHareketleri frmStok = new frmStokHareketleri(kullaniciId);
            frmStok.Show();
        }
    }
}