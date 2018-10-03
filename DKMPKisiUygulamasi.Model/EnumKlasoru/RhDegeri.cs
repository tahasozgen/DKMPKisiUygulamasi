using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.EnumKlasoru
{
    public enum RhDegeri
    {
        [Description("+")]
        Arti = 3,
        [Description("-")]
        Eksi = 10,
        [Description("Tanımsız")]
        Tanimsiz = 127
    }
}
