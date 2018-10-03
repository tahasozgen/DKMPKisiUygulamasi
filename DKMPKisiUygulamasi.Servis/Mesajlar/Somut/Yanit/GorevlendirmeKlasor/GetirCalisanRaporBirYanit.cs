using DKMPKisiUygulamasi.Model.Somut.RaporKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.GorevlendirmeKlasor
{
    public class GetirCalisanRaporBirYanit : SorguYanitBaz<CalisanRaporBir>
    {
        public GetirCalisanRaporBirYanit(bool basariliMi) : base(basariliMi)
        {

        }

        public GetirCalisanRaporBirYanit(bool basariliMi, string mesaj) : base(basariliMi, mesaj)
        {
        }

        public GetirCalisanRaporBirYanit(IEnumerable<CalisanRaporBir> liste) : base(liste)
        {
        }

        public GetirCalisanRaporBirYanit(Exception hata) : base(hata)
        {
        }

        public GetirCalisanRaporBirYanit(DKMPHataAltyapi.ServisHata hata) : base(hata)
        {

        }

    }
}
