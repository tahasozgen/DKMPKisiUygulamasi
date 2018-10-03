using DKMPKisiUygulamasi.Presentation.Mesajlar.Soyut;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.RaporKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.Mesajlar.Somut.Yanit
{
    public class GetirCalisanOzetYanitViewModel : SorguYanitBaz<CalisanOzetViewModel>
    {
        public GetirCalisanOzetYanitViewModel(bool basariliMi) : base(basariliMi)
        {

        }

        public GetirCalisanOzetYanitViewModel(bool basariliMi, string mesaj) : base(basariliMi, mesaj)
        {
        }

        public GetirCalisanOzetYanitViewModel(IEnumerable<CalisanOzetViewModel> liste) : base(liste)
        {
        }

        public GetirCalisanOzetYanitViewModel(Exception hata) : base(hata)
        {
        }

        public GetirCalisanOzetYanitViewModel(DKMPHataAltyapi.Soyut.HataBase hata) : base(hata)
        {

        }
    }
}
