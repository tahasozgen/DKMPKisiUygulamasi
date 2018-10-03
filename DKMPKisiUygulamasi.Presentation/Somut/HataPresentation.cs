using DKMPKisiUygulamasi.Presentation.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPHataAltyapi;

namespace DKMPKisiUygulamasi.Presentation.Somut
{
    public class HataPresentation : PresentationBaz,IHataPresentation
    {
        public void YazHata(UIHata hata)
        {
            if (hata != null)
                this._hataServis.YazHata(hata);
        }

        public void YazHata(Exception hata)
        {
            if (hata != null)
                this._hataServis.YazHata(hata);
        }
    }
}
