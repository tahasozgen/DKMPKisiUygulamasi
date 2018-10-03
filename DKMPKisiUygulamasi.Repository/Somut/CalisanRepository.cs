using DKMPKisiUygulamasi.Model.RepositoryKlasoru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using DKMPKisiUygulamasi.Repository.Somut.KontrolKlasoru;
using System.Data.Entity.Validation;
using DKMPKisiUygulamasi.Model.IsKatmani.Somut;
using DKMPKisiUygulamasi.Model.SabitlerMesajlar;

namespace DKMPKisiUygulamasi.Repository.Somut
{
    public class CalisanRepository : ICalisanRepository
    {
        private NorthwindContext _context;
        private Kontrol _kontrol;

        public CalisanRepository(IUnitOfWork unitOfWork)
        {
            try
            {
                if (unitOfWork == null)
                    throw new ArgumentNullException("unitOfWork");

                _context = unitOfWork as NorthwindContext;

                this._kontrol = new Kontrol();
            }
            catch (Exception hata)
            {
                throw hata;
            }
        }

        private bool yazHata(Exception hata)
        {
            if (hata != null)
            {
                HataIsKurali kural = new HataIsKurali();
                kural.YazHata(hata);
                return true;
            }
            return false;
        }
        
        public int EkleCalisanveDonAnahtar(Calisan deger)
        {
            try
            {

                int sonucId = int.MinValue;

                if (deger == null)
                    throw new ArgumentNullException();

                if (this._kontrol.uygunMu(deger))
                    return sonucId;

                this._context.Calisanlar.Add(deger);
                this._context.Kaydet();
                this._context.Entry(deger).GetDatabaseValues();
                sonucId = deger.Anahtar;

                return sonucId;
            }
            catch (ArgumentException hata)
            {
                throw hata;
            }
            catch (InvalidOperationException hata)
            {
                this.yazHata(hata);
            }
            catch (DbEntityValidationException hata)
            {
                this.yazHata(hata);
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }
            return int.MinValue;


        }

