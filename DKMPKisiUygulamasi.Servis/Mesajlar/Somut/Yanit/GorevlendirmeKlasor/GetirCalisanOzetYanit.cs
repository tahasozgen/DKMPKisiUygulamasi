
using DKMPKisiUygulamasi.Model.Somut.RaporKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.GorevlendirmeKlasor
{
    public class GetirCalisanOzetYanit : SorguYanitBaz<CalisanOzet>
    {
        public GetirCalisanOzetYanit(bool basariliMi) : base(basariliMi)
        {

        }

        public GetirCalisanOzetYanit(bool basariliMi, string mesaj) : base(basariliMi, mesaj)
        {
        }

        public GetirCalisanOzetYanit(IEnumerable<CalisanOzet> liste) : base(liste)
        {
        }

        public GetirCalisanOzetYanit(Exception hata) : base(hata)
        {
        }

        public GetirCalisanOzetYanit(DKMPHataAltyapi.ServisHata hata) : base(hata)
        {

        }
    }
}
