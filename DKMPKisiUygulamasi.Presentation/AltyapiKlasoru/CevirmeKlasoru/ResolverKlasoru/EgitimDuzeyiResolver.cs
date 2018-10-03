using AutoMapper;
using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Presentation.Somut;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.TanimlayiciKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.AltyapiKlasoru.CevirmeKlasoru.ResolverKlasoru
{
    class EgitimDuzeyiResolver : ITypeConverter<EgitimDuzeyi, EgitimDuzeyiViewModel>
    {
        public EgitimDuzeyiViewModel Convert(EgitimDuzeyi source, EgitimDuzeyiViewModel destination, ResolutionContext context)
        {
            string aciklama = Arac.DescriptionAttr<EgitimDuzeyi>(source);
            int anahtar = (int)source;
            return new EgitimDuzeyiViewModel(anahtar, aciklama);
        }
    }
}
