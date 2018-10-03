using DKMPKisiUygulamasi.Servis.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.KisiIletisimKlasoru
{
    public class EkleKisiIletisimIstek : IstekBaz
    {
        public int? KisiId { get; set; }
        
        public string Deger { get; set; }
        
        public int? TurId { get; set; }

        private EkleKisiIletisimIstek():base()
        {
            this.KisiId = null;
            this.Deger = null;
            this.TurId = null;
        }

        public EkleKisiIletisimIstek(int kullaniciId, int kisiId, string deger, int turId) : this()
        {
            this.KullaniciId = kullaniciId;
            this.KisiId = kisiId;
            this.Deger = deger;
            this.TurId = turId;
        }



    }
}
