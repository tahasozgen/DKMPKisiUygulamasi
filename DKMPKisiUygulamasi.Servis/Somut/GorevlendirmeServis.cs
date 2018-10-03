using DKMPKisiUygulamasi.Servis.Soyut;
using System;
using System.Collections.Generic;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.GorevlendirmeKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.GorevlendirmeKlasor;
using DKMPKisiUygulamasi.Model.IsKatmani.Somut;
using DKMPKisiUygulamasi.Model.IsKatmani.Soyut;
using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;
using DKMPKisiUygulamasi.Model.SabitlerMesajlar;
using DKMPKurumCografyaUygulamasi.Servis.ViewModel.VarlikKlasor;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using DKMPKisiUygulamasi.Model.Somut.IletisimKlasor;
using DKMPKisiUygulamasi.Model.Somut.HataKlasoru;
using DKMPKisiUygulamasi.Model.Somut.RaporKlasor;

namespace DKMPKisiUygulamasi.Servis.Somut
{
    public class GorevlendirmeServis : IGorevlendirmeServis
    {
        private IGorevlendirmeIsKurali _gorevlendirmeIsKurali;
        private ICalisanIsKurali _calisanIsKurali;
        private Kontrol _kontrol;
        private IsGuder _isGuder;
        private HataServis _hataServis;

        public GorevlendirmeServis(IGorevlendirmeIsKurali gorevlendirmeIsKurali,ICalisanIsKurali calisanIsKurali)
        {
            this._gorevlendirmeIsKurali = gorevlendirmeIsKurali;
            this._calisanIsKurali = calisanIsKurali;
            this._kontrol = new Kontrol();
            this._isGuder = new IsGuder(calisanIsKurali, gorevlendirmeIsKurali);
            this._hataServis = new HataServis();
        }

