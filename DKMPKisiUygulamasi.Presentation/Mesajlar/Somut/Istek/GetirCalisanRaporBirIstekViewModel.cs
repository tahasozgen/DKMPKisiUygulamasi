using DKMPKisiUygulamasi.Presentation.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.Mesajlar.Somut.Istek
{
    public class GetirCalisanRaporBirIstekViewModel: IstekBazViewModel
    {
        protected GetirCalisanRaporBirIstekViewModel() : base()
        {

        }

        public GetirCalisanRaporBirIstekViewModel(int anahtar) : base(anahtar)
        {

        }
    }
}
