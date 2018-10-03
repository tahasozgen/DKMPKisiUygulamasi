using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.GorevKlasoru;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.KisiIletisimKlasor;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.RaporKlasor
{
    public class CalisanOzetViewModel
    {
        public CalisanGorevlendirmeViewModel Gorevlendirme { get; private set; }

        public KisiOgrenimViewModel Ogrenimi { get; private set; }

        public KisiIletisimViewModel Dahili { get; private set; }

        public KisiIletisimViewModel BakanlikEposta { get; private set; }

        public KisiIletisimViewModel CepTelefonu { get; private set; }

        public int? KidemYili { get; private set; }
        
        private CalisanOzetViewModel()
        {
            this.Gorevlendirme = null;
            this.Ogrenimi = null;
            this.Dahili = null;
            this.BakanlikEposta = null;
            this.CepTelefonu = null;
            this.KidemYili = null;
        }

        public CalisanOzetViewModel(CalisanGorevlendirmeViewModel gorevlendirme, KisiOgrenimViewModel ogrenimi, KisiIletisimViewModel dahili,
            KisiIletisimViewModel bakanlikEposta, KisiIletisimViewModel cepTelefonu,int kidemYili) :this()
        {
            this.Gorevlendirme = gorevlendirme;
            this.Ogrenimi = ogrenimi;
            this.Dahili = dahili;
            this.BakanlikEposta = bakanlikEposta;
            this.CepTelefonu = cepTelefonu;
            this.KidemYili = kidemYili;
        }

        public string AdiSoyadi
        {
            get
            {
                return (this.Gorevlendirme != null && this.Gorevlendirme.Calisani != null) ? this.Gorevlendirme.Calisani.AdiSoyadi : string.Empty;
            }
        }

        public string Birimi
        {
            get
            {
                return (this.Gorevlendirme != null && this.Gorevlendirme.Birimi != null) ? this.Gorevlendirme.Birimi.BirimAdi : string.Empty;
            }
        }

        public string SicilNo
        {
            get
            {
                return (this.Gorevlendirme != null && this.Gorevlendirme.Calisani != null) ? this.Gorevlendirme.Calisani.SicilNo : string.Empty;
            }
        }

        public string Unvani
        {
            get
            {
                return (this.Gorevlendirme != null && this.Gorevlendirme.Unvani != null) ? this.Gorevlendirme.Unvani.Adi : string.Empty;
            }
        }

        public string Gorevi
        {
            get
            {
                return (this.Gorevlendirme != null && this.Gorevlendirme.Gorev != null) ? this.Gorevlendirme.Gorev.Adi : string.Empty;
            }
        }

        public string OgrenimAdi
        {
            get
            {
                return (this.Ogrenimi != null) ? this.Ogrenimi.OgrenimAdi : string.Empty;
            }
        }
        
        public string Sinifi
        {
            get
            {
                return (this.Gorevlendirme != null && this.Gorevlendirme.Calisani != null) ? this.Gorevlendirme.Calisani.Sinifi : string.Empty;
            }
        }

        public string KidemYiliSozce
        {
            get
            {
                return this.KidemYili != null ? this.KidemYili.ToString() : string.Empty;
            }
        }

        public string CinsiyetSozce
        {
            get
            {
                return (this.Gorevlendirme != null && this.Gorevlendirme.Calisani != null) ? this.Gorevlendirme.Calisani.Cinsiyeti : string.Empty;
            }
        }

        public string KanGrubuveRh
        {
            get
            {
                return (this.Gorevlendirme != null && this.Gorevlendirme.Calisani != null) ? this.Gorevlendirme.Calisani.KanGrubuveRh : string.Empty;
            }
        }

        public string DahiliSozce
        {
            get
            {
                return (this.Dahili != null) ? this.Dahili.Deger : string.Empty;
            }
        }

        public string BakanlikEpostaSozce
        {
            get
            {
                return (this.BakanlikEposta != null) ? this.BakanlikEposta.Deger : string.Empty;
            }
        }

        public string CepTelefonuSozce
        {
            get
            {
                return (this.CepTelefonu != null) ? this.CepTelefonu.Deger : string.Empty;
            }
        }

        public string GoreveBaslamaTarihi
        {
            get
            {
                return (this.Gorevlendirme != null) ? this.Gorevlendirme.Baslangic : string.Empty;
            }
        }

        public string TCKimlikNo
        {
            get
            {
                return (this.Gorevlendirme != null && this.Gorevlendirme.Calisani != null) ? this.Gorevlendirme.Calisani.TurCumKimlikNo : string.Empty;
            }
        }

    }
}
