using DKMPKisiUygulamasi.Presentation.Mesajlar.Soyut;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.Mesajlar.Somut.Yanit
{
    public class SorgulaCalisanYanitViewModel : SorguYanitBaz<CalisanViewModel>
    {
        public SorgulaCalisanYanitViewModel(bool basariliMi) : base(basariliMi)
        {

        }

        public SorgulaCalisanYanitViewModel(bool basariliMi, string mesaj) : base(basariliMi, mesaj)
        {
        }

        public SorgulaCalisanYanitViewModel(IEnumerable<CalisanViewModel> liste) : base(liste)
        {
        }

        public SorgulaCalisanYanitViewModel(Exception hata) : base(hata)
        {
        }

        public SorgulaCalisanYanitViewModel(DKMPHataAltyapi.ServisHata hata) : base(hata)
        {

        }

    }
}
