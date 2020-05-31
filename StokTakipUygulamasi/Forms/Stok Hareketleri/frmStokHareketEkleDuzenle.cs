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
        StokHareketView viewStokHareket;
        StokHareketleriDto dtoStokHareket;
        int kullaniciId;
        public frmStokHareketEkleDuzenle(int _kullaniciId, StokHareketView _stokHareketleri = null)
        {
            InitializeComponent();

            if (_stokHareketleri != null)
            {
                viewStokHareket = _stokHareketleri;
                this.Text = "Hareket Düzenleme Ekranı";
                btnKaydet.Hide();
                btnDuzenle.Show();
            }

            kullaniciId = _kullaniciId;
            InitializeForm();
        }

        private void InitializeForm()
        {
            StokHareketTipiBll stokHareketTipi = new StokHareketTipiBll();
            StokKartlariBll stokKarti = new StokKartlariBll();

            dtpKayitTarihi.DateTime = DateTime.Now;

            lookUpDurum.Properties.DataSource = stokHareketTipi.StokHareketTipleriniGetir().ToList();
            lookUpDurum.Properties.DisplayMember = "HareketTipi";
            lookUpDurum.Properties.ValueMember = "HareketDurumId";

            lookUpUrun.Properties.DataSource = stokKarti.StokKartlariGetir().ToList();
            lookUpUrun.Properties.DisplayMember = "StokAdi";
            lookUpUrun.Properties.ValueMember = "StokKartId";


            if (viewStokHareket != null)
            {
                txtFisNumarasi.Text = viewStokHareket.FisNo;
                txtMiktar.Text = viewStokHareket.Miktar.ToString();
                lookUpDurum.EditValue = viewStokHareket.HareketDurumId;
                lookUpUrun.EditValue = viewStokHareket.StokKartId;
                dtpKayitTarihi.DateTime = viewStokHareket.KayitTarihi;
            }

        }

        public void StokHareketiKaydet()
        {
            DynamicTryCatch.TryCatchLogla(() =>
            {
                dtoStokHareket = new StokHareketleriDto();
                dtoStokHareket.FisNo = txtFisNumarasi.Text;
                dtoStokHareket.Miktar = FormHelpers.TextNullCheck(txtMiktar.Text) ? Convert.ToInt32(txtMiktar.Text) : -1;
                dtoStokHareket.HareketDurumId = Convert.ToInt32(lookUpDurum.EditValue) > 0 ? Convert.ToInt32(lookUpDurum.EditValue) : -1;
                dtoStokHareket.KayitTarihi = dtpKayitTarihi.DateTime;
                dtoStokHareket.KullaniciId = kullaniciId;
                dtoStokHareket.StokKartId = Convert.ToInt32(lookUpUrun.EditValue) > 0 ? Convert.ToInt32(lookUpUrun.EditValue) : -1;
                dtoStokHareket.AktifMi = true;


            }, MethodBase.GetCurrentMethod().Name);

            StokHareketleriBll stokHareketleri = new StokHareketleriBll();

            CudEnums enums = stokHareketleri.StokHareketiEkle(dtoStokHareket);
            if (enums == CudEnums.IslemBasarili)
            {
                FormHelpers.ClearTextboxes(this.Controls);
                dtpKayitTarihi.DateTime = DateTime.Now;
            }

            FormHelpers.ShowMessage(enums);
        }

        private void StokHareketleriDuzenle()
        {
            dtoStokHareket = new StokHareketleriDto()
            {
                AktifMi = true,
                HareketId = viewStokHareket.HareketId
            };

            dtoStokHareket.FisNo = txtFisNumarasi.Text;
            dtoStokHareket.Miktar = FormHelpers.TextNullCheck(txtMiktar.Text) ? Convert.ToInt32(txtMiktar.Text) : -1;
            dtoStokHareket.HareketDurumId = Convert.ToInt32(lookUpDurum.EditValue) > 0 ? Convert.ToInt32(lookUpDurum.EditValue) : -1;
            dtoStokHareket.KayitTarihi = dtpKayitTarihi.DateTime;
            dtoStokHareket.KullaniciId = kullaniciId;
            dtoStokHareket.StokKartId = Convert.ToInt32(lookUpUrun.EditValue) > 0 ? Convert.ToInt32(lookUpUrun.EditValue) : -1;

            StokHareketleriBll stokHareketleriBLL = new StokHareketleriBll();

            
            CudEnums enums = stokHareketleriBLL.StokHareketiGuncelle(dtoStokHareket);

            if (enums == CudEnums.IslemBasarili)
            {
                FormHelpers.ClearTextboxes(this.Controls);
                dtpKayitTarihi.DateTime = DateTime.Now;
            }

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