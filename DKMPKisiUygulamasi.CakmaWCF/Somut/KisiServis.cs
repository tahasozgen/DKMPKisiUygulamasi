using DKMPKisiUygulamasi.CakmaWCF.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.CalisanKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.GorevlendirmeKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.CalisanKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.GorevlendirmeKlasor;
using DKMPKisiUygulamasi.Servis.Soyut;
using DKMPKisiUygulamasi.CakmaWCF.Altyapi;
using DKMPKisiUygulamasi.CakmaWCF.Mesajlar.Somut.Istek;
using DKMPKisiUygulamasi.CakmaWCF.Mesajlar.Somut.Yanit;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.RaporKlasor;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.GorevKlasoru;
using DKMPKurumCografyaUygulamasi.Servis.ViewModel.VarlikKlasor;
using DKMPKurumCografyaUygulamasi.Servis.Somut;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.OgrenimKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.OgrenimKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.KisiIletisimKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.KisiIletisimKlasoru;
using System.Web.Mvc;
using DKMPKisiUygulamasi.Model.SabitlerMesajlar;
using DKMPKisiUygulamasi.Model.Somut.HataKlasoru;
using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;

namespace DKMPKisiUygulamasi.CakmaWCF.Somut
{

    public class KisiServis : IKisiServis
    {
        private readonly ICalisanServis _calisanServis;

        private readonly IGorevlendirmeServis _gorevlendirmeServis;

        private readonly IOgrenimServis _ogrenimServis;

        private readonly IKisiIletisimServis _kisiIletisimServis;

        private readonly ITanimlayiciVarlikServis _tanimlayiciVarlikServis;

        private readonly HataServis _hataServis;

        private readonly Kontrol _kontrol;

        private readonly Cevir _cevir;

        private readonly KurumCografyaServis _kurumCografyaServis;

