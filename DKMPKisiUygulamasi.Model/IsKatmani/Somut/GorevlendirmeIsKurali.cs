using DKMPKisiUygulamasi.Model.IsKatmani.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;
using DKMPKisiUygulamasi.Model.Somut.RaporKlasor;
using DKMPKurumCografyaUygulamasi.Servis.ViewModel.VarlikKlasor;
using DKMPKisiUygulamasi.Model.RepositoryKlasoru;
using DKMPKisiUygulamasi.Model.Somut.HataKlasoru;
using DKMPKisiUygulamasi.Model.Somut.TanimlayiciKlasor;
using DKMPKisiUygulamasi.Model.SabitlerMesajlar;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.Somut.IletisimKlasor;
using DKMPKisiUygulamasi.Model.Somut.OgrenimKlasor;

namespace DKMPKisiUygulamasi.Model.IsKatmani.Somut
{
    public class GorevlendirmeIsKurali : IGorevlendirmeIsKurali
    {        
        private ICalisanGorevRepository _calisanGorevRepository;

        private IGorevRepository _gorevRepository;

        private IUnvanRepository _unvanRepository;

        private IKisiIletisimRepository _kisiIletisim;

        private IKisiOgrenimRepository _kisiOgrenimRepository;

        private HataIsKurali _hataIsKurali;

        private Kontrol _kontrol;

        public GorevlendirmeIsKurali(ICalisanGorevRepository repository, IGorevRepository tanimlayiciVarlikRepository,IUnvanRepository unvanRepository,IKisiIletisimRepository kisiIletisim, IKisiOgrenimRepository kisiOgrenimRepository)
        {
            if (repository == null || tanimlayiciVarlikRepository == null || unvanRepository == null) 
                throw new ArgumentNullException();

            this._calisanGorevRepository = repository;
            this._gorevRepository = tanimlayiciVarlikRepository;
            this._kisiIletisim = kisiIletisim;
            this._kisiOgrenimRepository = kisiOgrenimRepository;
            this._unvanRepository = unvanRepository;
            this._kontrol = new Kontrol();
            this._hataIsKurali = new HataIsKurali();
        }
        
        private void yazHata(Exception hata)
        {
            if (hata != null)
            {                
                this._hataIsKurali.YazHata(hata);
            }
        }

        private void yazHata(DKMPHataAltyapi.Soyut.HataBase hata)
        {
            if (hata != null)
            {
                this._hataIsKurali.YazHata(hata);
            }
        }

        private CalisanGorevlendirme getirDevamEdenGorevlendirme(List<CalisanGorevlendirme> liste,bool getirilsinMiSadeceResmiGorevler)
        {

            try
            {
                CalisanGorevlendirme guncelGorevlendirme = null;
                DateTime tarih = Sabitler.BosTarih;
                IEnumerable<CalisanGorevlendirme> altListe = null;

                if (liste == null)
                    throw new ArgumentNullException();

                altListe = this.getirDevamEdenGorevlendirmeListe(liste);

                if (altListe == null)
                    throw new IslemBasarisizHatasi();

                foreach (CalisanGorevlendirme gorevlendirme in altListe.ToList())
                {
                    if (gorevlendirme == null)
                    {
                        BosReferansHatasi hata = new BosReferansHatasi(Arac.AlSinifYolu<CalisanGorevlendirme>(),Arac.AlHataLokasyonu<GorevlendirmeIsKurali>(76));
                        this.yazHata(hata);
                        continue;
                    }                       

                    if(getirilsinMiSadeceResmiGorevler && !gorevlendirme.ResmiMi)                    
                        continue;
                    
                    if (tarih < gorevlendirme.Baslangic)
                    {
                        tarih = gorevlendirme.Baslangic;
                        guncelGorevlendirme = gorevlendirme;
                    }

                }

                return guncelGorevlendirme;

            }
            catch (ArgumentNullException)
            {
                
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }

            return null;

        }

