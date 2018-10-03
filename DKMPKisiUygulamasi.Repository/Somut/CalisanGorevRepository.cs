using DKMPKisiUygulamasi.Model.RepositoryKlasoru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;
using DKMPKisiUygulamasi.Repository.Somut.KontrolKlasoru;
using System.Data.Entity.Validation;
using System.Data.Entity;
using DKMPKisiUygulamasi.Model.SabitlerMesajlar;
using DKMPKisiUygulamasi.Model.IsKatmani.Somut;

namespace DKMPKisiUygulamasi.Repository.Somut
{
    public class CalisanGorevRepository : ICalisanGorevRepository
    {
        private NorthwindContext _context;
        private Kontrol _kontrol;

        private bool yazHata(Exception hata)
        {
            if(hata != null)
            {
                HataIsKurali kural = new HataIsKurali();
                kural.YazHata(hata);
                return true;
            }
            return false;
        }

        public CalisanGorevRepository(IUnitOfWork unitOfWork)
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
                this.yazHata(hata);
            }
        }

        public int EkleGorevveDonAnahtar(CalisanGorevlendirme deger)
        {
            try
            {

                int sonucId = int.MinValue;

                if (deger == null)
                    throw new ArgumentNullException();

                if (!this._kontrol.uygunMu(deger))
                    return Sabitler.HataliArgumanKodu;

                this._context.CalisanGorevlendirmeListe.Add(deger);
                this._context.Kaydet();
                this._context.Entry(deger).GetDatabaseValues();
                sonucId = deger.Anahtar;

                return sonucId;
            }
            catch (ArgumentException hata)
            {
                this.yazHata(hata);
                return Sabitler.HataliArgumanKodu;
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

        public IEnumerable<CalisanGorevlendirme> GetirGorevlendirmeListe(int calisanId)
        {
            try
            {

                IQueryable<CalisanGorevlendirme> sorguSonucu;

                if (calisanId == int.MinValue)
                    throw new ArgumentException(calisanId.GetType().ToString());

                sorguSonucu = from b in this._context.CalisanGorevlendirmeListe.Include(b=>b.Calisani).Include(b => b.Gorev).Include(b => b.Unvani)
                              where b.CalisanId == calisanId
                              select b;

                if (sorguSonucu == null)
                    sorguSonucu = Enumerable.Empty<CalisanGorevlendirme>().AsQueryable();

                return sorguSonucu.ToList();

            }
            catch (ArgumentException)
            {

            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }
            return new List<CalisanGorevlendirme>();
        }

        public IEnumerable<CalisanGorevlendirme> GetirGorevlendirmeListeBirimeGore(int birimId)
        {
            try
            {

                IQueryable<CalisanGorevlendirme> sorguSonucu = null;

                if (birimId == int.MinValue)
                    throw new ArgumentException(birimId.GetType().ToString());

                sorguSonucu = from b in this._context.CalisanGorevlendirmeListe.Include(b => b.Calisani).Include(b => b.Gorev).Include(b => b.Unvani)
                              where b.BirimId == birimId
                              select b;

                if (sorguSonucu == null)
                    sorguSonucu = Enumerable.Empty<CalisanGorevlendirme>().AsQueryable();

                return sorguSonucu.ToList();

            }
            catch (ArgumentException)
            {
                
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }
            return new List<CalisanGorevlendirme>();
        }

        public int GunleGorev(CalisanGorevlendirme deger)
        {

            try
            {
                IQueryable<CalisanGorevlendirme> sorguSonucu = null;
                CalisanGorevlendirme gunlenecek = null;

                if (deger == null)
                    throw new ArgumentNullException();

                sorguSonucu = from b in this._context.CalisanGorevlendirmeListe
                              where b.Anahtar == deger.Anahtar
                              select b;

                if (sorguSonucu == null)
                    sorguSonucu = Enumerable.Empty<CalisanGorevlendirme>().AsQueryable();

                foreach (CalisanGorevlendirme gorevlendirme in sorguSonucu.ToList())                
                    gunlenecek = gorevlendirme;

                if (gunlenecek == null)
                    return int.MinValue;

                this._context.CalisanGorevlendirmeListe.Attach(gunlenecek);

                gunlenecek.Aciklama = deger.Aciklama;
                gunlenecek.AsilMi = deger.AsilMi;
                gunlenecek.Baslangic = deger.Baslangic;
                gunlenecek.BirimId = deger.BirimId;
                gunlenecek.Bitis = deger.Bitis;
                gunlenecek.CalisanId = deger.CalisanId;
                gunlenecek.GorevId = deger.GorevId;
                gunlenecek.ResmiMi = deger.ResmiMi;
                gunlenecek.SonlanisNedeni = deger.SonlanisNedeni;
                gunlenecek.UnvanId = deger.UnvanId;
                gunlenecek.UnvanId = deger.UnvanId;

                this._context.Entry(gunlenecek).State = EntityState.Modified;
                return this._context.Kaydet();
            }
            catch (ArgumentNullException)
            {
                return Sabitler.HataliArgumanKodu;
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }

            return int.MinValue;

        }

        public IEnumerable<CalisanGorevlendirme> GetirGorevlendirmeListe(DateTime tarihi)
        {
            try
            {
                IQueryable<CalisanGorevlendirme> sorguSonucu = null;
                int yil = int.MinValue;

                if (tarihi == Sabitler.BosTarih)
                    throw new ArgumentNullException();

                yil = tarihi.Year;               

                if(tarihi.ToShortDateString().Equals( DateTime.Now.ToShortDateString()))
                {
                    sorguSonucu = from b in this._context.CalisanGorevlendirmeListe.Include(b => b.Calisani).Include(b => b.Gorev).Include(b => b.Unvani)
                                  where b.Bitis == null
                                  select b;
                }
                else
                {
                    if (tarihi.ToShortDateString().Equals(DateTime.Now.ToShortDateString()))
                    {
                        sorguSonucu = from b in this._context.CalisanGorevlendirmeListe
                                      where b.Bitis.Value.Year == yil
                                      select b;
                    }
                }
                            

                if (sorguSonucu == null)
                    sorguSonucu = Enumerable.Empty<CalisanGorevlendirme>().AsQueryable();

                return sorguSonucu.ToList();

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
    }
}