        public KisiServis()
        {
            this._calisanServis = NesneFabrikasiBirimTesti.Ornek.AlOrnek<ICalisanServis>();

            this._gorevlendirmeServis = NesneFabrikasiBirimTesti.Ornek.AlOrnek<IGorevlendirmeServis>();

            this._ogrenimServis = NesneFabrikasiBirimTesti.Ornek.AlOrnek<IOgrenimServis>();

            this._kisiIletisimServis = NesneFabrikasiBirimTesti.Ornek.AlOrnek<IKisiIletisimServis>();

            this._tanimlayiciVarlikServis = NesneFabrikasiBirimTesti.Ornek.AlOrnek<ITanimlayiciVarlikServis>();

            this._hataServis = new HataServis();

            this._kontrol = new Kontrol();

            this._cevir = new Cevir();

            //TODO: buraya bağlantı cümlesi gelecek.
            this._kurumCografyaServis = new KurumCografyaServis(Sabitler.KurumCografyaServisBaglantiCumlesi);
                
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

        private bool ekleOgrenim(int kullaniciId, int calisanId, int ogrenimDurumuId, int universiteId)
        {

            try
            {
                EkleKisiOgrenimYanit yanit = null;
                EkleKisiOgrenimIstek istek = null;

                istek = new EkleKisiOgrenimIstek(kullaniciId, calisanId, ogrenimDurumuId, universiteId);

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

                if (!yanit.BasariliMi)
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
        
        private BirimViewModel getirBirim(CalisanGorevlendirme deger)
        {

            try
            {
                BirimViewModel birimVm = null;

                if (deger == null)
                    throw new ArgumentNullException();

                birimVm = _kurumCografyaServis.GetirBirim(deger.BirimId);

                return birimVm;
            }
            catch (ArgumentNullException)
            {
                
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return null;

        }

        private IlViewModel getirIl(CalisanGorevlendirme deger)
        {

            try
            {
                IlViewModel ilVm = null;
                int ilId = int.MinValue;

                if (deger == null)
                    throw new ArgumentNullException();

                ilId = deger.IlId ?? int.MinValue;

                if (ilId == int.MinValue)
                    throw new ArgumentException();

                ilVm = _kurumCografyaServis.GetirIl(ilId);

                return ilVm;
            }
            catch (ArgumentException)
            {

            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return null;

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
                List<SelectListItem> akademikUnvanListe = null;
                List<SelectListItem> cinsiyetListe = null;
                List<SelectListItem> kanGrubuListe = null;
                List<SelectListItem> phDegeriListe = null;
                List<SelectListItem> ogrenimDurumuListe = null;
                List<SelectListItem> unvanListe = null;
                List<SelectListItem> sinifListe = null;
                List<SelectListItem> medeniDurumuListe = null;
                List<SelectListItem> kadrosuListe = null;
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
            return this._calisanServis.EkleCalisan(istek);
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
        
        public IlklendirCalisanGorevlendirmeYanitViewModel IlklendirCalisanGorevlendirme(IlklendirCalisanGorevlendirmeIstekViewModel istek)
        {
            try
            {
                IlklendirCalisanGorevlendirmeYanitViewModel yanit = new IlklendirCalisanGorevlendirmeYanitViewModel(false);
                IlklendirCalisanGorevlendirmeYanit servisYanit = null;
                IlklendirCalisanGorevlendirmeIstek servisIstek = null;
                int kullaniciId, gorevlendirilecekCalisanId = int.MinValue;
                CalisanViewModel calisanVm = null;
                CalisanGorevlendirmeViewModel gorevlendirmeVm = null;
                IEnumerable<SelectListItem> gorevVmListe = null;
                BirimViewModel birimVm = null;              
                IlViewModel ilVm = null;


                if (!this._kontrol.uygunMu(istek))
                {
                    yanit.IsaretleGecemediIlkKontrolu(this._kontrol.alHataKodu(istek));
                    return yanit;
                }

                kullaniciId = istek.KullaniciId ?? int.MinValue;
                gorevlendirilecekCalisanId = istek.GorevlendirilecekCalisanId ?? int.MinValue;

                servisIstek = new IlklendirCalisanGorevlendirmeIstek(kullaniciId, gorevlendirilecekCalisanId);

                servisYanit = this._gorevlendirmeServis.IlklendirCalisanGorevlendirme(servisIstek);

                if (servisYanit == null)
                    throw new ApplicationException();

                if (!servisYanit.BasariliMi)
                    throw new ApplicationException();

                calisanVm = this._cevir.cevir(servisYanit.Calisani);

                if (calisanVm == null)
                    throw new ApplicationException();

                birimVm = this.getirBirim(servisYanit.MevcutGorevi);

                ilVm = this.getirIl(servisYanit.MevcutGorevi);

                gorevlendirmeVm = this._cevir.cevir(servisYanit.MevcutGorevi, birimVm,ilVm);

                if (gorevlendirmeVm == null)
                    throw new ApplicationException();

                gorevVmListe = this._cevir.cevir(servisYanit.GorevListe.ToList());

                if (gorevVmListe == null)
                    throw new ApplicationException();

                yanit = new IlklendirCalisanGorevlendirmeYanitViewModel(calisanVm, gorevlendirmeVm, servisYanit.BirimListe, gorevVmListe, servisYanit.IlListe);

                return yanit;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public GorevlendirCalisanYanit GorevlendirCalisan(GorevlendirCalisanIstek istek)
        {
            try
            {
                GorevlendirCalisanYanit yanit = new GorevlendirCalisanYanit(false);

                if (!this._kontrol.uygunMu(istek))
                {
                    yanit.IsaretleGecemediIlkKontrolu(this._kontrol.alHataKodu(istek));
                    return yanit;
                }

                yanit = this._gorevlendirmeServis.GorevlendirCalisan(istek);

                if (yanit == null)
                    throw new ApplicationException();

                if (!yanit.BasariliMi)
                    throw new ApplicationException();

                return yanit;
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
                return new GorevlendirCalisanYanit(hata);
            }
        }
        
        public SorgulaGorevlendirCalisanYanitViewModel SorgulaGorevlendirCalisan(SorgulaGorevlendirCalisanIstekViewModel istek)
        {
            try
            {

                SorgulaGorevlendirCalisanYanitViewModel yanit = new SorgulaGorevlendirCalisanYanitViewModel(false);
                SorgulaGorevlendirCalisanYanit servisYanit = null;
                SorgulaGorevlendirCalisanIstek servisIstek = null;
                DateTime tarih = DateTime.MinValue;
                int kullaniciId = int.MinValue;
                List<CalisanGorevlendirmeViewModel> vmListe = null;

                if (!this._kontrol.uygunMu(istek))
                {
                    yanit.IsaretleGecemediIlkKontrolu(this._kontrol.alHataKodu(istek));
                    return yanit;
                }

                tarih = istek.Tarihi ?? DateTime.MinValue;
                kullaniciId = istek.KullaniciId ?? int.MinValue;

                if (kullaniciId == int.MinValue)
                    throw new ApplicationException();

                servisIstek = new SorgulaGorevlendirCalisanIstek(kullaniciId, tarih);

                servisYanit = this._gorevlendirmeServis.SorgulaCalisanGorevlendirme(servisIstek);

                if (servisYanit == null)
                    throw new ApplicationException();

                if (!servisYanit.BasariliMi)
                    throw new ApplicationException();

                vmListe = this._cevir.cevir(servisYanit.Liste.ToList());

                if (vmListe == null)
                    throw new ApplicationException();

                yanit = new SorgulaGorevlendirCalisanYanitViewModel(vmListe);

                return yanit;
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
                return new SorgulaGorevlendirCalisanYanitViewModel(hata);
            }

        }

        public GetirCalisanOzetYanitViewModel GetirCalisanOzet(GetirCalisanOzetIstekViewModel istek)
        {
            try
            {
                GetirCalisanOzetYanitViewModel yanit = new GetirCalisanOzetYanitViewModel(false);
                GetirCalisanOzetYanit servisYanit = new GetirCalisanOzetYanit(true);
                GetirCalisanOzetIstek servisIstek = null;
                int kullaniciId = int.MinValue;
                DateTime tarihi = DateTime.MinValue;
                List<CalisanOzetViewModel> vmListe = null;

                if (!this._kontrol.uygunMu(istek))
                {
                    yanit.IsaretleGecemediIlkKontrolu(this._kontrol.alHataKodu(istek));
                    return yanit;
                }

                kullaniciId = istek.KullaniciId ?? int.MinValue;

                if (kullaniciId == int.MinValue)
                    throw new ArgumentException();
                
                if(istek.girildiMiTarih)
                {
                    tarihi = istek.Tarihi ?? DateTime.MinValue;

                    if (tarihi == DateTime.MinValue)
                        throw new ArgumentException();

                    servisIstek = new GetirCalisanOzetIstek(kullaniciId, tarihi);

                    servisYanit = this._gorevlendirmeServis.GetirCalisanOzet(servisIstek);

                    if (servisYanit == null)
                        throw new ApplicationException();

                    if (!servisYanit.BasariliMi)
                        throw new ApplicationException();

                }else if(istek.girildiMiSozce)
                {
                    servisIstek = new GetirCalisanOzetIstek(kullaniciId, istek.SorguSozcesi);

                    servisYanit = this._gorevlendirmeServis.GetirCalisanOzet(servisIstek);

                    if (servisYanit == null)
                        throw new ApplicationException();

                    if (!servisYanit.BasariliMi)
                        throw new ApplicationException();
                }
                
                vmListe = this._cevir.cevir(servisYanit.Liste.ToList());

                if (vmListe == null)
                    throw new ApplicationException();

                yanit = new GetirCalisanOzetYanitViewModel(vmListe);

                return yanit;
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
                return new GetirCalisanOzetYanitViewModel(hata);
            }
        }   
        
        public IlklendirEkleCalisanIletisimGorevEgitimViewModel IlklendirEkleCalisanIletisimGorevEgitim()
        {
            try
            {
                IlklendirEkleCalisanIletisimGorevEgitimViewModel yanit = new IlklendirEkleCalisanIletisimGorevEgitimViewModel(false);
                List<SelectListItem> akademikListe = null;
                List<SelectListItem> cinsiyetListe = null;
                List<SelectListItem> kanGrubuListe = null;
                List<SelectListItem> phListe = null;
                List<SelectListItem> ogrenimDurumuListe = null;
                List<SelectListItem> unvanListe = null;
                List<SelectListItem> sinifListe = null;
                List<SelectListItem> medeniDurumuListe = null;
                List<SelectListItem> hizmetSonlanisNedeniListe = null;
                List<SelectListItem> kadrosuListe = null;
                List<BirimViewModel> birimListe = null;
                List<SelectListItem> birimslcListe = null;
                List<SelectListItem> esCalismaDurumuListe = null;
                List<SelectListItem> gorevListe = null;
                IEnumerable<IlViewModel> ilListe = null;
                List<SelectListItem> ilslcListe = null;
                bool tumuGetirilsinMi = true;

                //TODO: selectlistitemların burada üretilmesi doğru değildir, presentation katmanında AkademikUnvaniViewModel listesinin selectlistitem'a çevrilmesi gerekir. 
                
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

                birimslcListe = this._cevir.cevir(birimListe.ToList());

                if (birimslcListe == null)
                    throw new ApplicationException();

                esCalismaDurumuListe = this._cevir.cevir(this._tanimlayiciVarlikServis.GetirCalismaDurumuListe(tumuGetirilsinMi).ToList());

                if (esCalismaDurumuListe == null)
                    throw new ApplicationException();

                gorevListe = this._cevir.cevir(this._tanimlayiciVarlikServis.GetirGoreviListe(tumuGetirilsinMi).ToList());
                
                if (gorevListe == null)
                    throw new ApplicationException();

                ilListe = this._kurumCografyaServis.GetirIlListe(tumuGetirilsinMi);

                if (ilListe == null)
                {
                    IslemBasarisizHatasi hata = new IslemBasarisizHatasi(DKMPKisiUygulamasi.Model.IsKatmani.Somut.Arac.AlHataLokasyonu<KisiServis>(746));
                    this._hataServis.YazHata(hata);
                }

                ilslcListe = this._cevir.cevir(ilListe.ToList());

                if (ilslcListe == null)
                {
                    IslemBasarisizHatasi hata = new IslemBasarisizHatasi(DKMPKisiUygulamasi.Model.IsKatmani.Somut.Arac.AlHataLokasyonu<KisiServis>(754));
                    this._hataServis.YazHata(hata);
                }

                yanit = new IlklendirEkleCalisanIletisimGorevEgitimViewModel(akademikListe, cinsiyetListe, kanGrubuListe,
                    phListe, ogrenimDurumuListe, unvanListe, sinifListe, medeniDurumuListe, hizmetSonlanisNedeniListe, kadrosuListe,
                    birimslcListe, esCalismaDurumuListe, gorevListe, ilslcListe);

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

        public EkleCalisanIletisimGorevEgitimYanitViewModel Ekle(IlklendirEkleCalisanIletisimGorevEgitimViewModel model)
        {
            try
            {

                EkleCalisanIletisimGorevEgitimYanitViewModel yanit = new EkleCalisanIletisimGorevEgitimYanitViewModel(false);
                int akademikUnvanId, cinsiyetId, kanGrubuId, phDegerId, medeniDurumId,
                    kadrosuId, sinifId, birimId, gorevId, unvanId, ilId, ogrenimDurumuId, universiteId, kullaniciId = int.MinValue;
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

                calisanId = this.ekleCalisan(akademikUnvanId, model.Adi, model.KizlikSoyadi, model.Soyadi, cinsiyetId, kanGrubuId, phDegerId, medeniDurumId, model.TurCumKimlikNo, model.DogumTarihi, null, resim, model.SicilNo, kadrosuId, sinifId);
                sonucCalisanEkleme = calisanId != int.MinValue;

                if (!sonucCalisanEkleme)
                    return new EkleCalisanIletisimGorevEgitimYanitViewModel(sonucCalisanEkleme, sonucCalisanEkleme);

                birimId = model.BirimId ?? int.MinValue;
                gorevId = model.GorevId ?? int.MinValue;
                asilMi = model.AsilMi;
                resmiMi = model.ResmiMi;
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

        
    }
}