        private List<CalisanGorevlendirme> getirDevamEdenGorevlendirmeListe(List<CalisanGorevlendirme> liste)
        {
            try
            {
                IEnumerable<CalisanGorevlendirme> altListe = null;

                if (liste == null)
                    throw new ArgumentNullException();

                altListe = liste.Where(p => p.Bitis.Equals(Sabitler.BosTarih));

                return (liste != null) ? altListe.ToList() : new List<CalisanGorevlendirme>();

            }
            catch (ArgumentNullException)
            {
                
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }

            return new List<CalisanGorevlendirme>();

        }

        private CalisanGorevlendirme getirCalisaninGorevlendirmesi(List<CalisanGorevlendirme> liste, int calisanId,bool getirilsinMiSadeceResmiGorev)
        {

            try
            {
                IEnumerable<CalisanGorevlendirme> calisanGorevlendirmeListe = null;

                if (liste == null)
                    throw new ArgumentNullException();

                if (calisanId == int.MinValue)
                    throw new ArgumentException(calisanId.GetType().ToString());

                calisanGorevlendirmeListe = liste.Where(p => p.CalisanId == calisanId);

                if (calisanGorevlendirmeListe == null)
                    return null;

                return this.getirDevamEdenGorevlendirme(calisanGorevlendirmeListe.ToList(), getirilsinMiSadeceResmiGorev);

            }
            catch (ArgumentException)
            {
                
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }

            return null;
        }

        private bool yapilabilirMiGorevlendirme(int calisanId, CalisanGorevlendirme yeniGorevlendirme)
        {

            try
            {
                bool sonuc = true;
                CalisanGorevlendirme deJure = null;
                bool getirilsinMiSadeceResmiGorevler = true;
                IEnumerable<CalisanGorevlendirme> gorevlendirmeListe = null;

                if (calisanId == int.MinValue)
                    throw new ArgumentException(calisanId.GetType().ToString());

                if (yeniGorevlendirme == null)
                    throw new ArgumentNullException();

                gorevlendirmeListe = this._calisanGorevRepository.GetirGorevlendirmeListe(calisanId);

                if (gorevlendirmeListe == null)
                {
                    IslemBasarisizHatasi hata = new IslemBasarisizHatasi(Arac.AlHataLokasyonu<GorevlendirmeIsKurali>(162));
                    this.yazHata(hata);
                    gorevlendirmeListe = new List<CalisanGorevlendirme>();
                }

                deJure = this.getirDevamEdenGorevlendirme(gorevlendirmeListe.ToList(), getirilsinMiSadeceResmiGorevler);

                if (yeniGorevlendirme.ResmiMi)                
                    return (deJure == null) ? sonuc : !(yeniGorevlendirme.AsilMi == deJure.AsilMi);                
                else                
                    sonuc = (deJure != null);
                
                return sonuc;
            }
            catch (ArgumentNullException)
            {
                
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }

            return false;

        }

        private KisiIletisim getirEnGuncelKisiIletisim(List<KisiIletisim> iletisimListe, IletisimTuru turu)
        {

            try
            {
                IEnumerable<KisiIletisim> liste = null;
                DateTime eklenmeTarihi = Sabitler.BosTarih;
                KisiIletisim iletisim = null;

                if (iletisimListe == null)
                    throw new ArgumentNullException();

                liste = iletisimListe.Where(p => p.Turu == turu);

                if (liste == null)
                    return iletisim;

                foreach (KisiIletisim deger in liste.ToList())
                {
                    if (deger == null)
                        continue;

                    if (eklenmeTarihi < deger.EklenmeTarihi)
                    {
                        eklenmeTarihi = deger.EklenmeTarihi;
                        iletisim = deger;
                    }

                }

                return iletisim;

            }
            catch (ArgumentException)
            {
                
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }

            return null;
        }

