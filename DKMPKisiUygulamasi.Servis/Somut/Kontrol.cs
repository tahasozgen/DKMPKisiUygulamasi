using DKMPKisiUygulamasi.Model.SabitlerMesajlar;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.CalisanKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.GorevlendirmeKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.KisiIletisimKlasoru;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.OgrenimKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Somut
{

    class Kontrol
    {
        //EkleKisiIletisimIstek istek istek istek
        internal bool uygunMu(EkleKisiIletisimIstek istek)
        {
            return !(istek == null || istek.KisiId == null || istek.TurId == null || String.IsNullOrEmpty(istek.Deger));
        }

        internal string alHataKodu(EkleKisiIletisimIstek istek)
        {
            return Sabitler.UygulamaKodu;
        }

        internal bool uygunMu(EkleKisiOgrenimIstek istek)
        {
            return !(istek == null);
        }

        internal string alHataKodu(EkleKisiOgrenimIstek istek)
        {
            return Sabitler.UygulamaKodu;
        }

        internal bool uygunMu(GetirCalisanOzetIstek istek)
        {
            return !(istek == null);
        }

        internal string alHataKodu(GetirCalisanOzetIstek istek)
        {
            return Sabitler.UygulamaKodu;
        }
        internal bool uygunMu(SorgulaGorevlendirCalisanIstek istek)
        {
            return !(istek == null);
        }

        internal string alHataKodu(SorgulaGorevlendirCalisanIstek istek)
        {
            return Sabitler.UygulamaKodu;
        }

        internal bool uygunMu(EkleCalisanIstek istek)
        {
            return !(istek == null ||String.IsNullOrEmpty(istek.Adi) || String.IsNullOrEmpty(istek.Soyadi));
        }

        internal string alHataKodu(EkleCalisanIstek istek)
        {
            return Sabitler.UygulamaKodu;
        }

        internal bool uygunMu(GetirCalisanRaporBirIstek istek)
        {
            return !(istek == null);
        }

        internal string alHataKodu(GetirCalisanRaporBirIstek istek)
        {
            return Sabitler.UygulamaKodu;
        }

        internal bool uygunMu(IlklendirCalisanEkleIstek istek)
        {
            return !(istek == null);
        }

        internal string alHataKodu(IlklendirCalisanEkleIstek istek)
        {
            return Sabitler.UygulamaKodu;
        }

        internal bool uygunMu(SorgulaCalisanIstek istek)
        {
            return !(istek == null ||istek.KullaniciId == int.MinValue || String.IsNullOrEmpty(istek.SorguSozcesi));
        }

        internal string alHataKodu(SorgulaCalisanIstek istek)
        {
            return Sabitler.UygulamaKodu;
        }

        internal bool uygunMu(GorevlendirCalisanIstek istek)
        {
            return !(istek == null || istek.KullaniciId == int.MinValue );
        }

        internal string alHataKodu(GorevlendirCalisanIstek istek)
        {
            return Sabitler.UygulamaKodu;
        }

        internal bool uygunMu(IlklendirCalisanGorevlendirmeIstek istek)
        {
            return !(istek == null || istek.KullaniciId == int.MinValue);
        }

        internal string alHataKodu(IlklendirCalisanGorevlendirmeIstek istek)
        {
            return Sabitler.UygulamaKodu;
        }
        
    }
}
