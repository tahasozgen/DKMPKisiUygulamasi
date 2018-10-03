using DKMPKisiUygulamasi.Servis.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.GorevlendirmeKlasor
{
    public class IlklendirCalisanGorevlendirmeIstek : IstekBaz
    {
        public int GorevlendirilecekCalisanId { get; set; }

        private IlklendirCalisanGorevlendirmeIstek():base()
        {
            this.GorevlendirilecekCalisanId = int.MinValue;
        }

        public IlklendirCalisanGorevlendirmeIstek(int kullaniciId, int gorevlendirilecekCalisanId) : base(kullaniciId)
        {
            this.GorevlendirilecekCalisanId = gorevlendirilecekCalisanId;
        }


    }
}