        private KisiIletisim[] getirKisiIletisimDizi(int kisiId)
        {
            try
            {

                KisiIletisim[] sonuc = new KisiIletisim[Sabitler.KisiIletisimDiziUzunlugu];
                IEnumerable<KisiIletisim> iletisimListe = null;
                IletisimTuru[] turDizisi = new IletisimTuru[Sabitler.KisiIletisimDiziUzunlugu] { IletisimTuru.Dahili, IletisimTuru.BakanlikEposta, IletisimTuru.CepTelefonu };

                if (kisiId == int.MinValue)
                    throw new ArgumentException();

                iletisimListe = this._kisiIletisim.GetirKisiIletisimListe(kisiId);

                if (iletisimListe == null)
                    throw new IslemBasarisizHatasi();

                for (int i = 0; i < 3; i++)
                {
                    sonuc[i] = this.getirEnGuncelKisiIletisim(iletisimListe.ToList(), turDizisi[i]);
                }

                return sonuc;

            }
            catch (ArgumentException)
            {
                
            }
            catch (IslemBasarisizHatasi hata)
            {
                this.yazHata(hata);
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }

            return new KisiIletisim[3];

        }
 
        public int EkleGorevlendirme(CalisanGorevlendirme deger)
        {

            try
            {
                int sonucId = int.MinValue;
                int calisanId = int.MinValue;

                if (!this._kontrol.uygunMu(deger))
                    return Sabitler.HataliArgumanKodu;

                calisanId = deger.CalisanId ?? int.MinValue;

                if (calisanId == int.MinValue)
                    throw new ApplicationException(calisanId.GetType().ToString());

                if (!this.yapilabilirMiGorevlendirme(calisanId, deger))
                    return Sabitler.IsKuraliHatasiKodu;

                sonucId = this._calisanGorevRepository.EkleGorevveDonAnahtar(deger);

                if (sonucId < 0)
                    throw new IslemBasarisizHatasi();

                return sonucId;

            }
            catch (ArgumentException )
            {
                return Sabitler.HataliArgumanKodu;
            }
            catch (IslemBasarisizHatasi hata)
            {
                this.yazHata(hata);
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }

            return int.MinValue;

        }

        private List<CalisanRaporBir> ekleListeyeYoksaYadaBirArttir(List<CalisanRaporBir> liste, CalisanRaporBir rapor)
        {

            try
            {
                int calisanSayisi = int.MinValue;
                CalisanRaporBir eskiRapor = null;

                if (liste == null)
                    throw new ArgumentNullException();
                if(rapor == null)
                    throw new ArgumentNullException();

                if (liste.Any(p => p.Unvani.Anahtar == rapor.Unvani.Anahtar))
                {
                    eskiRapor = liste.FirstOrDefault(p => p.Unvani.Anahtar == rapor.Unvani.Anahtar);

                    if (eskiRapor != null)
                    {
                        calisanSayisi = eskiRapor.CalisanSayisi;
                        liste.Remove(eskiRapor);
                        rapor.CalisanSayisi += calisanSayisi;
                    }
                    else
                    {
                        BosReferansHatasi hata = new BosReferansHatasi(Arac.AlSinifYolu<CalisanRaporBir>(), Arac.AlHataLokasyonu<GorevlendirmeIsKurali>(160));
                        this.yazHata(hata);
                    }

                }

                liste.Add(rapor);

                return liste;
            }
            catch (ArgumentNullException)
            {
                
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }

            return new List<CalisanRaporBir>();

        }

