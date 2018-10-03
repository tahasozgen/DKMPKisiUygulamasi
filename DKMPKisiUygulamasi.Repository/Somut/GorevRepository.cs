using DKMPKisiUygulamasi.Model.RepositoryKlasoru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;
using DKMPKisiUygulamasi.Model.IsKatmani.Somut;

namespace DKMPKisiUygulamasi.Repository.Somut
{
    public class GorevRepository : IGorevRepository
    {
        private NorthwindContext _context;

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

        public GorevRepository(IUnitOfWork unitofwork)
        {

            if (unitofwork == null)
                throw new ArgumentNullException();

            this._context = unitofwork as NorthwindContext;
        }

        public IEnumerable<Gorevi> GetirGorevListe(bool tumuGetirilsinMi)
        {
            try
            {
                IQueryable<Gorevi> sorguSonucu = null;

                if (!tumuGetirilsinMi)
                    return new List<Gorevi>();

                sorguSonucu = from b in this._context.Gorevler
                              select b;

                if (sorguSonucu == null)
                    sorguSonucu = Enumerable.Empty<Gorevi>().AsQueryable();

                return sorguSonucu.ToList();

            }
            catch (ArgumentException)
            {

            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }
            return new List<Gorevi>();


        }
    }
}
