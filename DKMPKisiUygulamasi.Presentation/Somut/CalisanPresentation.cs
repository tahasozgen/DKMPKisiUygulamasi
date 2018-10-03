using DKMPKisiUygulamasi.Presentation.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPKisiUygulamasi.Presentation.Mesajlar.Somut.Istek;
using DKMPKisiUygulamasi.Presentation.Mesajlar.Somut.Yanit;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.TanimlayiciKlasor;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.RaporKlasor;

using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.CalisanKlasor;
using DKMPKisiUygulamasi.Servis.Soyut;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.CalisanKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.GorevlendirmeKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.GorevlendirmeKlasor;

namespace DKMPKisiUygulamasi.Presentation.Somut
{
    public class CalisanPresentation : PresentationBaz,ICalisanPresentation
    {
        private ICalisanServis _calisanServis;
        
        private CalisanPresentation():base()
        {
        }

        public CalisanPresentation(ICalisanServis calisanServis) :this()
        {
            this._calisanServis = calisanServis;
        }

        public SorgulaCalisanYanitViewModel SorgulaCalisan(SorgulaCalisanIstekViewModel istek)
        {
            try
            {

                SorgulaCalisanYanitViewModel yanit = new SorgulaCalisanYanitViewModel(false);
                SorgulaCalisanYanit modelYanit = null;
                SorgulaCalisanIstek modelistek = null;
                int kullaniciId = int.MinValue;
                List<CalisanViewModel> vmListe = new List<CalisanViewModel>();

                if (!this._kontrol.uygunMu(istek))
                {
                    yanit.IsaretleGecemediIlkKontrolu(this._kontrol.alHataKodu(istek));
                    return yanit;
                }

                kullaniciId = istek.KullaniciId ?? int.MinValue;

                if (kullaniciId == int.MinValue)
                    throw new ArgumentException();

                modelistek = new SorgulaCalisanIstek(kullaniciId, istek.SorguSozcesi);

                modelYanit = this._calisanServis.SorgulaCalisan(modelistek);

                if (modelYanit == null)
                    throw new ApplicationException();

                if (!modelYanit.BasariliMi)
                    throw new ApplicationException();

                vmListe = this._cevir.cevir(modelYanit.Liste.ToList());

                if (vmListe == null)
                    throw new ApplicationException();

                yanit = new SorgulaCalisanYanitViewModel(vmListe);

                return yanit;
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
                return new SorgulaCalisanYanitViewModel(hata);
            }


        }

