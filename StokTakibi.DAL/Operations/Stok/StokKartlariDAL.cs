﻿using StokTakibi.DAL.EntitiyFramework;
using StokTakibi.DAL.EntitiyFramework.UnitOfWork;
using StokTakibi.Entities.Stok_Karti;
using StokTakibi.Helper.TryCatch;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace StokTakibi.DAL.Operations.Stok
{

    public class StokKartlariDal
    {
        UnitOfWorkBase _uow;
        StokContext context;
        public StokKartlariDal()
        {
            context = new StokContext();
            _uow = new UnitOfWorkBase(context);
        }
        public IEnumerable<StokKartiDto> StokKartlariniGetir()
        {
          
            IEnumerable<StokKartiDto> stokKartlari = null;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                stokKartlari = _uow.GenericRepository<StokKartiDto>().Where(x => x.AktifMi == true);
            }, MethodBase.GetCurrentMethod().Name);
            return stokKartlari;
        }
        public int StokKartiEkle(StokKartiDto stokKarti)
        {
            int result = -1;
            DynamicTryCatch.TryCatchLogla(() =>
            {

                result = _uow.GenericRepository<StokKartiDto>().InsertWithProcedure(
                    "exec Insert_StokKartlari @StokKodu, @StokAdi, @Kdv, @Fiyat, @Aciklama, @Resim, @DepoId, @Aktif",
                     new SqlParameter("@StokKodu", SqlDbType.NVarChar) { Value = stokKarti.StokKodu },
                     new SqlParameter("@StokAdi", SqlDbType.NVarChar) { Value = stokKarti.StokAdi },
                     new SqlParameter("@Kdv", SqlDbType.Int) { Value = stokKarti.Kdv },
                     new SqlParameter("@Fiyat", SqlDbType.Decimal) { Value = stokKarti.Fiyat },
                     new SqlParameter("@Aciklama", SqlDbType.NVarChar) { Value = stokKarti.Aciklama },
                     new SqlParameter("@Resim", SqlDbType.VarBinary) { Value = stokKarti.Resim },
                     new SqlParameter("@DepoId", SqlDbType.Int) { Value = stokKarti.DepoId },
                     new SqlParameter("@Aktif", SqlDbType.Bit) { Value = stokKarti.AktifMi });
                
            }, MethodBase.GetCurrentMethod().Name);
            return result;
        }

        public int StokKartiDuzenle(StokKartiDto stokKarti)
        {
            int result = -1;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                _uow.GenericRepository<StokKartiDto>().Update(stokKarti);
                result = _uow.Commit();               
            }, MethodBase.GetCurrentMethod().Name);

            return result;
        }

        public int StokKartiSil(StokKartiDto stokKarti)
        {
            int result = -1;
            DynamicTryCatch.TryCatchLogla(() =>
            {
                _uow.GenericRepository<StokKartiDto>().Update(stokKarti);
                result = _uow.Commit();
               
            }, MethodBase.GetCurrentMethod().Name);

            return result;
        }

    }
}