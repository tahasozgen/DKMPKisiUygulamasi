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
    class SinifResolver : ITypeConverter<Sinif, SinifViewModel>
    {
        public SinifViewModel Convert(Sinif source, SinifViewModel destination, ResolutionContext context)
        {
            string aciklama = Arac.DescriptionAttr<Sinif>(source);
            int anahtar = (int)source;
            return new SinifViewModel(anahtar, aciklama);
        }
    }
}
