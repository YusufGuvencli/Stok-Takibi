using NLog;

namespace StokTakibi.Helper.Logger
{
    class HataLogla
    {
        public static void Logla(string exMessage, string metotBilgisi)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Log(LogLevel.Error, $"{exMessage} Hata alınan metot : {metotBilgisi}");
        }
    }
}
