
using DKMPKisiUygulamasi.CakmaWCF.Mesajlar.Soyut;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.RaporKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.Mesajlar.Somut.Yanit
{
    public class GetirCalisanOzetYanitViewModel : SorguYanitBaz<CalisanOzetViewModel>
    {
        public string SorguSozcesi { get; set; }

        public int? KullaniciId { get; set; }

        public GetirCalisanOzetYanitViewModel():base(true)
        {
            this.SorguSozcesi = string.Empty;
            this.KullaniciId = null;
        }

        public GetirCalisanOzetYanitViewModel(bool basariliMi) : this()
        {
            this.BasariliMi = basariliMi;
        }

        public GetirCalisanOzetYanitViewModel(bool basariliMi, string mesaj) : this(basariliMi)
        {
            this.Mesaj = mesaj;
        }

        public GetirCalisanOzetYanitViewModel(IEnumerable<CalisanOzetViewModel> liste) : this(true)
        {
            this.Liste = liste;
            this.BasariliMi = liste != null;
        }

        public GetirCalisanOzetYanitViewModel(Exception hata) : base(hata)
        {
        }

        public GetirCalisanOzetYanitViewModel(DKMPHataAltyapi.Soyut.HataBase hata) : base(hata)
        {

        }
    }
}
