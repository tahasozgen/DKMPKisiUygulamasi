using DKMPKisiUygulamasi.Servis.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.OgrenimKlasor
{

    public class EkleKisiOgrenimIstek : IstekBaz
    {
        public int? CalisanId { get; set; }

        public int? OgrenimDurumuId { get; set; }

        public int? UniversiteId { get; set; }

        private EkleKisiOgrenimIstek():base()
        {
            this.CalisanId = null;
            this.OgrenimDurumuId = null;
            this.UniversiteId = null;
        }

        public EkleKisiOgrenimIstek(int kullaniciId, int calisanId, int ogrenimDurumuId) : this()
        {
            this.KullaniciId = kullaniciId;
            this.CalisanId = calisanId;
            this.OgrenimDurumuId = ogrenimDurumuId;            
        }

        public EkleKisiOgrenimIstek(int kullaniciId, int calisanId, int ogrenimDurumuId,int universiteId) : this(kullaniciId,calisanId, ogrenimDurumuId)
        {
            this.UniversiteId = universiteId;
        }
    }
}
