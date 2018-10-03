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
    class KadrosuResolver : ITypeConverter<Kadrosu, KadrosuViewModel>
    {
        public KadrosuViewModel Convert(Kadrosu source, KadrosuViewModel destination, ResolutionContext context)
        {

            string aciklama = Arac.DescriptionAttr<Kadrosu>(source);
            int anahtar = (int)source;
            return new KadrosuViewModel(anahtar, aciklama);
        }

    }
}
