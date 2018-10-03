using DKMPKisiUygulamasi.Presentation.Mesajlar.Somut.Yanit;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.IslemKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.Soyut
{
    public interface ITopluIslemPresentation
    {

        IlklendirEkleCalisanIletisimGorevEgitimViewModel IlklendirEkle();

        EkleCalisanIletisimGorevEgitimYanitViewModel Ekle(IlklendirEkleCalisanIletisimGorevEgitimViewModel model);
    }
}
