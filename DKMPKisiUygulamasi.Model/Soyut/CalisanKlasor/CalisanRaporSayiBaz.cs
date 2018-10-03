using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.Soyut.CalisanKlasor
{
    public abstract class CalisanRaporSayiBaz
    {
        public int CalisanSayisi { get; set; }

        protected CalisanRaporSayiBaz()
        {
            this.CalisanSayisi = 0;
        }
        
        public CalisanRaporSayiBaz( int calisanSayisi):this()
        {
            if (calisanSayisi < 0)
                throw new ArgumentException();

            this.CalisanSayisi = calisanSayisi;
                
        }

    }

}
