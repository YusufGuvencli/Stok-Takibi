using StokTakibi.DAL.Operations.Stok;
using StokTakibi.Entities.Stok_Hareketleri;
using StokTakibi.Helper.Enums;
using StokTakibi.Helper.TryCatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StokTakibi.BLL.Business_Operations
{
    public class StokHareketleriBLL
    {
        StokHareketDal stokHareketDal;
        public StokHareketleriBLL()
        {
            stokHareketDal = new StokHareketDal();
        }
        /// <summary>
        /// IEnumerable olarak stok hareket listesini döner.
        /// Hata alması durumunda null değer döner.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StokHareketleriDto> StokHareketleriniGetir()
        {
            IEnumerable<StokHareketleriDto> lstStokHareketleri = null;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                lstStokHareketleri = stokHareketDal.StokHareketleriniGetir();
            }, MethodBase.GetCurrentMethod().Name);
            return lstStokHareketleri;
        }
        /// <summary>
        /// StokHareketleriDto tipinde entity alır ve StokHareketDal nesnesine göndererek kayıt yapar.
        /// İşlem durumuna göre enum döner.
        /// </summary>
        /// <param name="stokHareketleri"></param>
        /// <returns></returns>
        public CudEnums StokHareketiEkle(StokHareketleriDto stokHareketleri)
        {
            CudEnums enums = CudEnums.EksikParametreHatasi;
            if (!string.IsNullOrEmpty(stokHareketleri.FisNumarasi)
                && !string.IsNullOrEmpty(stokHareketleri.GirisCikisMiktari.ToString())
                && !string.IsNullOrEmpty(stokHareketleri.GirisCikisDurum.ToString())
                && stokHareketleri.KayitTarihi != DateTime.MinValue
                && !string.IsNullOrEmpty(stokHareketleri.KullaniciId.ToString()))
            {
                int result = stokHareketDal.StokHareketiEkle(stokHareketleri);
                if (result > 0)
                {
                    enums = CudEnums.IslemBasarili;
                }
                else
                {
                    enums = CudEnums.VeritabaniHatasi;
                }
            }

            return enums;

        }

        /// <summary>
        /// StokHareketleriDto tipinde entity alır ve StokHareketDal nesnesine göndererek güncelleme yapar.
        /// İşlem durumuna göre enum döner.
        /// </summary>
        /// <param name="stokHareketleri"></param>
        /// <returns></returns>
        public CudEnums StokHareketiGuncelle(StokHareketleriDto stokHareketleri)
        {
            CudEnums enums = CudEnums.EksikParametreHatasi;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                if (!string.IsNullOrEmpty(stokHareketleri.FisNumarasi)
                    && !string.IsNullOrEmpty(stokHareketleri.GirisCikisMiktari.ToString())
                    && !string.IsNullOrEmpty(stokHareketleri.GirisCikisDurum.ToString())
                    && stokHareketleri.KayitTarihi != DateTime.MinValue
                    && !string.IsNullOrEmpty(stokHareketleri.KullaniciId.ToString()))
                {
                    int result = stokHareketDal.StokHareketiGuncelle(stokHareketleri);
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
        /// StokHareketleriDto tipinde entity alır ve StokHareketDal nesnesine göndererek datayı deaktif eder.
        /// İşlem durumuna göre enum döner.
        /// </summary>
        /// <param name="stokHareketleri"></param>
        /// <returns></returns>
        public CudEnums StokHareketiSil(StokHareketleriDto stokHareketleri)
        {
            CudEnums enums = CudEnums.VeritabaniHatasi;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                stokHareketleri.AktifMi = false;
                int result = stokHareketDal.StokHareketiSil(stokHareketleri);
                if (result > 0)
                {
                    enums = CudEnums.IslemBasarili;
                }
            }, MethodBase.GetCurrentMethod().Name);

            return enums;
        }
    }
}
