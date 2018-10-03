using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;
using DKMPKisiUygulamasi.Model.Somut.HataKlasoru;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using DKMPKisiUygulamasi.Model.Somut.TanimlayiciKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPHataAltyapi.Enum;
using DKMPKisiUygulamasi.Model.SabitlerMesajlar;

namespace DKMPKisiUygulamasi.Model.IsKatmani.Somut
{
    public class HataIsKurali
    {
        private DKMPHataAltyapi.HataRaporlama _hataRapor;
        private int _uygulamaIdSi = int.MinValue;
        private string _veriKaynagi = null;

        public HataIsKurali()
        {
            this._uygulamaIdSi = Sabitler.UygulamaId;
            this._veriKaynagi = Sabitler.HataServisBaglantiCumlesi;
            this._hataRapor = new DKMPHataAltyapi.HataRaporlama(this._uygulamaIdSi, this._veriKaynagi);
        }

        public bool HataAlindiMi()
        {
            return this._hataRapor.AlindiMiHata();
        }

        public bool YazHata(Exception hata)
        {
            if (hata != null)
            {
                return this._hataRapor.RaporlaHata(hata);
            }
            else
                return false;
        }

        public bool YazHata(DKMPHataAltyapi.Soyut.HataBase hata)
        {
            return (hata != null) ? this._hataRapor.RaporlaHata(hata) : false;
        }

        public void KurSayac(Sayac sayac)
        {
            this._hataRapor.KurSayac(sayac);
        }


        internal BosReferansHatasi alHataNesnesi(string hataninAlindigiYer, CalisanGorevlendirme deger1, Calisan deger2, Unvan deger3)
        {
            BosReferansHatasi hata = null;

            if (deger1 == null)
                hata = new BosReferansHatasi(Arac.AlSinifYolu<CalisanGorevlendirme>(), hataninAlindigiYer);
            else if (deger2 == null)
                hata = new BosReferansHatasi(Arac.AlSinifYolu<Calisan>(), hataninAlindigiYer);
            else if (deger3 == null)
                hata = new BosReferansHatasi(Arac.AlSinifYolu<Unvan>(), hataninAlindigiYer);

            return hata;

        }      

    }

}
