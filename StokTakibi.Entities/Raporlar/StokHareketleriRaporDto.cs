using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakibi.Entities.Raporlar
{
    public class StokHareketleriRaporDto
    {
        public string FisNo { get; set; }
        public int Miktar { get; set; }
        public DateTime HareketTarihi { get; set; }
        public string HareketTipi { get; set; }
        public string StokKodu { get; set; }
        public string StokAdi { get; set; }
        public string Aciklama { get; set; }
        public DateTime SokKayitTarihi { get; set; }
    }
}
