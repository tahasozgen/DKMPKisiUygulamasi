using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.Soyut
{
    public interface IHataPresentation
    {
        void YazHata(Exception hata);

        void YazHata(DKMPHataAltyapi.UIHata hata);

    }
}
