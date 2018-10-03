using DKMPKisiUygulamasi.Repository.Baglam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPKisiUygulamasi.Model.RepositoryKlasoru;

namespace DKMPKisiUygulamasi.Repository.Somut
{
    public class NorthwindContext : KisiUygulamasiBaglam, IUnitOfWork
    {
        public int Kaydet()
        {
            try
            {
                return SaveChanges();
            }
            catch (Exception hata)
            {

                throw hata;
            }
        }

    }
}
