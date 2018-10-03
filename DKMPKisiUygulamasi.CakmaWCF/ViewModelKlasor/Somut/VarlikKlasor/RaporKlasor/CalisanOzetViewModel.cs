using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.GorevKlasoru;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.KisiIletisimKlasor;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.RaporKlasor
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

        [Display(Name = "Adı ve Soyadı")]
        public string AdiSoyadi
        {
            get
            {
                return (this.Gorevlendirme != null && this.Gorevlendirme.Calisani != null) ? this.Gorevlendirme.Calisani.AdiSoyadi : string.Empty;
            }
        }

        [Display(Name = "Sicil No")]
        public string SicilNo
        {
            get
            {
                return (this.Gorevlendirme != null && this.Gorevlendirme.Calisani != null) ? this.Gorevlendirme.Calisani.SicilNo : string.Empty;
            }
        }

        [Display(Name = "Kadrosu & Unvanı")]
        public string Unvani
        {
            get
            {
                return (this.Gorevlendirme != null && this.Gorevlendirme.Unvani != null) ? this.Gorevlendirme.Unvani.Adi : string.Empty;
            }
        }

        [Display(Name = "Görevi")]
        public string Gorevi
        {
            get
            {
                return (this.Gorevlendirme != null && this.Gorevlendirme.Gorev != null) ? this.Gorevlendirme.Gorev.Adi : string.Empty;
            }
        }

        [Display(Name = "Mezuniyeti & Bölümü")]
        public string OgrenimAdi
        {
            get
            {
                return (this.Ogrenimi != null) ? this.Ogrenimi.OgrenimAdi : string.Empty;
            }
        }

        [Display(Name = "Doğum Tarihi")]
        public string DogumTarihi
        {
            get
            {
                return this.Gorevlendirme != null ? this.Gorevlendirme.CalisanDogumTarihi : string.Empty;
            }
        }

        [Display(Name = "Kıdem Yılı")]
        public string KidemYiliSozce
        {
            get
            {
                return this.KidemYili != null ? this.KidemYili.ToString() : string.Empty;
            }
        }

        [Display(Name = "Cinsiyeti")]
        public string CinsiyetSozce
        {
            get
            {
                return (this.Gorevlendirme != null && this.Gorevlendirme.Calisani != null) ? this.Gorevlendirme.Calisani.Cinsiyeti : string.Empty;
            }
        }

        [Display(Name = "Kan Grubu ve Rh")]
        public string KanGrubuveRh
        {
            get
            {
                return (this.Gorevlendirme != null && this.Gorevlendirme.Calisani != null) ? this.Gorevlendirme.Calisani.KanGrubuveRh : string.Empty;
            }
        }


        [Display(Name = "Dahili")]
        public string DahiliSozce
        {
            get
            {
                return (this.Dahili != null) ? this.Dahili.Deger : string.Empty;
            }
        }

        [Display(Name = "Bakanlık Eposta")]
        public string BakanlikEpostaSozce
        {
            get
            {
                return (this.BakanlikEposta != null) ? this.BakanlikEposta.Deger : string.Empty;
            }
        }

        [Display(Name = "Cep Telefonu")]
        public string CepTelefonuSozce
        {
            get
            {
                return (this.CepTelefonu != null) ? this.CepTelefonu.Deger : string.Empty;
            }
        }

        [Display(Name = "Göreve Başlayış")]
        public string GoreveBaslamaTarihi
        {
            get
            {
                return (this.Gorevlendirme != null) ? this.Gorevlendirme.Baslangic : string.Empty;
            }
        }

        [Display(Name = "Türkiye Cumhuriyeti Kimlik No")]
        public string TCKimlikNo
        {
            get
            {
                return (this.Gorevlendirme != null && this.Gorevlendirme.Calisani != null) ? this.Gorevlendirme.Calisani.TurCumKimlikNo : string.Empty;
            }
        }

        [Display(Name = "Sınıfı")]
        public string Sinifi
        {
            get
            {
                return (this.Gorevlendirme != null && this.Gorevlendirme.Calisani != null) ? this.Gorevlendirme.Calisani.SinifiSozce : string.Empty;
            }
        }

        [Display(Name = "Birimi")]
        public string Birimi
        {
            get
            {
                return (this.Gorevlendirme != null && this.Gorevlendirme.Birimi != null) ? this.Gorevlendirme.Birimi.BirimAdi : string.Empty;
            }
        }
    }
}
