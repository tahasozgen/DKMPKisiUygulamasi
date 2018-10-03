using DKMPKisiUygulamasi.Presentation.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.IslemKlasor;
using DKMPKisiUygulamasi.Servis.Soyut;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.CalisanKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.CalisanKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.GorevlendirmeKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.GorevlendirmeKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.OgrenimKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.OgrenimKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.KisiIletisimKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.KisiIletisimKlasoru;
using DKMPKisiUygulamasi.Presentation.Mesajlar.Somut.Yanit;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.TanimlayiciKlasor;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.GorevKlasoru;
using DKMPKurumCografyaUygulamasi.Servis.ViewModel.VarlikKlasor;
using DKMPKurumCografyaUygulamasi.Servis.Somut;

namespace DKMPKisiUygulamasi.Presentation.Somut
{
    public class TopluIslemPresentation : PresentationBaz,ITopluIslemPresentation
    {
        private readonly ICalisanServis _calisanServis;

        private readonly IGorevlendirmeServis _gorevlendirmeServis;

        private readonly IOgrenimServis _ogrenimServis;

        private readonly IKisiIletisimServis _kisiIletisimServis;

        private readonly ITanimlayiciVarlikServis _tanimlayiciVarlikServis;

        private readonly KurumCografyaServis _kurumCografyaServis;

        private TopluIslemPresentation():base()
        {
            this._kurumCografyaServis = new KurumCografyaServis("");
        }

        public TopluIslemPresentation(ICalisanServis calisanServis, IGorevlendirmeServis gorevlendirmeServis, IOgrenimServis ogrenimServis, IKisiIletisimServis kisiIletisimServis, ITanimlayiciVarlikServis tanimlayiciVarlikServis) : this()
        {
            this._calisanServis = calisanServis;
            this._gorevlendirmeServis = gorevlendirmeServis;
            this._ogrenimServis = ogrenimServis;
            this._kisiIletisimServis = kisiIletisimServis;
            this._tanimlayiciVarlikServis = tanimlayiciVarlikServis;
        }

        private int ekleCalisan(int akademikUnvanId, string adi, string kizlikSoyadi, string soyadi, int cinsiyetId, int kanGrubuId,
            int phDegerId, int medeniDurumId, string turCumKimlikNo, string dogumTarihi, string ibanNo, byte[] resim, 
            string sicilNo, int kadrosuId, int sinifId)
        {
            try
            {

                EkleCalisanYanit yanit = null;
                EkleCalisanIstek istek = null;

                istek = new EkleCalisanIstek(akademikUnvanId, adi, kizlikSoyadi, soyadi, cinsiyetId, kanGrubuId,
                 phDegerId, medeniDurumId, turCumKimlikNo, dogumTarihi, ibanNo, resim,
                 sicilNo, kadrosuId, sinifId);

                yanit = this._calisanServis.EkleCalisan(istek);

                if (yanit == null)
                    throw new ApplicationException();

                if (!yanit.BasariliMi)
                    throw new ApplicationException();

                return yanit.IslemId;
            }
            catch (Exception)
            {

                throw;
            }


        }

