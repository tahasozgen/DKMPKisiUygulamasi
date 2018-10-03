using AutoMapper;
using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.CakmaWCF.Somut;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPKisiUygulamasi.Model.IsKatmani.Somut;

namespace DKMPKisiUygulamasi.CakmaWCF.AltyapiKlasoru.CevirmeKlasoru.ResolverKlasoru
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
