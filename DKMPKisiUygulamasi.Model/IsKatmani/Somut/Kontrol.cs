using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;
using DKMPKisiUygulamasi.Model.Somut.IletisimKlasor;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using DKMPKisiUygulamasi.Model.Somut.OgrenimKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.IsKatmani.Somut
{
    class Kontrol
    {
        //KisiIletisim deger deger
        internal bool uygunMu(KisiIletisim deger)
        {
            return !(deger == null || (deger.KisiId == null && deger.Kisisi == null) || String.IsNullOrEmpty(deger.Deger) || deger.Turu == EnumKlasoru.IletisimTuru.Tanimsiz);
        }

        internal bool uygunMu(KisiOgrenim deger)
        {
            return !(deger == null);
        }

        internal bool uygunMu(Calisan deger)
        {
            return !(deger == null);
        }
    
        internal bool uygunMu(CalisanGorevlendirme deger)
        {
            return !(deger == null);
        }
    }
}
