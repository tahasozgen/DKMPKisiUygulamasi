using DKMPKisiUygulamasi.Model.Somut.TanimlayiciKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.RepositoryKlasoru
{
    public interface IUnvanRepository
    {
        IEnumerable<Unvan> GetirUnvanListe(bool tumuGetirilsinMi);

    }
}
