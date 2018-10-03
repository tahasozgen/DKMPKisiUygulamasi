using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.EnumKlasoru
{
    public enum EgitimDuzeyi
    {
        [Description("İlkokul Aşağısı")]
        IlkokulAsagisi = 3,
        [Description("İlkokul")]
        Ilkokul = 10,
        [Description("Ortaokul")]
        Ortaokul = 17, 
        [Description("Lise")]
        Lise = 24,
        [Description("Yüksekokul")]
        YuksekOkul = 31,
        [Description("Lisans")]
        Lisans = 38,
        [Description("Yüksek Lisans")]
        YuksekLisans = 45,
        [Description("Doktora")]
        Doktora = 52,
        [Description("Diğer")]
        Diger = 59,
        [Description("Tanımsız")]
        Tanimsiz = 127

    }
}
