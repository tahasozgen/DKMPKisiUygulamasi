using DKMPKisiUygulamasi.Model.IsKatmani.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPKisiUygulamasi.Model.Somut.OgrenimKlasor;
using DKMPKisiUygulamasi.Model.RepositoryKlasoru;
using DKMPKisiUygulamasi.Model.SabitlerMesajlar;

namespace DKMPKisiUygulamasi.Model.IsKatmani.Somut
{
    public class OgrenimIsKurali : IOgrenimIsKurali
    {
        private IKisiOgrenimRepository _kisiOgrenimRepository;
        private Kontrol _kontrol;
        private HataIsKurali _hataIsKurali;

        public OgrenimIsKurali(IKisiOgrenimRepository kisiOgrenimRepository)
        {
            if (kisiOgrenimRepository == null)
                throw new ArgumentNullException();

            this._kisiOgrenimRepository = kisiOgrenimRepository;
            this._kontrol = new Kontrol();
            this._hataIsKurali = new HataIsKurali();

        }

        public int EkleveDonKisiOgrenim(KisiOgrenim deger)
        {

            try
            {
                if (!this._kontrol.uygunMu(deger))
                    return Sabitler.HataliArgumanKodu;

                return this._kisiOgrenimRepository.EkleveDonAnahtar(deger);

            }
            catch (Exception hata)
            {
                this._hataIsKurali.YazHata(hata);
            }

            return int.MinValue;


        }
    }
}
