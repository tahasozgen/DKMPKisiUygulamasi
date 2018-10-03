using DKMPKisiUygulamasi.Servis.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.OgrenimKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.OgrenimKlasor;
using DKMPKisiUygulamasi.Model.IsKatmani.Soyut;
using DKMPKisiUygulamasi.Model.Somut.OgrenimKlasor;
using DKMPKisiUygulamasi.Model.Somut.HataKlasoru;

namespace DKMPKisiUygulamasi.Servis.Somut
{
    public class OgrenimServis : IOgrenimServis
    {

        private IOgrenimIsKurali _ogrenimIsKurali;
        private Kontrol _kontrol;
        private HataServis _hataServis;

        public OgrenimServis(IOgrenimIsKurali ogrenimIsKurali)
        {
            this._ogrenimIsKurali = ogrenimIsKurali;
            this._kontrol = new Kontrol();
            this._hataServis = new HataServis();
        }

        public EkleKisiOgrenimYanit EkleKisiOgrenim(EkleKisiOgrenimIstek istek)
        {

            try
            {
                EkleKisiOgrenimYanit yanit = new EkleKisiOgrenimYanit(false);
                KisiOgrenim ogrenim = null;
                int calisanId, ogrenimDurumuId, universiteId, sonucId = int.MinValue;

                if (!this._kontrol.uygunMu(istek))
                {
                    yanit.IsaretleGecemediIlkKontrolu(this._kontrol.alHataKodu(istek));
                    return yanit;
                }

                calisanId = istek.CalisanId ?? int.MinValue;

                if (calisanId == int.MinValue)
                    throw new ArgumentException();

                ogrenimDurumuId = istek.OgrenimDurumuId ?? int.MinValue;

                if (ogrenimDurumuId == int.MinValue)
                    throw new ArgumentException();

                universiteId = istek.UniversiteId ?? int.MinValue;

                ogrenim = new KisiOgrenim(calisanId, ogrenimDurumuId, universiteId);

                sonucId = this._ogrenimIsKurali.EkleveDonKisiOgrenim(ogrenim);

                if (sonucId == int.MinValue)
                    throw new IslemBasarisizHatasi();

                yanit = new EkleKisiOgrenimYanit(sonucId);

                return yanit;
            }
            catch (ArgumentException hata)
            {
                return new EkleKisiOgrenimYanit(hata);
            }
            catch (IslemBasarisizHatasi hata)
            {
                this._hataServis.YazHata(hata);
                return new EkleKisiOgrenimYanit(hata);                
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
                return new EkleKisiOgrenimYanit(hata);
            }

        }
    }
}
