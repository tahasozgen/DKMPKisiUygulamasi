using DKMPHataAltyapi.Enum;
using DKMPKisiUygulamasi.Model.IsKatmani.Somut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.BirimTesti.Altyapi
{
    public abstract class HataEleAlma
    {
        private HataIsKurali _hataik;

        public HataEleAlma()
        {
            this._hataik = new HataIsKurali();
        }

        protected void YazHata(Exception hata)
        {
            if (hata != null)
            {
                this._hataik.YazHata(hata);
            }

        }

        public void KurSayac(Sayac sayac)
        {
            this._hataik.KurSayac(sayac);
        }

        /// <summary>
        /// Daha önce kurulan başlangıç ve bitiş zamanları arasında veritabanında hata alınıp alınmadığını kontrol eden işlev.
        /// </summary>
        /// <returns></returns>
        public bool AlindiMiHata()
        {
            return this._hataik.HataAlindiMi();
        }

    }
}
