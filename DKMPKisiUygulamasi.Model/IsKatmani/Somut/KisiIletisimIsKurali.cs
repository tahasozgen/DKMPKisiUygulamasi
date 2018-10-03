using DKMPKisiUygulamasi.Model.IsKatmani.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPKisiUygulamasi.Model.Somut.IletisimKlasor;
using DKMPKisiUygulamasi.Model.RepositoryKlasoru;
using DKMPKisiUygulamasi.Model.Somut.HataKlasoru;

namespace DKMPKisiUygulamasi.Model.IsKatmani.Somut
{
    public class KisiIletisimIsKurali : IKisiIletisimIsKurali
    {
        private Kontrol _kontrol;

        private IKisiIletisimRepository _kisiIletisimRepository;

        private HataIsKurali _hataIsKurali;

        public KisiIletisimIsKurali(IKisiIletisimRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException();

            this._kisiIletisimRepository = repository;
            this._kontrol = new Kontrol();
            this._hataIsKurali = new HataIsKurali();
        }

        public int EkleveDonAnahtar(KisiIletisim deger)
        {
            try
            {
                int sonucId = int.MinValue;

                if (!this._kontrol.uygunMu(deger))
                    throw new ArgumentException();

                sonucId = this._kisiIletisimRepository.EkleVeDonAnahtar(deger);

                if (sonucId == int.MinValue)
                    throw new IslemBasarisizHatasi();

                return sonucId;
            }
            catch (ArgumentException)
            {
                
            }
            catch (IslemBasarisizHatasi hata)
            {
                this._hataIsKurali.YazHata(hata);
            }
            catch (Exception hata)
            {
                this._hataIsKurali.YazHata(hata);
            }

            return int.MinValue;

        }
    }
}
