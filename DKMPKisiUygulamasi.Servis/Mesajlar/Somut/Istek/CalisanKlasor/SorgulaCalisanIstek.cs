using DKMPKisiUygulamasi.Servis.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.CalisanKlasor
{
    public class SorgulaCalisanIstek: IstekBaz
    {
        public string SorguSozcesi { get; set; }

        public SorgulaCalisanIstek() : base()
        {
            this.SorguSozcesi = string.Empty;
        }

        public SorgulaCalisanIstek(int kullaniciId, string sorguSozcesi) : this()
        {
            this.KullaniciId = kullaniciId;
            this.SorguSozcesi = sorguSozcesi;
        }


    }
}
