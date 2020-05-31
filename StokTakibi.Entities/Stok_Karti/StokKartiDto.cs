using StokTakibi.Entities.Depo;
using StokTakibi.Entities.Kullanici;
using StokTakibi.Entities.Stok_Hareketleri;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StokTakibi.Entities.Stok_Karti
{
    [Table("Stok_Kartlari")]
    public class StokKartiDto
    {
        [Key]
        public int StokKartId { get; set; }
        [Required, MaxLength(15)]
        public string StokKodu { get; set; }
        [Required, MaxLength(50)]
        public string StokAdi { get; set; }
        [Required]
        public int Kdv { get; set; }
        [Required]
        public decimal Fiyat { get; set; }
        public string Aciklama { get; set; }
        public byte[] Resim { get; set; }
        public int DepoId { get; set; }
        public DateTime KayitTarihi { get; set; }
        public int KullaniciId { get; set; }
        public bool AktifMi { get; set; }
        public KullaniciDto kullanici { get; set; }
        public DepoDto depo { get; set; }

    }
}
