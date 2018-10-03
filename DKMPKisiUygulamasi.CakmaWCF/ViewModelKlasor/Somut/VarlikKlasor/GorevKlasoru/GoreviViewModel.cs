using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.GorevKlasoru
{
    public class GoreviViewModel
    {
        public int? Anahtar { get; private set; }

        public string Adi { get; private set; }

        public bool? YoneticiMi { get; private set; }

        public bool? AmirMi { get; private set; }

        public string KisaAdi { get; private set; }

        protected GoreviViewModel()
        {
            this.Anahtar = int.MinValue;
            this.Adi = null;
            this.YoneticiMi = false;
            this.AmirMi = false;
            this.KisaAdi = null;
        }

        public GoreviViewModel(int anahtar):this()
        {
            this.Anahtar = anahtar;
        }

        public GoreviViewModel(int anahtar, string adi) : this(anahtar)
        {
            this.Adi = adi;
        }

        public GoreviViewModel(int anahtar, string adi, bool yoneticiMi) : this(anahtar, adi)
        {
            this.YoneticiMi = yoneticiMi;
        }

        public GoreviViewModel(int anahtar, string adi, bool yoneticiMi, bool amirMi) : this(anahtar, adi, yoneticiMi)
        {
            this.AmirMi = amirMi;
        }

    }
}
