using DKMPKisiUygulamasi.Servis.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.CalisanKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.GorevlendirmeKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.CalisanKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.GorevlendirmeKlasor;
using DKMPKisiUygulamasi.Model.IsKatmani.Soyut;
using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using DKMPKisiUygulamasi.Model.SabitlerMesajlar;
using DKMPKisiUygulamasi.Model.IsKatmani.Somut;
using DKMPKurumCografyaUygulamasi.Servis.ViewModel.VarlikKlasor;
using DKMPKisiUygulamasi.Model.Somut.RaporKlasor;
using DKMPKisiUygulamasi.Model.Somut.TanimlayiciKlasor;
using DKMPKisiUygulamasi.Model.Somut.HataKlasoru;
using DKMPKisiUygulamasi.Model.Somut.OgrenimKlasor;

namespace DKMPKisiUygulamasi.Servis.Somut
{
    public class CalisanServis : ICalisanServis
    {

        private ITanimlayiciVarlikIsKurali _tanimlayiciVarlikIsKurali;
        private ICalisanIsKurali _calisanIsKurali;
        private IGorevlendirmeIsKurali _gorevlendirmeIsKurali;
        private Kontrol _kontrol;
        private HataServis _hataServis;

        public CalisanServis(ITanimlayiciVarlikIsKurali tanimlayiciVarlikIsKurali, ICalisanIsKurali calisanIsKurali, IGorevlendirmeIsKurali gorevlendirmeIsKurali)
        {
            this._tanimlayiciVarlikIsKurali = tanimlayiciVarlikIsKurali;
            this._calisanIsKurali = calisanIsKurali;
            this._gorevlendirmeIsKurali = gorevlendirmeIsKurali;
            this._kontrol = new Kontrol();
            this._hataServis = new HataServis();
        }
        
        public EkleCalisanYanit EkleCalisan(EkleCalisanIstek istek)
        {

            try
            {                
                int sonucId = int.MinValue;
                string adi = string.Empty;
                string soyadi = string.Empty;
                Cinsiyeti cinsiyeti = Cinsiyeti.Tanimsiz;
                AkademikUnvani unvani = AkademikUnvani.Tanimsiz;
                KanGrubu kaninGrubu = KanGrubu.Tanimsiz;
                RhDegeri phDeger = RhDegeri.Tanimsiz;
                MedeniDurumu medeniHali = MedeniDurumu.Tanimsiz;
                string turCumKimlikNo = string.Empty;
                DateTime dogumTarihi = Sabitler.BosTarih;
                string sicilNo = string.Empty;
                Kadrosu kadroDurumu = Kadrosu.Tanimsiz;
                Sinif sinifi = Sinif.Tanimsiz;
                EkleCalisanYanit yanit = new EkleCalisanYanit(false);
                Calisan calisan = null;

                if (!this._kontrol.uygunMu(istek))
                {
                    yanit.IsaretleGecemediIlkKontrolu(this._kontrol.alHataKodu(istek));
                    return yanit;
                }

                adi = istek.Adi;
                soyadi = istek.Soyadi;
                cinsiyeti = (Cinsiyeti)Enum.ToObject(typeof(Cinsiyeti), istek.CinsiyetId);
                unvani = (AkademikUnvani)Enum.ToObject(typeof(AkademikUnvani), istek.AkademikUnvanId);
                kaninGrubu = (KanGrubu)Enum.ToObject(typeof(KanGrubu), istek.KanGrubuId);
                phDeger = (RhDegeri)Enum.ToObject(typeof(RhDegeri), istek.PhDegerId);
                medeniHali = (MedeniDurumu)Enum.ToObject(typeof(MedeniDurumu), istek.MedeniDurumId);
                turCumKimlikNo = istek.TurCumKimlikNo;
                dogumTarihi = Arac.CevirTarihe(istek.DogumTarihi);
                sicilNo = istek.SicilNo;
                kadroDurumu = (Kadrosu)Enum.ToObject(typeof(Kadrosu), istek.KadrosuId);
                sinifi = (Sinif)Enum.ToObject(typeof(Sinif), istek.SinifId);

                calisan = new Calisan(adi, soyadi, cinsiyeti, unvani, kaninGrubu, phDeger, medeniHali, turCumKimlikNo, dogumTarihi, sicilNo, kadroDurumu, sinifi);

                sonucId = this._calisanIsKurali.EkleCalisan(calisan);

                yanit = new EkleCalisanYanit(sonucId);

                return yanit;
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
                return new EkleCalisanYanit(hata);
            }

        }

