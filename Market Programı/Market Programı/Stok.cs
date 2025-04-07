using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Programı
{
    class marketci
    {
        public int urunNo { get; set; }
        public string urunAdi { get; set; }
        public string urunTipi { get; set; }
        public string urunMarka { get; set; }
        public string urunOzellikleri { get; set; }
        public int urunMiktari { get; set; }
        public float urunFiyati { get; set; }
    }
    class satis
    {
        public int urunNo { get; set; }
        public string urunAdi { get; set;}
        public DateTime tarih { get; set; }
        public int miktari { get; set; }
        public float fiyati { get; set; }
    }
}