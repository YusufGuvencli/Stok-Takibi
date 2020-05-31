using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakibi.Entities.SqlView
{
    public class StokHareketView
    {
        public int HareketId { get; set; }
        public string FisNo { get; set; }
        public int Miktar { get; set; }
        public int HareketDurumId { get; set; }
        public string HareketTipi { get; set; }
        public int StokKartId { get; set; }
        public string StokKodu { get; set; }
        public string StokAdi { get; set; }

        public DateTime KayitTarihi { get; set; }
    }
}
