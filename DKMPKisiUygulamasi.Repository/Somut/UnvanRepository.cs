using DKMPKisiUygulamasi.Model.RepositoryKlasoru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPKisiUygulamasi.Model.Somut.TanimlayiciKlasor;
using DKMPKisiUygulamasi.Model.IsKatmani.Somut;

namespace DKMPKisiUygulamasi.Repository.Somut
{
    public class UnvanRepository : IUnvanRepository
    {
        private NorthwindContext _context;        

        public UnvanRepository(IUnitOfWork unitOfWork)
        {
            try
            {
                if (unitOfWork == null)
                    throw new ArgumentNullException();

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


        public IEnumerable<Unvan> GetirUnvanListe(bool tumuGetirilsinMi)
        {
            try
            {
                IQueryable<Unvan> sorguSonucu = null;

                if (!tumuGetirilsinMi)
                    return new List<Unvan>();

                sorguSonucu = from b in this._context.Unvanlar
                              select b;

                if (sorguSonucu == null)
                    sorguSonucu = Enumerable.Empty<Unvan>().AsQueryable();

                return sorguSonucu.ToList();

            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }

            return new List<Unvan>(); 

        }
    }
}
