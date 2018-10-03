using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.KisiIletisimKlasoru;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.KisiIletisimKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Soyut
{
    public interface IKisiIletisimServis
    {
        EkleKisiIletisimYanit EkleKisiIletisim(EkleKisiIletisimIstek istek);
    }
}
