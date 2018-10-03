using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.CalisanKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.GorevlendirmeKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.CalisanKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.GorevlendirmeKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Soyut
{
    public interface ICalisanServis
    {
        SorgulaCalisanYanit SorgulaCalisan(SorgulaCalisanIstek yanit);

        IlklendirCalisanEkleYanit IlklendirCalisanEkle(IlklendirCalisanEkleIstek istek);

        EkleCalisanYanit EkleCalisan(EkleCalisanIstek istek);
        
        GetirCalisanRaporBirYanit GetirCalisanRaporBir(GetirCalisanRaporBirIstek istek);
        
    }
}