        private List<CalisanRaporBir> analizEtTekGorevliCalisanlari(List<CalisanGorevlendirme> gorevlendirmeListe,out List<int> cokGorevliCalisanIdListe)
        {
            try
            {

                List<Calisan> calisanListe = new List<Calisan>();
                CalisanRaporBir rapor = null;
                List<CalisanRaporBir> raporListe = new List<CalisanRaporBir>();
                List<int> liste = new List<int>();

                if (gorevlendirmeListe == null)
                    throw new ArgumentNullException();

                //tek görevli çalışanları analiz ediyorum.
                foreach (CalisanGorevlendirme deger in gorevlendirmeListe)
                {
                    if (deger == null || deger.Calisani == null || deger.Unvani == null)
                    {
                        BosReferansHatasi hata = this._hataIsKurali.alHataNesnesi(Arac.AlHataLokasyonu<GorevlendirmeIsKurali>(321), deger, deger.Calisani, deger.Unvani);
                        this.yazHata(hata);
                        continue;
                    }

                    if (calisanListe.Any(p => p.Anahtar == deger.Calisani.Anahtar))
                        continue;

                    calisanListe.Add(deger.Calisani);

                    if (gorevlendirmeListe.Count(p => p.Calisani.Anahtar == deger.CalisanId) == Sabitler.Bir)
                    {
                        //tek görevli çalışan
                        rapor = new CalisanRaporBir(deger.Unvani);
                        raporListe = this.ekleListeyeYoksaYadaBirArttir(raporListe, rapor);

                        if (raporListe == null)
                            throw new IslemBasarisizHatasi();

                    }
                    else
                        liste.Add(deger.Calisani.Anahtar);
                }

                cokGorevliCalisanIdListe = liste;
                return raporListe;
            }
            catch (ArgumentNullException)
            {

            }
            catch (IslemBasarisizHatasi hata)
            {
                this.yazHata(hata);
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }
            cokGorevliCalisanIdListe = new List<int>();
            return new List<CalisanRaporBir>();
        }

        private List<CalisanRaporBir> analizEtCokGorevliCalisanlari(List<CalisanGorevlendirme> gorevlendirmeListe, List<int> cokGorevliCalisanIdListe, List<CalisanRaporBir> oncekiAnalizListesi)
        {
            try
            {
                CalisanGorevlendirme gorevlendirme = null;
                CalisanRaporBir rapor = null;
                bool getirilsinMiSadeceResmiGorev = true;

                if (gorevlendirmeListe == null)
                    throw new ArgumentNullException();
                if (cokGorevliCalisanIdListe == null)
                    throw new ArgumentNullException();
                if( oncekiAnalizListesi == null)
                    throw new ArgumentNullException();
                
                //çok görevli çalışanların de jure görevlendirmelerinin hesaplanması
                foreach (int cokGorevliCalisanId in cokGorevliCalisanIdListe)
                {
                    gorevlendirme = this.getirCalisaninGorevlendirmesi(gorevlendirmeListe, cokGorevliCalisanId, getirilsinMiSadeceResmiGorev);

                    if (gorevlendirme == null)
                    {
                        BosReferansHatasi hata = new BosReferansHatasi(Arac.AlSinifYolu<CalisanGorevlendirme>(), Arac.AlHataLokasyonu<GorevlendirmeIsKurali>(229));
                        this.yazHata(hata);
                        continue;
                    }

                    rapor = new CalisanRaporBir(gorevlendirme.Unvani);

                    oncekiAnalizListesi = this.ekleListeyeYoksaYadaBirArttir(oncekiAnalizListesi, rapor);

                    if (oncekiAnalizListesi == null)
                        throw new IslemBasarisizHatasi();
                    
                }
                
                return oncekiAnalizListesi;

            }
            catch (ArgumentNullException)
            {

            }
            catch (IslemBasarisizHatasi hata)
            {
                this.yazHata(hata);
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }

            return new List<CalisanRaporBir>();

        }
        
        private List<CalisanRaporBir> getirCalisanRaporBirListe(List<CalisanGorevlendirme> gorevlendirmeListe, List<Unvan> unvanListe)
        {

            try
            {
                List<CalisanRaporBir> raporListe = new List<CalisanRaporBir>();
                List<int> cokGorevliCalisanIdListe = new List<int>();

                if (gorevlendirmeListe == null)
                    throw new ArgumentNullException();
                if(unvanListe == null)
                    throw new ArgumentNullException();

                //tek görevli çalışanları analiz ediyorum.
                raporListe = this.analizEtTekGorevliCalisanlari(gorevlendirmeListe, out cokGorevliCalisanIdListe);

                if (raporListe == null)
                    throw new IslemBasarisizHatasi();

                //çok görevli çalışanları analiz ediyorum.
                raporListe = this.analizEtCokGorevliCalisanlari(gorevlendirmeListe, cokGorevliCalisanIdListe, raporListe);

                if (raporListe == null)
                    throw new IslemBasarisizHatasi();

                return raporListe;

            }
            catch (ArgumentException)
            {
                
            }
            catch (IslemBasarisizHatasi hata)
            {
                this.yazHata(hata);
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }
            return new List<CalisanRaporBir>();
        }

