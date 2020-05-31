using StokTakibi.DAL.EntitiyFramework;
using StokTakibi.DAL.EntitiyFramework.UnitOfWork;
using StokTakibi.Entities.SqlView;
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
        public IEnumerable<StokHareketView> StokHareketleriniGetir()
        {
            IEnumerable<StokHareketView> lstStokHareketleri = null;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                lstStokHareketleri = _uow.GenericRepository<StokHareketView>().SqlQuery("SELECT * FROM vw_StokHareketleri", true);
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
                     "Insert_StokHareketleri @FisNo,@Miktar,@HareketDurumId,@StokKartId,@KayitTarihi,@KullaniciId,@AktifMi",
                     new SqlParameter("@FisNo", SqlDbType.NVarChar) { Value = stokHareketleri.FisNo },
                     new SqlParameter("@Miktar", SqlDbType.Int) { Value = stokHareketleri.Miktar },
                     new SqlParameter("@HareketDurumId", SqlDbType.Int) { Value = stokHareketleri.HareketDurumId },
                     new SqlParameter("@StokKartId", SqlDbType.Int) { Value = stokHareketleri.StokKartId },
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
            }, MethodBase.GetCurrentMethod().Name);

            return result;
        }

        /// <summary>
        /// Id tipinde değer alır ve veritabanına sorgu atar. 
        /// Bulduğu değeri StokHareketleriDto tipinde döner.
        /// Hata alırsa null değer döndürür.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public StokHareketleriDto StokHareketiBul(int Id)
        {
            StokHareketleriDto stokHareketleriDto = null;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                stokHareketleriDto = _uow.GenericRepository<StokHareketleriDto>().GetById(Id);
            }, MethodBase.GetCurrentMethod().Name);

            return stokHareketleriDto;
        }
    }
}
