using StokTakibi.DAL.Operations.Stok;
using StokTakibi.Entities.SqlView;
using StokTakibi.Entities.Stok_Hareketleri;
using StokTakibi.Helper.Enums;
using StokTakibi.Helper.TryCatch;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace StokTakibi.BLL.Business_Operations
{
    public class StokHareketleriBll
    {
        StokHareketDal dalStokHareket;
        public StokHareketleriBll()
        {
            dalStokHareket = new StokHareketDal();
        }
        /// <summary>
        /// IEnumerable olarak stok hareket listesini döner.
        /// Hata alması durumunda null değer döner.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StokHareketView> StokHareketleriniGetir()
        {
            IEnumerable<StokHareketView> lstStokHareketleri = null;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                lstStokHareketleri = dalStokHareket.StokHareketleriniGetir();
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
            if (!string.IsNullOrEmpty(stokHareketleri.FisNo)
                && stokHareketleri.Miktar != -1
                && stokHareketleri.HareketDurumId != -1
                && stokHareketleri.KayitTarihi != DateTime.MinValue
                && stokHareketleri.StokKartId != -1
                && stokHareketleri.KullaniciId != 0)
            {
                int result = dalStokHareket.StokHareketiEkle(stokHareketleri);
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
                if (!string.IsNullOrEmpty(stokHareketleri.FisNo)
                    && stokHareketleri.Miktar != -1
                    && stokHareketleri.HareketDurumId != -1
                    && stokHareketleri.KayitTarihi != DateTime.MinValue
                    && stokHareketleri.StokKartId != -1
                    && stokHareketleri.KullaniciId != 0)
                {
                    int result = dalStokHareket.StokHareketiGuncelle(stokHareketleri);
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
                int result = dalStokHareket.StokHareketiSil(stokHareketleri);
                if (result > 0)
                {
                    enums = CudEnums.IslemBasarili;
                }
            }, MethodBase.GetCurrentMethod().Name);

            return enums;
        }

        /// <summary>
        /// Int tipinde Id alır ve StokHareketleriDto tipinde dönüş yapar..
        /// Hata alması durumunda null döner.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public StokHareketleriDto StokHareketiBul(int Id)
        {
            StokHareketleriDto stokHareketleriDto = null;
            DynamicTryCatch.TryCatchLogla(() => 
            {
                stokHareketleriDto = dalStokHareket.StokHareketiBul(Id);
            }, MethodBase.GetCurrentMethod().Name);

            return stokHareketleriDto;
        }
    }
}
