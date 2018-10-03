using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.EnumKlasoru
{
    public enum Cinsiyeti
    {
        [Description("Kadın")]
        Kadin = 3,
        [Description("Erkek")]
        Erkek = 10,
        [Description("Tanımsız")]
        Tanimsiz = 127
    }
}
