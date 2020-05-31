using DevExpress.XtraEditors;
using StokTakibi.Helper.Enums;
using System.Windows.Forms;

namespace StokTakibi.Helper.Form_Helpers
{
    public static class FormHelpers
    {
        public static void ShowMessage(CudEnums enums)
        {
            switch (enums)
            {
                case CudEnums.IslemBasarili:
                    XtraMessageBox.Show("İşlem başarıyla gerçekleşti.", "HATA",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case CudEnums.EksikParametreHatasi:
                    XtraMessageBox.Show("Lütfen tüm alanları doldurduğunuza emin olunuz.", "HATA",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case CudEnums.VeritabaniHatasi:
                    XtraMessageBox.Show("Veritabanında bir hata meydana geldi.", "HATA",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }
        }
        public static void ShowError(string mesaj)
        {
            XtraMessageBox.Show(mesaj, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ShowWarning(string mesaj)
        {
            XtraMessageBox.Show(mesaj, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowInfo(string mesaj)
        {
            XtraMessageBox.Show(mesaj, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ClearTextboxes(System.Windows.Forms.Control.ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;
                ClearTextboxes(ctrl.Controls);
            }
        }
    }
}
