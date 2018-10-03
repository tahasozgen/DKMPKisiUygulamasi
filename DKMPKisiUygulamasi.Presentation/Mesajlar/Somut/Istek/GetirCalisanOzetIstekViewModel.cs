using DKMPKisiUygulamasi.Presentation.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.Mesajlar.Somut.Istek
{
    public class GetirCalisanOzetIstekViewModel : IstekBazViewModel
    {
        public DateTime? Tarihi { get; set; }

        protected GetirCalisanOzetIstekViewModel() : base()
        {
            this.Tarihi = null;
        }

        public GetirCalisanOzetIstekViewModel(int anahtar,DateTime tarihi) : base(anahtar)
        {
            this.Tarihi = tarihi;
        }
    }
}
