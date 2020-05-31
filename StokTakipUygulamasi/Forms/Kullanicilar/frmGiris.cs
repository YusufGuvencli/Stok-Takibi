using System;
using StokTakibi.Entities.Kullanici;
using StokTakibi.BLL.Business_Operations;
using StokTakibi.Helper.Form_Helpers;
using StokTakibi.Helper.Enums;

namespace StokTakipUygulamasi.Forms.Users
{
    public partial class GirisFormu : DevExpress.XtraEditors.XtraForm
    {
        KullaniciBll kullaniciBLL;
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

            kullaniciBLL = new KullaniciBll();
            LoginEnums enums = kullaniciBLL.KullaniciGiris(kullanici);
           
            switch (enums)
            {
                case LoginEnums.GirisBasarili:
                    frmAna anaForm = new frmAna();
                    anaForm.Show();
                    this.Hide();
                    break;
                case LoginEnums.KullaniciBulunamadi:
                    FormHelpers.ShowWarning("Kullanıcı adı ya da şifrenizi yanlış girdiniz.");
                    FormHelpers.ClearTextboxes(this.Controls);
                    txtKullaniciAdi.Focus();
                    break;
                case LoginEnums.EksikParametreHatasi:
                    FormHelpers.ShowWarning("Kullanıcı adı veya şifre boş alanını doldurmadınız.");
                    break;
                default:
                    break;
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