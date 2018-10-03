using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.EnumKlasoru
{
    public enum CalismaDurumu
    {
        [Description("Çalışıyor")]
        Calisiyor,
        [Description("Çalışmıyor")]
        Calismiyor,
        [Description("Tanımsız")]
        Tanimsiz
    }
}
