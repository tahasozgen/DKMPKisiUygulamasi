using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.Somut.OgrenimKlasor;
using DKMPKisiUygulamasi.Model.Somut.TanimlayiciKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.CalisanKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.GorevlendirmeKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.KisiIletisimKlasoru;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.OgrenimKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.CalisanKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.GorevlendirmeKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.KisiIletisimKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.OgrenimKlasor;
using DKMPKisiUygulamasi.CakmaWCF.Mesajlar.Somut.Istek;
using DKMPKisiUygulamasi.CakmaWCF.Mesajlar.Somut.Yanit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.Soyut
{

    public interface IKisiServis
    {

        #region çalışan fonksiyonu (yeni)


        SorgulaCalisanYanitViewModel SorgulaCalisan(SorgulaCalisanIstekViewModel istek);

        IlklendirCalisanEkleYanitViewModel IlklendirCalisanEkle(IlklendirCalisanEkleIstekViewModel istek);

        EkleCalisanYanit EkleCalisan(EkleCalisanIstek istek);

        GetirCalisanRaporBirYanitViewModel GetirCalisanRaporBir(GetirCalisanRaporBirIstekViewModel istek);

        GetirCalisanOzetYanitViewModel GetirCalisanOzet(GetirCalisanOzetIstekViewModel istek);

        #endregion

        #region çalisan görevlendirme

        IlklendirCalisanGorevlendirmeYanitViewModel IlklendirCalisanGorevlendirme(IlklendirCalisanGorevlendirmeIstekViewModel istek);

        GorevlendirCalisanYanit GorevlendirCalisan(GorevlendirCalisanIstek istek);

        SorgulaGorevlendirCalisanYanitViewModel SorgulaGorevlendirCalisan(SorgulaGorevlendirCalisanIstekViewModel istek);
            

        #endregion

        #region öğrenim

       
        #endregion

        #region iletişim

       

        #endregion

        #region tamamlayıcı

      

        #endregion
                
        #region toplu işlem

        IlklendirEkleCalisanIletisimGorevEgitimViewModel IlklendirEkleCalisanIletisimGorevEgitim();

        EkleCalisanIletisimGorevEgitimYanitViewModel Ekle(IlklendirEkleCalisanIletisimGorevEgitimViewModel model);

        #endregion

    }
}
