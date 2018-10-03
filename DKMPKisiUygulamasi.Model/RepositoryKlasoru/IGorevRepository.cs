using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;
using DKMPKisiUygulamasi.Model.Somut.TanimlayiciKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.RepositoryKlasoru
{
    public interface IGorevRepository
    {   
        IEnumerable<Gorevi> GetirGorevListe(bool tumuGetirilsinMi);

    }
}
