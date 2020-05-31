using StokTakibi.DAL.Operations.Kullanici;
using StokTakibi.Entities.Kullanici;
using StokTakibi.Helper.Enums;
using StokTakibi.Helper.TryCatch;

namespace StokTakibi.BLL.Business_Operations
{
    public class KullaniciBll
    {
        KullaniciDal _kullanici;
        public KullaniciBll()
        {
            _kullanici = new KullaniciDal();
        }
        /// <summary>
        /// Kullanici icin girilen bilgiye göre entity sorgulanır
        /// Elde edilen sonuca göre LoginEnums döner.
        /// </summary>
        /// <param name="kullanici"></param>
        /// <returns></returns>
        public int KullaniciGiris (KullaniciDto kullanici)
        {
            int result = -1;
           
            DynamicTryCatch.TryCatchLogla(() => {
               if(!string.IsNullOrEmpty(kullanici.KullaniciAdi) && !string.IsNullOrEmpty(kullanici.Sifre))
                {
                     result = _kullanici.KullaniciGiris(kullanici);                   
                }              
               
            }, "");

            return result;
        }
    }
}
