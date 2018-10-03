using DKMPKisiUygulamasi.Presentation.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using DKMPKisiUygulamasi.Presentation.Mesajlar.Somut.Istek;
using DKMPKisiUygulamasi.Presentation.Mesajlar.Somut.Yanit;
using DKMPKisiUygulamasi.Servis.Soyut;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.GorevlendirmeKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.GorevlendirmeKlasor;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.GorevKlasoru;
using DKMPKisiUygulamasi.Model.SabitlerMesajlar;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.RaporKlasor;

namespace DKMPKisiUygulamasi.Presentation.Somut
{
    public class GorevlendirmePresentation : PresentationBaz,IGorevlendirmePresentation
    {
        private IGorevlendirmeServis _gorevlendirmeServis;   

        private GorevlendirmePresentation():base()
        {
        }

        public GorevlendirmePresentation(IGorevlendirmeServis gorevlendirmeServis) : this()
        {
            this._gorevlendirmeServis = gorevlendirmeServis;
        }

        public IlklendirCalisanGorevlendirmeYanitViewModel IlklendirCalisanGorevlendirme(IlklendirCalisanGorevlendirmeIstekViewModel istek)
        {

            try
            {
                IlklendirCalisanGorevlendirmeYanitViewModel yanit = new IlklendirCalisanGorevlendirmeYanitViewModel(false);
                IlklendirCalisanGorevlendirmeYanit servisYanit = null;
                IlklendirCalisanGorevlendirmeIstek servisIstek = null;
                int kullaniciId, gorevlendirilecekCalisanId = int.MinValue;
                CalisanViewModel calisanVm = null;
                CalisanGorevlendirmeViewModel gorevlendirmeVm = null;
                IEnumerable<GoreviViewModel> gorevVmListe = null;

                if (!this._kontrol.uygunMu(istek))
                {
                    yanit.IsaretleGecemediIlkKontrolu(this._kontrol.alHataKodu(istek));
                    return yanit;
                }

                kullaniciId = istek.KullaniciId ?? int.MinValue;
                gorevlendirilecekCalisanId = istek.GorevlendirilecekCalisanId ?? int.MinValue;

                servisIstek = new IlklendirCalisanGorevlendirmeIstek(kullaniciId, gorevlendirilecekCalisanId);

                servisYanit = this._gorevlendirmeServis.IlklendirCalisanGorevlendirme(servisIstek);

                if (servisYanit == null)
                    throw new ApplicationException();

                if (!servisYanit.BasariliMi)
                    throw new ApplicationException();

                calisanVm = this._cevir.cevir(servisYanit.Calisani);

                if (calisanVm == null)
                    throw new ApplicationException();

                gorevlendirmeVm = this._cevir.cevir(servisYanit.MevcutGorevi);

                if (gorevlendirmeVm == null)
                    throw new ApplicationException();

                gorevVmListe = this._cevir.cevir(servisYanit.GorevListe.ToList());

                if (gorevVmListe == null)
                    throw new ApplicationException();

                yanit = new IlklendirCalisanGorevlendirmeYanitViewModel(calisanVm, gorevlendirmeVm, servisYanit.BirimListe, gorevVmListe, servisYanit.IlListe);

                return yanit;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public GorevlendirCalisanYanit GorevlendirCalisan(GorevlendirCalisanIstek istek)
        {

            try
            {
                GorevlendirCalisanYanit yanit = new GorevlendirCalisanYanit(false);

                if (!this._kontrol.uygunMu(istek))
                {
                    yanit.IsaretleGecemediIlkKontrolu(this._kontrol.alHataKodu(istek));
                    return yanit;
                }

                yanit = this._gorevlendirmeServis.GorevlendirCalisan(istek);

                if (yanit == null)
                    throw new ApplicationException();

                if (!yanit.BasariliMi)
                    throw new ApplicationException();

                return yanit;
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
                return new GorevlendirCalisanYanit(hata);
            }


        }

        public SorgulaGorevlendirCalisanYanitViewModel SorgulaCalisanGorevlendirme(SorgulaGorevlendirCalisanIstekViewModel istek)
        {
            try
            {

                SorgulaGorevlendirCalisanYanitViewModel yanit = new SorgulaGorevlendirCalisanYanitViewModel(false);
                SorgulaGorevlendirCalisanYanit servisYanit = null;
                SorgulaGorevlendirCalisanIstek servisIstek = null;
                DateTime tarih = Sabitler.BosTarih;
                int kullaniciId = int.MinValue;
                List<CalisanGorevlendirmeViewModel> vmListe = null;

                if (!this._kontrol.uygunMu(istek))
                {
                    yanit.IsaretleGecemediIlkKontrolu(this._kontrol.alHataKodu(istek));
                    return yanit;
                }

                tarih = istek.Tarihi ?? Sabitler.BosTarih;
                kullaniciId = istek.KullaniciId ?? int.MinValue;

                if (tarih == Sabitler.BosTarih || kullaniciId == int.MinValue)
                    throw new ApplicationException();

                servisIstek = new SorgulaGorevlendirCalisanIstek(kullaniciId, tarih);

                servisYanit = this._gorevlendirmeServis.SorgulaCalisanGorevlendirme(servisIstek);

                if (servisYanit == null)
                    throw new ApplicationException();

                if (!servisYanit.BasariliMi)
                    throw new ApplicationException();

                vmListe = this._cevir.cevir(servisYanit.Liste.ToList());

                if (vmListe == null)
                    throw new ApplicationException();

                yanit = new SorgulaGorevlendirCalisanYanitViewModel(vmListe);

                return yanit;
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
                return new SorgulaGorevlendirCalisanYanitViewModel(hata);
            }

        }

        public GetirCalisanOzetYanitViewModel GetirCalisanOzet(GetirCalisanOzetIstekViewModel istek)
        {   
            try
            {

                GetirCalisanOzetYanitViewModel yanit = new GetirCalisanOzetYanitViewModel(false);
                GetirCalisanOzetYanit servisYanit = null;
                GetirCalisanOzetIstek servisIstek = null;
                int kullaniciId = int.MinValue;
                DateTime tarihi = Sabitler.BosTarih;
                List<CalisanOzetViewModel> vmListe = null;

                if (this._kontrol.uygunMu(istek))
                {
                    yanit.IsaretleGecemediIlkKontrolu(this._kontrol.alHataKodu(istek));
                    return yanit;
                }

                kullaniciId = istek.KullaniciId ?? int.MinValue;

                if (kullaniciId == int.MinValue)
                    throw new ArgumentException();

                tarihi = istek.Tarihi ?? Sabitler.BosTarih;

                if (tarihi == Sabitler.BosTarih)
                    throw new ArgumentException();

                servisIstek = new GetirCalisanOzetIstek(kullaniciId, tarihi);

                servisYanit = this._gorevlendirmeServis.GetirCalisanOzet(servisIstek);

                if (servisYanit == null)
                    throw new ApplicationException();

                if (!servisYanit.BasariliMi)
                    throw new ApplicationException();

                vmListe = this._cevir.cevir(servisYanit.Liste.ToList());

                if (vmListe == null)
                    throw new ApplicationException();

                yanit = new GetirCalisanOzetYanitViewModel(vmListe);

                return yanit;
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
                return new GetirCalisanOzetYanitViewModel(hata);
            }

        }
    }
}
