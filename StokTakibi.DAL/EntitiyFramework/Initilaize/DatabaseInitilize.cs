using StokTakibi.DAL.EntitiyFramework.UnitOfWork;
using StokTakibi.DAL.Operations.Depo;
using StokTakibi.DAL.Operations.Kullanici;
using StokTakibi.DAL.Operations.Stok;
using StokTakibi.Entities.Depo;
using StokTakibi.Entities.Kullanici;
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
    @FisNumarasi NVARCHAR(15),
    @GirisCikisMiktari INT,
    @GirisCikisDurum INT,
    @KayitTarihi DATETIME,
    @KullaniciId INT,
    @DepoId INT,
    @AktifMi BIT
AS
BEGIN
    BEGIN TRANSACTION [insert_tran];
    BEGIN TRY

        INSERT INTO dbo.Stok_Hareketleri
        (
            FisNumarasi,
            GirisCikisMiktari,
            GirisCikisDurum,
            KayitTarihi,
            KullaniciId,
            Depo_DepoId,
            AktifMi
        )
        VALUES
        (   @FisNumarasi,       -- FisNumarasi - nvarchar(15)	       
            @GirisCikisMiktari, -- GirisCikisMiktari - int
            @GirisCikisDurum,   -- GirisCikisDurum - int
            @KayitTarihi,       -- KayitTarihi - datetime
            @KullaniciId,       -- KullaniciId - int
            @DepoId,            -- AktifMi - bit
            @AktifMi            -- Depo_DepoId - int
            );

        COMMIT TRANSACTION [insert_tran];
        RETURN 1;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION [insert_tran];
        RETURN -1;
    END CATCH;
    END;";
            _uow.GenericRepository<StokHareketleriDto>().SqlQuery(insertStokHareketleriProcedure);
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
   @Aktif BIT
AS
BEGIN
    BEGIN TRANSACTION [insert_tran];
    BEGIN TRY

       INSERT INTO	 dbo.Stok_Kartlari
       (
           stokKodu,
           StokAdi,
           Kdv,
           Fiyat,
           Aciklama,
           Resim,
           DepoId,
           AktifMi          
       )
       VALUES
       (   @StokKodu,  -- stokKodu - nvarchar(15)
           @StokAdi,  -- StokAdi - nvarchar(50)
           @Kdv,    -- Kdv - int
           @Fiyat, -- Fiyat - decimal(18, 2)
           @Aciklama,  -- Aciklama - nvarchar(max)
           @Resim,    -- Resim - tinyint
           @DepoId,    -- DepoId - int
           @Aktif -- AktifMi - bit           
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
        INSERT INTO Stok_Hareket_Tipi(stokHareketTipi,AktifMi)
		VALUES (@StokHareketTipi,@AktifMi);        
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
            string[] hareketler = new string[] { "Giriş", "Çıkış"};
            for (int i = 0; i < hareketler.Length; i++)
            {
                stokHareketTipi = new StokHareketTipiDto();
                stokHareketTipi.StokHareketTipi = hareketler[i];
                stokHareketTipi.AktifMi = true;

                stokHareketDal = new StokHareketTipiDal();
                stokHareketDal.StokHareketTipiEkle(stokHareketTipi);
            }
            #endregion

            #region Depo Olustur 

            DepoDto depoDto = new DepoDto()
            {
                DepoAdi="Test Deposu",
                DepoKodu="00001",
                AktifMi=true
            };

            DepoDal depoDal = new DepoDal();
            depoDal.DepoEkle(depoDto);

            #endregion

        }

    }
}
