using DKMPKisiUygulamasi.Model.RepositoryKlasoru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPKisiUygulamasi.Model.Somut.IletisimKlasor;
using DKMPKisiUygulamasi.Repository.Somut.KontrolKlasoru;
using DKMPKisiUygulamasi.Model.IsKatmani.Somut;
using DKMPKisiUygulamasi.Model.EnumKlasoru;

namespace DKMPKisiUygulamasi.Repository.Somut
{
    public class KisiIletisimRepository : IKisiIletisimRepository
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

        public KisiIletisimRepository(IUnitOfWork unitOfWork)
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

        public int EkleVeDonAnahtar(KisiIletisim deger)
        {
            try
            {

                int sonucId = int.MinValue;

                if (!this._kontrol.uygunMu(deger))
                    throw new ArgumentNullException();

                this._context.KisiIletisimler.Add(deger);
                this._context.Kaydet();
                this._context.Entry(deger).GetDatabaseValues();
                sonucId = deger.Anahtar;

                return sonucId;
            }
            catch (ArgumentNullException)
            {
                
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }

            return int.MinValue;

        }    

        public IEnumerable<KisiIletisim> GetirKisiIletisimListe(int kisiId)
        {
            try
            {

                IQueryable<KisiIletisim> liste = null;

                if (kisiId == int.MinValue)
                    throw new ArgumentException();

                liste = from b in this._context.KisiIletisimler
                              where b.KisiId == kisiId
                                   select b;

                if (liste == null)
                    liste = Enumerable.Empty<KisiIletisim>().AsQueryable();

                return liste;

            }
            catch (ArgumentException)
            {

            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }

            return new List<KisiIletisim>();

        }

    }

}
