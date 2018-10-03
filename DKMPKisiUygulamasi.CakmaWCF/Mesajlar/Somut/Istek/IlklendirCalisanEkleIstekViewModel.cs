using DKMPKisiUygulamasi.CakmaWCF.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.Mesajlar.Somut.Istek
{
    public class IlklendirCalisanEkleIstekViewModel : IstekBazViewModel
    {
        protected IlklendirCalisanEkleIstekViewModel() : base()
        {

        }

        public IlklendirCalisanEkleIstekViewModel(int anahtar) : base(anahtar)
        {

        }
    }
}
