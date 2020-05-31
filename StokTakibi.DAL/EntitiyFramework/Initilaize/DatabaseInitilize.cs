using StokTakibi.DAL.EntitiyFramework.UnitOfWork;
using StokTakibi.DAL.Operations.Depo;
using StokTakibi.DAL.Operations.Kullanici;
using StokTakibi.DAL.Operations.Stok;
using StokTakibi.Entities.Depo;
using StokTakibi.Entities.Kullanici;
using StokTakibi.Entities.Raporlar;
using StokTakibi.Entities.Stok_Hareketleri;
using StokTakibi.Entities.Stok_Karti;

namespace StokTakibi.DAL.EntitiyFramework.Initilaize
{
    public class DatabaseInitilize
    {
        UnitOfWorkBase _uow;
        StokContext context;


        public DatabaseInitilize()
        {
            context = new StokContext();
            _uow = new UnitOfWorkBase(context);

            // Procedure Initilize
            #region Kullanici Procedure 
            string insertKullaniciProducedure = @"CREATE PROCEDURE [dbo].[Insert_Kullanici]
    @KullaniciAdi NVARCHAR(25),
    @Isim NVARCHAR(20),
    @Soyisim NVARCHAR(20),
    @Sifre NVARCHAR(35),
    @AktifMi BIT
AS
BEGIN
    BEGIN TRANSACTION [insert_tran];
    BEGIN TRY
        INSERT INTO dbo.Kullanicilar
        (
            KullaniciAdi,
            Isim,
            Soyisim,
            Sifre,
            AktifMi
        )
        VALUES
        (@KullaniciAdi, @Isim, @Soyisim, @Sifre, @AktifMi);
        COMMIT TRANSACTION [insert_tran];
        RETURN 1;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION [insert_tran];
        RETURN -1;
    END CATCH;
END;";

            _uow.GenericRepository<KullaniciDto>().SqlQuery(insertKullaniciProducedure);
            #endregion

            #region Depo Procedure 
            string InsertDepoProcedure = @"CREATE PROCEDURE [dbo].[Insert_Depo]
   @DepoKodu NVARCHAR(15),
   @DepoAdi NVARCHAR(25),
   @AktifMi BIT
    AS
    BEGIN
    BEGIN TRANSACTION [insert_tran];
    BEGIN TRY
        INSERT INTO	dbo.Depolar
        (
            DepoKodu,
            DepoAdi,
            AktifMi
        )
        VALUES
        (   @DepoKodu, -- DepoKodu - nvarchar(15)
            @DepoAdi, -- DepoAdi - nvarchar(max)
            @AktifMi -- AktifMi - bit
            );
        
        COMMIT TRANSACTION [insert_tran];
        RETURN 1;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION [insert_tran];
        RETURN -1;
    END CATCH;
END;";
            _uow.GenericRepository<DepoDto>().SqlQuery(InsertDepoProcedure);
            #endregion

            #region Stok Hareketleri Procedure 
            string insertStokHareketleriProcedure = @"CREATE PROCEDURE [dbo].[Insert_StokHareketleri]
    @Fisno NVARCHAR(15),
    @Miktar INT,
    @HareketDurumId INT,
    @StokKartId INT,
    @KayitTarihi DATETIME,
    @KullaniciId INT,
    @AktifMi BIT
AS
BEGIN
    BEGIN TRANSACTION [insert_tran];
    BEGIN TRY


			INSERT INTO dbo.Stok_Hareketleri
			(
			    FisNo,
			    Miktar,
			    HareketDurumId,
			    StokKartId,
			    KayitTarihi,
			    KullaniciId,
			    AktifMi
			)
			VALUES
			(   @Fisno,
				@Miktar,
				@HareketDurumId,
				@StokKartId,
				@KayitTarihi,
				@KullaniciId,
				@AktifMi
			    )
        COMMIT TRANSACTION [insert_tran];
        RETURN 1;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION [insert_tran];
        RETURN -1;
    END CATCH;
    END;";
            _uow.GenericRepository<StokHareketleriDto>().SqlQuery(insertStokHareketleriProcedure);

            string queryForeignKey = @"ALTER TABLE Stok_Hareketleri
                ADD FOREIGN KEY(StokKartId) REFERENCES Stok_Kartlari(StokKartId); ";
            _uow.GenericRepository<StokHareketleriDto>().SqlQuery(queryForeignKey);
            #endregion

            #region Stok Kartları Procedure
            string insertStokKartlariProcedure = @"CREATE PROCEDURE [dbo].[Insert_StokKartlari]
   @StokKodu NVARCHAR(15),
   @StokAdi NVARCHAR(50),
   @Kdv INT,
   @Fiyat DECIMAL(18,2),
   @Aciklama NVARCHAR(MAX),
   @Resim VARBINARY(MAX),
   @DepoId INT,
   @KayitTarihi DATETIME,
   @KullaniciId INT,
   @Aktif BIT
AS
BEGIN
    BEGIN TRANSACTION [insert_tran];
    BEGIN TRY

       INSERT INTO	dbo.Stok_Kartlari
       (
           StokKodu,
           StokAdi,
           Kdv,
           Fiyat,
           Aciklama,
           Resim,
           DepoId,
           KayitTarihi,
           KullaniciId,
           AktifMi
       )
       VALUES
       (   @StokKodu,       -- StokKodu - nvarchar(15)
           @StokAdi,       -- StokAdi - nvarchar(50)
           @Kdv,         -- Kdv - int
           @Fiyat,      -- Fiyat - decimal(18, 2)
          @Aciklama,       -- Aciklama - nvarchar(max)
           @Resim,      -- Resim - varbinary(max)
           @DepoId,         -- DepoId - int
           @KayitTarihi, -- KayitTarihi - datetime
           @KullaniciId,         -- KullaniciId - int
           @Aktif       -- AktifMi - bit
           )

        COMMIT TRANSACTION [insert_tran];
        RETURN 1;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION [insert_tran];
        RETURN -1;
    END CATCH;
END;";
            _uow.GenericRepository<StokKartiDto>().SqlQuery(insertStokKartlariProcedure);
            #endregion

            #region Stok Hareket Tipi Procedure 
            string insertStokHareketTipiProcedure = @"CREATE PROCEDURE [dbo].[Insert_Stok_Hareket_Tipi]
   @StokHareketTipi NVARCHAR(10),
    @AktifMi Bit
    AS
    BEGIN
    BEGIN TRANSACTION [insert_tran];
    BEGIN TRY
       INSERT INTO dbo.Stok_Hareket_Tipi
       (
           HareketTipi,
           AktifMi
       )
       VALUES
       (   @StokHareketTipi, -- HareketTipi - nvarchar(10)
           @AktifMi -- AktifMi - bit
           )        
        COMMIT TRANSACTION [insert_tran];
        RETURN 1;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION [insert_tran];
        RETURN -1;
    END CATCH;
END;";
            _uow.GenericRepository<StokHareketTipiDto>().SqlQuery(insertStokHareketTipiProcedure);
            #endregion

            #region Kullanıcı Olustur
            PasswordHash passwordHash = new PasswordHash();

            KullaniciDto kullanici = new KullaniciDto()
            {
                Isim = "Yusuf",
                Soyisim = "Güvençli",
                KullaniciAdi = "YusufGuvencli",
                Sifre = passwordHash.Hash("123456"),
                AktifMi = true
            };

            KullaniciDal kullaniciDLL = new KullaniciDal();
            kullaniciDLL.KullaniciEkle(kullanici);
            #endregion

            #region Stok Hareket Tipi Olustur

            StokHareketTipiDto stokHareketTipi;
            StokHareketTipiDal stokHareketDal;
            string[] hareketler = new string[] { "Giriş", "Çıkış" };
            for (int i = 0; i < hareketler.Length; i++)
            {
                stokHareketTipi = new StokHareketTipiDto();
                stokHareketTipi.HareketTipi = hareketler[i];
                stokHareketTipi.AktifMi = true;

                stokHareketDal = new StokHareketTipiDal();
                stokHareketDal.StokHareketTipiEkle(stokHareketTipi);
            }
            #endregion

            #region Depo Olustur 

            DepoDto depoDto = new DepoDto()
            {
                DepoAdi = "Test Deposu",
                DepoKodu = "00001",
                AktifMi = true
            };

            DepoDal depoDal = new DepoDal();
            depoDal.DepoEkle(depoDto);

            #endregion

            #region Stok Hareketleri View 
            string stokHareketView = @"CREATE VIEW [dbo].[vw_StokHareketleri]
AS
SELECT        H.HareketId, H.FisNo, H.Miktar, tip.HareketDurumId, tip.HareketTipi, K.StokKartId, K.StokKodu, K.StokAdi, H.KayitTarihi
FROM            dbo.Stok_Hareketleri AS H INNER JOIN
                         dbo.Stok_Kartlari AS K ON K.StokKartId = H.StokKartId INNER JOIN
                         dbo.Stok_Hareket_Tipi AS tip ON tip.HareketDurumId = H.HareketDurumId
WHERE        (H.AktifMi = 1)";
            _uow.GenericRepository<StokHareketleriDto>().SqlQuery(stokHareketView);
            #endregion

            #region Stok Hareket Raporu View 
            string stokHareketRaporu = @"CREATE VIEW [dbo].[vw_StokHareketRaporu]
AS
SELECT        H.FisNo, H.Miktar, H.KayitTarihi AS HareketTarihi, tip.HareketTipi, K.StokKodu, K.StokAdi, K.Aciklama, K.KayitTarihi AS StokKayitTarihi
FROM            dbo.Stok_Hareketleri AS H INNER JOIN
                         dbo.Stok_Hareket_Tipi AS tip ON tip.HareketDurumId = H.HareketDurumId INNER JOIN
                         dbo.Stok_Kartlari AS K ON K.StokKartId = H.StokKartId";
            _uow.GenericRepository<StokHareketleriRaporDto>().SqlQuery(stokHareketRaporu);
            #endregion
        }


    }
}
