using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakibi.Entities.Stok_Hareketleri
{
    [Table("Stok_Hareket_Tipi")]
   public class StokHareketTipiDto
    {
        [Key]
        public int HareketDurumId { get; set; }
        [Required,MaxLength(10)]
        public string HareketTipi { get; set; }
        [Required]
        public bool AktifMi { get; set; }
        public List<StokHareketleriDto> stokHareketleriDtos { get; set; }
    }
}
