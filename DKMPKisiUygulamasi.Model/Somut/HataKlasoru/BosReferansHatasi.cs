using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.Somut.HataKlasoru
{
    class BosReferansHatasi : DKMPHataAltyapi.ModelHata
    {
        public BosReferansHatasi() : base()
        {

        }

        public BosReferansHatasi(string bosGelenVarlik) : this()
        {
            this.Mesaj = "varlik bos geliyor:" + bosGelenVarlik;
            this.HataCiddiyeti = DKMPHataAltyapi.Enum.HataCiddiyetiEnum.Normal;
        }

        public BosReferansHatasi(string bosGelenVarlik, string hataninAlindigiYer) : this(bosGelenVarlik)
        {
            this.HataninAlindigiYer = hataninAlindigiYer;
        }

        public BosReferansHatasi(string bosGelenVarlik, DKMPHataAltyapi.Enum.HataCiddiyetiEnum hataCiddiyeti) : this(bosGelenVarlik)
        {
            this.HataCiddiyeti = hataCiddiyeti;
        }
    }
}
