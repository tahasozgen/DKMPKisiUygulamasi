using DKMPKisiUygulamasi.Model.Somut.OgrenimKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.RepositoryKlasoru
{
    public interface IKisiOgrenimRepository
    {
        int EkleveDonAnahtar(KisiOgrenim deger);

        IEnumerable<KisiOgrenim> GetirKisiOgrenimListe(int calisanId);

        KisiOgrenim GetirEnGuncelKisiOgrenim(int calisanId);


    }
}
