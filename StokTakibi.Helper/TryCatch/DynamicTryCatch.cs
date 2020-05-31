using StokTakibi.Helper.Form_Helpers;
using StokTakibi.Helper.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakibi.Helper.TryCatch
{
   public static class DynamicTryCatch
    {
        public static void TryCatchLogla(Action action, string metotAdi)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                FormHelpers.ShowError(ex.Message);
                HataLogla.Logla(ex.Message, metotAdi);
            }
        }
    }
}
