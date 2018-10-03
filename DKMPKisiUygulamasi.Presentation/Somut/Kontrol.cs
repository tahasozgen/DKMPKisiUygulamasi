using DKMPKisiUygulamasi.Presentation.Mesajlar.Somut.Istek;
using DKMPKisiUygulamasi.Presentation.Mesajlar.Somut.Yanit;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.IslemKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.CalisanKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.GorevlendirmeKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.Somut
{
    public class Kontrol
    {

        //IlklendirEkleCalisanIletisimGorevEgitimViewModel model istek model istek istek istek istek istek istek
        internal bool uygunMu(IlklendirEkleCalisanIletisimGorevEgitimViewModel istek)
        {
            return !(istek == null || String.IsNullOrEmpty(istek.Adi) || istek.AkademikUnvaniId == null ||
                istek.AsilMi == null || istek.BirimId == null || istek.CinsId == null || istek.GorevId == null ||
                istek.KadroDurumuId == null || istek.KaninGrubuId == null || istek.MedeniHaliId == null ||
                istek.OgrenimDurumuId == null || String.IsNullOrEmpty(istek.DogumTarihi) || istek.PhDegerId == null
                || istek.ResmiMi == null || String.IsNullOrEmpty(istek.Soyadi) || istek.UnvanId == null || istek.KullaniciId == null);
        }

        internal string alHataKodu(IlklendirEkleCalisanIletisimGorevEgitimViewModel istek)
        {
            return "";
        }

        internal bool uygunMu(EkleCalisanIletisimGorevEgitimViewModel istek)
        {
            return !(istek == null || String.IsNullOrEmpty(istek.Adi) || istek.AkademikUnvaniId == null ||
                istek.AsilMi == null || istek.BirimId == null || istek.CinsId == null || istek.GorevId == null ||
                istek.KadroDurumuId == null || istek.KaninGrubuId == null || istek.MedeniHaliId == null ||
                istek.OgrenimDurumuId == null || String.IsNullOrEmpty(istek.DogumTarihi) || istek.PhDegerId == null 
                || istek.ResmiMi == null || String.IsNullOrEmpty(istek.Soyadi) || istek.UnvanId == null);
        }

        internal string alHataKodu(EkleCalisanIletisimGorevEgitimViewModel istek)
        {
            return "";
        }


        internal bool uygunMu(GetirCalisanOzetIstekViewModel istek)
        {
            return !(istek == null);
        }

        internal string alHataKodu(GetirCalisanOzetIstekViewModel istek)
        {
            return "";
        }

        internal bool uygunMu(SorgulaGorevlendirCalisanIstekViewModel istek)
        {
            return !(istek == null);
        }

        internal string alHataKodu(SorgulaGorevlendirCalisanIstekViewModel istek)
        {
            return "";
        }

        internal bool uygunMu(GorevlendirCalisanIstek istek)
        {
            return !(istek == null);
        }

        internal string alHataKodu(GorevlendirCalisanIstek istek)
        {
            return "";
        }

        internal bool uygunMu(SorgulaCalisanIstekViewModel istek)
        {
            return !(istek == null);
        }

        internal string alHataKodu(SorgulaCalisanIstekViewModel istek)
        {
            return "";
        }

        internal bool uygunMu(IlklendirCalisanGorevlendirmeIstekViewModel istek)
        {
            return !(istek == null);
        }

        internal string alHataKodu(IlklendirCalisanGorevlendirmeIstekViewModel istek)
        {
            return "";
        }

        internal bool uygunMu(GetirCalisanRaporBirIstekViewModel istek)
        {
            return !(istek == null);
        }

        internal string alHataKodu(GetirCalisanRaporBirIstekViewModel istek)
        {
            return "";
        }

        internal bool uygunMu(EkleCalisanIstek istek)
        {
            return !(istek == null);
        }

        internal string alHataKodu(EkleCalisanIstek istek)
        {
            return "";
        }

        internal bool uygunMu(IlklendirCalisanEkleIstekViewModel istek)
        {
            return !(istek == null);
        }

        internal string alHataKodu(IlklendirCalisanEkleIstekViewModel istek)
        {
            return "";
        } 

    }
}
