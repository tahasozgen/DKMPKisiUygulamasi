using DKMPKisiUygulamasi.Model.IsKatmani.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.Somut.TanimlayiciKlasor;
using DKMPKisiUygulamasi.Model.RepositoryKlasoru;
using DKMPKisiUygulamasi.Model.Somut.HataKlasoru;
using DKMPKisiUygulamasi.Model.Somut.OgrenimKlasor;
using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;

namespace DKMPKisiUygulamasi.Model.IsKatmani.Somut
{
    public class TanimlayiciVarlikIsKurali : ITanimlayiciVarlikIsKurali
    {

        private readonly IOgrenimDurumuRepository _ogrenimRepository;

        private readonly IUnvanRepository _unvanRepository;

        private readonly IGorevRepository _gorevRepository;

        private readonly HataIsKurali _hataIsKurali;

        public TanimlayiciVarlikIsKurali(IOgrenimDurumuRepository ogrenimRepository, IUnvanRepository unvanRepository, IGorevRepository gorevRepository)
        {
            this._unvanRepository = unvanRepository;
            this._ogrenimRepository = ogrenimRepository;
            this._gorevRepository = gorevRepository;
            this._hataIsKurali = new HataIsKurali();
        }

        public IEnumerable<AkademikUnvani> GetirAkademikUnvanListe(bool tumuGetirilsinMi)
        {

            try
            {
                List<AkademikUnvani> liste = new List<AkademikUnvani>();
                var degerler = Enum.GetValues(typeof(AkademikUnvani)).Cast<AkademikUnvani>();

                if (!tumuGetirilsinMi)
                    return liste;

                if (degerler == null)
                    return liste;

                foreach (AkademikUnvani deger in degerler)
                {
                    if (deger != AkademikUnvani.Tanimsiz)
                        liste.Add(deger);
                }

                return liste;
            }
            catch (Exception hata)
            {
                this._hataIsKurali.YazHata(hata);
            }

            return new List<AkademikUnvani>();

        }

        public IEnumerable<Cinsiyeti> GetirCinsiyetListe(bool tumuGetirilsinMi)
        {
            try
            {
                List<Cinsiyeti> liste = new List<Cinsiyeti>();
                var degerler = Enum.GetValues(typeof(Cinsiyeti)).Cast<Cinsiyeti>();

                if (!tumuGetirilsinMi)
                    return liste;

                if (degerler == null)
                    return liste;

                foreach (Cinsiyeti deger in degerler)
                {
                    if (deger != Cinsiyeti.Tanimsiz)
                        liste.Add(deger);
                }

                return liste;
            }
            catch (Exception hata)
            {
                this._hataIsKurali.YazHata(hata);
            }

            return new List<Cinsiyeti>();
        }

        public IEnumerable<HizmetSonlanisNedeni> GetirHizmetSonlanisNedeniListe(bool tumuGetirilsinMi)
        {
            try
            {
                List<HizmetSonlanisNedeni> liste = new List<HizmetSonlanisNedeni>();
                var degerler = Enum.GetValues(typeof(HizmetSonlanisNedeni)).Cast<HizmetSonlanisNedeni>();

                if (!tumuGetirilsinMi)
                    return liste;

                if (degerler == null)
                    return liste;

                foreach (HizmetSonlanisNedeni deger in degerler)
                {
                    if (deger != HizmetSonlanisNedeni.Tanimsiz)
                        liste.Add(deger);
                }

                return liste;
            }
            catch (Exception hata)
            {
                this._hataIsKurali.YazHata(hata);
            }

            return new List<HizmetSonlanisNedeni>();

        }

        public IEnumerable<Kadrosu> GetirKadrosuListe(bool tumuGetirilsinMi)
        {
            try
            {
                List<Kadrosu> liste = new List<Kadrosu>();
                var degerler = Enum.GetValues(typeof(Kadrosu)).Cast<Kadrosu>();

                if (!tumuGetirilsinMi)
                    return liste;

                if (degerler == null)
                    return liste;

                foreach (Kadrosu deger in degerler)
                {
                    if (deger != Kadrosu.Tanimsiz)
                        liste.Add(deger);
                }

                return liste;
            }
            catch (Exception hata)
            {
                this._hataIsKurali.YazHata(hata);
            }

            return new List<Kadrosu>();
        }

        public IEnumerable<KanGrubu> GetirKanGrubuListe(bool tumuGetirilsinMi)
        {
            try
            {
                List<KanGrubu> liste = new List<KanGrubu>();
                var degerler = Enum.GetValues(typeof(KanGrubu)).Cast<KanGrubu>();

                if (!tumuGetirilsinMi)
                    return liste;

                if (degerler == null)
                    return liste;

                foreach (KanGrubu deger in degerler)
                {
                    if (deger != KanGrubu.Tanimsiz)
                        liste.Add(deger);
                }

                return liste;
            }
            catch (Exception hata)
            {
                this._hataIsKurali.YazHata(hata);
            }

            return new List<KanGrubu>();
        }

