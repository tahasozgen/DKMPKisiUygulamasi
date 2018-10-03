using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;
using DKMPKisiUygulamasi.Model.Somut.IletisimKlasor;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Repository.Somut.KontrolKlasoru
{
    class Kontrol
    {
        //KisiIletisim deger

        internal bool uygunMu(KisiIletisim deger)
        {
            return !(deger == null || String.IsNullOrEmpty(deger.Deger));
        }

        internal bool uygunMu(CalisanGorevlendirme deger)
        {
            return true;
        }

        internal bool uygunMu(Calisan deger)
        {
            return true;
        }
    }
}
