using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.EnumKlasoru
{
    public enum IletisimTuru
    {
        [Description("Bakanlık E-Posta")]
        BakanlikEposta = 3,
        [Description("Normal E-Posta")]
        NormalEPosta = 10,
        [Description("Cep Telefonu")]
        CepTelefonu = 17,
        [Description("Dahili")]
        Dahili = 24,
        [Description("Ev Telefonu")]
        EvTelefonu = 31,
        [Description("Adresi")]
        Adres = 38,
        [Description("Tanımsız")]
        Tanimsiz = 127
        
    }
}
