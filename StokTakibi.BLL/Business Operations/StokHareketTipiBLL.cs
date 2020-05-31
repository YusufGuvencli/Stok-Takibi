using StokTakibi.DAL.Operations.Stok;
using StokTakibi.Entities.Stok_Hareketleri;
using StokTakibi.Helper.TryCatch;
using System.Collections.Generic;
using System.Reflection;

namespace StokTakibi.BLL.Business_Operations
{
    public class StokHareketTipiBll
    {
        StokHareketTipiDal dalStokHareketTipi;

        public StokHareketTipiBll()
        {
            dalStokHareketTipi = new StokHareketTipiDal();
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
                lstStokHareketTipleri = dalStokHareketTipi.StokHareketTipleriniGetir();
            }, MethodBase.GetCurrentMethod().Name);

            return lstStokHareketTipleri;
        }
    }
}
