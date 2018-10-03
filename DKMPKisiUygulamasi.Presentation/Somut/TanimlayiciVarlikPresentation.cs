using DKMPKisiUygulamasi.Presentation.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.GorevKlasoru;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.TanimlayiciKlasor;
using DKMPKisiUygulamasi.Servis.Soyut;
using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.Somut.OgrenimKlasor;
using DKMPKisiUygulamasi.Model.Somut.TanimlayiciKlasor;

namespace DKMPKisiUygulamasi.Presentation.Somut
{
    public class TanimlayiciVarlikPresentation : PresentationBaz,ITanimlayiciVarlikPresentation
    {
        private readonly ITanimlayiciVarlikServis _tanimlayiciServis;

        private TanimlayiciVarlikPresentation():base()
        {
            this._tanimlayiciServis = null;
        }

        public TanimlayiciVarlikPresentation(ITanimlayiciVarlikServis tanimlayiciServis) : this()
        {
            this._tanimlayiciServis = tanimlayiciServis;
        }


        public IEnumerable<AkademikUnvaniViewModel> GetirAkademikUnvanListe(bool tumuGetirilsinMi)
        {

            try
            {
                IEnumerable<AkademikUnvaniViewModel> vmListe = null;
                IEnumerable<AkademikUnvani> liste = this._tanimlayiciServis.GetirAkademikUnvanListe(tumuGetirilsinMi);

                if (liste == null)
                    throw new ApplicationException();

                vmListe = this._cevir.cevir(liste.ToList());

                if (vmListe == null)
                    throw new ApplicationException();

                return vmListe;

            }
            catch (ApplicationException hata)
            {
                this._hataServis.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return new List<AkademikUnvaniViewModel>();

        }

        public IEnumerable<CinsiyetiViewModel> GetirCinsiyetListe(bool tumuGetirilsinMi)
        {
            try
            {
                IEnumerable<CinsiyetiViewModel> vmListe = null;
                IEnumerable<Cinsiyeti> liste = this._tanimlayiciServis.GetirCinsiyetListe(tumuGetirilsinMi);

                if (liste == null)
                    throw new ApplicationException();

                vmListe = this._cevir.cevir(liste.ToList());

                if (vmListe == null)
                    throw new ApplicationException();

                return vmListe;

            }
            catch (ApplicationException hata)
            {
                this._hataServis.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return new List<CinsiyetiViewModel>();
        }

        public IEnumerable<HizmetSonlanisNedeniViewModel> GetirHizmetSonlanisNedeniListe(bool tumuGetirilsinMi)
        {
            try
            {
                IEnumerable<HizmetSonlanisNedeniViewModel> vmListe = null;
                IEnumerable<HizmetSonlanisNedeni> liste = this._tanimlayiciServis.GetirHizmetSonlanisNedeniListe(tumuGetirilsinMi);

                if (liste == null)
                    throw new ApplicationException();

                vmListe = this._cevir.cevir(liste.ToList());

                if (vmListe == null)
                    throw new ApplicationException();

                return vmListe;

            }
            catch (ApplicationException hata)
            {
                this._hataServis.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return new List<HizmetSonlanisNedeniViewModel>();
        }

        public IEnumerable<KadrosuViewModel> GetirKadrosuListe(bool tumuGetirilsinMi)
        {
            try
            {
                IEnumerable<KadrosuViewModel> vmListe = null;
                IEnumerable<Kadrosu> liste = this._tanimlayiciServis.GetirKadrosuListe(tumuGetirilsinMi);

                if (liste == null)
                    throw new ApplicationException();

                vmListe = this._cevir.cevir(liste.ToList());

                if (vmListe == null)
                    throw new ApplicationException();

                return vmListe;

            }
            catch (ApplicationException hata)
            {
                this._hataServis.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return new List<KadrosuViewModel>();
        }

        public IEnumerable<KanGrubuViewModel> GetirKanGrubuListe(bool tumuGetirilsinMi)
        {
            try
            {
                IEnumerable<KanGrubuViewModel> vmListe = null;
                IEnumerable<KanGrubu> liste = this._tanimlayiciServis.GetirKanGrubuListe(tumuGetirilsinMi);

                if (liste == null)
                    throw new ApplicationException();

                vmListe = this._cevir.cevir(liste.ToList());

                if (vmListe == null)
                    throw new ApplicationException();

                return vmListe;

            }
            catch (ApplicationException hata)
            {
                this._hataServis.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return new List<KanGrubuViewModel>();
        }

        public IEnumerable<MedeniDurumuViewModel> GetirMedeniDurumuListe(bool tumuGetirilsinMi)
        {
            try
            {
                IEnumerable<MedeniDurumuViewModel> vmListe = null;
                IEnumerable<MedeniDurumu> liste = this._tanimlayiciServis.GetirMedeniDurumuListe(tumuGetirilsinMi);

                if (liste == null)
                    throw new ApplicationException();

                vmListe = this._cevir.cevir(liste.ToList());

                if (vmListe == null)
                    throw new ApplicationException();

                return vmListe;

            }
            catch (ApplicationException hata)
            {
                this._hataServis.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return new List<MedeniDurumuViewModel>();
        }

        public IEnumerable<OgrenimDurumuViewModel> GetirOgrenimDurumuListe(bool tumuGetirilsinMi)
        {
            try
            {
                IEnumerable<OgrenimDurumuViewModel> vmListe = null;
                IEnumerable<OgrenimDurumu> liste = this._tanimlayiciServis.GetirOgrenimDurumuListe(tumuGetirilsinMi);

                if (liste == null)
                    throw new ApplicationException();

                vmListe = this._cevir.cevir(liste.ToList());

                if (vmListe == null)
                    throw new ApplicationException();

                return vmListe;

            }
            catch (ApplicationException hata)
            {
                this._hataServis.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return new List<OgrenimDurumuViewModel>();
        }

        public IEnumerable<PhDegeriViewModel> GetirPhDegeriListe(bool tumuGetirilsinMi)
        {
            try
            {
                IEnumerable<PhDegeriViewModel> vmListe = null;
                IEnumerable<PhDegeri> liste = this._tanimlayiciServis.GetirPhDegeriListe(tumuGetirilsinMi);

                if (liste == null)
                    throw new ApplicationException();

                vmListe = this._cevir.cevir(liste.ToList());

                if (vmListe == null)
                    throw new ApplicationException();

                return vmListe;

            }
            catch (ApplicationException hata)
            {
                this._hataServis.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return new List<PhDegeriViewModel>();
        }

        public IEnumerable<SinifViewModel> GetirSinifListe(bool tumuGetirilsinMi)
        {
            try
            {
                IEnumerable<SinifViewModel> vmListe = null;
                IEnumerable<Sinif> liste = this._tanimlayiciServis.GetirSinifListe(tumuGetirilsinMi);

                if (liste == null)
                    throw new ApplicationException();

                vmListe = this._cevir.cevir(liste.ToList());

                if (vmListe == null)
                    throw new ApplicationException();

                return vmListe;

            }
            catch (ApplicationException hata)
            {
                this._hataServis.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return new List<SinifViewModel>();
        }

        public IEnumerable<UnvanViewModel> GetirUnvanListe(bool tumuGetirilsinMi)
        {
            try
            {
                IEnumerable<UnvanViewModel> vmListe = null;
                IEnumerable<Unvan> liste = this._tanimlayiciServis.GetirUnvanListe(tumuGetirilsinMi);

                if (liste == null)
                    throw new ApplicationException();

                vmListe = this._cevir.cevir(liste.ToList());

                if (vmListe == null)
                    throw new ApplicationException();

                return vmListe;

            }
            catch (ApplicationException hata)
            {
                this._hataServis.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return new List<UnvanViewModel>();
        }
    }
}
