using DKMPKisiUygulamasi.Model.IsKatmani.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using DKMPKisiUygulamasi.Model.RepositoryKlasoru;
using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.Somut.HataKlasoru;
using DKMPKisiUygulamasi.Model.Somut.SorguKlasor;
using DKMPKisiUygulamasi.Model.SabitlerMesajlar;

namespace DKMPKisiUygulamasi.Model.IsKatmani.Somut
{
    public class CalisanIsKurali : ICalisanIsKurali
    {

        private Kontrol _kontrol;

        private ICalisanRepository _calisanRepository;
        
        public CalisanIsKurali(ICalisanRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException();

            this._calisanRepository = repository;
            this._kontrol = new Kontrol();
        }

        private void yazHata(Exception hata)
        {
            if(hata != null)
            {
                HataIsKurali ik = new HataIsKurali();
                ik.YazHata(hata);
            }
        }

        private void yazHata(DKMPHataAltyapi.Soyut.HataBase hata)
        {
            if (hata != null)
            {
                HataIsKurali ik = new HataIsKurali();
                ik.YazHata(hata);
            }
        }
        
        private List<SorguNitelik> getirNitelik(string sorguSozcesi)
        {
            try
            {

                SorguAnaliz sorgu = new SorguAnaliz();
                List<SorguNitelik> liste = new List<SorguNitelik>();

                if (String.IsNullOrEmpty(sorguSozcesi))
                    throw new ArgumentNullException();

                sorguSozcesi = Arac.KucultveKirp(sorguSozcesi);

                if (sorgu.nitelikteMiSorgu(sorguSozcesi, SorguNitelik.Akademik))
                {
                    liste.Add(SorguNitelik.Akademik);
                    return liste;
                }

                if (sorgu.nitelikteMiSorgu(sorguSozcesi,SorguNitelik.Cinsiyet))
                {
                    liste.Add(SorguNitelik.Cinsiyet);
                }

                if (sorgu.nitelikteMiSorgu(sorguSozcesi,SorguNitelik.KanRh))
                {
                    liste.Add(SorguNitelik.KanRh);
                    return liste;
                }

                if (sorgu.nitelikteMiSorgu(sorguSozcesi,SorguNitelik.MedeniHali))
                {
                    liste.Add(SorguNitelik.MedeniHali);
                }

                if (sorgu.nitelikteMiSorgu(sorguSozcesi,SorguNitelik.TurkiyeCumhuriyetiKimlikNo))
                {
                    liste.Add(SorguNitelik.TurkiyeCumhuriyetiKimlikNo);
                    return liste;
                }

                if (sorgu.nitelikteMiSorgu(sorguSozcesi, SorguNitelik.DogumTarihi))
                {
                    liste.Add(SorguNitelik.DogumTarihi);
                    return liste;
                }

                if (sorgu.nitelikteMiSorgu(sorguSozcesi,SorguNitelik.SicilNo))
                {
                    liste.Add(SorguNitelik.SicilNo);
                    return liste;
                }

                if (sorgu.nitelikteMiSorgu(sorguSozcesi, SorguNitelik.Kadro))
                {
                    liste.Add(SorguNitelik.Kadro);
                }

                if (sorgu.nitelikteMiSorgu(sorguSozcesi,SorguNitelik.Sinif))
                {
                    liste.Add(SorguNitelik.Sinif);
                    return liste;
                }
                if (sorgu.nitelikteMiSorgu(sorguSozcesi, SorguNitelik.Adi))
                {
                    liste.Add(SorguNitelik.Adi);       
                }
                if (sorgu.nitelikteMiSorgu(sorguSozcesi, SorguNitelik.Soyadi))
                {
                    liste.Add(SorguNitelik.Soyadi);            
                }

                if (sorgu.nitelikteMiSorgu(sorguSozcesi, SorguNitelik.KizlikSoyadi))
                {
                    liste.Add(SorguNitelik.KizlikSoyadi);            
                }

                return liste;

            }
            catch (ArgumentException)
            {
                
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }

            return new List<SorguNitelik>();
        }

