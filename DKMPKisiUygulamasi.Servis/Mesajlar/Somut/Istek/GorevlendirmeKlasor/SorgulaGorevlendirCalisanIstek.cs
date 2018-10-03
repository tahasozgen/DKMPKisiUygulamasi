using DKMPKisiUygulamasi.Model.SabitlerMesajlar;
using DKMPKisiUygulamasi.Servis.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.GorevlendirmeKlasor
{
    public class SorgulaGorevlendirCalisanIstek: IstekBaz
    {
        public DateTime? Tarihi { get; set; }

        protected SorgulaGorevlendirCalisanIstek():base()
        {
            this.Tarihi = null;
        }

        public SorgulaGorevlendirCalisanIstek(int kullaniciId):base(kullaniciId)
        {
            this.Tarihi = null;
        }

        public SorgulaGorevlendirCalisanIstek(int kullaniciId,DateTime tarihi) : base(kullaniciId)
        {
            this.Tarihi = tarihi;
        }

        internal bool girildiMiTarih
        {
            get
            {
                return !(this.Tarihi == null || this.Tarihi == Sabitler.BosTarih);
            }
        }

    }
}
