using System;
using StokTakibi.Entities.Kullanici;
using StokTakibi.BLL.Business_Operations;
using StokTakibi.Helper.Form_Helpers;
using StokTakibi.Helper.Enums;

namespace StokTakipUygulamasi.Forms.Users
{
    public partial class GirisFormu : DevExpress.XtraEditors.XtraForm
    {
        KullaniciBll bllKullanici;
        public GirisFormu()
        {
            InitializeComponent();
            txtKullaniciAdi.Focus();
            txtKullaniciAdi.Text = Properties.Settings.Default.Username;
            txtSifre.Text = Properties.Settings.Default.Password;
            chkBeniHatirla.Checked = true;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GirisKontrol()
        {
            KullaniciDto kullanici = new KullaniciDto()
            {
                KullaniciAdi = txtKullaniciAdi.Text,
                Sifre = txtSifre.Text
            };

            bllKullanici = new KullaniciBll();
            int kullaniciId = bllKullanici.KullaniciGiris(kullanici);

            if (kullaniciId > 0)
            {
                frmAna frmAna = new frmAna(kullaniciId);
                frmAna.Show();
                this.Hide();
            }
            else
            {
                FormHelpers.ShowWarning("Kullanıcı adı ya da şifreyi yanlış girdiniz!");
            }
            
        }
        private void BeniHatirla()
        {
            if (chkBeniHatirla.Checked)
            {
                Properties.Settings.Default.Username = txtKullaniciAdi.Text;
                Properties.Settings.Default.Password = txtSifre.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            BeniHatirla();
            GirisKontrol();           
        }
    }
}