        public GetirCalisanRaporBirYanit GetirCalisanRaporBir(GetirCalisanRaporBirIstek istek)
        {
                        
            try
            {
                IEnumerable<BirimViewModel> birimListe = null;
                BirimServis birimServis = new BirimServis();
                GetirCalisanRaporBirYanit yanit = new GetirCalisanRaporBirYanit(false);
                int kullaniciId = int.MinValue;
                IEnumerable<CalisanRaporBir> calisanRaporBirListe = new List<CalisanRaporBir>();

                if (!this._kontrol.uygunMu(istek))
                {
                    yanit.IsaretleGecemediIlkKontrolu(this._kontrol.alHataKodu(istek));
                    return yanit;
                }

                kullaniciId = istek.KullaniciId ?? int.MinValue;

                if (kullaniciId == int.MinValue)
                    throw new ArgumentException();

                birimListe = birimServis.getirBirimKullanicininGorebilecegi(kullaniciId);

                if (birimListe == null)
                    throw new ApplicationException();

                calisanRaporBirListe = this._gorevlendirmeIsKurali.GetirCalisanRaporBir(birimListe);

                if (calisanRaporBirListe == null)
                    throw new ApplicationException();

                yanit = new GetirCalisanRaporBirYanit(calisanRaporBirListe);

                return yanit;
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
                return new GetirCalisanRaporBirYanit(hata);
            }

        }

