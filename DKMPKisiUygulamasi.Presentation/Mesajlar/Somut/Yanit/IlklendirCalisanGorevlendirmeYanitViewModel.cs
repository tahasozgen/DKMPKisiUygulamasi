﻿using DKMPKisiUygulamasi.Presentation.Mesajlar.Soyut;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.GorevKlasoru;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using DKMPKurumCografyaUygulamasi.Servis.ViewModel.VarlikKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.Mesajlar.Somut.Yanit
{
    public class IlklendirCalisanGorevlendirmeYanitViewModel: YanitBaz
    {
        public CalisanViewModel Calisani { get; private set; }
        public CalisanGorevlendirmeViewModel MevcutGorevi { get; private set; }
        public IEnumerable<BirimViewModel> BirimListe { get; private set; }
        public IEnumerable<GoreviViewModel> GorevListe { get; private set; }
        public IEnumerable<IlViewModel> IlListe { get; private set; }

        private IlklendirCalisanGorevlendirmeYanitViewModel() : base()
        {
            this.Calisani = null;
            this.MevcutGorevi = null;
            this.BirimListe = new List<BirimViewModel>();
            this.GorevListe = new List<GoreviViewModel>();
            this.IlListe = new List<IlViewModel>();
        }

        public IlklendirCalisanGorevlendirmeYanitViewModel(bool basariliMi) : this()
        {
            this.BasariliMi = basariliMi;
        }

        public IlklendirCalisanGorevlendirmeYanitViewModel(Exception hata) : this()
        {
            this.kurHata(hata);
        }

        public IlklendirCalisanGorevlendirmeYanitViewModel(CalisanViewModel calisani, CalisanGorevlendirmeViewModel gorevi, IEnumerable<BirimViewModel> birimListe,
            IEnumerable<GoreviViewModel> gorevListe, IEnumerable<IlViewModel> ilListe) : this()
        {
            this.Calisani = calisani;
            this.MevcutGorevi = gorevi;
            this.BirimListe = birimListe;
            this.GorevListe = gorevListe;
            this.IlListe = ilListe;
            this.BasariliMi = !(calisani == null || MevcutGorevi == null || this.BirimListe == null || !this.BirimListe.Any()
                || this.GorevListe == null || !this.GorevListe.Any() || this.IlListe == null || !this.IlListe.Any());
        }
    }
}