        private int hesaplaKidemYili(List<CalisanGorevlendirme> gorevlendirmeListe)
        {

            try
            {
                DateTime gorevBitis = Sabitler.BosTarih;
                TimeSpan aralik = TimeSpan.Zero;
                int kidemYili = int.MinValue;

                if (gorevlendirmeListe == null)
                    throw new ArgumentNullException();

                foreach (CalisanGorevlendirme gorevlendirme in gorevlendirmeListe)
                {

                    if (gorevlendirme == null)
                    {
                        BosReferansHatasi hata = new BosReferansHatasi(Arac.AlSinifYolu<CalisanGorevlendirme>(), Arac.AlHataLokasyonu<GorevlendirmeIsKurali>(491));
                        this.yazHata(hata);
                        continue;
                    }

                    gorevBitis = (gorevlendirme.Bitis != null) ? gorevlendirme.Bitis.Value : DateTime.Now;

                    aralik.Add(gorevBitis.Subtract(gorevlendirme.Baslangic));

                }

                kidemYili = (int)Math.Ceiling(aralik.TotalDays / Sabitler.GunSayisiBirYildaki);

                if (kidemYili < 0)
                {
                    IslemBasarisizHatasi hata = new IslemBasarisizHatasi(Arac.AlHataLokasyonu<GorevlendirmeIsKurali>(738));
                    this.yazHata(hata);
                }

                return kidemYili;
            }
            catch (ArgumentException)
            {
                
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }

            return int.MinValue;

        }

        private List<Calisan> getirCalisanListe(List<CalisanGorevlendirme> liste)
        {

            try
            {
                HashSet<Calisan> calisanhash = new HashSet<Calisan>();
                List<Calisan> calisanListe = new List<Calisan>();

                if (liste == null)
                    throw new ArgumentNullException();

                foreach (CalisanGorevlendirme deger in liste)
                {
                    if (deger == null || deger.Calisani == null)
                        continue;

                    calisanhash.Add(deger.Calisani);
                }

                foreach(Calisan deger in calisanhash)
                {
                    calisanListe.Add(deger);
                }

                return calisanListe;
            }
            catch (ArgumentNullException)
            {
                
            }
            catch (Exception hata)
            {
                this._hataIsKurali.YazHata(hata);
            }

            return new List<Calisan>();
        }


      

        public IEnumerable<CalisanRaporBir> GetirCalisanRaporBir(IEnumerable<BirimViewModel> birimVmListe)
        {
            try
            {
                List<CalisanRaporBir> liste = new List<CalisanRaporBir>();
                IEnumerable<Unvan> unvanListe = null;
                IEnumerable<CalisanGorevlendirme> lokalGorevlendirme = null;
                List<CalisanGorevlendirme> genelListe = new List<CalisanGorevlendirme>();

                 if (birimVmListe == null)
                    throw new ArgumentNullException();

                unvanListe = this._unvanRepository.GetirUnvanListe(true);

                if (unvanListe == null)
                    throw new IslemBasarisizHatasi();

                foreach(BirimViewModel birimVm in birimVmListe.ToList())
                {
                    if(birimVm == null)
                    {
                        BosReferansHatasi hata = new BosReferansHatasi(Arac.AlSinifYolu<BirimViewModel>(), Arac.AlHataLokasyonu<GorevlendirmeIsKurali>(487));
                        this.yazHata(hata);
                        continue;                        
                    }

                    lokalGorevlendirme = this._calisanGorevRepository.GetirGorevlendirmeListeBirimeGore(birimVm.BirimId);

                    if(lokalGorevlendirme == null)
                    {
                        BosReferansHatasi hata = new BosReferansHatasi(Arac.AlSinifYolu<IEnumerable<CalisanGorevlendirme>>(), Arac.AlHataLokasyonu<GorevlendirmeIsKurali>(493));
                        this.yazHata(hata);
                        continue;
                    }

                    genelListe.AddRange(lokalGorevlendirme.ToList());

                }
                
                liste = this.getirCalisanRaporBirListe(genelListe.ToList(), unvanListe.ToList());

                if(liste == null)
                    throw new IslemBasarisizHatasi();

                return liste;

            }
            catch (ArgumentNullException)
            {

            }
            catch (IslemBasarisizHatasi hata)
            {
                this.yazHata(hata);
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }

            return new List<CalisanRaporBir>();
        }

