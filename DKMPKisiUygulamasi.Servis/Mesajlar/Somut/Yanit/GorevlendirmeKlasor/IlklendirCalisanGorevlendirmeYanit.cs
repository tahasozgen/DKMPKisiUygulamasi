using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Soyut;
using DKMPKurumCografyaUygulamasi.Servis.ViewModel.VarlikKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.GorevlendirmeKlasor
{
    public class IlklendirCalisanGorevlendirmeYanit : YanitBaz
    {
        public Calisan Calisani { get; private set; }
        public CalisanGorevlendirme MevcutGorevi{ get; private set; }
        public IEnumerable<BirimViewModel> BirimListe { get; private set; }
        public IEnumerable<Gorevi> GorevListe { get; private set; }
        public IEnumerable<IlViewModel> IlListe { get; private set; }

        private IlklendirCalisanGorevlendirmeYanit() : base()
        {
            this.Calisani = null;
            this.MevcutGorevi = null;
            this.BirimListe = new List<BirimViewModel>();
            this.GorevListe = new List<Gorevi>();
            this.IlListe = new List<IlViewModel>();
        }

        public IlklendirCalisanGorevlendirmeYanit(bool basariliMi) : this()
        {
            this.BasariliMi = basariliMi;
        }

        public IlklendirCalisanGorevlendirmeYanit(Exception hata) : this()
        {
            this.kurHata(hata);
        }

        public IlklendirCalisanGorevlendirmeYanit(Calisan calisani, CalisanGorevlendirme gorevi, IEnumerable<BirimViewModel> birimListe,
            IEnumerable<Gorevi> gorevListe, IEnumerable<IlViewModel> ilListe) : this()
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
