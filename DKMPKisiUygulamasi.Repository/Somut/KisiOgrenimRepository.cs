using DKMPKisiUygulamasi.Model.RepositoryKlasoru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPKisiUygulamasi.Model.Somut.OgrenimKlasor;
using DKMPKisiUygulamasi.Repository.Somut.KontrolKlasoru;
using DKMPKisiUygulamasi.Model.IsKatmani.Somut;
using DKMPKisiUygulamasi.Model.SabitlerMesajlar;
using System.Data.Entity.Validation;
using System.Data.Entity;

namespace DKMPKisiUygulamasi.Repository.Somut
{
    public class KisiOgrenimRepository : IKisiOgrenimRepository
    {
        private NorthwindContext _context;
        private Kontrol _kontrol;

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

        public KisiOgrenimRepository(IUnitOfWork unitOfWork)
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
        
        public int EkleveDonAnahtar(KisiOgrenim deger)
        {
            try
            {

                int sonucId = int.MinValue;

                if (deger == null)
                    throw new ArgumentNullException();

                //if (!this._kontrol.uygunMu(deger))
                //    return Sabitler.HataliArgumanKodu;

                this._context.KisiOgrenimListe.Add(deger);
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

        public IEnumerable<KisiOgrenim> GetirKisiOgrenimListe(int calisanId)
        {
            try
            {
                IQueryable<KisiOgrenim> sorguSonucu = null;

                if (calisanId == int.MinValue)
                    throw new ArgumentException(calisanId.GetType().ToString());

                sorguSonucu = from b in this._context.KisiOgrenimListe.Include(b => b.Calisani).Include(b => b.OgrenimDurumu).Include(b => b.Universitesi)
                              where b.Calisani.Anahtar == calisanId
                              select b;

                if (sorguSonucu == null)
                    sorguSonucu = Enumerable.Empty<KisiOgrenim>().AsQueryable();              

                return sorguSonucu;

            }
            catch (ArgumentException)
            {

            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }
            return new List<KisiOgrenim>();
        }

        public KisiOgrenim GetirEnGuncelKisiOgrenim(int calisanId)
        {
            try
            {
                int anahtar = int.MinValue;
                KisiOgrenim sonuc = null;
                IQueryable<KisiOgrenim> sorguSonucu = null;

                if (calisanId == int.MinValue)
                    throw new ArgumentException(calisanId.GetType().ToString());

                sorguSonucu = from b in this._context.KisiOgrenimListe.Include(b=>b.Calisani).Include(b=>b.OgrenimDurumu).Include(b=>b.Universitesi)
                              where b.Calisani.Anahtar == calisanId
                              select b;

                if (sorguSonucu == null)
                    sorguSonucu = Enumerable.Empty<KisiOgrenim>().AsQueryable();

                foreach(KisiOgrenim deger in sorguSonucu)
                {
                    if(anahtar < deger.Anahtar)
                    {
                        anahtar = deger.Anahtar;
                        sonuc = deger;
                    }
                }

                return sonuc;

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
    }
}
