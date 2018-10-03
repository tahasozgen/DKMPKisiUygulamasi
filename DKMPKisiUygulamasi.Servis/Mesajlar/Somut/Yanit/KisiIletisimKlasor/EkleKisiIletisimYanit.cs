using DKMPKisiUygulamasi.Servis.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.KisiIletisimKlasor
{
    public class EkleKisiIletisimYanit : TransactionYanitBaz
    {
        private EkleKisiIletisimYanit() : base()
        {
        }

        public EkleKisiIletisimYanit(bool basariliMi) : base()
        {
        }

        public EkleKisiIletisimYanit(int islemId) : base(islemId)
        {
        }

        public EkleKisiIletisimYanit(int islemId, string mesajKodu) : base( islemId,  mesajKodu)
        {
        }

        public EkleKisiIletisimYanit(Exception hata) : base(hata)
        {

        }

        public EkleKisiIletisimYanit(DKMPHataAltyapi.ModelHata hata) : base(hata)
        {

        }

    }
}