        public IEnumerable<MedeniDurumu> GetirMedeniDurumuListe(bool tumuGetirilsinMi)
        {
            try
            {
                List<MedeniDurumu> liste = new List<MedeniDurumu>();
                var degerler = Enum.GetValues(typeof(MedeniDurumu)).Cast<MedeniDurumu>();

                if (!tumuGetirilsinMi)
                    return liste;

                if (degerler == null)
                    return liste;

                foreach (MedeniDurumu deger in degerler)
                {
                    if (deger != MedeniDurumu.Tanimsiz)
                        liste.Add(deger);
                }

                return liste;
            }
            catch (Exception hata)
            {
                this._hataIsKurali.YazHata(hata);
            }

            return new List<MedeniDurumu>();
        }

        public IEnumerable<OgrenimDurumu> GetirOgrenimDurumuListe(bool tumuGetirilsinMi)
        {

            try
            {
                IEnumerable<OgrenimDurumu> liste = new List<OgrenimDurumu>();

                if (!tumuGetirilsinMi)
                    return liste;

                liste = this._ogrenimRepository.GetirOgrenimDurumuListe(tumuGetirilsinMi);

                if (liste == null)
                    throw new IslemBasarisizHatasi();

                return liste;
            }
            catch (IslemBasarisizHatasi hata)
            {
                this._hataIsKurali.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataIsKurali.YazHata(hata);
            }

            return new List<OgrenimDurumu>();

        }

        public IEnumerable<RhDegeri> GetirPhDegeriListe(bool tumuGetirilsinMi)
        {
            try
            {
                List<RhDegeri> liste = new List<RhDegeri>();
                var degerler = Enum.GetValues(typeof(RhDegeri)).Cast<RhDegeri>();

                if (!tumuGetirilsinMi)
                    return liste;

                if (degerler == null)
                    return liste;

                foreach (RhDegeri deger in degerler)
                {
                    if (deger != RhDegeri.Tanimsiz)
                        liste.Add(deger);
                }

                return liste;
            }
            catch (Exception hata)
            {
                this._hataIsKurali.YazHata(hata);
            }

            return new List<RhDegeri>();
        }

        public IEnumerable<Sinif> GetirSinifListe(bool tumuGetirilsinMi)
        {
            try
            {
                List<Sinif> liste = new List<Sinif>();
                var degerler = Enum.GetValues(typeof(Sinif)).Cast<Sinif>();

                if (!tumuGetirilsinMi)
                    return liste;

                if (degerler == null)
                    return liste;

                foreach (Sinif deger in degerler)
                {
                    if (deger != Sinif.Tanimsiz)
                        liste.Add(deger);
                }

                return liste;
            }
            catch (Exception hata)
            {
                this._hataIsKurali.YazHata(hata);
            }

            return new List<Sinif>();
        }

        public IEnumerable<Unvan> GetirUnvanListe(bool tumuGetirilsinMi)
        {
            try
            {
                IEnumerable<Unvan> liste = new List<Unvan>();

                if (!tumuGetirilsinMi)
                    return liste;

                liste = this._unvanRepository.GetirUnvanListe(tumuGetirilsinMi);

                if (liste == null)
                    throw new IslemBasarisizHatasi();

                return liste;
            }
            catch (IslemBasarisizHatasi hata)
            {
                this._hataIsKurali.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataIsKurali.YazHata(hata);
            }

            return new List<Unvan>();
        }

        public IEnumerable<CalismaDurumu> GetirCalismaDurumuListe(bool tumuGetirilsinMi)
        {
            try
            {
                List<CalismaDurumu> liste = new List<CalismaDurumu>();
                var degerler = Enum.GetValues(typeof(CalismaDurumu)).Cast<CalismaDurumu>();

                if (!tumuGetirilsinMi)
                    return liste;

                if (degerler == null)
                    return liste;

                foreach (CalismaDurumu deger in degerler)
                {
                    if (deger != CalismaDurumu.Tanimsiz)
                        liste.Add(deger);
                }

                return liste;
            }
            catch (Exception hata)
            {
                this._hataIsKurali.YazHata(hata);
            }

            return new List<CalismaDurumu>();
        }

        public IEnumerable<Gorevi> GetirGoreviListe(bool tumuGetirilsinMi)
        {

            try
            {
                IEnumerable<Gorevi> liste = new List<Gorevi>();

                if (!tumuGetirilsinMi)
                    return liste;

                liste = this._gorevRepository.GetirGorevListe(tumuGetirilsinMi);

                if (liste == null)
                    throw new IslemBasarisizHatasi();

                return liste;

            }
            catch (IslemBasarisizHatasi hata)
            {
                this._hataIsKurali.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataIsKurali.YazHata(hata);
            }

            return new List<Gorevi>();

        }
    }
}