        public Calisan GetirCalisan(string tcKimlikNo)
        {
            try
            {

                IQueryable<Calisan> sorguSonucu = null;
                Calisan deger = null;

                if (String.IsNullOrEmpty(tcKimlikNo))
                    throw new ArgumentNullException();

                sorguSonucu = from b in this._context.Calisanlar
                              where b.TurCumKimlikNo.Equals(tcKimlikNo)
                              select b;

                if (sorguSonucu == null)
                    sorguSonucu = Enumerable.Empty<Calisan>().AsQueryable();

                foreach(Calisan calisan in sorguSonucu.ToList())
                {
                    deger = calisan;
                }

                return deger;

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

        public IEnumerable<Calisan> GetirCalisanListe(Cinsiyeti cinsi)
        {
            try
            {

                IQueryable<Calisan> sorguSonucu = null;             

                if (cinsi == Cinsiyeti.Tanimsiz)
                    throw new ArgumentException();

                sorguSonucu = from b in this._context.Calisanlar
                              where b.Cinsi == cinsi
                              select b;

                if (sorguSonucu == null)
                    sorguSonucu = Enumerable.Empty<Calisan>().AsQueryable();

                return sorguSonucu;

            }
            catch (ArgumentException)
            {

            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }
            return new List<Calisan>();
        }

        public IEnumerable<Calisan> GetirCalisanListe(string adi)
        {
            try
            {

                IQueryable<Calisan> sorguSonucu = null;

                if (String.IsNullOrEmpty(adi))
                    throw new ArgumentNullException();

                sorguSonucu = from b in this._context.Calisanlar
                              where b.Adi.Equals(adi)
                              select b;

                if (sorguSonucu == null)
                    sorguSonucu = Enumerable.Empty<Calisan>().AsQueryable();

                return sorguSonucu;

            }
            catch (ArgumentException)
            {

            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }
            return new List<Calisan>();
        }

        public IEnumerable<Calisan> GetirCalisanListe(AkademikUnvani unvani)
        {
            try
            {

                IQueryable<Calisan> sorguSonucu = null;

                if (unvani == AkademikUnvani.Tanimsiz)
                    throw new ArgumentException();

                sorguSonucu = from b in this._context.Calisanlar
                              where b.Unvani == unvani
                              select b;

                if (sorguSonucu == null)
                    sorguSonucu = Enumerable.Empty<Calisan>().AsQueryable();

                return sorguSonucu;

            }
            catch (ArgumentException)
            {

            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }
            return new List<Calisan>();
        }

        public IEnumerable<Calisan> GetirCalisanListeSoyadinaGore(string soyadi)
        {
            try
            {

                IQueryable<Calisan> sorguSonucu = null;

                if (String.IsNullOrEmpty(soyadi))
                    throw new ArgumentNullException();

                sorguSonucu = from b in this._context.Calisanlar
                              where b.Soyadi.Equals(soyadi)
                              select b;

                if (sorguSonucu == null)
                    sorguSonucu = Enumerable.Empty<Calisan>().AsQueryable();

                return sorguSonucu;

            }
            catch (ArgumentException)
            {

            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }
            return new List<Calisan>();
        }

        public IEnumerable<Calisan> GetirCalisanListe(string adi, string soyadi)
        {
            try
            {

                IQueryable<Calisan> sorguSonucu = null;

                if (String.IsNullOrEmpty(soyadi) || String.IsNullOrEmpty(adi))
                    throw new ArgumentNullException();

                sorguSonucu = from b in this._context.Calisanlar
                              where b.Soyadi.Equals(soyadi) && b.Adi.Equals(adi)
                              select b;

                if (sorguSonucu == null)
                    sorguSonucu = Enumerable.Empty<Calisan>().AsQueryable();

                return sorguSonucu;

            }
            catch (ArgumentException)
            {

            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }
            return new List<Calisan>();
        }

        public IEnumerable<Calisan> GetirCalisanListe(DateTime dogumTarihi)
        {
            try
            {

                IQueryable<Calisan> sorguSonucu = null;

                if (dogumTarihi == Sabitler.BosTarih)
                    throw new ArgumentException();

                sorguSonucu = from b in this._context.Calisanlar
                              where b.DogumTarihi == dogumTarihi
                              select b;

                if (sorguSonucu == null)
                    sorguSonucu = Enumerable.Empty<Calisan>().AsQueryable();

                return sorguSonucu;

            }
            catch (ArgumentException)
            {

            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }
            return new List<Calisan>();
        }

        public Calisan GetirCalisanSicileGore(string sicilNo)
        {
            try
            {

                IQueryable<Calisan> sorguSonucu = null;
                Calisan deger = null;

                if (String.IsNullOrEmpty(sicilNo))
                    throw new ArgumentNullException();

                sorguSonucu = from b in this._context.Calisanlar
                              where b.SicilNo.Equals(sicilNo)
                              select b;

                if (sorguSonucu == null)
                    sorguSonucu = Enumerable.Empty<Calisan>().AsQueryable();

                foreach (Calisan calisan in sorguSonucu.ToList())
                {
                    deger = calisan;
                }

                return deger;

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

        public Calisan GetirCalisan(int calisanId)
        {
            
            try
            {
                IQueryable<Calisan> sorguSonucu = null;
                Calisan deger = null;

                if (calisanId == int.MinValue)
                    throw new ArgumentException();

                sorguSonucu = from b in this._context.Calisanlar
                              where b.Anahtar == calisanId
                              select b;

                if (sorguSonucu == null)
                    sorguSonucu = Enumerable.Empty<Calisan>().AsQueryable();

                foreach (Calisan calisan in sorguSonucu.ToList())
                {
                    deger = calisan;
                }

                return deger;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public IEnumerable<Calisan> GetirCalisanListe(bool tumuGetirilsinMi)
        {
            try
            {

                IQueryable<Calisan> sorguSonucu = null;

                if (!tumuGetirilsinMi)
                    return new List<Calisan>();

                sorguSonucu = from b in this._context.Calisanlar
                              select b;

                if (sorguSonucu == null)
                    sorguSonucu = Enumerable.Empty<Calisan>().AsQueryable();

                return sorguSonucu;

            }
            catch (ArgumentException)
            {

            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }
            return new List<Calisan>();
        }
    }
}
