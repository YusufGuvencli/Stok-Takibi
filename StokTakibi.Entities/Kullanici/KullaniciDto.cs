using StokTakibi.Entities.Stok_Hareketleri;
using StokTakibi.Entities.Stok_Karti;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StokTakibi.Entities.Kullanici
{
    [Table("Kullanicilar")]
    public class KullaniciDto
    {
        [Key]
        public int KullaniciId { get; set; }
        [Required, MaxLength(25)]
        public string KullaniciAdi { get; set; }
        [Required, MaxLength(20)]
        public string Isim { get; set; }
        [Required, MaxLength(20)]
        public string Soyisim { get; set; }
        [Required, MaxLength(35)]
        public string Sifre { get; set; }
        public bool AktifMi { get; set; }
        public List<StokHareketleriDto> stokHareketleri { get; set; }
        public List<StokKartiDto> stokKartlari { get; set; }
    }
}
