using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.EnumKlasoru
{
    public enum HizmetSonlanisNedeni
    {
        [Description("İstifa")]
        Istifa = 3,
        [Description("Emeklilik")]
        Emeklilik = 10,
        [Description("Başka Birime Görevlendirme")]
        BaskaBirimeGorevlendirme = 17,
        [Description("Atılma")]
        Atilma = 24,
        [Description("Diğer")]
        Diger = 31,
        [Description("Tanımsız")]
        Tanimsiz = 127
    }
}
