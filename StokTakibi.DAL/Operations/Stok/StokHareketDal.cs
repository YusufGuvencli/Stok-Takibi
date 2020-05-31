using StokTakibi.DAL.EntitiyFramework;
using StokTakibi.DAL.EntitiyFramework.UnitOfWork;
using StokTakibi.Entities.Stok_Hareketleri;
using StokTakibi.Helper.TryCatch;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StokTakibi.DAL.Operations.Stok
{
    public class StokHareketDal
    {
        UnitOfWorkBase _uow;
        StokContext _context;
        public StokHareketDal()
        {
            _context = new StokContext();
            _uow = new UnitOfWorkBase(_context);
        }

        /// <summary>
        /// IEnumerable tipinde stok hareketlerini döner.
        /// Hata alması durumunda null değer döndürür.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StokHareketleriDto> StokHareketleriniGetir()
        {
            IEnumerable<StokHareketleriDto> lstStokHareketleri = null;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                lstStokHareketleri = _uow.GenericRepository<StokHareketleriDto>().Where(x => x.AktifMi == true);
            }, MethodBase.GetCurrentMethod().Name);

            return lstStokHareketleri;
        }
        /// <summary>
        /// StokHareketleriDto tipinde entity alır ve procedure ile veritabanına gönderir.
        /// Hata alması durumunda -1 başarılı olması durumunda 1 geri döner.
        /// </summary>
        /// <param name="stokHareketleri"></param>
        /// <returns></returns>
        public int StokHareketiEkle(StokHareketleriDto stokHareketleri)
        {
            int result = -1;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                result = _uow.GenericRepository<StokHareketleriDto>().InsertWithProcedure(
                     "Insert_StokHareketleri @FisNumarasi,@GirisCikisMiktari,@GirisCikisDurum,@KayitTarihi,@KullaniciId,@DepoId,@AktifMi",
                     new SqlParameter("@FisNumarasi", SqlDbType.NVarChar) { Value = stokHareketleri.FisNumarasi },
                     new SqlParameter("@GirisCikisMiktari", SqlDbType.Int) { Value = stokHareketleri.GirisCikisMiktari },
                     new SqlParameter("@GirisCikisDurum", SqlDbType.Int) { Value = stokHareketleri.GirisCikisDurum },
                     new SqlParameter("@KayitTarihi", SqlDbType.DateTime) { Value = stokHareketleri.KayitTarihi },
                     new SqlParameter("@KullaniciId", SqlDbType.Int) { Value = stokHareketleri.KullaniciId },
                     new SqlParameter("@AktifMi", SqlDbType.Bit) { Value = stokHareketleri.AktifMi });

            }, MethodBase.GetCurrentMethod().Name);

            return result;
        }
        /// <summary>
        /// StokHareketleriDto tipinde entity alır. Aldığı datayı veritabanında günceller.
        /// Hata alması durumunda -1 başarılı olması durumunda 1 geri döner.
        /// </summary>
        /// <param name="stokHareketleri"></param>
        /// <returns></returns>
        public int StokHareketiGuncelle(StokHareketleriDto stokHareketleri)
        {
            int result = -1;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                result = _uow.GenericRepository<StokHareketleriDto>().Update(stokHareketleri);
                _uow.Commit();
                _uow.Dispose();
            }, MethodBase.GetCurrentMethod().Name);
            return result;
        }
        /// <summary>
        /// StokHareketleriDto tipinde entity alır. Aldığı datayı deaktif eder.
        /// Hata alması durumunda -1 başarılı olması durumunda 1 geri döner.
        /// </summary>
        /// <param name="stokHareketleri"></param>
        /// <returns></returns>
        public int StokHareketiSil(StokHareketleriDto stokHareketleri)
        {
            int result = -1;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                result = _uow.GenericRepository<StokHareketleriDto>().Update(stokHareketleri);
                _uow.Commit();
                _uow.Dispose();
            }, MethodBase.GetCurrentMethod().Name);

            return result;
        }
    }
}
