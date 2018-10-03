using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.Soyut
{
    public interface IHataServis
    {
        void YazHata(Exception hata);

        void YazHata(DKMPHataAltyapi.UIHata hata);
    }
}
