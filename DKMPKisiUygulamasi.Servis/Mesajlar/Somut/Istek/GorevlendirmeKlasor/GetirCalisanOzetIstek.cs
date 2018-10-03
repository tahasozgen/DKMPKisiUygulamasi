using DKMPKisiUygulamasi.Model.SabitlerMesajlar;
using DKMPKisiUygulamasi.Servis.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.GorevlendirmeKlasor
{
    public class GetirCalisanOzetIstek : IstekBaz
    {

        public DateTime Tarihi { get; set; }

        public string SorguSozcesi { get; set; }

        protected GetirCalisanOzetIstek():base()
        {
            this.Tarihi = Sabitler.BosTarih;
            this.SorguSozcesi = null;
        }

        private GetirCalisanOzetIstek(int kullaniciId):this()
        {
            this.KullaniciId = kullaniciId;
        }

        public GetirCalisanOzetIstek(int kullaniciId,DateTime tarih):this(kullaniciId)
        {
            this.Tarihi = tarih;
        }

        public GetirCalisanOzetIstek(int kullaniciId, string sorgu) : this(kullaniciId)
        {
            this.SorguSozcesi = sorgu;
        }


        internal bool girildiMiTarih
        {
            get
            {
                return this.Tarihi != Sabitler.BosTarih;
            }
        }

        internal bool girildiMiSorguSozcesi
        {
            get
            {
                return !String.IsNullOrEmpty(this.SorguSozcesi);
            }
        }

        internal bool girildiMiSorgu
        {
            get
            {
                return girildiMiTarih || girildiMiSorguSozcesi;
            }
        }

    }
}
