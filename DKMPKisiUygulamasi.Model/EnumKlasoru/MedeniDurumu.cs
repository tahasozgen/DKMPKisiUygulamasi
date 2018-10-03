using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.EnumKlasoru
{
    public enum MedeniDurumu
    {
        [Description("Bekar")]
        Bekar = 3,
        [Description("Boşanmış")]
        Bosanmis = 10,
        [Description("Evli")]
        Evli = 17,
        [Description("Tanımsız")]
        Tanimsiz = 127
    }
}
