using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace StokTakibi.Logger
{
    public class FormHelpers
    {
        public static void ShowError(string mesaj)
        {
            XtraMessageBox.Show(mesaj, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ShowWarning(string mesaj)
        {
            XtraMessageBox.Show(mesaj, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


