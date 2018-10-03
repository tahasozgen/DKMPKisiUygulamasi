using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;
using DKMPKisiUygulamasi.Servis.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.GorevlendirmeKlasor
{
    public class SorgulaGorevlendirCalisanYanit:SorguYanitBaz<CalisanGorevlendirme>
    {
        public SorgulaGorevlendirCalisanYanit(bool basariliMi) : base(basariliMi)
        {

        }

        public SorgulaGorevlendirCalisanYanit(bool basariliMi, string mesaj) : base(basariliMi, mesaj)
        {
        }

        public SorgulaGorevlendirCalisanYanit(IEnumerable<CalisanGorevlendirme> liste) : base(liste)
        {
        }

        public SorgulaGorevlendirCalisanYanit(Exception hata) : base(hata)
        {
        }

        public SorgulaGorevlendirCalisanYanit(DKMPHataAltyapi.ServisHata hata) : base(hata)
        {

        }
    }
}
