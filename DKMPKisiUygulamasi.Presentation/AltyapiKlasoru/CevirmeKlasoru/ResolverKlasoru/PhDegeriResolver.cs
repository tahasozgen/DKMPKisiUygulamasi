using AutoMapper;
using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.AltyapiKlasoru.CevirmeKlasoru.ResolverKlasoru
{
    class PhDegeriResolver : ITypeConverter<PhDegeri, PhDegeriViewModel>
    {
        public PhDegeriViewModel Convert(PhDegeri source, PhDegeriViewModel destination, ResolutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
