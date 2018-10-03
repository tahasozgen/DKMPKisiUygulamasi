using DKMPKisiUygulamasi.Servis.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.Somut.OgrenimKlasor;
using DKMPKisiUygulamasi.Model.Somut.TanimlayiciKlasor;
using DKMPKisiUygulamasi.Model.IsKatmani.Soyut;
using DKMPKisiUygulamasi.Model.Somut.HataKlasoru;
using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;

namespace DKMPKisiUygulamasi.Servis.Somut
{
    public class TanimlayiciVarlikServis : ITanimlayiciVarlikServis
    {
        private ITanimlayiciVarlikIsKurali _isKurali;
        private HataServis _hataServis;

        public TanimlayiciVarlikServis(ITanimlayiciVarlikIsKurali isKurali)
        {
            this._isKurali = isKurali;
            this._hataServis = new HataServis();
        }
        
        public IEnumerable<AkademikUnvani> GetirAkademikUnvanListe(bool tumuGetirilsinMi)
        {

            try
            {
                IEnumerable<AkademikUnvani> liste = null;

                liste = this._isKurali.GetirAkademikUnvanListe(tumuGetirilsinMi);

                if (liste == null)
                    throw new IslemBasarisizHatasi();

                return liste.ToList();
            }
            catch (IslemBasarisizHatasi hata)
            {
                this._hataServis.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);

            }

            return new List<AkademikUnvani>();

        }

        public IEnumerable<Cinsiyeti> GetirCinsiyetListe(bool tumuGetirilsinMi)
        {

            try
            {
                IEnumerable<Cinsiyeti> liste = null;

                liste = this._isKurali.GetirCinsiyetListe(tumuGetirilsinMi);

                if (liste == null)
                    throw new IslemBasarisizHatasi();

                return liste.ToList();
            }
            catch (IslemBasarisizHatasi hata)
            {
                this._hataServis.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);

            }

            return new List<Cinsiyeti>();
        }

        public IEnumerable<HizmetSonlanisNedeni> GetirHizmetSonlanisNedeniListe(bool tumuGetirilsinMi)
        {
            try
            {
                IEnumerable<HizmetSonlanisNedeni> liste = null;

                liste = this._isKurali.GetirHizmetSonlanisNedeniListe(tumuGetirilsinMi);

                if (liste == null)
                    throw new IslemBasarisizHatasi();

                return liste;
            }
            catch (IslemBasarisizHatasi hata)
            {
                this._hataServis.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return new List<HizmetSonlanisNedeni>();

        }

        public IEnumerable<Kadrosu> GetirKadrosuListe(bool tumuGetirilsinMi)
        {
            try
            {
                IEnumerable<Kadrosu> liste = null;

                liste = this._isKurali.GetirKadrosuListe(tumuGetirilsinMi);

                if (liste == null)
                    throw new IslemBasarisizHatasi();

                return liste;
            }
            catch (IslemBasarisizHatasi hata)
            {
                this._hataServis.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return new List<Kadrosu>();
        }

        public IEnumerable<KanGrubu> GetirKanGrubuListe(bool tumuGetirilsinMi)
        {
            try
            {
                IEnumerable<KanGrubu> liste = null;

                liste = this._isKurali.GetirKanGrubuListe(tumuGetirilsinMi);

                if (liste == null)
                    throw new IslemBasarisizHatasi();

                return liste;
            }
            catch (IslemBasarisizHatasi hata)
            {
                this._hataServis.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return new List<KanGrubu>();
        }

        public IEnumerable<MedeniDurumu> GetirMedeniDurumuListe(bool tumuGetirilsinMi)
        {
            try
            {
                IEnumerable<MedeniDurumu> liste = null;

                liste = this._isKurali.GetirMedeniDurumuListe(tumuGetirilsinMi);

                if (liste == null)
                    throw new IslemBasarisizHatasi();

                return liste;
            }
            catch (IslemBasarisizHatasi hata)
            {
                this._hataServis.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return new List<MedeniDurumu>();
        }

        public IEnumerable<OgrenimDurumu> GetirOgrenimDurumuListe(bool tumuGetirilsinMi)
        {
            try
            {
                IEnumerable<OgrenimDurumu> liste = null;

                liste = this._isKurali.GetirOgrenimDurumuListe(tumuGetirilsinMi);

                if (liste == null)
                    throw new IslemBasarisizHatasi();

                return liste;
            }
            catch (IslemBasarisizHatasi hata)
            {
                this._hataServis.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return new List<OgrenimDurumu>();
        }

        public IEnumerable<RhDegeri> GetirPhDegeriListe(bool tumuGetirilsinMi)
        {
            try
            {
                IEnumerable<RhDegeri> liste = null;

                liste = this._isKurali.GetirPhDegeriListe(tumuGetirilsinMi);

                if (liste == null)
                    throw new IslemBasarisizHatasi();

                return liste;
            }
            catch (IslemBasarisizHatasi hata)
            {
                this._hataServis.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return new List<RhDegeri>();
        }

        public IEnumerable<Sinif> GetirSinifListe(bool tumuGetirilsinMi)
        {
            try
            {
                IEnumerable<Sinif> liste = null;

                liste = this._isKurali.GetirSinifListe(tumuGetirilsinMi);

                if (liste == null)
                    throw new IslemBasarisizHatasi();

                return liste;
            }
            catch (IslemBasarisizHatasi hata)
            {
                this._hataServis.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return new List<Sinif>();
        }

        public IEnumerable<Unvan> GetirUnvanListe(bool tumuGetirilsinMi)
        {
            try
            {
                IEnumerable<Unvan> liste = null;

                liste = this._isKurali.GetirUnvanListe(tumuGetirilsinMi);

                if (liste == null)
                    throw new IslemBasarisizHatasi();

                return liste;
            }
            catch (IslemBasarisizHatasi hata)
            {
                this._hataServis.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return new List<Unvan>();
        }

        public IEnumerable<CalismaDurumu> GetirCalismaDurumuListe(bool tumuGetirilsinMi)
        {
            try
            {
                IEnumerable<CalismaDurumu> liste = null;

                liste = this._isKurali.GetirCalismaDurumuListe(tumuGetirilsinMi);

                if (liste == null)
                    throw new IslemBasarisizHatasi();

                return liste;
            }
            catch (IslemBasarisizHatasi hata)
            {
                this._hataServis.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return new List<CalismaDurumu>();
        }

        public IEnumerable<Gorevi> GetirGoreviListe(bool tumuGetirilsinMi)
        {
            try
            {
                IEnumerable<Gorevi> liste = null;

                liste = this._isKurali.GetirGoreviListe(tumuGetirilsinMi);

                if (liste == null)
                    throw new IslemBasarisizHatasi();

                return liste;

            }
            catch (IslemBasarisizHatasi hata)
            {
                this._hataServis.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return new List<Gorevi>();
        }
    }
}
