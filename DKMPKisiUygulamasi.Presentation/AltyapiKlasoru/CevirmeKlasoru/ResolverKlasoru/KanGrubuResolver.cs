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
    class KanGrubuResolver : ITypeConverter<KanGrubu, KanGrubuViewModel>
    {
        public KanGrubuViewModel Convert(KanGrubu source, KanGrubuViewModel destination, ResolutionContext context)
        {
            string aciklama = Arac.DescriptionAttr<KanGrubu>(source);
            int anahtar = (int)source;
            return new KanGrubuViewModel(anahtar, aciklama);
        }
    }
}
