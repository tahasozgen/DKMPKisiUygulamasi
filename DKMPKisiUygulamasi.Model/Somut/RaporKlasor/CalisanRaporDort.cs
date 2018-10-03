using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.Soyut.CalisanKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.Somut.RaporKlasor
{
    public class CalisanRaporDort : CalisanRaporSayiBaz
    {
        public Kadrosu Kadrosu { get; set; }

        private CalisanRaporDort():base()
        {

        }

        public CalisanRaporDort(Kadrosu kadrosu) : this()
        {
            if (kadrosu == Kadrosu.Tanimsiz)
                throw new ArgumentException();

            this.Kadrosu = kadrosu;
            this.CalisanSayisi++;

        }
        public CalisanRaporDort(Kadrosu kadrosu, int calisanSayisi) : this(kadrosu)
        {
            this.CalisanSayisi = calisanSayisi;
        }

    }
}