        public IlklendirCalisanEkleYanit IlklendirCalisanEkle(IlklendirCalisanEkleIstek istek)
        {

            try
            {
                IlklendirCalisanEkleYanit yanit = new IlklendirCalisanEkleYanit(false);
                IEnumerable<AkademikUnvani> akademikUnvanListe = new List<AkademikUnvani>();
                IEnumerable<Cinsiyeti> cinsiyetListe = new List<Cinsiyeti>();
                IEnumerable<KanGrubu> kanGrubuListe = new List<KanGrubu>();
                IEnumerable<RhDegeri> phDegeriListe = new List<RhDegeri>();
                IEnumerable<OgrenimDurumu> ogrenimDurumuListe = new List<OgrenimDurumu>();
                IEnumerable<Unvan> unvanListe = new List<Unvan>();
                IEnumerable<Sinif> sinifListe = new List<Sinif>();
                IEnumerable<MedeniDurumu> medeniDurumuListe = new List<MedeniDurumu>();
                IEnumerable<Kadrosu> kadrosuListe = new List<Kadrosu>();

                if(!this._kontrol.uygunMu(istek))
                {
                    yanit.IsaretleGecemediIlkKontrolu(this._kontrol.alHataKodu(istek));
                    return yanit;
                }

                akademikUnvanListe = this._tanimlayiciVarlikIsKurali.GetirAkademikUnvanListe(true);

                if (akademikUnvanListe == null || akademikUnvanListe.Any())
                {
                    akademikUnvanListe = new List<AkademikUnvani>();
                    this._hataServis.YazHata(new IslemBasarisizHatasi(Arac.AlHataLokasyonu<CalisanServis>(173)));
                }

                cinsiyetListe = this._tanimlayiciVarlikIsKurali.GetirCinsiyetListe(true);

                if (cinsiyetListe == null || cinsiyetListe.Any())
                {
                    cinsiyetListe = new List<Cinsiyeti>();
                    this._hataServis.YazHata(new IslemBasarisizHatasi(Arac.AlHataLokasyonu<CalisanServis>(181)));
                }

                kanGrubuListe = this._tanimlayiciVarlikIsKurali.GetirKanGrubuListe(true);

                if (kanGrubuListe == null || kanGrubuListe.Any())
                {
                    kanGrubuListe = new List<KanGrubu>();
                    this._hataServis.YazHata(new IslemBasarisizHatasi(Arac.AlHataLokasyonu<CalisanServis>(189)));
                }

                phDegeriListe = this._tanimlayiciVarlikIsKurali.GetirPhDegeriListe(true);

                if (phDegeriListe == null || phDegeriListe.Any())
                {
                    phDegeriListe = new List<RhDegeri>();
                    this._hataServis.YazHata(new IslemBasarisizHatasi(Arac.AlHataLokasyonu<CalisanServis>(197)));
                }

                ogrenimDurumuListe = this._tanimlayiciVarlikIsKurali.GetirOgrenimDurumuListe(true);

                if (ogrenimDurumuListe == null || ogrenimDurumuListe.Any())
                {
                    ogrenimDurumuListe = new List<OgrenimDurumu>();
                    this._hataServis.YazHata(new IslemBasarisizHatasi(Arac.AlHataLokasyonu<CalisanServis>(205)));
                }

                unvanListe = this._tanimlayiciVarlikIsKurali.GetirUnvanListe(true);

                if (unvanListe == null || unvanListe.Any())
                {
                    unvanListe = new List<Unvan>();
                    this._hataServis.YazHata(new IslemBasarisizHatasi(Arac.AlHataLokasyonu<CalisanServis>(213)));
                }

                sinifListe = this._tanimlayiciVarlikIsKurali.GetirSinifListe(true);

                if (sinifListe == null || sinifListe.Any())
                {
                    sinifListe = new List<Sinif>();
                    this._hataServis.YazHata(new IslemBasarisizHatasi(Arac.AlHataLokasyonu<CalisanServis>(221)));
                }

                medeniDurumuListe = this._tanimlayiciVarlikIsKurali.GetirMedeniDurumuListe(true);

                if (medeniDurumuListe == null || medeniDurumuListe.Any())
                {
                    medeniDurumuListe = new List<MedeniDurumu>();
                    this._hataServis.YazHata(new IslemBasarisizHatasi(Arac.AlHataLokasyonu<CalisanServis>(229)));
                }

                kadrosuListe = this._tanimlayiciVarlikIsKurali.GetirKadrosuListe(true);

                if (kadrosuListe == null || kadrosuListe.Any())
                {
                    kadrosuListe = new List<Kadrosu>();
                    this._hataServis.YazHata(new IslemBasarisizHatasi(Arac.AlHataLokasyonu<CalisanServis>(237)));
                }

                yanit = new IlklendirCalisanEkleYanit(akademikUnvanListe, cinsiyetListe, kanGrubuListe, phDegeriListe, ogrenimDurumuListe, unvanListe,
                    sinifListe, medeniDurumuListe, kadrosuListe);

                return yanit;
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
                return new IlklendirCalisanEkleYanit(hata);                
            }

        }

        public SorgulaCalisanYanit SorgulaCalisan(SorgulaCalisanIstek istek)
        {
            try
            {
                SorgulaCalisanYanit yanit = new SorgulaCalisanYanit(false);
                IEnumerable<Calisan> calisanListe = null;

                if (!this._kontrol.uygunMu(istek))
                {
                    yanit.IsaretleGecemediIlkKontrolu(this._kontrol.alHataKodu(istek));
                    return yanit;
                }

                calisanListe = this._calisanIsKurali.SorgulaCalisan(istek.SorguSozcesi);

                if (calisanListe == null)
                    throw new IslemBasarisizHatasi();

                yanit = new SorgulaCalisanYanit(calisanListe);

                return yanit;
            }
            catch (IslemBasarisizHatasi hata)
            {
                this._hataServis.YazHata(hata);
                return new SorgulaCalisanYanit(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
                return new SorgulaCalisanYanit(hata);
            }

        }
    }
}