        private IEnumerable<Calisan> sorgulaCalisan(IEnumerable<SorguNitelik> nitelikListe, string sorguSozcesi)
        {

            try
            {
                DateTime dogumTarihi = Sabitler.BosTarih;
                SorguAnaliz analiz = new SorguAnaliz();
                AkademikUnvani unvan = AkademikUnvani.Tanimsiz;
                Cinsiyeti cinsi = Cinsiyeti.Tanimsiz;
                List<Calisan> calisanListe = new List<Calisan>();
                List<SorguNitelik> nitelikListesi = new List<SorguNitelik>();
                IEnumerable<Calisan> kismiListe = new List<Calisan>();

                if (nitelikListe == null)
                    throw new ArgumentNullException();
                if (String.IsNullOrEmpty(sorguSozcesi))
                    throw new ArgumentNullException();

                nitelikListesi = nitelikListe.ToList();

                foreach (SorguNitelik nitelik in nitelikListe)
                {
                    if (nitelik == SorguNitelik.Tanimsiz)
                        continue;

                    if (nitelik == SorguNitelik.Adi)
                        kismiListe = this._calisanRepository.GetirCalisanListe(sorguSozcesi);
                    else if (nitelik == SorguNitelik.Akademik)
                    {
                        unvan = analiz.getirAkademikUnvani(sorguSozcesi);
                        kismiListe = this._calisanRepository.GetirCalisanListe(unvan);
                    }
                    else if (nitelik == SorguNitelik.Cinsiyet)
                    {
                        cinsi = analiz.getirCinsiyeti(sorguSozcesi);
                        kismiListe = this._calisanRepository.GetirCalisanListe(cinsi);
                    }
                    else if (nitelik == SorguNitelik.DogumTarihi)
                    {
                        if (!DateTime.TryParse(sorguSozcesi, out dogumTarihi))
                            continue;

                        kismiListe = this._calisanRepository.GetirCalisanListe(dogumTarihi);

                    }
                    else if (nitelik == SorguNitelik.Kadro)
                    {
                        //TODO: yapılacak.
                    }
                    else if (nitelik == SorguNitelik.KanRh)
                    {
                        //TODO: yapılacak.
                    }
                    else if (nitelik == SorguNitelik.KizlikSoyadi)
                    {
                        //TODO: yapılacak.
                    }
                    else if (nitelik == SorguNitelik.MedeniHali)
                    {
                        //TODO: yapılacak.
                    }
                    else if (nitelik == SorguNitelik.SicilNo)
                    {
                        Calisan calisan = this._calisanRepository.GetirCalisanSicileGore(sorguSozcesi);

                        if (calisan != null)
                        {
                            List<Calisan> yerelListe = new List<Calisan>();
                            yerelListe.Add(calisan);
                            kismiListe = yerelListe;
                        }

                    }
                    else if (nitelik == SorguNitelik.Sinif)
                    {
                        //TODO: yapılacak.
                    }
                    else if (nitelik == SorguNitelik.Soyadi)
                    {
                        kismiListe = this._calisanRepository.GetirCalisanListeSoyadinaGore(sorguSozcesi);
                    }
                    else if (nitelik == SorguNitelik.TurkiyeCumhuriyetiKimlikNo)
                    {
                        Calisan calisan = this._calisanRepository.GetirCalisan(sorguSozcesi);

                        if (calisan != null)
                        {
                            List<Calisan> yerelListe = new List<Calisan>();
                            yerelListe.Add(calisan);
                            kismiListe = yerelListe;
                        }
                    }

                    if (kismiListe == null)
                    {
                        this.yazHata(new IslemBasarisizHatasi(Arac.AlHataLokasyonu<CalisanIsKurali>(147)));
                        continue;
                    }

                    calisanListe.AddRange(kismiListe.ToList());

                    kismiListe = new List<Calisan>();
                }

                return calisanListe;
            }
            catch (ArgumentException)
            {                
            }
            catch (DKMPHataAltyapi.Soyut.HataBase hata)
            {
                this.yazHata(hata);
            }
            catch (Exception hata) 
            {
                this.yazHata(hata);
            }

            return new List<Calisan>();

        }

        public IEnumerable<Calisan> SorgulaCalisan(string sorguSozcesi)
        {

            try
            {
                IEnumerable<SorguNitelik> nitelikListe = null;
                IEnumerable<Calisan> calisanListe = null;

                if (String.IsNullOrEmpty(sorguSozcesi))
                    throw new ArgumentNullException();

                nitelikListe = this.getirNitelik(sorguSozcesi);

                if (nitelikListe == null || !nitelikListe.Any())
                    throw new IslemBasarisizHatasi();

                calisanListe = this.sorgulaCalisan(nitelikListe, sorguSozcesi);

                if (calisanListe == null)
                    throw new IslemBasarisizHatasi();

                return calisanListe;

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

            return new List<Calisan>();

        }

        public int EkleCalisan(Calisan deger)
        {

            try
            {
                int sonucId = int.MinValue;

                if (!this._kontrol.uygunMu(deger))
                    return sonucId;

                deger.Adi = Arac.KucultveKirp(deger.Adi);
                deger.IbanNo = Arac.KucultveKirp(deger.IbanNo);
                deger.KizlikSoyadi = Arac.KucultveKirp(deger.KizlikSoyadi);
                deger.SicilNo = Arac.KucultveKirp(deger.SicilNo);
                deger.Soyadi = Arac.KucultveKirp(deger.Soyadi);
                deger.TurCumKimlikNo = Arac.KucultveKirp(deger.TurCumKimlikNo);                

                sonucId = _calisanRepository.EkleCalisanveDonAnahtar(deger);

                if (sonucId < 0)
                    throw new IslemBasarisizHatasi();

                return sonucId;
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }

            return int.MinValue;

        }

        public Calisan GetirCalisan(int calisanId)
        {

            try
            {
                if (calisanId == int.MinValue)
                    throw new ArgumentException();

                return this._calisanRepository.GetirCalisan(calisanId);

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

        public IEnumerable<Calisan> SorgulaCalisan(DateTime tarih)
        {

            try
            {
                IEnumerable<Calisan> liste = new List<Calisan>();

                if (tarih.ToShortDateString().Equals(DateTime.Now.ToShortDateString()))
                {
                    liste = this._calisanRepository.GetirCalisanListe(true);

                    if (liste == null)
                        throw new IslemBasarisizHatasi();
                }

                return liste;
            }
            catch (IslemBasarisizHatasi hata)
            {
                this.yazHata(hata);
            }
            catch (Exception hata)
            {
                this.yazHata(hata);

            }
            return new List<Calisan>();
        }
    }
}
