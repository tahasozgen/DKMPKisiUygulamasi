using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.Somut.OgrenimKlasor;
using DKMPKisiUygulamasi.Model.Somut.TanimlayiciKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.CalisanKlasor
{
    public class IlklendirCalisanEkleYanit : YanitBaz
    {
        public IEnumerable<AkademikUnvani> AkademikUnvanListe { get; private set; }
        public IEnumerable<Cinsiyeti> CinsiyetListe { get; private set; }
        public IEnumerable<KanGrubu> KanGrubuListe { get; private set; }
        public IEnumerable<RhDegeri> PhDegeriListe { get; private set; }
        public IEnumerable<OgrenimDurumu> OgrenimDurumuListe { get; private set; }
        public IEnumerable<Unvan> UnvanListe { get; private set; }
        public IEnumerable<Sinif> SinifListe { get; private set; }
        public IEnumerable<MedeniDurumu> MedeniDurumuListe { get; private set; }
        public IEnumerable<Kadrosu> KadrosuListe { get; private set; }

        private IlklendirCalisanEkleYanit() : base()
        {
            this.AkademikUnvanListe = new List<AkademikUnvani>();
            this.CinsiyetListe = new List<Cinsiyeti>();
            this.KanGrubuListe = new List<KanGrubu>();
            this.PhDegeriListe = new List<RhDegeri>();
            this.OgrenimDurumuListe = new List<OgrenimDurumu>();
            this.UnvanListe = new List<Unvan>();
            this.SinifListe = new List<Sinif>();
            this.MedeniDurumuListe = new List<MedeniDurumu>();
            this.KadrosuListe = new List<Kadrosu>();
        }

        public IlklendirCalisanEkleYanit(bool basariliMi) : this()
        {
            this.BasariliMi = basariliMi;          
        }

        public IlklendirCalisanEkleYanit(Exception hata) : this()
        {
            this.kurHata(hata);
        }

        public IlklendirCalisanEkleYanit(IEnumerable<AkademikUnvani> akademikUnvanListe, IEnumerable<Cinsiyeti> cinsiyetListe, IEnumerable<KanGrubu> kanGrubuListe,
           IEnumerable<RhDegeri> phDegeriListe, IEnumerable<OgrenimDurumu> ogrenimDurumuListe, IEnumerable<Unvan> unvanListe, IEnumerable<Sinif> sinifListe,
           IEnumerable<MedeniDurumu> medeniDurumuListe, IEnumerable<Kadrosu> kadrosuListe) : this()
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
