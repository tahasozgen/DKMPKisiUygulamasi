using AutoMapper;
using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.CakmaWCF.Somut;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.TanimlayiciKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPKisiUygulamasi.Model.IsKatmani.Somut;

namespace DKMPKisiUygulamasi.CakmaWCF.AltyapiKlasoru.CevirmeKlasoru.ResolverKlasoru
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
