using System;
using StokTakibi.BLL.Business_Operations;
using StokTakibi.Entities.Stok_Hareketleri;
using StokTakibi.Entities.SqlView;
using StokTakibi.Helper.Form_Helpers;
using StokTakibi.Helper.Enums;

namespace StokTakipUygulamasi.Forms.Stok_Hareketleri
{
    public partial class frmStokHareketleri : DevExpress.XtraEditors.XtraForm
    {
        StokHareketleriBll bllStokHareketleri;
        int kullaniciId;

        public frmStokHareketleri(int _kullaniciId)
        {
            InitializeComponent();
            bllStokHareketleri = new StokHareketleriBll();
            StokHareketleriniGetir();
            kullaniciId = _kullaniciId;
        }
        private void StokHareketleriniGetir()
        {
            grdStokHareketleri.DataSource = bllStokHareketleri.StokHareketleriniGetir();
        }

        private void hareketEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStokHareketEkleDuzenle frmStokHareket = new frmStokHareketEkleDuzenle(kullaniciId);
            frmStokHareket.ShowDialog();
            StokHareketleriniGetir();
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StokHareketView viewStokHareketleri = new StokHareketView();
            viewStokHareketleri = (StokHareketView)gridView1.GetRow(gridView1.FocusedRowHandle);
            frmStokHareketEkleDuzenle frmStokHareket = new frmStokHareketEkleDuzenle(kullaniciId, viewStokHareketleri);
            frmStokHareket.ShowDialog();
            StokHareketleriniGetir();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StokHareketView viewStokHareketleri = new StokHareketView();
            if (gridView1.SelectedRowsCount == 1)
            {
                viewStokHareketleri = (StokHareketView)gridView1.GetRow(gridView1.FocusedRowHandle);
                StokHareketleriDto stokHareketleriDto = bllStokHareketleri.StokHareketiBul(viewStokHareketleri.HareketId);
                CudEnums enums = bllStokHareketleri.StokHareketiSil(stokHareketleriDto);
                FormHelpers.ShowMessage(enums);
                StokHareketleriniGetir();
            }
            else if (gridView1.SelectedRowsCount > 1)
            {
                FormHelpers.ShowWarning("Aynı anda tek kayıt silebilirsiniz.");
            }
            else
            {
                FormHelpers.ShowWarning("Lütfen silmek istediğiniz kaydı seçiniz!");
            }

        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}