        public GorevlendirCalisanYanit GorevlendirCalisan(GorevlendirCalisanIstek istek)
        {

            try
            {
                CalisanGorevlendirme gorevlendirme = null;
                int calisanId = int.MinValue;
                int birimId = int.MinValue;
                int gorevId = int.MinValue;
                int unvanId = int.MinValue;
                DateTime baslangic = Sabitler.BosTarih;
                bool asilMi = false;
                string aciklama = null;
                bool resmiMi = true;
                GorevlendirCalisanYanit yanit = new GorevlendirCalisanYanit(false);
                int sonucId = int.MinValue;

                if (!this._kontrol.uygunMu(istek))
                {
                    yanit.IsaretleGecemediIlkKontrolu(this._kontrol.alHataKodu(istek));
                    return yanit;
                }

                calisanId = istek.CalisanId ?? int.MinValue;

                if (calisanId == int.MinValue)
                    throw new ArgumentException();

                birimId = istek.BirimId ?? int.MinValue;

                if (birimId == int.MinValue)
                    throw new ArgumentException();

                gorevId = istek.GorevId ?? int.MinValue;
                
                if (gorevId == int.MinValue)
                    throw new ArgumentException();

                unvanId = istek.UnvanId ?? int.MinValue;

                if (unvanId == int.MinValue)
                    throw new ArgumentException();

                baslangic = Arac.CevirTarihe(istek.BaslangicTarihi);

                if (baslangic == Sabitler.BosTarih)
                    baslangic = DateTime.Now;

                asilMi = istek.AsilMi ?? false;
                aciklama = istek.Aciklama;
                resmiMi = istek.ResmiMi ?? false;

                gorevlendirme = new CalisanGorevlendirme(calisanId, birimId, gorevId, unvanId, baslangic, asilMi, aciklama, resmiMi);

                sonucId = this._gorevlendirmeIsKurali.EkleGorevlendirme(gorevlendirme);

                yanit = new GorevlendirCalisanYanit(sonucId);

                return yanit;
            }
            catch (ArgumentException hata)
            {
                return new GorevlendirCalisanYanit(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
                return new GorevlendirCalisanYanit(hata);
            }

        }

        public IlklendirCalisanGorevlendirmeYanit IlklendirCalisanGorevlendirme(IlklendirCalisanGorevlendirmeIstek istek)
        {

            try
            {
                Calisan calisani = null;
                CalisanGorevlendirme gorevi = null;
                IEnumerable<BirimViewModel> birimListe = new List<BirimViewModel>();
                IEnumerable<Gorevi> gorevListe = new List<Gorevi>();
                IEnumerable<IlViewModel> ilListe = new List<IlViewModel>();
                IlklendirCalisanGorevlendirmeYanit yanit = new IlklendirCalisanGorevlendirmeYanit(false);
                bool getirilsinMiSadeceResmiGorevler = true;
                KurumCografyaServis kurumCografya = new KurumCografyaServis();
                bool getirilsinMiTumu = true;

                if (!this._kontrol.uygunMu(istek))
                {
                    yanit.IsaretleGecemediIlkKontrolu(this._kontrol.alHataKodu(istek));
                    return yanit;
                }

                calisani = this._isGuder.getirCalisan(istek.GorevlendirilecekCalisanId);

                if (calisani == null)
                    throw new ApplicationException();

                gorevi = this._isGuder.getirMevcutGorevi(istek.GorevlendirilecekCalisanId, getirilsinMiSadeceResmiGorevler);

                if (gorevi == null)
                    throw new ApplicationException();

                birimListe = this._isGuder.getirBirimKullanicininGorebilecegi(istek.KullaniciId);

                if (birimListe == null)
                    throw new ApplicationException();

                gorevListe = this._gorevlendirmeIsKurali.GetirGorevListe(getirilsinMiTumu);

                if (gorevListe == null)
                    throw new ApplicationException();

                ilListe = kurumCografya.getirIlListe(getirilsinMiTumu);

                if (ilListe == null)
                    throw new ApplicationException();

                yanit = new IlklendirCalisanGorevlendirmeYanit(calisani, gorevi, birimListe, gorevListe, ilListe);

                return yanit;
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
                return new IlklendirCalisanGorevlendirmeYanit(hata);
            }

        }

        public SorgulaGorevlendirCalisanYanit SorgulaCalisanGorevlendirme(SorgulaGorevlendirCalisanIstek istek)
        {

            try
            {
                SorgulaGorevlendirCalisanYanit yanit = new SorgulaGorevlendirCalisanYanit(false);
                IEnumerable<CalisanGorevlendirme> gorevlendirmeListe = null;
                DateTime tarihi = Sabitler.BosTarih;

                if (!this._kontrol.uygunMu(istek))
                {
                    yanit.IsaretleGecemediIlkKontrolu(this._kontrol.alHataKodu(istek));
                    return yanit;
                }

                if (istek.girildiMiTarih)
                {
                    tarihi = istek.Tarihi ?? Sabitler.BosTarih;

                    if (tarihi == Sabitler.BosTarih)
                        throw new ArgumentException();

                    gorevlendirmeListe = this._gorevlendirmeIsKurali.GetirCalisanGorevlendirmeListe(tarihi);

                    if (gorevlendirmeListe == null)
                        throw new ApplicationException();

                    yanit = new SorgulaGorevlendirCalisanYanit(gorevlendirmeListe);

                }
                else
                    yanit = new SorgulaGorevlendirCalisanYanit(new List<CalisanGorevlendirme>());

                return yanit;

            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
                return new SorgulaGorevlendirCalisanYanit(hata);
            }

        }

        public GetirCalisanOzetYanit GetirCalisanOzet(GetirCalisanOzetIstek istek)
        {

            try
            {
                GetirCalisanOzetYanit yanit = new GetirCalisanOzetYanit(false);
                IEnumerable<CalisanOzet> ozetListe = null;
                IEnumerable<Calisan> calisanListe = null;

                if (!this._kontrol.uygunMu(istek))
                {
                    yanit.IsaretleGecemediIlkKontrolu(this._kontrol.alHataKodu(istek));
                    return yanit;
                }

                if(istek.girildiMiSorgu)
                {

                    if (istek.girildiMiTarih)
                    {
                        calisanListe = this._calisanIsKurali.SorgulaCalisan(istek.Tarihi);

                        if (calisanListe == null)
                            throw new IslemBasarisizHatasi();

                    }
                    else if (istek.girildiMiSorguSozcesi)
                    {
                        calisanListe = this._calisanIsKurali.SorgulaCalisan(istek.SorguSozcesi);

                        if (calisanListe == null)
                            throw new IslemBasarisizHatasi();
                    }

                    ozetListe = this._gorevlendirmeIsKurali.GetirCalisanOzetListe(calisanListe);

                    if (ozetListe == null)
                        throw new IslemBasarisizHatasi();

                    yanit = new GetirCalisanOzetYanit(ozetListe);

                }              
                else
                    yanit = new GetirCalisanOzetYanit(new List<CalisanOzet>());


                return yanit;
            }
            catch (IslemBasarisizHatasi hata)
            {
                this._hataServis.YazHata(hata);
                return new GetirCalisanOzetYanit(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
                return new GetirCalisanOzetYanit(hata);
            }

        }

    }
}
