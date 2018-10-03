using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.CalisanKlasor
{
    public class SorgulaCalisanYanit: SorguYanitBaz<Calisan>
    {
        public SorgulaCalisanYanit(bool basariliMi) : base(basariliMi)
        {

        }

        public SorgulaCalisanYanit(bool basariliMi, string mesaj) : base(basariliMi, mesaj)
        {
        }

        public SorgulaCalisanYanit(IEnumerable<Calisan> liste) : base(liste)
        {
        }

        public SorgulaCalisanYanit(Exception hata) : base(hata)
        {
        }

        public SorgulaCalisanYanit(DKMPHataAltyapi.ServisHata hata) : base(hata)
        {
 
        }
    }
}
