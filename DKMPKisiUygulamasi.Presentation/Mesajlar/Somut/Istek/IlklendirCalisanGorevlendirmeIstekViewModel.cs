using DKMPKisiUygulamasi.Presentation.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.Mesajlar.Somut.Istek
{
    public class IlklendirCalisanGorevlendirmeIstekViewModel : IstekBazViewModel
    {

        public int? GorevlendirilecekCalisanId { get; set; }

        protected IlklendirCalisanGorevlendirmeIstekViewModel() : base()
        {
            this.GorevlendirilecekCalisanId = null;
        }

        public IlklendirCalisanGorevlendirmeIstekViewModel(int gorevlendirilecekCalisanId, int kullaniciId) : base(kullaniciId)
        {
            this.GorevlendirilecekCalisanId = gorevlendirilecekCalisanId;
        }

    }
}
