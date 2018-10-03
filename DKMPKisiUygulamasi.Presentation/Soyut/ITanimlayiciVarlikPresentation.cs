using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.GorevKlasoru;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.TanimlayiciKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.Soyut
{
    public interface ITanimlayiciVarlikPresentation
    {
        IEnumerable<AkademikUnvaniViewModel> GetirAkademikUnvanListe(bool tumuGetirilsinMi);

        IEnumerable<CinsiyetiViewModel> GetirCinsiyetListe(bool tumuGetirilsinMi);

        IEnumerable<KanGrubuViewModel> GetirKanGrubuListe(bool tumuGetirilsinMi);

        IEnumerable<PhDegeriViewModel> GetirPhDegeriListe(bool tumuGetirilsinMi);

        IEnumerable<OgrenimDurumuViewModel> GetirOgrenimDurumuListe(bool tumuGetirilsinMi);

        IEnumerable<UnvanViewModel> GetirUnvanListe(bool tumuGetirilsinMi);

        IEnumerable<SinifViewModel> GetirSinifListe(bool tumuGetirilsinMi);

        IEnumerable<MedeniDurumuViewModel> GetirMedeniDurumuListe(bool tumuGetirilsinMi);

        IEnumerable<HizmetSonlanisNedeniViewModel> GetirHizmetSonlanisNedeniListe(bool tumuGetirilsinMi);

        IEnumerable<KadrosuViewModel> GetirKadrosuListe(bool tumuGetirilsinMi);

    }
}
