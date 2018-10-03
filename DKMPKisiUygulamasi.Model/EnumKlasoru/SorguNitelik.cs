using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.EnumKlasoru
{
    enum SorguNitelik
    {
        [Description("Akademik")]
        Akademik = 3,
        [Description("Cinsiyeti")]
        Cinsiyet = 10,
        [Description("Rh")]
        KanRh = 17,
        [Description("Medeni Hali")]
        MedeniHali = 24,
        [Description("Türkiye Cumhuriyeti Kimlik No")]
        TurkiyeCumhuriyetiKimlikNo = 31,
        [Description("Doğum Tarihi")]
        DogumTarihi = 38,
        [Description("Sicil No")]
        SicilNo = 45,
        [Description("Kadro")]
        Kadro = 52,
        [Description("Sınıf")]
        Sinif = 59,
        [Description("Adı")]
        Adi = 66,
        [Description("Soyadı")]
        Soyadi = 73,
        [Description("Kızlık Soyadı")]
        KizlikSoyadi = 80,
        [Description("Yeni Gelen")]
        YeniGelen = 87,
        [Description("Tanımsız")]
        Tanimsiz = 127
    }
}
