using StokTakibi.DAL.Operations.Stok;
using StokTakibi.Entities.Stok_Hareketleri;
using StokTakibi.Helper.TryCatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StokTakibi.BLL.Business_Operations
{
    public class StokHareketTipiBLL
    {
        StokHareketTipiDal stokHareketTipi;

        public StokHareketTipiBLL()
        {
            stokHareketTipi = new StokHareketTipiDal();
        }
        /// <summary>
        /// IEnumerable tipinde stok hareket tiplerini döner.
        /// Hata alması durumunda null değer döndürür.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StokHareketTipiDto> StokHareketTipleriniGetir()
        {
            IEnumerable<StokHareketTipiDto> lstStokHareketTipleri = null;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                lstStokHareketTipleri = stokHareketTipi.StokHareketTipleriniGetir();
            }, MethodBase.GetCurrentMethod().Name);

            return lstStokHareketTipleri;
        }
    }
}
