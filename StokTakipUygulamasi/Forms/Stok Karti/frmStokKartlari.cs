using System;
using StokTakibi.BLL.Business_Operations.Stok_Kartlari;
using StokTakibi.Entities.Stok_Karti;
using StokTakibi.Helper.Enums;
using StokTakibi.Helper.Form_Helpers;

namespace StokTakipUygulamasi.Forms.Stok_Karti
{
    public partial class frmStokKartlari : DevExpress.XtraEditors.XtraForm
    {
        StokKartlariBll stokKartlariBLL;
        int kullaniciId;
        public frmStokKartlari(int _kullaniciId)
        {
            InitializeComponent();
            stokKartlariBLL = new StokKartlariBll();
            kullaniciId = _kullaniciId;

        }

        private void stokKartıEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStokEkleDuzenle yeniStok = new frmStokEkleDuzenle(kullaniciId);
            yeniStok.ShowDialog();
            StokKartlariGetir();
        }
        private void StokKartlariGetir()
        {
            gridControl1.DataSource = stokKartlariBLL.StokKartlariGetir();
        }
        private void frmStokKartlari_Load(object sender, EventArgs e)
        {
            StokKartlariGetir();
        }

        private void DuzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 1)
            {
                StokKartiDto stokKarti = (StokKartiDto)gridView1.GetRow(gridView1.FocusedRowHandle);
                frmStokEkleDuzenle frmStokEkleDuzenle = new frmStokEkleDuzenle(kullaniciId, stokKarti);
                frmStokEkleDuzenle.ShowDialog();
                StokKartlariGetir();
            }
            else if (gridView1.SelectedRowsCount > 1)
            {
                FormHelpers.ShowWarning("Aynı anda tek kayıtta düzenleme yapabilirsiniz");
            }
            else
            {
                FormHelpers.ShowWarning("Düzenlemek istediğiniz kaydı seçiniz.");
            }
        }
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StokKartiDto stokKarti = (StokKartiDto)gridView1.GetRow(gridView1.FocusedRowHandle);           
            CudEnums enums = stokKartlariBLL.StokKartiSil(stokKarti);
            FormHelpers.ShowMessage(enums);
            StokKartlariGetir();
        }

        private void kapatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}