using StokTakibi.DAL.EntitiyFramework;
using StokTakibi.DAL.EntitiyFramework.UnitOfWork;
using StokTakibi.Entities.Raporlar;
using StokTakibi.Helper.TryCatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StokTakibi.DAL.Operations.Raporlar
{
    public class StokHareketRaporuDal
    {
        UnitOfWorkBase _uow;
        StokContext _context;
        public StokHareketRaporuDal()
        {
            _context = new StokContext();
            _uow = new UnitOfWorkBase(_context);
        }

        /// <summary>
        /// StokHareketleriRaporDto entitysinde stok hareket raporu döner.
        /// Hata alması durumunda null değer gönderir.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StokHareketleriRaporDto> StokHareketRaporuGetir()
        {
            IEnumerable<StokHareketleriRaporDto> lstStokHareket = null;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                lstStokHareket = _uow.GenericRepository<StokHareketleriRaporDto>().SqlQuery("SELECT * FROM vw_stokHareketleri", true);
            }, MethodBase.GetCurrentMethod().Name);

            return lstStokHareket;
        }
    }
}
