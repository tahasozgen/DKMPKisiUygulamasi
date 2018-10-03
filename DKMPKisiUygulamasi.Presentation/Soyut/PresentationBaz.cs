using DKMPKisiUygulamasi.Presentation.Somut;
using DKMPKisiUygulamasi.Servis.Somut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.Soyut
{
    public abstract class PresentationBaz
    {

        protected readonly Kontrol _kontrol;

        protected readonly Cevir _cevir;

        protected readonly HataServis _hataServis;

        protected PresentationBaz()
        {
            this._hataServis = new HataServis();
            this._kontrol = new Kontrol();
            this._cevir = new Cevir();
        }


      

    }
}
