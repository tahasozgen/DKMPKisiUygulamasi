using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor
{
    public class KisiViewModel
    {

        public int? Anahtar { get; protected set; }

        protected AkademikUnvaniViewModel Unvani { private get; set; }
        
        public string Adi { get; protected set; }
        
        public string KizlikSoyadi { get; protected set; }
        
        public string Soyadi { get; protected set; }

        protected CinsiyetiViewModel Cinsi { private get; set; }

        protected KanGrubuViewModel KaninGrubu { private get; set; }

        protected RhDegeriViewModel PhDeger { private get; set; }

        protected MedeniDurumuViewModel MedeniHali { private get; set; }
                
        public string TurCumKimlikNo { get; protected set; }

        public string DogumTarihiSozce { get; protected set; }

        public string IbanNo { get; protected set; }

        public byte[] Vesikalik { get; protected set; }
        
        protected KisiViewModel()
        {
            this.Adi = string.Empty;
            this.Anahtar = null;
            this.Cinsi = null;
            this.DogumTarihiSozce = string.Empty;
            this.IbanNo = string.Empty;
            this.KaninGrubu = null;
            this.KizlikSoyadi = string.Empty;
            this.MedeniHali = null;
            this.PhDeger = null;
            this.Soyadi = string.Empty;
            this.TurCumKimlikNo = string.Empty;
            this.Unvani = null;
            this.Vesikalik = null;
        }
        
        public string Cinsiyeti
        {
            get
            {
                return this.Cinsi != null ? this.Cinsi.Adi : string.Empty;
            }
        }

        public string KanGrubuveRh
        {
            get
            {
                string kanGrubu = this.KaninGrubu != null ? this.KaninGrubu.Adi : string.Empty;
                string rh = this.PhDeger != null ? this.PhDeger.Adi : string.Empty;

                return new StringBuilder(kanGrubu + " rh" + rh).ToString();
            }
        }

        public string MedeniHaliSozce
        {
            get
            {
                return this.MedeniHali != null ? this.MedeniHali.Adi : string.Empty;
            }
        }

        public string AkademikUnvani
        {
            get
            {
                return this.Unvani != null ? this.Unvani.Adi : string.Empty;
            }
        }

        public string AdiSoyadi
        {
            get
            {
                string adi = (String.IsNullOrEmpty(this.Adi)) ? string.Empty : this.Adi;
                string soyadi = (String.IsNullOrEmpty(this.Soyadi)) ? string.Empty : this.Soyadi;

                return adi + " " + soyadi;

            }
        }

    }
}
