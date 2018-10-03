using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;
using DKMPKisiUygulamasi.Model.Somut.OgrenimKlasor;
using DKMPKisiUygulamasi.Model.Somut.TanimlayiciKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Soyut
{
    public interface ITanimlayiciVarlikServis
    {
        IEnumerable<AkademikUnvani> GetirAkademikUnvanListe(bool tumuGetirilsinMi);

        IEnumerable<Cinsiyeti> GetirCinsiyetListe(bool tumuGetirilsinMi);

        IEnumerable<KanGrubu> GetirKanGrubuListe(bool tumuGetirilsinMi);

        IEnumerable<RhDegeri> GetirPhDegeriListe(bool tumuGetirilsinMi);

        IEnumerable<OgrenimDurumu> GetirOgrenimDurumuListe(bool tumuGetirilsinMi);

        IEnumerable<Unvan> GetirUnvanListe(bool tumuGetirilsinMi);

        IEnumerable<Sinif> GetirSinifListe(bool tumuGetirilsinMi);

        IEnumerable<MedeniDurumu> GetirMedeniDurumuListe(bool tumuGetirilsinMi);

        IEnumerable<HizmetSonlanisNedeni> GetirHizmetSonlanisNedeniListe(bool tumuGetirilsinMi);

        IEnumerable<Kadrosu> GetirKadrosuListe(bool tumuGetirilsinMi);

        IEnumerable<CalismaDurumu> GetirCalismaDurumuListe(bool tumuGetirilsinMi);

        IEnumerable<Gorevi> GetirGoreviListe(bool tumuGetirilsinMi);
    }
}
