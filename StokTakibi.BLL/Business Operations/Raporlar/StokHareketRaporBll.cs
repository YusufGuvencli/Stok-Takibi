﻿using StokTakibi.DAL.Operations.Raporlar;
using StokTakibi.Entities.Raporlar;
using StokTakibi.Helper.TryCatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StokTakibi.BLL.Business_Operations.Raporlar
{
    public class StokHareketRaporBll
    {
        StokHareketRaporuDal dalStokHareketRaporu;
        public StokHareketRaporBll()
        {
            dalStokHareketRaporu = new StokHareketRaporuDal();
        }

        public IEnumerable<StokHareketleriRaporDto> StokHareketRaporuGetir()
        {
            IEnumerable<StokHareketleriRaporDto> lstStokHareketleri = null;

            DynamicTryCatch.TryCatchLogla(() =>
            {
                lstStokHareketleri = dalStokHareketRaporu.StokHareketRaporuGetir();
            }, MethodBase.GetCurrentMethod().Name);

            return lstStokHareketleri;
        }
    }
}
