using DKMPKisiUygulamasi.Servis.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.KisiIletisimKlasoru;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.KisiIletisimKlasor;
using DKMPKisiUygulamasi.Model.IsKatmani.Soyut;
using DKMPKisiUygulamasi.Model.Somut.IletisimKlasor;
using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.Somut.HataKlasoru;

namespace DKMPKisiUygulamasi.Servis.Somut
{
    public class KisiIletisimServis : IKisiIletisimServis
    {
        private IKisiIletisimIsKurali _kisiIletisimIsKurali;
        private Kontrol _kontrol;
        private HataServis _hataServis;

        public KisiIletisimServis(IKisiIletisimIsKurali kisiIletisimIsKurali)
        {
            this._kisiIletisimIsKurali = kisiIletisimIsKurali;
            this._kontrol = new Kontrol();            
            this._hataServis = new HataServis();
        }

        public EkleKisiIletisimYanit EkleKisiIletisim(EkleKisiIletisimIstek istek)
        {
            try
            {

                IletisimTuru turu = IletisimTuru.Tanimsiz;
                int iletisimTurId, kisiId, sonucId = int.MinValue;
                KisiIletisim iletisim = null;
                EkleKisiIletisimYanit yanit = new EkleKisiIletisimYanit(false);

                if (!this._kontrol.uygunMu(istek))
                {
                    yanit.IsaretleGecemediIlkKontrolu(this._kontrol.alHataKodu(istek));
                    return yanit;
                }

                iletisimTurId = istek.TurId ?? int.MinValue;

                if (iletisimTurId == int.MinValue)
                    throw new ArgumentException();

                kisiId = istek.KisiId ?? int.MinValue;

                if (kisiId == int.MinValue)
                    throw new ArgumentException();

                turu = (IletisimTuru)Enum.ToObject(typeof(IletisimTuru), iletisimTurId);

                iletisim = new KisiIletisim(istek.Deger, turu, kisiId);

                sonucId = this._kisiIletisimIsKurali.EkleveDonAnahtar(iletisim);

                if (sonucId == int.MinValue)
                    throw new IslemBasarisizHatasi();

                yanit = new EkleKisiIletisimYanit(sonucId);

                return yanit;

            }
            catch (ArgumentException hata)
            {
                return new EkleKisiIletisimYanit(hata);
            }
            catch (IslemBasarisizHatasi hata)
            {
                this._hataServis.YazHata(hata);
                return new EkleKisiIletisimYanit(hata);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
                return new EkleKisiIletisimYanit(hata);
            }

        }
    }
}
