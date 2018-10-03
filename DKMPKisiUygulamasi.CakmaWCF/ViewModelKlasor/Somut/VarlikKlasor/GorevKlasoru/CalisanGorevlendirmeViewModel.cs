using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.TanimlayiciKlasor;
using DKMPKurumCografyaUygulamasi.Servis.ViewModel.VarlikKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.GorevKlasoru
{
    public class CalisanGorevlendirmeViewModel
    {
        
        public int? Anahtar { get; private set; }

        public CalisanViewModel Calisani { get; private set; }
        
        public BirimViewModel Birimi { get; private set; }

        public IlViewModel Ili { get; private set; }

        public GoreviViewModel Gorev { get; private set; }

        public UnvanViewModel Unvani { get; private set; }
        
        public string Baslangic { get; private set; }

        public string Bitis { get; private set; }
        
        public bool? AsilMi { get; private set; }
    
        public string EklenmeTarihi { get; private set; }

        public string Aciklama { get; private set; }

        public HizmetSonlanisNedeniViewModel SonlanisNedeni { get; private set; }
        
        public bool? ResmiMi { get; private set; }

        private CalisanGorevlendirmeViewModel()
        {
            this.Anahtar = null;
            this.Calisani = null;
            this.Birimi = null;
            this.Ili = null;
            this.Gorev = null;
            this.Unvani = null;
            this.Baslangic = string.Empty;
            this.Bitis = string.Empty;
            this.AsilMi = null;
            this.EklenmeTarihi = string.Empty;
            this.Aciklama = string.Empty;
            this.SonlanisNedeni = null;
            this.ResmiMi = null;
        }


        public CalisanGorevlendirmeViewModel(int anahtar, CalisanViewModel calisani, BirimViewModel birimi, IlViewModel ili,
            GoreviViewModel gorev, UnvanViewModel unvani, string baslangic,bool asilMi, string aciklama, bool resmiMi) : this()
        {
            this.Anahtar = anahtar;
            this.Calisani = calisani;
            this.Birimi = birimi;
            this.Gorev = gorev;
            this.Unvani = unvani;
            this.Baslangic = baslangic;
            this.AsilMi = asilMi;
            this.Aciklama = aciklama;
            this.ResmiMi = resmiMi;
        }

        public CalisanGorevlendirmeViewModel(int anahtar, CalisanViewModel calisani, BirimViewModel birimi, IlViewModel ili,
            GoreviViewModel gorev, UnvanViewModel unvani, string baslangic, bool asilMi, string aciklama, bool resmiMi, string bitis, HizmetSonlanisNedeniViewModel sonlanisNedeni) : this(anahtar, calisani, birimi, ili, gorev,  unvani,  baslangic,  asilMi,  aciklama,  resmiMi)
        {
            this.Bitis = bitis;
            this.SonlanisNedeni = sonlanisNedeni;
        }

        public string CalisanAdi
        {
            get
            {
                return this.Calisani != null ? this.Calisani.Adi : string.Empty;
            }
        }

        public string CalisanSoyadi
        {
            get
            {
                return this.Calisani != null ? this.Calisani.Soyadi : string.Empty;
            }
        }

        public string CalisanDogumTarihi
        {
            get
            {
                return this.Calisani != null ? this.Calisani.DogumTarihiSozce : string.Empty;
            }
        }

    }
}
