using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.EnumKlasoru
{
    public enum IzinTuru
    {
        [Description("Saatlik")]
        Saatlik = 3,
        [Description("Yıllık")]        
        Yillik = 10,
        [Description("Hastalık")]
        Hastalik = 17,
        [Description("Refakat")]
        Refakat = 24,
        [Description("Aylıksız İzin")]
        AyliksizIzin = 31,
        [Description("Doğum İzni")]
        Dogum = 38,
        [Description("Yurtdışında Başka bir Birimde Aylıksız İzin")]
        Yurtdisi = 45,
        [Description("Düğün İzni")]
        Dugun = 52,
        [Description("Ölüm İzni")]
        Olum = 59,
        [Description("Babalık İzni")]
        Babalik = 63,
        [Description("Askerlik İçin Aylıksız İzin")]
        Askerlik = 70,
        [Description("Tanımsız")]
        Tanimsiz = 255
    }
}
