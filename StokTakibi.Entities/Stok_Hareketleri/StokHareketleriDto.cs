using StokTakibi.Entities.Depo;
using StokTakibi.Entities.Kullanici;
using StokTakibi.Entities.Stok_Karti;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StokTakibi.Entities.Stok_Hareketleri
{
    [Table("Stok_Hareketleri")]
    public class StokHareketleriDto
    {
        [Key]
        public int HareketId { get; set; }
        [Required, MaxLength(15)]
        public string FisNumarasi { get; set; }
        [Required]
        public int GirisCikisMiktari { get; set; }
        [Required]
        public int GirisCikisDurum { get; set; }
        [Required]
        public DateTime KayitTarihi { get; set; }
        [Required]
        public int KullaniciId { get; set; }
        public KullaniciDto Kullanici { get; set; }
        public DepoDto Depo { get; set; }
        public bool AktifMi { get; set; }
        public List<StokKartiDto> StokKartiDto { get; set; }
    }
}
