using AutoMapper;
using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Presentation.Somut;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.GorevKlasoru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.AltyapiKlasoru.CevirmeKlasoru.ResolverKlasoru
{
    class HizmetSonlanisNedeniResolver : ITypeConverter<HizmetSonlanisNedeni, HizmetSonlanisNedeniViewModel>
    {
        public HizmetSonlanisNedeniViewModel Convert(HizmetSonlanisNedeni source, HizmetSonlanisNedeniViewModel destination, ResolutionContext context)
        {
            string aciklama = Arac.DescriptionAttr<HizmetSonlanisNedeni>(source);
            int anahtar = (int)source;
            return new HizmetSonlanisNedeniViewModel(anahtar, aciklama);
        }
    }
}
