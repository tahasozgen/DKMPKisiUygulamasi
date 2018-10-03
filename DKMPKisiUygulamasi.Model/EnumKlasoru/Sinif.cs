using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.EnumKlasoru
{
    public enum Sinif
    {
        [Description("Teknik Hizmetler")]
        TeknikHizmetler = 3,
        [Description("Genel İdare Hizmet Sınıfı")]
        GenelIdareHizmetSinifi = 10,
        [Description("Tanımsız")]
        Tanimsiz = 127
    }
}
