using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.EnumKlasoru
{
    public enum AkademikUnvani
    {
        [Description("-")]
        Bos = 3,
        [Description("Avukat")]
        Avukat = 10,
        [Description("Yüksek Mühendis")]
        YuksekMuhendis = 17,
        [Description("Doktor")]
        Doktor = 24,
        [Description("Doçent")]
        Docent = 31,
        [Description("Profesör Doktor")]
        Profesor = 38,
        [Description("Tanımsız")]
        Tanimsiz = 255
        
    }
}
