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
using StokTakibi.Entities.Stok_Karti;
using StokTakibi.Entities.Stok_Hareketleri;
using StokTakibi.BLL.Business_Operations.Stok_Kartlari;
using StokTakibi.Helper.Enums;
using StokTakibi.Helper.Form_Helpers;
using StokTakibi.Helper.TryCatch;
using System.IO;
using System.Reflection;

namespace StokTakipUygulamasi.Forms.Stok_Karti
{
    public partial class frmStokEkleDuzenle : DevExpress.XtraEditors.XtraForm
    {
        DepoBll depoBLL;
        StokKartlariBll stokKartiBll;
        StokKartiDto stokKarti;
        int kullaniciId;
        public frmStokEkleDuzenle(int _kullaniciId, StokKartiDto _stokKarti = null)
        {
            InitializeComponent();
            kullaniciId = _kullaniciId;
            txtStokKodu.Focus();
            depoBLL = new DepoBll();
            stokKartiBll = new StokKartlariBll();
            dtpKayitTarihi.DateTime = DateTime.Now;
            cmbKdv.SelectedIndex = 0;
            if (_stokKarti != null)
            {
                stokKarti = _stokKarti;
                InitilizeStokKarti();
                this.Text = "Stok Düzenleme Ekranı";
                btnKaydet.Text = "Düzenle";
                btnKaydet.Hide();
                btnDuzenle.Show();
            }
        }

        private void InitilizeStokKarti()
        {
            txtStokKodu.Text = stokKarti.StokKodu;
            txtStokAdi.Text = stokKarti.StokAdi;
            cmbKdv.Text = stokKarti.Kdv.ToString();
            txtFiyat.Text = stokKarti.Fiyat.ToString();
            lookUpDepo.EditValue = stokKarti.DepoId;
            txtAciklama.Text = stokKarti.Aciklama;
            dtpKayitTarihi.DateTime = stokKarti.KayitTarihi;

            DynamicTryCatch.TryCatchLogla(() =>
            {
                MemoryStream ms = new MemoryStream(stokKarti.Resim, 0, stokKarti.Resim.Length);
                ms.Write(stokKarti.Resim, 0, stokKarti.Resim.Length);
                pictureBox1.Image = Image.FromStream(ms, true);
            }, MethodBase.GetCurrentMethod().Name);
        }

        private void ClearControls()
        {
            FormHelpers.ClearTextboxes(this.Controls);
            pictureBox1.Image = null;
            cmbKdv.SelectedIndex = -1;
            lookUpDepo.ItemIndex = -1;
        }

        private void YeniStokKaydet()
        {
            DynamicTryCatch.TryCatchLogla(() =>
            {
                byte[] arr;
                Image img = pictureBox1.Image;
                ImageConverter converter = new ImageConverter();
                arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

                stokKarti = new StokKartiDto();
                stokKarti.StokKodu = txtStokKodu.Text;
                stokKarti.StokAdi = txtStokAdi.Text;
                stokKarti.Kdv = FormHelpers.TextNullCheck(cmbKdv.SelectedItem.ToString()) ? Convert.ToInt32(cmbKdv.SelectedItem.ToString()) : -1;
                stokKarti.Fiyat = FormHelpers.TextNullCheck(txtFiyat.Text) ? Convert.ToDecimal(txtFiyat.Text) : -1;
                stokKarti.DepoId = Convert.ToInt32(lookUpDepo.EditValue) > 0 ? Convert.ToInt32(lookUpDepo.EditValue) : -1;
                stokKarti.Aciklama = txtAciklama.Text;
                stokKarti.KullaniciId = kullaniciId;
                stokKarti.KayitTarihi = dtpKayitTarihi.DateTime;
                stokKarti.Resim = arr;
                stokKarti.AktifMi = true;

                CudEnums enums = stokKartiBll.StokKartiEkle(stokKarti);
                if (enums == CudEnums.IslemBasarili)
                    ClearControls();

                FormHelpers.ShowMessage(enums);
            }, MethodBase.GetCurrentMethod().Name);
        }

        private void frmYeniStok_Load(object sender, EventArgs e)
        {
            lookUpDepo.Properties.DataSource = depoBLL.DepolariGetir().ToList();
            lookUpDepo.Properties.DisplayMember = "DepoAdi";
            lookUpDepo.Properties.ValueMember = "DepoId";
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            YeniStokKaydet();
        }

        private void btnResimSec_Click(object sender, EventArgs e)
        {
            Image file;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.jpg, *.png) | *.jpg; *.png";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                file = Image.FromFile(fileDialog.FileName);
                pictureBox1.Image = file;
            }
        }

        private void btnResmiKaldir_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            DynamicTryCatch.TryCatchLogla(() =>
            {
                Image img = pictureBox1.Image;
                byte[] arr;
                ImageConverter converter = new ImageConverter();
                arr = (byte[])converter.ConvertTo(img, typeof(byte[]));


                stokKarti.StokKodu = txtStokKodu.Text;
                stokKarti.StokAdi = txtStokAdi.Text;
                stokKarti.Kdv = FormHelpers.TextNullCheck(cmbKdv.SelectedItem.ToString()) ? Convert.ToInt32(cmbKdv.SelectedItem.ToString()) : -1;
                stokKarti.Fiyat = FormHelpers.TextNullCheck(txtFiyat.Text) ? Convert.ToDecimal(txtFiyat.Text) : -1;
                stokKarti.DepoId = Convert.ToInt32(lookUpDepo.EditValue) > 0 ? Convert.ToInt32(lookUpDepo.EditValue) : -1;
                stokKarti.Aciklama = txtAciklama.Text;
                stokKarti.KullaniciId = kullaniciId;
                stokKarti.KayitTarihi = dtpKayitTarihi.DateTime;
                stokKarti.Resim = arr;
                stokKarti.AktifMi = true;

                CudEnums enums = stokKartiBll.StokKartiDuzenle(stokKarti);

                if (enums == CudEnums.IslemBasarili)
                    ClearControls();

                FormHelpers.ShowMessage(enums);

            }, MethodBase.GetCurrentMethod().Name);
        }
    }
}