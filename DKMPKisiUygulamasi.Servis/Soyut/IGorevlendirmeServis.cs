using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.GorevlendirmeKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.GorevlendirmeKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Soyut
{
    public interface IGorevlendirmeServis
    {
        IlklendirCalisanGorevlendirmeYanit IlklendirCalisanGorevlendirme(IlklendirCalisanGorevlendirmeIstek istek);

        GorevlendirCalisanYanit GorevlendirCalisan(GorevlendirCalisanIstek istek);

        SorgulaGorevlendirCalisanYanit SorgulaCalisanGorevlendirme(SorgulaGorevlendirCalisanIstek istek);
        
        GetirCalisanOzetYanit GetirCalisanOzet(GetirCalisanOzetIstek istek);


    }
}
