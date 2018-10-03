using DKMPKisiUygulamasi.CakmaWCF.Mesajlar.Soyut;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.GorevKlasoru;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.TanimlayiciKlasor;
using DKMPKurumCografyaUygulamasi.Servis.ViewModel.VarlikKlasor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Xml.Linq;

namespace DKMPKisiUygulamasi.CakmaWCF.Mesajlar.Somut.Yanit
{
    public class IlklendirEkleCalisanIletisimGorevEgitimViewModel : IslemBaz
    {
        public int? KullaniciId { get; set; }

        #region çalışan verileri

        [Display(Name = "Akademik Ünvanı")]
        public int? AkademikUnvaniId { get; set; }

        [Display(Name = "Adı")]
        [Required]
        public string Adi { get; set; }

        [Display(Name = "Kızlık Soyadı")]        
        public string KizlikSoyadi { get; set; }

        [Display(Name = "Soyadı")]
        [Required]
        public string Soyadi { get; set; }

        [Display(Name = "Cinsiyeti")]
        public int? CinsId { get; set; }

        [Display(Name = "Kan Grubu")]
        public int? KaninGrubuId { get; set; }

        [Display(Name = "Ph Değeri")]
        public int? PhDegerId { get; set; }

        [Display(Name = "Medeni Hali")]
        public int? MedeniHaliId { get; set; }
        
