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
        public LoginEnums KullaniciGiris (KullaniciDto kullanici)
        {
            LoginEnums loginEnums=LoginEnums.EksikParametreHatasi;

            DynamicTryCatch.TryCatchLogla(() => {
               if(!string.IsNullOrEmpty(kullanici.KullaniciAdi) && !string.IsNullOrEmpty(kullanici.Sifre))
                {
                    bool result = _kullanici.KullaniciGiris(kullanici);
                    if (result)
                    {
                        loginEnums=LoginEnums.GirisBasarili;
                    }
                    else
                    {
                        loginEnums= LoginEnums.KullaniciBulunamadi;
                    }
                }              
               
            }, "");

            return loginEnums;
        }
    }
}
