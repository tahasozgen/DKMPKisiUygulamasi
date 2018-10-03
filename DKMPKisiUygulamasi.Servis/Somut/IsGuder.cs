using DKMPKisiUygulamasi.Model.IsKatmani.Somut;
using DKMPKisiUygulamasi.Model.IsKatmani.Soyut;
using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using DKMPKisiUygulamasi.Servis.Soyut;
using DKMPKurumCografyaUygulamasi.Servis.ViewModel.VarlikKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Somut
{
    class IsGuder
    {
        private ICalisanIsKurali _calisanIsKurali;

        private IGorevlendirmeIsKurali _gorevlendirmeIsKurali;

        private BirimServis _birimServis;

        private HataServis _hataServis;

        public IsGuder(ICalisanIsKurali calisanIsKurali, IGorevlendirmeIsKurali gorevlendirmeIsKurali )
        {
            this._calisanIsKurali = calisanIsKurali;
            this._gorevlendirmeIsKurali = gorevlendirmeIsKurali;
            this._hataServis = new HataServis();
            this._birimServis = new BirimServis();
        }
        
        internal Calisan getirCalisan(int calisanId)
        {
            try
            {
                if (calisanId == int.MinValue)
                    throw new ArgumentException();

                return this._calisanIsKurali.GetirCalisan(calisanId);

            }
            catch (ArgumentException)
            {
                
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return null;
        }

        internal CalisanGorevlendirme getirMevcutGorevi(int calisanId, bool getirilsinMiSadeceResmiGorevler)
        {
            try
            {
                if (calisanId == int.MinValue)
                    throw new ArgumentException();

                return this._gorevlendirmeIsKurali.GetirMevcutGorevi(calisanId, getirilsinMiSadeceResmiGorevler);
            }
            catch (ArgumentException)
            {
                
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return null;
        }

        internal IEnumerable<BirimViewModel> getirBirimKullanicininGorebilecegi(int? kullaniciId)
        {
            try
            {
                int deger = int.MinValue;
                IEnumerable<BirimViewModel> birimVmListe = null;

                if (kullaniciId == null|| kullaniciId == int.MinValue )
                    throw new ArgumentException();

                deger = kullaniciId ?? int.MinValue;

                birimVmListe = this._birimServis.getirBirimKullanicininGorebilecegi(deger);

                if (birimVmListe == null)
                    throw new ApplicationException();

                return birimVmListe;
            }
            catch (ArgumentException)
            {
                
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return new List<BirimViewModel>();
        }

    }
}
