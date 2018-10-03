using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Soyut
{
    public class SozlukViewModel
    {
        public int? Anahtar { get; private set; }

        public string Adi { get; private set; }

        protected SozlukViewModel()
        {
            this.Adi = string.Empty;
            this.Anahtar = null;
        }

        public SozlukViewModel(int anahtar, string adi) : this()
        {
            this.Anahtar = anahtar;
            this.Adi = adi;
        }
    }
}
