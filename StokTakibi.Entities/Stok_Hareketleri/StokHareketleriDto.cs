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
        public string FisNo { get; set; }
        [Required]
        public int Miktar { get; set; }
        [Required]
        public int HareketDurumId { get; set; }
        [Required]
        public int StokKartId { get; set; }
        [Required]
        public DateTime KayitTarihi { get; set; }
        [Required]
        public int KullaniciId { get; set; }
        [Required]
        public bool AktifMi { get; set; }
        public KullaniciDto kullanici { get; set; }     
   
        public StokHareketTipiDto stokHareketTipi { get; set; }
       
    }
}
