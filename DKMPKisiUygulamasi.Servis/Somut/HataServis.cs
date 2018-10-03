using DKMPKisiUygulamasi.Model.IsKatmani.Somut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Somut
{

   public class HataServis
    {
        private HataIsKurali _hataIsKurali;

        public HataServis()
        {
            this._hataIsKurali = new HataIsKurali();
        }

        public void YazHata(Exception hata)
        {
            if (hata != null)                         
                this._hataIsKurali.YazHata(hata);         
        }

        public void YazHata(DKMPHataAltyapi.Soyut.HataBase hata)
        {
            if (hata != null)
                this._hataIsKurali.YazHata(hata);
        }

    }
}
