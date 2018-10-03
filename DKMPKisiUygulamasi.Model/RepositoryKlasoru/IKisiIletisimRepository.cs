using DKMPKisiUygulamasi.Model.Somut.IletisimKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.RepositoryKlasoru
{
    public interface IKisiIletisimRepository
    {
        int EkleVeDonAnahtar(KisiIletisim deger);

        IEnumerable<KisiIletisim> GetirKisiIletisimListe(int kisiId);


    }
}
