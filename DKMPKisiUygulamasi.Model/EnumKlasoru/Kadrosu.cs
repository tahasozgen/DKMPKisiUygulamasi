using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.EnumKlasoru
{
    public enum Kadrosu
    {
        [Description("Memur")]
        Memur = 3,
        [Description("Daimi İşçi")]
        DaimiIsci = 10,
        [Description("Tanımsız")]
        Tanimsiz = 127
    }
}
