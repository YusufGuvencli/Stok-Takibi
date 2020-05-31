using StokTakibi.DAL.EntitiyFramework;
using StokTakibi.DAL.EntitiyFramework.UnitOfWork;
using StokTakibi.Entities.Depo;
using StokTakibi.Helper.TryCatch;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace StokTakibi.DAL.Operations.Depo
{
    public class DepoDal
    {
        UnitOfWorkBase _uow;
        StokContext _context;
        public DepoDal()
        {
            _context = new StokContext();
            _uow = new UnitOfWorkBase(_context);
        }
        /// <summary>
        /// Gönderilen depo entity'sini veritabanına ekler.
        /// Hata alması durumunda -1 döner.
        /// </summary>
        /// <param name="depo"></param>
        /// <returns></returns>
        public int DepoEkle(DepoDto depo)
        {
            int result = -1;
            DynamicTryCatch.TryCatchLogla(() =>
            {
              result=  _uow.GenericRepository<DepoDto>().InsertWithProcedure("Exec Insert_Depo @DepoKodu, @DepoAdi, @AktifMi",
                    new SqlParameter("@DepoKodu", SqlDbType.VarChar) { Value = depo.DepoKodu },
                     new SqlParameter("@DepoAdi", SqlDbType.VarChar) { Value = depo.DepoAdi },
                     new SqlParameter("@AktifMi", SqlDbType.Bit) { Value = depo.AktifMi });
               
                _uow.Dispose();
            }
            , MethodBase.GetCurrentMethod().Name);
            return result;
        }
        public int DepoDuzenle(DepoDto depo)
        {
            int result = -1;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                _uow.GenericRepository<DepoDto>().Update(depo);
                result = _uow.Commit();
                _uow.Dispose();
            }, MethodBase.GetCurrentMethod().Name);
            return result;
        }

        public int DepoSil(DepoDto depo)
        {
            int result = -1;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                _uow.GenericRepository<DepoDto>().Update(depo);
                result = _uow.Commit();
                _uow.Dispose();
            }, "StokTakibi.DAL.Operations.Depo.DepoDuzenle");
            return result;
        }
        public IEnumerable<DepoDto> DepolariGetir()
        {
            IEnumerable<DepoDto> depolar = null;

            DynamicTryCatch.TryCatchLogla(() =>
            {
                depolar = _uow.GenericRepository<DepoDto>().Where(i => i.AktifMi == true);
            }, "StokTakibi.DAL.Operations.Depo.DepolariGetir");

            return depolar;
        }
    }
}
