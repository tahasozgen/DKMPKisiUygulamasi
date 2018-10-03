using DKMPKisiUygulamasi.Presentation.Mesajlar.Somut.Istek;
using DKMPKisiUygulamasi.Presentation.Mesajlar.Somut.Yanit;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.GorevlendirmeKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.GorevlendirmeKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.Soyut
{
    public interface IGorevlendirmePresentation
    {
        IlklendirCalisanGorevlendirmeYanitViewModel IlklendirCalisanGorevlendirme(IlklendirCalisanGorevlendirmeIstekViewModel istek);

        GorevlendirCalisanYanit GorevlendirCalisan(GorevlendirCalisanIstek istek);

        SorgulaGorevlendirCalisanYanitViewModel SorgulaCalisanGorevlendirme(SorgulaGorevlendirCalisanIstekViewModel istek);

        GetirCalisanOzetYanitViewModel GetirCalisanOzet(GetirCalisanOzetIstekViewModel istek);
    }
}
