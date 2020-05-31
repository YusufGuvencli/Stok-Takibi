using StokTakibi.DAL.EntitiyFramework;
using StokTakibi.DAL.EntitiyFramework.UnitOfWork;
using StokTakibi.Entities.Stok_Karti;
using StokTakibi.Helper.TryCatch;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace StokTakibi.DAL.Operations.Stok
{

    public class StokKartlariDal
    {
        UnitOfWorkBase _uow;
        StokContext context;
        public StokKartlariDal()
        {
            context = new StokContext();
            _uow = new UnitOfWorkBase(context);
        }
        /// <summary>
        /// Aktif olan tüm stok kartlarını döndürür.
        /// Hata alması durumunda null değer döner.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StokKartiDto> StokKartlariniGetir()
        {

            IEnumerable<StokKartiDto> stokKartlari = null;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                stokKartlari = _uow.GenericRepository<StokKartiDto>().Where(x => x.AktifMi == true);
            }, MethodBase.GetCurrentMethod().Name);
            return stokKartlari;
        }
        /// <summary>
        /// Almış olduğu StokKartiDto tipindeki entity i veritabanına insert eder.
        /// Hata alması durumunda -1 döner.
        /// </summary>
        /// <param name="stokKarti"></param>
        /// <returns></returns>
        public int StokKartiEkle(StokKartiDto stokKarti)
        {
            int result = -1;
            DynamicTryCatch.TryCatchLogla(() =>
            {

                result = _uow.GenericRepository<StokKartiDto>().InsertWithProcedure(
                    "exec Insert_StokKartlari @StokKodu, @StokAdi, @Kdv, @Fiyat, @Aciklama, @Resim, @DepoId,@KayitTarihi,@KullaniciId, @Aktif",
                     new SqlParameter("@StokKodu", SqlDbType.NVarChar) { Value = stokKarti.StokKodu },
                     new SqlParameter("@StokAdi", SqlDbType.NVarChar) { Value = stokKarti.StokAdi },
                     new SqlParameter("@Kdv", SqlDbType.Int) { Value = stokKarti.Kdv },
                     new SqlParameter("@Fiyat", SqlDbType.Decimal) { Value = stokKarti.Fiyat },
                     new SqlParameter("@Aciklama", SqlDbType.NVarChar) { Value = stokKarti.Aciklama },
                     new SqlParameter("@Resim", SqlDbType.VarBinary) { Value = stokKarti.Resim },
                     new SqlParameter("@DepoId", SqlDbType.Int) { Value = stokKarti.DepoId },
                     new SqlParameter("@KayitTarihi", SqlDbType.DateTime) { Value = stokKarti.KayitTarihi },
                     new SqlParameter("@KullaniciId", SqlDbType.Int) { Value = stokKarti.KullaniciId },
                     new SqlParameter("@Aktif", SqlDbType.Bit) { Value = stokKarti.AktifMi });

            }, MethodBase.GetCurrentMethod().Name);
            return result;
        }

        /// <summary>
        /// Almış olduğu entity i veritabanına gönderir. 
        /// Hata alması durumunda -1 döner.
        /// </summary>
        /// <param name="stokKarti"></param>
        /// <returns></returns>
        public int StokKartiDuzenle(StokKartiDto stokKarti)
        {
            int result = -1;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                _uow.GenericRepository<StokKartiDto>().Update(stokKarti);
                result = _uow.Commit();
            }, MethodBase.GetCurrentMethod().Name);

            return result;
        }

        /// <summary>
        /// Almış olduğu entity i veritabanından siler.
        /// Hata alması durumunda -1 döner.
        /// </summary>
        /// <param name="stokKarti"></param>
        /// <returns></returns>
        public int StokKartiSil(StokKartiDto stokKarti)
        {
            int result = -1;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                _uow.GenericRepository<StokKartiDto>().Update(stokKarti);
                result = _uow.Commit();

            }, MethodBase.GetCurrentMethod().Name);

            return result;
        }

    }
}
