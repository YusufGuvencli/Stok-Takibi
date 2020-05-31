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
        public frmStokEkleDuzenle(StokKartiDto _stokKarti = null)
        {
            InitializeComponent();
            txtStokKodu.Focus();
            depoBLL = new DepoBll();
            stokKartiBll = new StokKartlariBll();

            if (_stokKarti != null)
            {
                stokKarti = _stokKarti;
                InitilizeStokKarti();
                this.Text = "Stok Düzenleme Ekranı";
                btnKaydet.Text = "Düzenle";
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

        private void YeniStokKaydetveyaDuzenle()
        {
            Image img = pictureBox1.Image;
            byte[] arr;
            ImageConverter converter = new ImageConverter();
            arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            stokKarti = new StokKartiDto()
            {
                StokKodu = txtStokKodu.Text,
                StokAdi = txtStokAdi.Text,
                Kdv = Convert.ToInt32(cmbKdv.SelectedItem.ToString()),
                Fiyat = Convert.ToInt32(txtFiyat.Text),
                DepoId = Convert.ToInt32(lookUpDepo.EditValue),
                Aciklama = txtAciklama.Text,
                Resim = arr,
                AktifMi = true
            };

            CudEnums enums;
            if (btnKaydet.Text == "Kaydet")
            {
                enums = stokKartiBll.StokKartiEkle(stokKarti);
            }
            else
            {
                enums = stokKartiBll.StokKartiDuzenle(stokKarti);
            }
            FormHelpers.ShowMessage(enums);
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
            YeniStokKaydetveyaDuzenle();
            ClearControls();
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
    }
}