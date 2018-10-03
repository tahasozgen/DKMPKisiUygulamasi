using DKMPKisiUygulamasi.CakmaWCF.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPHataAltyapi;

namespace DKMPKisiUygulamasi.CakmaWCF.Somut
{
    public class HataServis : IHataServis
    {

        private readonly DKMPKisiUygulamasi.Servis.Somut.HataServis _hataServis;

        public HataServis()
        {
            this._hataServis = new DKMPKisiUygulamasi.Servis.Somut.HataServis();
        }

        public void YazHata(UIHata hata)
        {
            try
            {
                if (hata != null)
                    this._hataServis.YazHata(hata);
            }
            catch (Exception yeniHata)
            {
                this._hataServis.YazHata(yeniHata);
            }
        }

        public void YazHata(Exception hata)
        {
            try
            {
                if (hata != null)
                    this._hataServis.YazHata(hata);
            }
            catch (Exception yeniHata)
            {
                this._hataServis.YazHata(yeniHata);
            }
        }
    }
}
