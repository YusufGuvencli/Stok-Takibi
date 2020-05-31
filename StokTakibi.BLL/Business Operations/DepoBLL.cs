using StokTakibi.DAL.Operations.Depo;
using StokTakibi.Entities.Depo;
using StokTakibi.Helper.Enums;
using StokTakibi.Helper.TryCatch;
using System.Collections.Generic;
using System.Reflection;

namespace StokTakibi.BLL.Business_Operations
{

    public class DepoBll
    {
        private readonly DepoDal depoDAL;
        public DepoBll()
        {
            depoDAL = new DepoDal();
        }
        /// <summary>
        /// Depo tipinde entity alır ve DepoDAL nesnesine gönderir.
        /// Hata alması durumunda CudEnums döner.
        /// </summary>
        /// <param name="depo"></param>
        /// <returns></returns>
        public CudEnums DepoEkle(DepoDto depo)
        {
            CudEnums enums = CudEnums.EksikParametreHatasi;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                if (!string.IsNullOrEmpty(depo.DepoAdi) && !string.IsNullOrEmpty(depo.DepoKodu))
                {
                    int result = depoDAL.DepoEkle(depo);
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
        /// Veritabanındaki aktif tüm depoları IEnumarable tipinde döner.
        /// Hata alması durumunda null değer döner.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DepoDto> DepolariGetir()
        {
            IEnumerable<DepoDto> depolar = null;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                depolar = depoDAL.DepolariGetir();
            }, MethodBase.GetCurrentMethod().Name);

            return depolar;
        }

        public CudEnums DepoSil(DepoDto depo)
        {
            CudEnums enums = CudEnums.VeritabaniHatasi;            
            DynamicTryCatch.TryCatchLogla(()=> 
            {
                depo.AktifMi = false;
                int result = depoDAL.DepoDuzenle(depo);
                if (result > 0)
                {
                    enums = CudEnums.IslemBasarili;
                }               
            },MethodBase.GetCurrentMethod().Name);
            return enums;
        }

        public CudEnums DepoDuzenle(DepoDto depoDto)
        {
            CudEnums enums = CudEnums.EksikParametreHatasi;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                if (!string.IsNullOrEmpty(depoDto.DepoAdi) && !string.IsNullOrEmpty(depoDto.DepoKodu))
                {
                   int result= depoDAL.DepoDuzenle(depoDto);
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
    }

}
