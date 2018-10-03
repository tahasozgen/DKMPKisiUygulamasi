using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.OgrenimKlasor;
using DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.OgrenimKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Soyut
{
    public interface IOgrenimServis
    {
        EkleKisiOgrenimYanit EkleKisiOgrenim(EkleKisiOgrenimIstek istek);
    }
}
