using StokTakibi.DAL.EntitiyFramework;
using StokTakibi.DAL.EntitiyFramework.UnitOfWork;
using StokTakibi.Entities.Kullanici;
using StokTakibi.Helper.TryCatch;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace StokTakibi.DAL.Operations.Kullanici
{
    public class KullaniciDal
    {
        StokContext context;
        UnitOfWorkBase _uow;
        public KullaniciDal()
        {
            context = new StokContext();
            _uow = new UnitOfWorkBase(context);
        }
        /// <summary>
        /// Kullanıcı tipinde entity alarak aldığı entity'i veritabanina ekler.
        /// Hata alması ya da değer bulamaması durumunda false döner.
        /// </summary>
        /// <param name="kullanici"></param>
        /// <returns></returns>
        public bool KullaniciGiris(KullaniciDto kullanici)
        {
            bool result = false;

            DynamicTryCatch.TryCatchLogla(() =>
            {
                PasswordHash passwordHash = new PasswordHash();
                string password = passwordHash.Hash(kullanici.Sifre);
                string test = passwordHash.Hash(kullanici.Sifre);
                result = _uow.GenericRepository<KullaniciDto>().Any(x => x.KullaniciAdi == kullanici.KullaniciAdi
                                                              && x.Sifre == password);
            }, "StokTakibi.DAL.Operations.Kullanici.KullaniciGiris");
            return result;
        }
        public int KullaniciEkle(KullaniciDto kullanici)
        {
            int result = -1;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                result = _uow.GenericRepository<KullaniciDto>().InsertWithProcedure(
                    "exec [dbo].[Insert_Kullanici] @KullaniciAdi, @Isim,@Soyisim, @Sifre,@AktifMi",
                    new SqlParameter("@KullaniciAdi", SqlDbType.NVarChar) { Value = kullanici.KullaniciAdi },
                    new SqlParameter("@Isim", SqlDbType.NVarChar) { Value = kullanici.Isim },
                     new SqlParameter("@Soyisim", SqlDbType.NVarChar) { Value = kullanici.Soyisim },
                      new SqlParameter("@Sifre", SqlDbType.NVarChar) { Value = kullanici.Sifre },
                      new SqlParameter("@AktifMi", SqlDbType.Bit) { Value = kullanici.AktifMi }
                    );
            }, MethodBase.GetCurrentMethod().Name);
            return result;
        }
    }
}
