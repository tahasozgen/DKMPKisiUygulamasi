using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.TanimlayiciKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DKMPKisiUygulamasi.CakmaWCF.Mesajlar.Somut.Yanit
{
    public class IlklendirCalisanEkleYanitViewModel : YanitBaz
    {
        public IEnumerable<SelectListItem> AkademikUnvanListe { get; private set; }
        public IEnumerable<SelectListItem> CinsiyetListe { get; private set; }
        public IEnumerable<SelectListItem> KanGrubuListe { get; private set; }
        public IEnumerable<SelectListItem> PhDegeriListe { get; private set; }
        public IEnumerable<SelectListItem> OgrenimDurumuListe { get; private set; }
        public IEnumerable<SelectListItem> UnvanListe { get; private set; }
        public IEnumerable<SelectListItem> SinifListe { get; private set; }
        public IEnumerable<SelectListItem> MedeniDurumuListe { get; private set; }
        public IEnumerable<SelectListItem> KadrosuListe { get; private set; }

        private IlklendirCalisanEkleYanitViewModel() : base()
        {
            this.AkademikUnvanListe = new List<SelectListItem>();
            this.CinsiyetListe = new List<SelectListItem>();
            this.KanGrubuListe = new List<SelectListItem>();
            this.PhDegeriListe = new List<SelectListItem>();
            this.OgrenimDurumuListe = new List<SelectListItem>();
            this.UnvanListe = new List<SelectListItem>();
            this.SinifListe = new List<SelectListItem>();
            this.MedeniDurumuListe = new List<SelectListItem>();
            this.KadrosuListe = new List<SelectListItem>();
        }

        public IlklendirCalisanEkleYanitViewModel(bool basariliMi) : this()
        {
            this.BasariliMi = basariliMi;
        }

        public IlklendirCalisanEkleYanitViewModel(Exception hata) : this()
        {
            this.Hata = hata;
            this.BasariliMi = false;
        }

        public IlklendirCalisanEkleYanitViewModel(IEnumerable<SelectListItem> akademikUnvanListe, IEnumerable<SelectListItem> cinsiyetListe, IEnumerable<SelectListItem> kanGrubuListe,
           IEnumerable<SelectListItem> phDegeriListe, IEnumerable<SelectListItem> ogrenimDurumuListe, IEnumerable<SelectListItem> unvanListe, IEnumerable<SelectListItem> sinifListe,
           IEnumerable<SelectListItem> medeniDurumuListe, IEnumerable<SelectListItem> kadrosuListe) : this()
        {
            this.AkademikUnvanListe = akademikUnvanListe;
            this.CinsiyetListe = cinsiyetListe;
            this.KanGrubuListe = kanGrubuListe;
            this.PhDegeriListe = phDegeriListe;
            this.OgrenimDurumuListe = ogrenimDurumuListe;
            this.UnvanListe = unvanListe;
            this.SinifListe = sinifListe;
            this.MedeniDurumuListe = medeniDurumuListe;
            this.KadrosuListe = kadrosuListe;
        }

    }
}
