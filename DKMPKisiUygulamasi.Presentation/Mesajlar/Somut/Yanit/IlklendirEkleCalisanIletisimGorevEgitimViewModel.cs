using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.IslemKlasor;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.GorevKlasoru;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.TanimlayiciKlasor;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Soyut;
using DKMPKurumCografyaUygulamasi.Servis.ViewModel.VarlikKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.Mesajlar.Somut.Yanit
{
    public class IlklendirEkleCalisanIletisimGorevEgitimViewModel : IslemBazViewModel
    {
        public int? KullaniciId { get; set; }

        #region çalışan verileri

        public int? AkademikUnvaniId { get; set; }

        public string Adi { get; set; }

        public string KizlikSoyadi { get; set; }

        public string Soyadi { get; set; }

        public int? CinsId { get; set; }

        public int? KaninGrubuId { get; set; }

        public int? PhDegerId { get; set; }

        public int? MedeniHaliId { get; set; }

        public string TurCumKimlikNo { get; set; }

        public string DogumTarihi { get; set; }

        public string IbanNo { get; set; }

        public byte[] Vesikalik { get; set; }

        public string SicilNo { get; set; }

        public int? KadroDurumuId { get; set; }

        public int? SinifiId { get; set; }

        public int? EsCalismaDurumuId { get; set; }

        #endregion

        #region görevlendirme verileri
        public int? GorevId { get; set; }

        public int? UnvanId { get; set; }

        public int? BirimId { get; set; }

        public int? IlId { get; set; }

        public string Baslangic { get; set; }

        public bool? AsilMi { get; set; }

        public string Aciklama { get; set; }

        public bool? ResmiMi { get; set; }

        #endregion

        #region öğrenim durumu

        public int? OgrenimDurumuId { get; set; }

        public int? UniversiteId { get; set; }

        #endregion

        #region iletişim 

        public string Dahili { get; set; }

        public string CepTelefonu { get; set; }

        public string BakanlikEPosta { get; set; }

        #endregion

        #region listeler
        public IEnumerable<AkademikUnvaniViewModel> AkademikListe{ get; private set; }
        public IEnumerable<CinsiyetiViewModel> CinsiyetListe{ get; private set; }
        public IEnumerable<KanGrubuViewModel> KanGrubuListe{ get; private set; }
        public IEnumerable<PhDegeriViewModel> PhListe{ get; private set; }
        public IEnumerable<OgrenimDurumuViewModel>OgrenimDurumuListe{ get; private set; }
        public IEnumerable<UnvanViewModel> UnvanListe{ get; private set; }
        public IEnumerable<SinifViewModel> SinifListe{ get; private set; }
        public IEnumerable<MedeniDurumuViewModel> MedeniDurumuListe{ get; private set; }
        public IEnumerable<HizmetSonlanisNedeniViewModel> HizmetSonlanisNedeniListe{ get; private set; }
        public IEnumerable<KadrosuViewModel> KadrosuListe{ get; private set; }
        public IEnumerable<BirimViewModel> BirimListe{ get; private set; }
        
        #endregion

        public IlklendirEkleCalisanIletisimGorevEgitimViewModel(bool basariliMi):base(basariliMi)
        {

            this.AkademikListe = new List<AkademikUnvaniViewModel>();
            this.CinsiyetListe = new List<CinsiyetiViewModel>();
            this.KanGrubuListe = new List<KanGrubuViewModel>();
            this.PhListe = new List<PhDegeriViewModel>();
            this.OgrenimDurumuListe = new List<OgrenimDurumuViewModel>();
            this.UnvanListe = new List<UnvanViewModel>();
            this.SinifListe = new List<SinifViewModel>();
            this.MedeniDurumuListe = new List<MedeniDurumuViewModel>();
            this.HizmetSonlanisNedeniListe = new List<HizmetSonlanisNedeniViewModel>();
            this.KadrosuListe = new List<KadrosuViewModel>();
            this.BirimListe = new List<BirimViewModel>();
        }

        public IlklendirEkleCalisanIletisimGorevEgitimViewModel(IEnumerable<AkademikUnvaniViewModel> akademikListe, IEnumerable<CinsiyetiViewModel> cinsiyetListe, IEnumerable<KanGrubuViewModel> kanGrubuListe, IEnumerable<PhDegeriViewModel> phListe, IEnumerable<OgrenimDurumuViewModel> ogrenimDurumuListe, IEnumerable<UnvanViewModel> unvanListe, IEnumerable<SinifViewModel> sinifListe, IEnumerable<MedeniDurumuViewModel> medeniDurumuListe, IEnumerable<HizmetSonlanisNedeniViewModel> hizmetSonlanisNedeniListe, IEnumerable<KadrosuViewModel> kadrosuListe, IEnumerable<BirimViewModel> birimListe) : this(true)
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
            this.BasariliMi = !(akademikListe == null || cinsiyetListe == null || kanGrubuListe == null || phListe == null ||
                ogrenimDurumuListe == null|| unvanListe == null || sinifListe == null || medeniDurumuListe == null || hizmetSonlanisNedeniListe == null
                || kadrosuListe == null || birimListe==null);
        }

        public IlklendirEkleCalisanIletisimGorevEgitimViewModel(Exception hata):this(false)
        {
            this.kurHata(hata);
        }

    }
}
