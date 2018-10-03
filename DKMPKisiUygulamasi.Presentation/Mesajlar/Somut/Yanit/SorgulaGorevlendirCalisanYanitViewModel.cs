using DKMPKisiUygulamasi.Presentation.Mesajlar.Soyut;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.GorevKlasoru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.Mesajlar.Somut.Yanit
{
    public class SorgulaGorevlendirCalisanYanitViewModel : SorguYanitBaz<CalisanGorevlendirmeViewModel>
    {
        public SorgulaGorevlendirCalisanYanitViewModel(bool basariliMi) : base(basariliMi)
        {

        }

        public SorgulaGorevlendirCalisanYanitViewModel(bool basariliMi, string mesaj) : base(basariliMi, mesaj)
        {
        }

        public SorgulaGorevlendirCalisanYanitViewModel(IEnumerable<CalisanGorevlendirmeViewModel> liste) : base(liste)
        {
        }

        public SorgulaGorevlendirCalisanYanitViewModel(Exception hata) : base(hata)
        {
        }

        public SorgulaGorevlendirCalisanYanitViewModel(DKMPHataAltyapi.ServisHata hata) : base(hata)
        {

        }
    }
}
