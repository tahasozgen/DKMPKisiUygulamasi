using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.SabitlerMesajlar;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using DKMPKisiUygulamasi.Model.Somut.TanimlayiciKlasor;
using DKMPKurumCografyaUygulamasi.Servis.ViewModel.VarlikKlasor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.Somut.GorevKlasoru
{
    public class CalisanGorevlendirme
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Anahtar { get; set; }

        public int? CalisanId { get; set; }

        [Required]
        [ForeignKey("CalisanId")]
        public virtual Calisan Calisani { get; set; }

        [Required]
        public int BirimId { get; set; }
        
        public int? IlId { get; set; }

        public int? GorevId { get; set; }

        [Required]
        [ForeignKey("GorevId")]
        public virtual Gorevi Gorev { get ; set; }

        public int? UnvanId { get; set; }

        [Required]
        [ForeignKey("UnvanId")]
        public virtual Unvan Unvani { get; set; }

        [Required]
        public DateTime Baslangic { get; set; }

        public DateTime? Bitis { get; set; }

        [Required]
        public bool AsilMi { get; set; }

        [Required]
        public DateTime EklenmeTarihi { get; set; }

        public string Aciklama { get; set; }

        public HizmetSonlanisNedeni SonlanisNedeni { get; set; }

        [Required]
        public bool ResmiMi { get; set; }

        public EmeklilikDerecesi EmekliliginDerecesi { get; set; }

        public KazanilanHakAyligiDerecesi KazanilanHakAyligi { get; set; }

        private CalisanGorevlendirme()
        {
            this.Aciklama = null;
            this.Anahtar = int.MinValue;
            this.AsilMi = false;
            this.Baslangic = Sabitler.BosTarih;
            this.BirimId = int.MinValue;
            this.Bitis = Sabitler.BosTarih;
            this.Calisani = null;
            this.CalisanId = null;
            this.EklenmeTarihi = Sabitler.BosTarih;
            this.Gorev = null;
            this.GorevId = null;
            this.UnvanId = null;
            this.Unvani = null;
            this.SonlanisNedeni = HizmetSonlanisNedeni.Tanimsiz;
            this.ResmiMi = true;
            this.EmekliliginDerecesi = EmeklilikDerecesi.Tanimsiz;
            this.KazanilanHakAyligi = KazanilanHakAyligiDerecesi.Tanimsiz;
        }

        public CalisanGorevlendirme(int anahtar) : this()
        {
            this.Anahtar = anahtar;
        }

        public CalisanGorevlendirme(int calisanId, int birimId, int gorevId, int unvanId, DateTime baslangic) : this()
        {
            this.CalisanId = calisanId;
            this.BirimId = birimId;
            this.GorevId = gorevId;
            this.UnvanId = unvanId;
            this.Baslangic = baslangic;
            this.EklenmeTarihi = DateTime.Now;
        }

        public CalisanGorevlendirme(int calisanId, int birimId, int gorevId, int unvanId, DateTime baslangic, bool asilMi) : this( calisanId,  birimId,  gorevId,  unvanId,  baslangic)
        {
            this.AsilMi = asilMi;
        }

        public CalisanGorevlendirme(int calisanId, int birimId, int gorevId, int unvanId, DateTime baslangic, bool asilMi,string aciklama) : this( calisanId,  birimId,  gorevId,  unvanId,  baslangic,  asilMi)
        {
            this.Aciklama = aciklama;
        }

        public CalisanGorevlendirme(int calisanId, int birimId, int gorevId, int unvanId, DateTime baslangic, bool asilMi, bool resmiMi) : this(calisanId, birimId, gorevId, unvanId, baslangic, asilMi)
        {
            this.ResmiMi = resmiMi;
        }

        public CalisanGorevlendirme(int calisanId, int birimId, int gorevId, int unvanId, DateTime baslangic, bool asilMi, string aciklama, bool resmiMi) : this(calisanId, birimId, gorevId, unvanId, baslangic, asilMi, aciklama)
        {
            this.ResmiMi = resmiMi;
        }

        public CalisanGorevlendirme(Calisan calisan, Gorevi gorevi, Unvan unvani, int birimId):this()
        {
            if (calisan != null)
                this.CalisanId = calisan.Anahtar;
            this.Calisani = calisan;

            if (gorevi != null)
                this.GorevId = gorevi.Anahtar;
            this.Gorev = gorevi;

            if (unvani != null)
                this.UnvanId = unvani.Anahtar;
            this.Unvani = unvani;

            this.BirimId = birimId;

        }

        public CalisanGorevlendirme(Calisan calisan) : this()
        {
            this.Calisani = calisan;

            if (calisan != null)
                this.CalisanId = calisan.Anahtar;

            this.EklenmeTarihi = DateTime.Now;
        }

    }
}
