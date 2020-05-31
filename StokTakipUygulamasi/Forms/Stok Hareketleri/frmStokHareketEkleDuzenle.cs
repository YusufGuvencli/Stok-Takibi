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

namespace StokTakipUygulamasi.Forms.Stok_Hareketleri
{
    public partial class frmStokHareketEkleDuzenle : DevExpress.XtraEditors.XtraForm
    {
        StokHareketleriDto stokHareket;

        public frmStokHareketEkleDuzenle(StokHareketleriDto _stokHareketleri=null)
        {
            InitializeComponent();
            stokHareket = _stokHareketleri;
            InitializeForm();
        }

        private void InitializeForm()
        {
            StokHareketTipiBLL stokHareketTipi = new StokHareketTipiBLL();
            StokKartlariBll stokKarti = new StokKartlariBll();
            if (stokHareket == null)
            {
                dtpKayitTarihi.DateTime = DateTime.Now;

                lookUpDurum.Properties.DataSource = stokHareketTipi.StokHareketTipleriniGetir().ToList();
                lookUpDurum.Properties.DisplayMember = "StokHareketTipi";
                lookUpDurum.Properties.ValueMember = "StokHareketId";

                lookUpUrun.Properties.DataSource = stokKarti.StokKartlariGetir().ToList();
                lookUpUrun.Properties.DisplayMember = "StokAdi";
                lookUpUrun.Properties.ValueMember = "StokId";

            }

        }

        public void StokHareketiKaydet()
        {
            stokHareket = new StokHareketleriDto()
            {
                FisNumarasi = txtFisNumarasi.Text,
                GirisCikisMiktari = int.Parse(txtMiktar.Text),
                GirisCikisDurum=Convert.ToInt32(lookUpDurum.EditValue),
                KayitTarihi=dtpKayitTarihi.DateTime,
                
                AktifMi=true


            };
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFisNumarasi_EditValueChanged(object sender, EventArgs e)
        {
            int value = Convert.ToInt32(txtFisNumarasi.Text);


            string fisNumarasi = value.ToString("000000000000000");

            txtFisNumarasi.Text = fisNumarasi;
        }
    }
}