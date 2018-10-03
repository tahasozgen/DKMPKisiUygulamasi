using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor
{
    public class CalisanViewModel : KisiViewModel
    {
        public string SicilNo { get; private set; }

        private KadrosuViewModel _kadroDurumu { get; set; }

        public SinifViewModel Sinifi { get; private set; }

        private CalismaDurumuViewModel _esCalismaDurumu { get; set; }

        protected CalisanViewModel() : base()
        {
            this.SicilNo = string.Empty;
            this._kadroDurumu = null;
            this.Sinifi = null;
            this._esCalismaDurumu = null;
        }

        public CalisanViewModel(int anahtar) : this()
        {
            this.Anahtar = anahtar;
        }

        public CalisanViewModel(string adi, string soyadi) : this()
        {
            this.Adi = adi;
            this.Soyadi = soyadi;
        }

        public CalisanViewModel(string adi, string soyadi, CinsiyetiViewModel cinsiyeti) : this(adi, soyadi)
        {
            this.Cinsi = cinsiyeti;
        }

        public CalisanViewModel(string adi, string soyadi, CinsiyetiViewModel cinsiyeti, AkademikUnvaniViewModel unvani) : this(adi, soyadi, cinsiyeti)
        {
            this.Unvani = unvani;

        }

        public CalisanViewModel(string adi, string soyadi, CinsiyetiViewModel cinsiyeti, AkademikUnvaniViewModel unvani, KanGrubuViewModel kaninGrubu, RhDegeriViewModel phDeger, MedeniDurumuViewModel medeniHali, string turCumKimlikNo, string dogumTarihi, string sicilNo, KadrosuViewModel kadroDurumu, SinifViewModel sinifi) : this(adi, soyadi, cinsiyeti)
        {
            this.Unvani = unvani;
            this.KaninGrubu = kaninGrubu;
            this.PhDeger = phDeger;
            this.MedeniHali = medeniHali;
            this.TurCumKimlikNo = turCumKimlikNo;
            this.DogumTarihiSozce = dogumTarihi;
            this.SicilNo = sicilNo;
            this._kadroDurumu = kadroDurumu;
            this.Sinifi = sinifi;
        }

        public CalisanViewModel(string adi, string soyadi, CinsiyetiViewModel cinsiyeti, AkademikUnvaniViewModel unvani, KanGrubuViewModel kaninGrubu, RhDegeriViewModel phDeger, MedeniDurumuViewModel medeniHali, string turCumKimlikNo, string dogumTarihi, string sicilNo, KadrosuViewModel kadroDurumu, SinifViewModel sinifi, string ibanNo, byte[] vesikalik) : this( adi,  soyadi,  cinsiyeti,  unvani,  kaninGrubu,  phDeger,  medeniHali,  turCumKimlikNo,  dogumTarihi,  sicilNo,  kadroDurumu,  sinifi)
        {
            this.IbanNo = ibanNo;
            this.Vesikalik = vesikalik;
        }

        public string SinifiSozce
        {
            get
            {
                return (this.Sinifi != null) ? this.Sinifi.Adi : string.Empty;
            }

        }
    }
}
