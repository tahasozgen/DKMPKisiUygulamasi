using DKMPKisiUygulamasi.Model.Somut.OgrenimKlasor;
using DKMPKisiUygulamasi.Model.Somut.TanimlayiciKlasor;
using DKMPKisiUygulamasi.Model.Soyut.CalisanKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.Somut.RaporKlasor
{
    public class CalisanRaporUc : CalisanRaporSayiBaz
    {
        public OgrenimDurumu OgreniminDurumu { get; set; }

        private CalisanRaporUc():base()
        {

        }

        public CalisanRaporUc(OgrenimDurumu ogrenimDurumu) : this()
        {
            if (ogrenimDurumu == null)
                throw new ArgumentNullException();

            this.CalisanSayisi++;

        }

        public CalisanRaporUc(OgrenimDurumu ogrenimDurumu, int calisanSayisi) : this(ogrenimDurumu)
        {
            this.CalisanSayisi = calisanSayisi;
        }

    }
}
