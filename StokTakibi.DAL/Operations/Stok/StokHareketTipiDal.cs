using StokTakibi.DAL.EntitiyFramework;
using StokTakibi.DAL.EntitiyFramework.UnitOfWork;
using StokTakibi.Entities.Stok_Hareketleri;
using StokTakibi.Helper.TryCatch;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace StokTakibi.DAL.Operations.Stok
{
    public class StokHareketTipiDal
    {
        UnitOfWorkBase _uow;
        StokContext _context;
        public StokHareketTipiDal()
        {
            _context = new StokContext();
            _uow = new UnitOfWorkBase(_context);
        }
        /// <summary>
        /// StokHareketTipiDto olarak aldığı entityi procedure ile veritabanına ekler
        /// Hata alması durumunda -1 döner
        /// </summary>
        /// <param name="stokHareketleri"></param>
        /// <returns></returns>
        public int StokHareketTipiEkle(StokHareketTipiDto stokHareketleri)
        {
            int result = -1;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                result = _uow.GenericRepository<StokHareketTipiDto>().InsertWithProcedure("" +
                      "exec Insert_Stok_Hareket_Tipi @StokHareketTipi,@AktifMi",
                      new SqlParameter("@StokHareketTipi", SqlDbType.NVarChar) { Value = stokHareketleri.HareketTipi },
                      new SqlParameter("@AktifMi", SqlDbType.Bit) { Value = stokHareketleri.AktifMi }
 );
            }, MethodBase.GetCurrentMethod().Name);
            return result;
        }

        /// <summary>
        /// StokHareketleriDto entitysinde stok hareket tiplerini döner.
        /// Hata alması durumunda null değer döndürür.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StokHareketTipiDto> StokHareketTipleriniGetir()
        {
            IEnumerable<StokHareketTipiDto> stokHareketleri = null;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                stokHareketleri = _uow.GenericRepository<StokHareketTipiDto>().Where(x => x.AktifMi == true);
            }, MethodBase.GetCurrentMethod().Name);

            return stokHareketleri;
        }
    }
}
