using DKMPKisiUygulamasi.Presentation.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.Mesajlar.Somut.Istek
{
    public class SorgulaCalisanIstekViewModel: IstekBazViewModel
    {   
        public string SorguSozcesi { get; set; }

        private SorgulaCalisanIstekViewModel() : base()
        {
            this.SorguSozcesi = string.Empty;
        }

        public SorgulaCalisanIstekViewModel(int kullaniciId, string sorguSozcesi) : base(kullaniciId)
        {
            this.SorguSozcesi = sorguSozcesi;
        }

    }

}