        public CalisanGorevlendirme GetirMevcutGorevi(int calisanId, bool getirilsinMiSadeceResmiGorevler)
        {
            try
            {              
                IEnumerable<CalisanGorevlendirme> liste = null;

                if (calisanId == int.MinValue)
                    throw new ArgumentException(calisanId.GetType().ToString());

                liste = this._calisanGorevRepository.GetirGorevlendirmeListe(calisanId);
                
                if (liste == null)
                    throw new IslemBasarisizHatasi();

                return this.getirDevamEdenGorevlendirme(liste.ToList(), getirilsinMiSadeceResmiGorevler);

            }
            catch (ArgumentException )
            {

            }
            catch (IslemBasarisizHatasi hata)
            {
                this.yazHata(hata);
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }

            return null;
        }

        public int SonlandirMevcutGorevi(int calisanId, DateTime bitisTarihi, int hizmetSonlanisNedenId, string aciklama)
        {

            try
            {
                bool getirilsinMiSadeceResmiGorevler = true;
                CalisanGorevlendirme gorevlendirme = null;
                HizmetSonlanisNedeni nedeni = HizmetSonlanisNedeni.Tanimsiz;
                int islemId = int.MinValue;

                if (calisanId == int.MinValue)
                    throw new ArgumentException(calisanId.GetType().ToString());
                if (bitisTarihi == Sabitler.BosTarih)
                    throw new ArgumentException(bitisTarihi.GetType().ToString());
                if (hizmetSonlanisNedenId == int.MinValue)
                    throw new ArgumentException(hizmetSonlanisNedenId.GetType().ToString());

                nedeni = (HizmetSonlanisNedeni)Enum.ToObject(typeof(HizmetSonlanisNedeni), hizmetSonlanisNedenId);

                gorevlendirme = this.GetirMevcutGorevi(calisanId, getirilsinMiSadeceResmiGorevler);

                if (gorevlendirme == null)
                    throw new IslemBasarisizHatasi();

                gorevlendirme.Bitis = bitisTarihi;
                gorevlendirme.SonlanisNedeni = nedeni;
                gorevlendirme.Aciklama = Arac.KucultveKirp(aciklama);

                islemId = this.GunleGorev(gorevlendirme);

                return islemId;
            }
            catch (ArgumentException)
            {
                
            }
            catch (IslemBasarisizHatasi hata)
            {
                this.yazHata(hata);
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }

            return int.MinValue;
                
        }

        public int GunleGorev(CalisanGorevlendirme deger)
        {
            try
            {
                int calisanId = int.MinValue;

                if (!this._kontrol.uygunMu(deger))
                    return Sabitler.HataliArgumanKodu;

                calisanId = deger.CalisanId ?? int.MinValue;

                if (calisanId == int.MinValue)
                    throw new ArgumentException(calisanId.GetType().ToString());

                if (!this.yapilabilirMiGorevlendirme(calisanId, deger))
                    return Sabitler.IsKuraliHatasiKodu;

                return this._calisanGorevRepository.GunleGorev(deger);
            }
            catch (Exception hata)
            {
                this.yazHata(hata);                
            }

            return int.MinValue;

        }

        public IEnumerable<Gorevi> GetirGorevListe(bool getirilsinMiTumu)
        {

            try
            {
                IEnumerable<Gorevi> liste = null;

                liste = this._gorevRepository.GetirGorevListe(getirilsinMiTumu);

                if (liste == null)
                    throw new IslemBasarisizHatasi();

                return liste;
            }
            catch (IslemBasarisizHatasi hata)
            {
                this._hataIsKurali.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataIsKurali.YazHata(hata);
            }

            return new List<Gorevi>();
        }

