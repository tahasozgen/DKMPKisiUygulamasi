using DKMPKisiUygulamasi.Servis.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.Mesajlar.Somut.Istek
{
    public class SorgulaGorevlendirCalisanIstekViewModel:IstekBaz
    {
        public DateTime? Tarihi { get; set; }

        protected SorgulaGorevlendirCalisanIstekViewModel():base()
        {
            this.Tarihi = null;
        }

        public SorgulaGorevlendirCalisanIstekViewModel(int kullaniciId):base(kullaniciId)
        {
            this.Tarihi = null;
        }

        public SorgulaGorevlendirCalisanIstekViewModel(int kullaniciId, DateTime tarihi) : base(kullaniciId)
        {
            this.Tarihi = tarihi;
        }

     
    }
}
