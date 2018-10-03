using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Soyut
{
    public abstract class IslemBazViewModel
    {
        public bool BasariliMi { get; protected set; }

        public string Mesaj { get; protected set; }

        public bool GectiMiIlkKontrolu { get; protected set; }

        public Exception Hata { get; private set; }

        protected IslemBazViewModel()
        {
            this.BasariliMi = true;
            this.Mesaj = string.Empty;
            this.GectiMiIlkKontrolu = true;
            this.Hata = null;
        }

        public IslemBazViewModel(bool basariliMi) : this()
        {
            this.BasariliMi = basariliMi;
        }

        public IslemBazViewModel(string mesaj) : this()
        {
            this.Mesaj = mesaj;
        }

        internal void kurHata(Exception hata)
        {
            if(hata != null)
            {
                this.Hata = hata;
                this.BasariliMi = false;
            }
        }

    }
}