        public IEnumerable<CalisanGorevlendirme> GetirCalisanGorevlendirmeListe(DateTime tarih)
        {

            try
            {
                IEnumerable<CalisanGorevlendirme> liste = null;

                if (tarih == Sabitler.BosTarih)
                    throw new ArgumentException();

                liste = this._calisanGorevRepository.GetirGorevlendirmeListe(tarih);

                if (liste == null)
                    throw new IslemBasarisizHatasi();

                return liste;
            }
            catch (IslemBasarisizHatasi hata)
            {
                this._hataIsKurali.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataIsKurali.YazHata(hata);
            }

            return new List<CalisanGorevlendirme>();

        }

        public int HesaplaKidemYili(int calisanId)
        {
            try
            {                
                IEnumerable<CalisanGorevlendirme> gorevlendirmeIenListe = null;             
                TimeSpan aralik = TimeSpan.Zero;
                DateTime gorevBitis = Sabitler.BosTarih;

                if (calisanId == int.MinValue)
                    throw new ArgumentException();

                gorevlendirmeIenListe = this._calisanGorevRepository.GetirGorevlendirmeListe(calisanId);

                if (gorevlendirmeIenListe == null)
                    throw new IslemBasarisizHatasi();

                return this.hesaplaKidemYili(gorevlendirmeIenListe.ToList());
                                
            }
            catch (ArgumentException)
            {
                
            }
            catch (IslemBasarisizHatasi hata)
            {
                this._hataIsKurali.YazHata(hata);

            }
            catch (Exception hata)
            {
                this._hataIsKurali.YazHata(hata);
            }

            return int.MinValue;

        }

        public IEnumerable<CalisanOzet> GetirCalisanOzet(DateTime tarihi)
        {
            try
            {
                List<Calisan> calisanListe = null;
                IEnumerable<CalisanGorevlendirme> gorevlendirmeIenListe = null;     
                List<CalisanOzet> ozetListe = new List<CalisanOzet>();
                
                if (tarihi == Sabitler.BosTarih)
                    throw new ArgumentException();

                gorevlendirmeIenListe = this._calisanGorevRepository.GetirGorevlendirmeListe(tarihi);

                if (gorevlendirmeIenListe == null)
                    throw new IslemBasarisizHatasi();          

                calisanListe = this.getirCalisanListe(gorevlendirmeIenListe.ToList());

                if (calisanListe == null)
                    throw new IslemBasarisizHatasi();

                ozetListe = this.getirCalisanOzetListe(calisanListe, gorevlendirmeIenListe.ToList());

                return ozetListe;
            }
            catch (ArgumentException)
            {

            }
            catch (IslemBasarisizHatasi hata)
            {
                this.yazHata(hata);
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }

            return new List<CalisanOzet>();

        }

        private KisiIletisim getirIletisimTuru(KisiIletisim[] kisiIletisimDizi, IletisimTuru istenenIletisimTuru)
        {

            try
            {
                KisiIletisim sonuc = null;

                if (kisiIletisimDizi == null)
                    return sonuc;

                if (istenenIletisimTuru == IletisimTuru.Tanimsiz)
                    return sonuc;

                for (int i = 0; i < Sabitler.KisiIletisimDiziUzunlugu; i++)
                {
                    if (kisiIletisimDizi[i] == null)
                        continue;
                    else if (kisiIletisimDizi[i].Turu == istenenIletisimTuru)
                    {
                        sonuc = kisiIletisimDizi[i];
                        break;
                    }
                }

                return sonuc;

            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }

            return null;
        }            

