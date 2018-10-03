using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.Somut.HataKlasoru
{
    public class IslemBasarisizHatasi : DKMPHataAltyapi.ModelHata
    {

        public IslemBasarisizHatasi() : base()
        {
            this.HataCiddiyeti = DKMPHataAltyapi.Enum.HataCiddiyetiEnum.Normal;
        }

        public IslemBasarisizHatasi(string hataninAlindigiYer) : this()
        {
            this.HataninAlindigiYer = hataninAlindigiYer;
        }     

        public IslemBasarisizHatasi(DKMPHataAltyapi.Enum.HataCiddiyetiEnum hataCiddiyeti) : this()
        {
            this.HataCiddiyeti = hataCiddiyeti;
        }

    }
}
