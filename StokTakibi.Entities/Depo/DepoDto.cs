using StokTakibi.Entities.Kullanici;
using StokTakibi.Entities.Stok_Hareketleri;
using StokTakibi.Entities.Stok_Karti;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakibi.Entities.Depo
{
    [Table("Depolar")]
    public class DepoDto
    {
        [Key]
        public int DepoId { get; set; }
        [Required, MaxLength(15)]
        public string DepoKodu { get; set; }
        [Required,MaxLength(25)]
        public string DepoAdi { get; set; }
        public bool AktifMi { get; set; }
        public List<StokKartiDto> stokKartiDto { get; set; }
    }
}
