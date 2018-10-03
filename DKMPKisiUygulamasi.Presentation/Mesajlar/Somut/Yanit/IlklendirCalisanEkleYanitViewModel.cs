using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.TanimlayiciKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.Mesajlar.Somut.Yanit
{
    public class IlklendirCalisanEkleYanitViewModel : YanitBaz
    {
        public IEnumerable<AkademikUnvaniViewModel> AkademikUnvanListe { get; private set; }
        public IEnumerable<CinsiyetiViewModel> CinsiyetListe { get; private set; }
        public IEnumerable<KanGrubuViewModel> KanGrubuListe { get; private set; }
        public IEnumerable<PhDegeriViewModel> PhDegeriListe { get; private set; }
        public IEnumerable<OgrenimDurumuViewModel> OgrenimDurumuListe { get; private set; }
        public IEnumerable<UnvanViewModel> UnvanListe { get; private set; }
        public IEnumerable<SinifViewModel> SinifListe { get; private set; }
        public IEnumerable<MedeniDurumuViewModel> MedeniDurumuListe { get; private set; }
        public IEnumerable<KadrosuViewModel> KadrosuListe { get; private set; }

        private IlklendirCalisanEkleYanitViewModel() : base()
        {
            this.AkademikUnvanListe = new List<AkademikUnvaniViewModel>();
            this.CinsiyetListe = new List<CinsiyetiViewModel>();
            this.KanGrubuListe = new List<KanGrubuViewModel>();
            this.PhDegeriListe = new List<PhDegeriViewModel>();
            this.OgrenimDurumuListe = new List<OgrenimDurumuViewModel>();
            this.UnvanListe = new List<UnvanViewModel>();
            this.SinifListe = new List<SinifViewModel>();
            this.MedeniDurumuListe = new List<MedeniDurumuViewModel>();
            this.KadrosuListe = new List<KadrosuViewModel>();
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

        public IlklendirCalisanEkleYanitViewModel(IEnumerable<AkademikUnvaniViewModel> akademikUnvanListe, IEnumerable<CinsiyetiViewModel> cinsiyetListe, IEnumerable<KanGrubuViewModel> kanGrubuListe,
           IEnumerable<PhDegeriViewModel> phDegeriListe, IEnumerable<OgrenimDurumuViewModel> ogrenimDurumuListe, IEnumerable<UnvanViewModel> unvanListe, IEnumerable<SinifViewModel> sinifListe,
           IEnumerable<MedeniDurumuViewModel> medeniDurumuListe, IEnumerable<KadrosuViewModel> kadrosuListe) : this()
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
