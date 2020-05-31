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
using StokTakibi.Entities.Stok_Hareketleri;
using StokTakibi.BLL.Business_Operations;
using StokTakibi.BLL.Business_Operations.Stok_Kartlari;
using StokTakibi.Helper.Form_Helpers;
using StokTakibi.Helper.Enums;
using StokTakibi.Entities.SqlView;
using StokTakibi.Helper.TryCatch;
using System.Reflection;

namespace StokTakipUygulamasi.Forms.Stok_Hareketleri
{
    public partial class frmStokHareketEkleDuzenle : DevExpress.XtraEditors.XtraForm
    {
        StokHareketView stokHareketView;
        StokHareketleriDto stokHareketDto;
        int kullaniciId;
        public frmStokHareketEkleDuzenle(int _kullaniciId, StokHareketView _stokHareketleri = null)
        {
            InitializeComponent();

            if (_stokHareketleri != null)
            {
                stokHareketView = _stokHareketleri;
                this.Text = "Hareket Düzenleme Ekranı";
                btnKaydet.Hide();
                btnDuzenle.Show();
            }

            kullaniciId = _kullaniciId;
            InitializeForm();
        }

        private void InitializeForm()
        {
            StokHareketTipiBLL stokHareketTipi = new StokHareketTipiBLL();
            StokKartlariBll stokKarti = new StokKartlariBll();

            dtpKayitTarihi.DateTime = DateTime.Now;

            lookUpDurum.Properties.DataSource = stokHareketTipi.StokHareketTipleriniGetir().ToList();
            lookUpDurum.Properties.DisplayMember = "HareketTipi";
            lookUpDurum.Properties.ValueMember = "HareketDurumId";

            lookUpUrun.Properties.DataSource = stokKarti.StokKartlariGetir().ToList();
            lookUpUrun.Properties.DisplayMember = "StokAdi";
            lookUpUrun.Properties.ValueMember = "StokKartId";


            if (stokHareketView != null)
            {
                txtFisNumarasi.Text = stokHareketView.FisNo;
                txtMiktar.Text = stokHareketView.Miktar.ToString();
                lookUpDurum.EditValue = stokHareketView.HareketDurumId;
                lookUpUrun.EditValue = stokHareketView.StokKartId;
                dtpKayitTarihi.DateTime = stokHareketView.KayitTarihi;
            }

        }

        public void StokHareketiKaydet()
        {
            DynamicTryCatch.TryCatchLogla(() =>
            {
                stokHareketDto = new StokHareketleriDto();
                stokHareketDto.FisNo = txtFisNumarasi.Text;
                stokHareketDto.Miktar = FormHelpers.TextNullCheck(txtMiktar.Text) ? Convert.ToInt32(txtMiktar.Text) : -1;
                stokHareketDto.HareketDurumId = Convert.ToInt32(lookUpDurum.EditValue) > 0 ? Convert.ToInt32(lookUpDurum.EditValue) : -1;
                stokHareketDto.KayitTarihi = dtpKayitTarihi.DateTime;
                stokHareketDto.KullaniciId = kullaniciId;
                stokHareketDto.StokKartId = Convert.ToInt32(lookUpUrun.EditValue) > 0 ? Convert.ToInt32(lookUpUrun.EditValue) : -1;
                stokHareketDto.AktifMi = true;


            }, MethodBase.GetCurrentMethod().Name);

            StokHareketleriBLL stokHareketleri = new StokHareketleriBLL();

            CudEnums enums = stokHareketleri.StokHareketiEkle(stokHareketDto);
            FormHelpers.ShowMessage(enums);
        }

        private void StokHareketleriDuzenle()
        {
            stokHareketDto = new StokHareketleriDto()
            {
                AktifMi = true,
                HareketId = stokHareketView.HareketId
            };

            stokHareketDto.FisNo = txtFisNumarasi.Text;
            stokHareketDto.Miktar = FormHelpers.TextNullCheck(txtMiktar.Text) ? Convert.ToInt32(txtMiktar.Text) : -1;
            stokHareketDto.HareketDurumId = Convert.ToInt32(lookUpDurum.EditValue) > 0 ? Convert.ToInt32(lookUpDurum.EditValue) : -1;
            stokHareketDto.KayitTarihi = dtpKayitTarihi.DateTime;
            stokHareketDto.KullaniciId = kullaniciId;
            stokHareketDto.StokKartId = Convert.ToInt32(lookUpUrun.EditValue) > 0 ? Convert.ToInt32(lookUpUrun.EditValue) : -1;

            StokHareketleriBLL stokHareketleriBLL = new StokHareketleriBLL();

            CudEnums enums = stokHareketleriBLL.StokHareketiGuncelle(stokHareketDto);

            FormHelpers.ShowMessage(enums);
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            StokHareketiKaydet();
        }

        private void txtFisNumarasi_Leave(object sender, EventArgs e)
        {
            string fisNumarasi = txtFisNumarasi.Text;
            fisNumarasi = fisNumarasi.PadLeft(15, '0');
            txtFisNumarasi.Text = fisNumarasi;
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            StokHareketleriDuzenle();
        }

    }
}