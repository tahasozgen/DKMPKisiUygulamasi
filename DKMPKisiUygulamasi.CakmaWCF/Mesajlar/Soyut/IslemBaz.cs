using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.Mesajlar.Soyut
{
    public abstract class IslemBaz
    {
        public bool BasariliMi { get; protected set; }

        public string Mesaj { get; protected set; }

        public bool GectiMiIlkKontrolu { get; protected set; }

        public Exception Hata { get; set; }

        protected IslemBaz()
        {
            this.BasariliMi = true;
            this.Mesaj = string.Empty;
            this.GectiMiIlkKontrolu = true;
            this.Hata = null;
        }

        public IslemBaz(bool islemSonucu):this()
        {
            this.BasariliMi = islemSonucu;
        }

        public IslemBaz(string mesaj) : this()
        {
            this.Mesaj = mesaj;
        }

        protected void kurHata(Exception hata)
        {
            if(hata != null)
            {
                this.BasariliMi = false;
                this.Hata = hata;
            }
        }
        
    }
}
