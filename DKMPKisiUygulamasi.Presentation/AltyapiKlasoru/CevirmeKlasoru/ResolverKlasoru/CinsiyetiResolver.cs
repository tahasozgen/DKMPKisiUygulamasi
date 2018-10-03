using AutoMapper;
using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Presentation.Somut;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.AltyapiKlasoru.CevirmeKlasoru.ResolverKlasoru
{
    class CinsiyetiResolver : ITypeConverter<Cinsiyeti, CinsiyetiViewModel>
    {
        public CinsiyetiViewModel Convert(Cinsiyeti source, CinsiyetiViewModel destination, ResolutionContext context)
        {
            string aciklama = Arac.DescriptionAttr<Cinsiyeti>(source);
            int anahtar = (int)source;
            return new CinsiyetiViewModel(anahtar, aciklama);
        }
    }
}
