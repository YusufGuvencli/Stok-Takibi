using System;

namespace StokTakibi.Logger
{
    public static class TryCatch
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
