using StokTakibi.DAL.EntitiyFramework.Initilaize;
using StokTakibi.Entities.Depo;
using StokTakibi.Entities.Kullanici;
using StokTakibi.Entities.Stok_Hareketleri;
using StokTakibi.Entities.Stok_Karti;
using System.Data.Entity;

namespace StokTakibi.DAL.EntitiyFramework
{
    public class StokContext : DbContext
    {
        public StokContext() : base(System.Configuration.ConfigurationManager.ConnectionStrings["StokAppConnectionString"].ConnectionString.ToString())
        {
            if (!Database.Exists())
            {
                Database.Create();
                DatabaseInitilize kullaniciInitilaizer = new DatabaseInitilize();
            }
        }

        public DbSet<KullaniciDto> kullanici { get; set; }
        public DbSet<DepoDto> depo { get; set; }
        public DbSet<StokKartiDto> stokKarti { get; set; }
        public DbSet<StokHareketleriDto> stokHareketleri { get; set; }
        public DbSet<StokHareketTipiDto> stokHareketTipi { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
    
        }
    }
}
