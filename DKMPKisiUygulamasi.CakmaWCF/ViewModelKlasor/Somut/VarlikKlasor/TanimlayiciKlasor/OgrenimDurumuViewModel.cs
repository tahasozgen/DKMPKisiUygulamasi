using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.TanimlayiciKlasor
{
    public class OgrenimDurumuViewModel
    {

        public int? Anahtar { get; private set; }
        
        public string Adi { get; private set; }

        public EgitimDuzeyiViewModel Duzeyi { get; private set; }

        private OgrenimDurumuViewModel()
        {
            this.Anahtar = null;
            this.Adi = string.Empty;
            this.Duzeyi = null;
        }

        public OgrenimDurumuViewModel(int anahtar):this()
        {
            this.Anahtar = anahtar;
        }

        public OgrenimDurumuViewModel(string adi, EgitimDuzeyiViewModel duzeyi) : this()
        {
            this.Adi = adi;
            this.Duzeyi = duzeyi;
        }

    }

}
