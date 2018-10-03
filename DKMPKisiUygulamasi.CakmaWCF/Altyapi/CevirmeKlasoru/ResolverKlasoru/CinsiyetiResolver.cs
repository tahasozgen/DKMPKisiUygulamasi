using AutoMapper;
using DKMPKisiUygulamasi.CakmaWCF.Somut;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.IsKatmani.Somut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.AltyapiKlasoru.CevirmeKlasoru.ResolverKlasoru
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
