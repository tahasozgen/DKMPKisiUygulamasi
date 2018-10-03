using AutoMapper;
using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPKisiUygulamasi.CakmaWCF.Somut;
using DKMPKisiUygulamasi.Model.IsKatmani.Somut;

namespace DKMPKisiUygulamasi.CakmaWCF.AltyapiKlasoru.CevirmeKlasoru.ResolverKlasoru
{
    class PhDegeriResolver : ITypeConverter<RhDegeri, RhDegeriViewModel>
    {
        public RhDegeriViewModel Convert(RhDegeri source, RhDegeriViewModel destination, ResolutionContext context)
        {
            int id = (int)source;
            string sozce = Arac.DescriptionAttr<RhDegeri>(source);
            return new RhDegeriViewModel(id, sozce);

        }
    }
}
