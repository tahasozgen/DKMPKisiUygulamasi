using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.EnumKlasoru
{
    public enum AkrabalikDurumu
    {
        [Description("Kendisi")]
        Kendisi,
        [Description("Eşi")]
        Esi,
        [Description("Çocuğu")]
        Cocuk,
        [Description("Annesi")]
        Anne,
        [Description("Babası")]
        Baba,
        [Description("Kardeşi")]
        Kardes,
        [Description("Tanımsız")]
        Tanimsiz
    }
}
