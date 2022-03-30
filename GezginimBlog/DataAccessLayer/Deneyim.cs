using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Deneyim
    {
        public int ID { get; set; }
        public int Sehir_ID { get; set; }
        public string Sehir { get; set; }
        public int Yazar_ID { get; set; }
        public string Yazar { get; set; }
        public string Baslik { get; set; }
        public string Onyazi { get; set; }
        public string Icerik { get; set; }
        public string GeziResim { get; set; }
        public int GoruntulemeSayisi { get; set; }
        public DateTime EklemeTarih { get; set; }
        public bool Durum { get; set; }


    }
}