        private List<CalisanOzet> getirCalisanOzetListe(List<Calisan> calisanListe, List<CalisanGorevlendirme> gorevlendirmeListe)
        {

            try
            {
                int kidemYili = int.MinValue;
                List<CalisanOzet> ozetListe = new List<CalisanOzet>();
                CalisanGorevlendirme calisanGorevlendirme = null;
                KisiOgrenim ogrenim = null;
                KisiIletisim[] kisiIletisimDizi = null;
                KisiIletisim dahili = null;
                KisiIletisim bakanlikEposta = null;
                KisiIletisim cepTelefonu = null;
                CalisanOzet ozet = null;

                if (calisanListe == null)
                    throw new ArgumentNullException();

                if (gorevlendirmeListe == null)
                    throw new ArgumentNullException();

                foreach (Calisan calisan in calisanListe)
                {
                    if (calisan == null)
                        continue;

                    calisanGorevlendirme = gorevlendirmeListe.FirstOrDefault(p => p.CalisanId == calisan.Anahtar);

                    if (calisanGorevlendirme == null)
                        continue;

                    kidemYili = this.HesaplaKidemYili(calisan.Anahtar);

                    if (kidemYili == int.MinValue)
                        continue;

                    ogrenim = this._kisiOgrenimRepository.GetirEnGuncelKisiOgrenim(calisan.Anahtar);

                    kisiIletisimDizi = this.getirKisiIletisimDizi(calisan.Anahtar);

                    if (kisiIletisimDizi == null || kisiIletisimDizi.Length != Sabitler.KisiIletisimDiziUzunlugu)
                    {
                        IslemBasarisizHatasi hata = new IslemBasarisizHatasi(Arac.AlHataLokasyonu<GorevlendirmeIsKurali>(912));
                        this.yazHata(hata);
                        kisiIletisimDizi = new KisiIletisim[Sabitler.KisiIletisimDiziUzunlugu];
                    }

                    dahili = this.getirIletisimTuru(kisiIletisimDizi,IletisimTuru.Dahili);

                    bakanlikEposta = this.getirIletisimTuru(kisiIletisimDizi, IletisimTuru.BakanlikEposta);

                    cepTelefonu = this.getirIletisimTuru(kisiIletisimDizi, IletisimTuru.CepTelefonu);

                    ozet = new CalisanOzet(calisanGorevlendirme, ogrenim, dahili, bakanlikEposta, cepTelefonu, kidemYili);

                    ozetListe.Add(ozet);

                }

                return ozetListe;
            }
            catch (ArgumentException)
            {
                
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }

            return new List<CalisanOzet>();

        }

        public IEnumerable<CalisanOzet> GetirCalisanOzetListe(IEnumerable<Calisan> calisanListe)
        {

            try
            {
                List<Calisan> calisanTamListe = null;
                IEnumerable<CalisanGorevlendirme> calisanTekGorevlendirme = null;
                List<CalisanGorevlendirme> tumGorevlendirmeler = new List<CalisanGorevlendirme>();
                List<CalisanOzet> ozetListe = null;

                if (calisanListe == null)
                    throw new ArgumentNullException();

                calisanTamListe = calisanListe.ToList();

                foreach (Calisan deger in calisanTamListe)
                {
                    if (deger == null)
                        continue;

                    calisanTekGorevlendirme = this._calisanGorevRepository.GetirGorevlendirmeListe(deger.Anahtar);

                    if (calisanTekGorevlendirme == null)
                    {
                        IslemBasarisizHatasi hata = new IslemBasarisizHatasi(Arac.AlHataLokasyonu<GorevlendirmeIsKurali>(1050));
                        this.yazHata(hata);
                        continue;
                    }else if(!calisanTekGorevlendirme.Any())
                    {
                        List<CalisanGorevlendirme> olmayanGorevlendirme = new List<CalisanGorevlendirme>();
                        olmayanGorevlendirme.Add(new CalisanGorevlendirme(deger));
                        calisanTekGorevlendirme = olmayanGorevlendirme;
                    }

                    tumGorevlendirmeler.AddRange(calisanTekGorevlendirme);

                }

                ozetListe = this.getirCalisanOzetListe(calisanTamListe, tumGorevlendirmeler.ToList());

                return ozetListe;
            }
            catch (ArgumentNullException)
            {
                
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }

            return new List<CalisanOzet>();

        }
    }
}