        [Display(Name = "T.c. Kimlik No")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Türkiye Cumhuriyeti Kimlik No Sayı olmalıdır.")]
        [StringLength(11, MinimumLength = 11 ,ErrorMessage = "Türkiye Cumhuriyeti Kimlik No 11 basamaklı olmalıdır.")]
        public string TurCumKimlikNo { get; set; }

        [Display(Name = "Doğum Tarihi")]
        public string DogumTarihi { get; set; }      
                
        public byte[] Vesikalik { get; set; }

        [Display(Name = "Sicil No")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Sicil No Sayı olmalıdır.")]
        public string SicilNo { get; set; }

        [Display(Name = "Kadro Durumu")]
        public int? KadroDurumuId { get; set; }

        [Display(Name = "Sınıfı")]
        public int? SinifiId { get; set; }

        [Display(Name = "Eş çalışma durumu")]
        public int? EsCalismaDurumuId { get; set; }

        #endregion

        #region görevlendirme verileri

        [Display(Name = "Görevi")]
        public int? GorevId { get; set; }

        [Display(Name = "Ünvanı")]
        public int? UnvanId { get; set; }

        [Display(Name = "Birimi")]
        public int? BirimId { get; set; }

        [Display(Name = "İli")]
        public int? IlId { get; set; }

        [Display(Name = "Görev Başlangıç Tarihi")]
        public string Baslangic { get; set; }

        [Display(Name = "Asil Mi?")]
        public bool AsilMi { get; set; }

        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }

        [Display(Name = "Resmi Görevlendirme mi?")]
        public bool ResmiMi { get; set; }

        #endregion

        #region öğrenim durumu

        [Display(Name = "Öğrenim Durumu")]
        public int? OgrenimDurumuId { get; set; }

        [Display(Name = "Üniversitesi")]
        public int? UniversiteId { get; set; }

        #endregion

        #region iletişim 

        [Display(Name = "Dahili No")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Geçerli bir numara giriniz")]
        public string Dahili { get; set; }

        [Display(Name = "Cep Telefonu")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Geçerli bir numara giriniz")]
        public string CepTelefonu { get; set; }

        [Display(Name = "Bakanlık Eposta")]
        [EmailAddress(ErrorMessage = "Geçersiz Eposta Adresi")]
        public string BakanlikEPosta { get; set; }
        
        [Display(Name = "Gmail Eposta")]
        [EmailAddress(ErrorMessage = "Geçersiz Eposta Adresi")]
        public string GmailEPosta { get; set; }


        #endregion

        #region listeler

        public IEnumerable<SelectListItem> AkademikListe{ get; private set; }
        public IEnumerable<SelectListItem> CinsiyetListe{ get; private set; }
        public IEnumerable<SelectListItem> KanGrubuListe{ get; private set; }
        public IEnumerable<SelectListItem> PhListe{ get; private set; }
        public IEnumerable<SelectListItem> OgrenimDurumuListe{ get; private set; }
        public IEnumerable<SelectListItem> UnvanListe{ get; private set; }
        public IEnumerable<SelectListItem> SinifListe{ get; private set; }
        public IEnumerable<SelectListItem> MedeniDurumuListe{ get; private set; }
        public IEnumerable<SelectListItem> HizmetSonlanisNedeniListe{ get; private set; }
        public IEnumerable<SelectListItem> KadrosuListe{ get; private set; }
        public IEnumerable<SelectListItem> BirimListe{ get; private set; }
        public IEnumerable<SelectListItem> CalismaDurumuListe { get; private set; }
        public IEnumerable<SelectListItem> GorevListe { get; private set; }
        public IEnumerable<SelectListItem> IlListe { get; private set; }
        #endregion

        public IlklendirEkleCalisanIletisimGorevEgitimViewModel(bool basariliMi):base(basariliMi)
        {

            this.AkademikListe = new List<SelectListItem>();
            this.CinsiyetListe = new List<SelectListItem>();
            this.KanGrubuListe = new List<SelectListItem>();
            this.PhListe = new List<SelectListItem>();
            this.OgrenimDurumuListe = new List<SelectListItem>();
            this.UnvanListe = new List<SelectListItem>();
            this.SinifListe = new List<SelectListItem>();
            this.MedeniDurumuListe = new List<SelectListItem>();
            this.HizmetSonlanisNedeniListe = new List<SelectListItem>();
            this.KadrosuListe = new List<SelectListItem>();
            this.BirimListe = new List<SelectListItem>();
            this.CalismaDurumuListe = new List<SelectListItem>();
            this.GorevListe = new List<SelectListItem>();
            this.IlListe = new List<SelectListItem>();
        }

        public IlklendirEkleCalisanIletisimGorevEgitimViewModel(IEnumerable<SelectListItem> akademikListe, IEnumerable<SelectListItem> cinsiyetListe,
            IEnumerable<SelectListItem> kanGrubuListe, IEnumerable<SelectListItem> phListe, IEnumerable<SelectListItem> ogrenimDurumuListe,
            IEnumerable<SelectListItem> unvanListe, IEnumerable<SelectListItem> sinifListe, IEnumerable<SelectListItem> medeniDurumuListe, 
            IEnumerable<SelectListItem> hizmetSonlanisNedeniListe, IEnumerable<SelectListItem> kadrosuListe, IEnumerable<SelectListItem> birimListe, 
            IEnumerable<SelectListItem> calismaDurumuListe, IEnumerable<SelectListItem> gorevListe, IEnumerable<SelectListItem> ilListe) : this(true)
        {
            this.AkademikListe = akademikListe;
            this.CinsiyetListe = cinsiyetListe;
            this.KanGrubuListe = kanGrubuListe;
            this.PhListe = phListe;
            this.OgrenimDurumuListe = ogrenimDurumuListe;
            this.UnvanListe = unvanListe;
            this.SinifListe = sinifListe;
            this.MedeniDurumuListe = medeniDurumuListe;
            this.HizmetSonlanisNedeniListe = hizmetSonlanisNedeniListe;
            this.KadrosuListe = kadrosuListe;
            this.BirimListe = birimListe;
            this.CalismaDurumuListe = calismaDurumuListe;
            this.GorevListe = gorevListe;
            this.IlListe = ilListe;
            this.BasariliMi = !(akademikListe == null || cinsiyetListe == null || kanGrubuListe == null || phListe == null ||
                ogrenimDurumuListe == null|| unvanListe == null || sinifListe == null || medeniDurumuListe == null || hizmetSonlanisNedeniListe == null
                || kadrosuListe == null || birimListe==null || calismaDurumuListe == null);
        }

        public IlklendirEkleCalisanIletisimGorevEgitimViewModel(Exception hata):this(false)
        {
            this.kurHata(hata);
        }

    }
}