        private bool ekleGorevlendirme(int calisanId, int birimId, int gorevId, string baslangicTarihi, bool asilMi, string aciklama, int unvanId, bool resmiMi, int ilId)
        {

            try
            {
                GorevlendirCalisanYanit yanit = null;
                GorevlendirCalisanIstek istek = null;

                istek = new GorevlendirCalisanIstek(calisanId, birimId, gorevId, baslangicTarihi, asilMi, aciklama, unvanId, resmiMi, ilId);

                yanit = this._gorevlendirmeServis.GorevlendirCalisan(istek);

                if (yanit == null)
                    throw new ApplicationException();

                if (!yanit.BasariliMi)
                    throw new ApplicationException();

                return yanit.BasariliMi;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private bool ekleOgrenim(int kullaniciId,int calisanId, int ogrenimDurumuId, int universiteId)
        {

            try
            {
                EkleKisiOgrenimYanit yanit = null;
                EkleKisiOgrenimIstek istek = null;

                istek = new EkleKisiOgrenimIstek(kullaniciId,calisanId, ogrenimDurumuId, universiteId);

                yanit = this._ogrenimServis.EkleKisiOgrenim(istek);

                if (yanit == null)
                    throw new ApplicationException();

                if (!yanit.BasariliMi)
                    throw new ApplicationException();

                return yanit.BasariliMi;
            }
            catch (Exception hata)
            {
                throw hata;
            }

        }

        private bool ekleIletisimDahili(int kullaniciId, int calisanId, string dahili)
        {

            try
            {
                EkleKisiIletisimYanit yanit = null;
                EkleKisiIletisimIstek istek = null;

                istek = new EkleKisiIletisimIstek(kullaniciId, calisanId, dahili, 24);

                yanit = this._kisiIletisimServis.EkleKisiIletisim(istek);

                if (yanit == null)
                    throw new ApplicationException();

                if(!yanit.BasariliMi)
                    throw new ApplicationException();

                return yanit.BasariliMi;

            }
            catch (Exception hata)
            {
                throw hata;
            }

        }

        private bool ekleIletisimBakanlikEposta(int kullaniciId, int calisanId, string eposta)
        {

            try
            {
                EkleKisiIletisimYanit yanit = null;
                EkleKisiIletisimIstek istek = null;

                istek = new EkleKisiIletisimIstek(kullaniciId, calisanId, eposta, 3);

                yanit = this._kisiIletisimServis.EkleKisiIletisim(istek);

                if (yanit == null)
                    throw new ApplicationException();

                if (!yanit.BasariliMi)
                    throw new ApplicationException();

                return yanit.BasariliMi;

            }
            catch (Exception hata)
            {
                throw hata;
            }

        }

        private bool ekleIletisimCepTelefonu(int kullaniciId, int calisanId, string cepTelefonu)
        {

            try
            {
                EkleKisiIletisimYanit yanit = null;
                EkleKisiIletisimIstek istek = null;

                istek = new EkleKisiIletisimIstek(kullaniciId, calisanId, cepTelefonu, 17);

                yanit = this._kisiIletisimServis.EkleKisiIletisim(istek);

                if (yanit == null)
                    throw new ApplicationException();

                if (!yanit.BasariliMi)
                    throw new ApplicationException();

                return yanit.BasariliMi;

            }
            catch (Exception hata)
            {
                throw hata;
            }

        }
            
        public EkleCalisanIletisimGorevEgitimYanitViewModel Ekle(IlklendirEkleCalisanIletisimGorevEgitimViewModel model)
        {
            try
            {

                EkleCalisanIletisimGorevEgitimYanitViewModel yanit = new EkleCalisanIletisimGorevEgitimYanitViewModel(false);
                int akademikUnvanId, cinsiyetId, kanGrubuId, phDegerId, medeniDurumId,
                    kadrosuId, sinifId, birimId, gorevId, unvanId, ilId, ogrenimDurumuId, universiteId,kullaniciId = int.MinValue;
                byte[] resim = null;
                int calisanId = int.MinValue;
                bool asilMi, resmiMi, sonucCalisanEkleme, sonucEkleGorevlendirme, sonucEkleOgrenim, sonucEkleDahili, sonucEkleBakanlikEposta, sonucEkleCepTelefonu = true;

                if (!this._kontrol.uygunMu(model))
                {
                    yanit.IsaretleGecemediIlkKontrolu(this._kontrol.alHataKodu(model));
                    return yanit;
                }

                kullaniciId = model.KullaniciId ?? int.MinValue;
                akademikUnvanId = model.AkademikUnvaniId ?? int.MinValue;
                cinsiyetId = model.CinsId ?? int.MinValue;
                kanGrubuId = model.KaninGrubuId ?? int.MinValue;
                phDegerId = model.PhDegerId ?? int.MinValue;
                medeniDurumId = model.MedeniHaliId ?? int.MinValue;
                kadrosuId = model.KadroDurumuId ?? int.MinValue;
                sinifId = model.SinifiId ?? int.MinValue;

                calisanId = this.ekleCalisan(akademikUnvanId, model.Adi, model.KizlikSoyadi, model.Soyadi, cinsiyetId, kanGrubuId, phDegerId, medeniDurumId, model.TurCumKimlikNo, model.DogumTarihi, model.IbanNo, resim, model.SicilNo, kadrosuId, sinifId);
                sonucCalisanEkleme = calisanId != int.MinValue;

                if (!sonucCalisanEkleme)
                    return new EkleCalisanIletisimGorevEgitimYanitViewModel(sonucCalisanEkleme, sonucCalisanEkleme);

                birimId = model.BirimId ?? int.MinValue;
                gorevId = model.GorevId ?? int.MinValue;
                asilMi = model.AsilMi ?? true;
                resmiMi = model.ResmiMi ?? true;
                unvanId = model.UnvanId ?? int.MinValue;
                ilId = model.IlId ?? int.MinValue;

                sonucEkleGorevlendirme = this.ekleGorevlendirme(calisanId, birimId, gorevId, model.Baslangic, asilMi, model.Aciklama, unvanId, resmiMi, ilId);

                if (!sonucEkleGorevlendirme)
                    return new EkleCalisanIletisimGorevEgitimYanitViewModel(sonucCalisanEkleme, sonucCalisanEkleme, sonucEkleGorevlendirme);

                ogrenimDurumuId = model.OgrenimDurumuId ?? int.MinValue;
                universiteId = model.UniversiteId ?? int.MinValue;

                sonucEkleOgrenim = this.ekleOgrenim(kullaniciId, calisanId, ogrenimDurumuId, universiteId);

                if (!sonucEkleOgrenim)
                    return new EkleCalisanIletisimGorevEgitimYanitViewModel(false, sonucCalisanEkleme, sonucEkleGorevlendirme, sonucEkleOgrenim);

                sonucEkleDahili = this.ekleIletisimDahili(kullaniciId, calisanId, model.Dahili);

                sonucEkleBakanlikEposta = this.ekleIletisimBakanlikEposta(kullaniciId, calisanId, model.BakanlikEPosta);

                sonucEkleCepTelefonu = this.ekleIletisimCepTelefonu(kullaniciId, calisanId, model.CepTelefonu);

                yanit = new EkleCalisanIletisimGorevEgitimYanitViewModel(sonucCalisanEkleme, sonucCalisanEkleme, sonucEkleOgrenim, sonucEkleOgrenim, sonucEkleDahili, sonucEkleCepTelefonu, sonucEkleBakanlikEposta);

                return yanit;
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
                return new EkleCalisanIletisimGorevEgitimYanitViewModel(hata);
            }
        }

        public IlklendirEkleCalisanIletisimGorevEgitimViewModel IlklendirEkle()
        {

            try
            {
                IlklendirEkleCalisanIletisimGorevEgitimViewModel yanit = new IlklendirEkleCalisanIletisimGorevEgitimViewModel(false);
                List<AkademikUnvaniViewModel> akademikListe = null;
                List<CinsiyetiViewModel> cinsiyetListe = null;
                List<KanGrubuViewModel> kanGrubuListe = null;
                List<PhDegeriViewModel> phListe = null;
                List<OgrenimDurumuViewModel> ogrenimDurumuListe = null;
                List<UnvanViewModel> unvanListe = null;
                List<SinifViewModel> sinifListe = null;
                List<MedeniDurumuViewModel> medeniDurumuListe = null;
                List<HizmetSonlanisNedeniViewModel> hizmetSonlanisNedeniListe = null;
                List<KadrosuViewModel> kadrosuListe = null;
                List<BirimViewModel> birimListe = null;
                bool tumuGetirilsinMi = true;

                akademikListe = this._cevir.cevir(this._tanimlayiciVarlikServis.GetirAkademikUnvanListe(tumuGetirilsinMi).ToList());

                if (akademikListe == null)
                    throw new ApplicationException();

                cinsiyetListe = this._cevir.cevir(this._tanimlayiciVarlikServis.GetirCinsiyetListe(tumuGetirilsinMi).ToList());

                if (cinsiyetListe == null)
                    throw new ApplicationException();

                kanGrubuListe = this._cevir.cevir(this._tanimlayiciVarlikServis.GetirKanGrubuListe(tumuGetirilsinMi).ToList());

                if (kanGrubuListe == null)
                    throw new ApplicationException();

                phListe = this._cevir.cevir(this._tanimlayiciVarlikServis.GetirPhDegeriListe(tumuGetirilsinMi).ToList());

                if (phListe == null)
                    throw new ApplicationException();


                ogrenimDurumuListe = this._cevir.cevir(this._tanimlayiciVarlikServis.GetirOgrenimDurumuListe(tumuGetirilsinMi).ToList());

                if (ogrenimDurumuListe == null)
                    throw new ApplicationException();

                unvanListe = this._cevir.cevir(this._tanimlayiciVarlikServis.GetirUnvanListe(tumuGetirilsinMi).ToList());

                if (unvanListe == null)
                    throw new ApplicationException();

                sinifListe = this._cevir.cevir(this._tanimlayiciVarlikServis.GetirSinifListe(tumuGetirilsinMi).ToList());

                if (sinifListe == null)
                    throw new ApplicationException();

                medeniDurumuListe = this._cevir.cevir(this._tanimlayiciVarlikServis.GetirMedeniDurumuListe(tumuGetirilsinMi).ToList());

                if (medeniDurumuListe == null)
                    throw new ApplicationException();

                hizmetSonlanisNedeniListe = this._cevir.cevir(this._tanimlayiciVarlikServis.GetirHizmetSonlanisNedeniListe(tumuGetirilsinMi).ToList());

                if (hizmetSonlanisNedeniListe == null)
                    throw new ApplicationException();

                kadrosuListe = this._cevir.cevir(this._tanimlayiciVarlikServis.GetirKadrosuListe(tumuGetirilsinMi).ToList());

                if (kadrosuListe == null)
                    throw new ApplicationException();

                birimListe = this._kurumCografyaServis.GetirBirimListe(true).ToList();

                if (birimListe == null)
                    throw new ApplicationException();

                yanit = new IlklendirEkleCalisanIletisimGorevEgitimViewModel(akademikListe, cinsiyetListe, kanGrubuListe,
                    phListe, ogrenimDurumuListe, unvanListe, sinifListe, medeniDurumuListe, hizmetSonlanisNedeniListe, kadrosuListe,
                    birimListe);

                return yanit;
            }
            catch (ApplicationException hata)
            {
                this._hataServis.YazHata(hata);
                return new IlklendirEkleCalisanIletisimGorevEgitimViewModel(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
                return new IlklendirEkleCalisanIletisimGorevEgitimViewModel(hata);
            }

        }
    }
}
