using DKMPKisiUygulamasi.Model.RepositoryKlasoru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPKisiUygulamasi.Model.Somut.TanimlayiciKlasor;
using DKMPKisiUygulamasi.Model.IsKatmani.Somut;
using DKMPKisiUygulamasi.Model.Somut.OgrenimKlasor;

namespace DKMPKisiUygulamasi.Repository.Somut
{
    public class OgrenimDurumuRepository : IOgrenimDurumuRepository
    {
        private NorthwindContext _context;

        public OgrenimDurumuRepository(IUnitOfWork unitOfWork)
        {
            try
            {
                if (unitOfWork == null)
                    throw new ArgumentNullException("unitOfWork");

                _context = unitOfWork as NorthwindContext;                
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
        
        public IEnumerable<OgrenimDurumu> GetirOgrenimDurumuListe(bool tumuGetirilsinMi)
        {
            try
            {
                IQueryable<OgrenimDurumu> sorguSonucu = null;

                if (!tumuGetirilsinMi)
                    return new List<OgrenimDurumu>();

                sorguSonucu = from b in this._context.OgrenimDurumlari
                              select b;

                if (sorguSonucu == null)
                    sorguSonucu = Enumerable.Empty<OgrenimDurumu>().AsQueryable();

                return sorguSonucu.ToList();

            }
            catch (ArgumentException)
            {

            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }

            return new List<OgrenimDurumu>();

        }

    }

}
