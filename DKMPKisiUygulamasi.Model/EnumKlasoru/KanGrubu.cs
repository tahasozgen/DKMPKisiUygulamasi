using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.EnumKlasoru
{
    public enum KanGrubu
    {
        [Description("0")]
        Sifir = 3,
        [Description("A")]
        A = 10,
        [Description("B")]
        B = 17,
        [Description("AB")]
        AB = 24,
        [Description("Tanımsız")]
        Tanimsiz = 127
    }
}
