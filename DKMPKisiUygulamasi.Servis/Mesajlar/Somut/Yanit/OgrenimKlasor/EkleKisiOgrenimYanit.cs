using DKMPKisiUygulamasi.Servis.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.OgrenimKlasor
{
    public class EkleKisiOgrenimYanit : TransactionYanitBaz
    {
        private EkleKisiOgrenimYanit() : base()
        {
        }

        public EkleKisiOgrenimYanit(bool basariliMi) : base(basariliMi)
        {

        }

        public EkleKisiOgrenimYanit(int islemId) : base(islemId)
        {
        }

        public EkleKisiOgrenimYanit(int islemId, string mesajKodu) : base( islemId,  mesajKodu)
        {
        }

        public EkleKisiOgrenimYanit(Exception hata) : base(hata)
        {

        }

        public EkleKisiOgrenimYanit(DKMPHataAltyapi.ModelHata hata) : base(hata)
        {

        }
    }
}
