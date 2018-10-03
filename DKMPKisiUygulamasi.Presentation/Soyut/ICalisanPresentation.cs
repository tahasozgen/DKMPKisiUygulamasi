using DKMPKisiUygulamasi.Presentation.Mesajlar.Somut.Istek;
using DKMPKisiUygulamasi.Presentation.Mesajlar.Somut.Yanit;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.IslemKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.CalisanKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.CalisanKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.Soyut
{
    public interface ICalisanPresentation
    {
        SorgulaCalisanYanitViewModel SorgulaCalisan(SorgulaCalisanIstekViewModel istek);
        
        IlklendirCalisanEkleYanitViewModel IlklendirCalisanEkle(IlklendirCalisanEkleIstekViewModel istek);
        
        EkleCalisanYanit EkleCalisan(EkleCalisanIstek istek);

        GetirCalisanRaporBirYanitViewModel GetirCalisanRaporBir(GetirCalisanRaporBirIstekViewModel istek);
        

    }
}
