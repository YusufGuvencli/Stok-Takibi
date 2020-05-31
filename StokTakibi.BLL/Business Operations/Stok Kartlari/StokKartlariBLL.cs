using StokTakibi.DAL.Operations.Stok;
using StokTakibi.Entities.Stok_Karti;
using StokTakibi.Helper.Enums;
using StokTakibi.Helper.TryCatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StokTakibi.BLL.Business_Operations.Stok_Kartlari
{
    public class StokKartlariBll
    {
        StokKartlariDal stokKartlariDAL;
        public StokKartlariBll()
        {
            stokKartlariDAL = new StokKartlariDal();
        }
        /// <summary>
        /// IEnumerable tipinde liste döner.
        /// Aktif olmayan stoklar gösterilmez.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StokKartiDto> StokKartlariGetir()
        {
            IEnumerable<StokKartiDto> stokKartlari = null;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                stokKartlari = stokKartlariDAL.StokKartlariniGetir().ToList();
            }, MethodBase.GetCurrentMethod().Name);
            return stokKartlari;
        }


        /// <summary>
        /// StokKartlariDto tipinde entity alır ve StoKartlariDal nesnesine gönderir.
        /// Hata alması durumunda CudEnums döner.
        /// </summary>
        /// <param name="stokKarti"></param>
        /// <returns></returns>
        public CudEnums StokKartiEkle(StokKartiDto stokKarti)
        {
            CudEnums enums = CudEnums.EksikParametreHatasi;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                if (!string.IsNullOrEmpty(stokKarti.StokKodu)
                && !string.IsNullOrEmpty(stokKarti.StokAdi)
                && !string.IsNullOrEmpty(stokKarti.Kdv.ToString())
                && !string.IsNullOrEmpty(stokKarti.Fiyat.ToString())
                && !string.IsNullOrEmpty(stokKarti.DepoId.ToString()))
                {
                    int result = stokKartlariDAL.StokKartiEkle(stokKarti);
                    if (result > 0)
                    {
                        enums = CudEnums.IslemBasarili;
                    }
                    else
                    {
                        enums = CudEnums.VeritabaniHatasi;
                    }
                }
            }, MethodBase.GetCurrentMethod().Name);
            return enums;
        }
        /// <summary>
        /// StokKartlariDto tipinde entity alır ve StoKartlariDal nesnesine gönderir.
        /// Hata alması durumunda CudEnums döner.
        /// </summary>
        /// <param name="stokKarti"></param>
        /// <returns></returns>
        public CudEnums StokKartiDuzenle(StokKartiDto stokKarti)
        {
            CudEnums enums = CudEnums.EksikParametreHatasi;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                if (!string.IsNullOrEmpty(stokKarti.StokKodu)
                   && !string.IsNullOrEmpty(stokKarti.StokAdi)
                   && !string.IsNullOrEmpty(stokKarti.Kdv.ToString())
                   && !string.IsNullOrEmpty(stokKarti.Fiyat.ToString())
                   && !string.IsNullOrEmpty(stokKarti.DepoId.ToString()))
                {
                    stokKarti.AktifMi = false;
                    int result = stokKartlariDAL.StokKartiDuzenle(stokKarti);
                    if (result > 0)
                    {
                        enums = CudEnums.IslemBasarili;
                    }
                    else
                    {
                        enums = CudEnums.VeritabaniHatasi;
                    }
                }
            }, MethodBase.GetCurrentMethod().Name);
            return enums;
        }
        /// <summary>
        /// StokKartlariDto tipinde entity alır ve StoKartlariDal nesnesine gönderir.
        /// Hata alması durumunda CudEnums döner.
        /// </summary>
        /// <param name="stokKarti"></param>
        /// <returns></returns>
        public CudEnums StokKartiSil(StokKartiDto stokKarti)
        {
            CudEnums enums = CudEnums.EksikParametreHatasi;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                stokKarti.AktifMi = false;
                int result = stokKartlariDAL.StokKartiSil(stokKarti);
                if (result > 0)
                {
                    enums = CudEnums.IslemBasarili;
                }
                else
                {
                    enums = CudEnums.VeritabaniHatasi;
                }
            }, MethodBase.GetCurrentMethod().Name);
            return enums;
        }

    }
}