        public IlklendirCalisanEkleYanitViewModel IlklendirCalisanEkle(IlklendirCalisanEkleIstekViewModel istek)
        {

            try
            {
                IlklendirCalisanEkleYanitViewModel yanit = new IlklendirCalisanEkleYanitViewModel(false);
                IEnumerable<AkademikUnvaniViewModel> akademikUnvanListe = null;
                IEnumerable<CinsiyetiViewModel> cinsiyetListe = null;
                IEnumerable<KanGrubuViewModel> kanGrubuListe = null;
                IEnumerable<PhDegeriViewModel> phDegeriListe = null;
                IEnumerable<OgrenimDurumuViewModel> ogrenimDurumuListe = null;
                IEnumerable<UnvanViewModel> unvanListe = null;
                IEnumerable<SinifViewModel> sinifListe = null;
                IEnumerable<MedeniDurumuViewModel> medeniDurumuListe = null;
                IEnumerable<KadrosuViewModel> kadrosuListe = null;
                IlklendirCalisanEkleYanit modelYanit = null;
                IlklendirCalisanEkleIstek modelIstek = null;
                int kullaniciId = int.MinValue;

                if (!this._kontrol.uygunMu(istek))
                {
                    yanit.IsaretleGecemediIlkKontrolu(this._kontrol.alHataKodu(istek));
                    return yanit;
                }

                kullaniciId = istek.KullaniciId ?? int.MinValue;

                if (kullaniciId == int.MinValue)
                    throw new ArgumentException();

                modelIstek = new IlklendirCalisanEkleIstek(kullaniciId);

                modelYanit = this._calisanServis.IlklendirCalisanEkle(modelIstek);

                if (modelYanit == null)
                    throw new ApplicationException();

                if (!modelYanit.BasariliMi)
                    throw new ApplicationException();

                akademikUnvanListe = this._cevir.cevir(modelYanit.AkademikUnvanListe.ToList());

                if (akademikUnvanListe == null)
                    throw new ApplicationException();

                cinsiyetListe = this._cevir.cevir(modelYanit.CinsiyetListe.ToList());

                if (cinsiyetListe == null)
                    throw new ApplicationException();

                kanGrubuListe = this._cevir.cevir(modelYanit.KanGrubuListe.ToList());

                if (kanGrubuListe == null)
                    throw new ApplicationException();

                phDegeriListe = this._cevir.cevir(modelYanit.PhDegeriListe.ToList());

                if (phDegeriListe == null)
                    throw new ApplicationException();

                ogrenimDurumuListe = this._cevir.cevir(modelYanit.OgrenimDurumuListe.ToList());

                if (ogrenimDurumuListe == null)
                    throw new ApplicationException();

                unvanListe = this._cevir.cevir(modelYanit.UnvanListe.ToList());

                if (unvanListe == null)
                    throw new ApplicationException();

                sinifListe = this._cevir.cevir(modelYanit.SinifListe.ToList());

                if (sinifListe == null)
                    throw new ApplicationException();

                medeniDurumuListe = this._cevir.cevir(modelYanit.MedeniDurumuListe.ToList());

                if (medeniDurumuListe == null)
                    throw new ApplicationException();

                kadrosuListe = this._cevir.cevir(modelYanit.KadrosuListe.ToList());

                if (kadrosuListe == null)
                    throw new ApplicationException();

                yanit = new IlklendirCalisanEkleYanitViewModel(akademikUnvanListe, cinsiyetListe, kanGrubuListe, phDegeriListe, ogrenimDurumuListe,
                    unvanListe, sinifListe, medeniDurumuListe, kadrosuListe);

                return yanit;
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
                return new IlklendirCalisanEkleYanitViewModel(hata);
            }

        }

        public EkleCalisanYanit EkleCalisan(EkleCalisanIstek istek)
        {

            try
            {
                EkleCalisanYanit yanit = new EkleCalisanYanit(false);

                if (!this._kontrol.uygunMu(istek))
                {
                    yanit.IsaretleGecemediIlkKontrolu(this._kontrol.alHataKodu(istek));
                    return yanit;
                }

                yanit = this._calisanServis.EkleCalisan(istek);

                if (yanit == null)
                    throw new ApplicationException();

                if (!yanit.BasariliMi)
                    throw new ApplicationException();

                return yanit;
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
                return new EkleCalisanYanit(hata);
            }
            
        }

        public GetirCalisanRaporBirYanitViewModel GetirCalisanRaporBir(GetirCalisanRaporBirIstekViewModel istek)
        {
            
            try
            {
                GetirCalisanRaporBirYanit servisYanit = null;
                GetirCalisanRaporBirIstek servisIstek = null;
                GetirCalisanRaporBirYanitViewModel yanit = new GetirCalisanRaporBirYanitViewModel(false);
                int kullaniciId = int.MinValue;
                List<CalisanRaporBirViewModel> vmListe = null;

                if (!this._kontrol.uygunMu(istek))
                {
                    yanit.IsaretleGecemediIlkKontrolu(this._kontrol.alHataKodu(istek));
                    return yanit;
                }

                kullaniciId = istek.KullaniciId ?? int.MinValue;

                if (kullaniciId == int.MinValue)
                    throw new ArgumentException();

                servisIstek = new GetirCalisanRaporBirIstek(kullaniciId);

                servisYanit = this._calisanServis.GetirCalisanRaporBir(servisIstek);

                if (servisYanit == null)
                    throw new ApplicationException();

                if (!servisYanit.BasariliMi)
                    throw new ApplicationException();

                vmListe = this._cevir.cevir(servisYanit.Liste.ToList());

                if (vmListe == null)
                    throw new ApplicationException();

                yanit = new GetirCalisanRaporBirYanitViewModel(vmListe);

                return yanit;

            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
                return new GetirCalisanRaporBirYanitViewModel(hata);
            }
        }
    }
}
