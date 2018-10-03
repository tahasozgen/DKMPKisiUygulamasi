using DKMPKisiUygulamasi.Presentation.Mesajlar.Soyut;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.RaporKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.Mesajlar.Somut.Yanit
{
    public class GetirCalisanRaporBirYanitViewModel: SorguYanitBaz<CalisanRaporBirViewModel>
    {
        public GetirCalisanRaporBirYanitViewModel(bool basariliMi) : base(basariliMi)
        {

        }

        public GetirCalisanRaporBirYanitViewModel(bool basariliMi, string mesaj) : base(basariliMi, mesaj)
        {
        }

        public GetirCalisanRaporBirYanitViewModel(IEnumerable<CalisanRaporBirViewModel> liste) : base(liste)
        {
        }

        public GetirCalisanRaporBirYanitViewModel(Exception hata) : base(hata)
        {
        }

        public GetirCalisanRaporBirYanitViewModel(DKMPHataAltyapi.Soyut.HataBase hata) : base(hata)
        {

        }
    }
}
