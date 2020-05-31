using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using StokTakibi.BLL.Business_Operations;
using StokTakibi.Entities.Stok_Karti;
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
        DepoBll bllDepo;
        StokKartlariBll bllStokKarti;
        StokKartiDto dtoStokKarti;
        int kullaniciId;
        public frmStokEkleDuzenle(int _kullaniciId, StokKartiDto _stokKarti = null)
        {
            InitializeComponent();
            kullaniciId = _kullaniciId;
            txtStokKodu.Focus();
            bllDepo = new DepoBll();
            bllStokKarti = new StokKartlariBll();
            dtpKayitTarihi.DateTime = DateTime.Now;
            cmbKdv.SelectedIndex = 0;
            if (_stokKarti != null)
            {
                dtoStokKarti = _stokKarti;
                InitilizeStokKarti();
                this.Text = "Stok Düzenleme Ekranı";
                btnKaydet.Text = "Düzenle";
                btnKaydet.Hide();
                btnDuzenle.Show();
            }
        }

        private void InitilizeStokKarti()
        {
            txtStokKodu.Text = dtoStokKarti.StokKodu;
            txtStokAdi.Text = dtoStokKarti.StokAdi;
            cmbKdv.Text = dtoStokKarti.Kdv.ToString();
            txtFiyat.Text = dtoStokKarti.Fiyat.ToString();
            lookUpDepo.EditValue = dtoStokKarti.DepoId;
            txtAciklama.Text = dtoStokKarti.Aciklama;
            dtpKayitTarihi.DateTime = dtoStokKarti.KayitTarihi;

            DynamicTryCatch.TryCatchLogla(() =>
            {
                MemoryStream ms = new MemoryStream(dtoStokKarti.Resim, 0, dtoStokKarti.Resim.Length);
                ms.Write(dtoStokKarti.Resim, 0, dtoStokKarti.Resim.Length);
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

                dtoStokKarti = new StokKartiDto();
                dtoStokKarti.StokKodu = txtStokKodu.Text;
                dtoStokKarti.StokAdi = txtStokAdi.Text;
                dtoStokKarti.Kdv = FormHelpers.TextNullCheck(cmbKdv.SelectedItem.ToString()) ? Convert.ToInt32(cmbKdv.SelectedItem.ToString()) : -1;
                dtoStokKarti.Fiyat = FormHelpers.TextNullCheck(txtFiyat.Text) ? Convert.ToDecimal(txtFiyat.Text) : -1;
                dtoStokKarti.DepoId = Convert.ToInt32(lookUpDepo.EditValue) > 0 ? Convert.ToInt32(lookUpDepo.EditValue) : -1;
                dtoStokKarti.Aciklama = txtAciklama.Text;
                dtoStokKarti.KullaniciId = kullaniciId;
                dtoStokKarti.KayitTarihi = dtpKayitTarihi.DateTime;
                dtoStokKarti.Resim = arr;
                dtoStokKarti.AktifMi = true;

                CudEnums enums = bllStokKarti.StokKartiEkle(dtoStokKarti);
                if (enums == CudEnums.IslemBasarili)
                    ClearControls();

                FormHelpers.ShowMessage(enums);
            }, MethodBase.GetCurrentMethod().Name);
        }

        private void frmYeniStok_Load(object sender, EventArgs e)
        {
            lookUpDepo.Properties.DataSource = bllDepo.DepolariGetir().ToList();
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


                dtoStokKarti.StokKodu = txtStokKodu.Text;
                dtoStokKarti.StokAdi = txtStokAdi.Text;
                dtoStokKarti.Kdv = FormHelpers.TextNullCheck(cmbKdv.SelectedItem.ToString()) ? Convert.ToInt32(cmbKdv.SelectedItem.ToString()) : -1;
                dtoStokKarti.Fiyat = FormHelpers.TextNullCheck(txtFiyat.Text) ? Convert.ToDecimal(txtFiyat.Text) : -1;
                dtoStokKarti.DepoId = Convert.ToInt32(lookUpDepo.EditValue) > 0 ? Convert.ToInt32(lookUpDepo.EditValue) : -1;
                dtoStokKarti.Aciklama = txtAciklama.Text;
                dtoStokKarti.KullaniciId = kullaniciId;
                dtoStokKarti.KayitTarihi = dtpKayitTarihi.DateTime;
                dtoStokKarti.Resim = arr;
                dtoStokKarti.AktifMi = true;

                CudEnums enums = bllStokKarti.StokKartiDuzenle(dtoStokKarti);

                if (enums == CudEnums.IslemBasarili)
                    ClearControls();

                FormHelpers.ShowMessage(enums);

            }, MethodBase.GetCurrentMethod().Name);
        }
    }
}