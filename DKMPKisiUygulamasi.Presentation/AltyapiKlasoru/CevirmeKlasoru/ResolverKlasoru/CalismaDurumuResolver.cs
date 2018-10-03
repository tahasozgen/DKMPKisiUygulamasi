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
    class CalismaDurumuResolver : ITypeConverter<CalismaDurumu, CalismaDurumuViewModel>
    {
        public CalismaDurumuViewModel Convert(CalismaDurumu source, CalismaDurumuViewModel destination, ResolutionContext context)
        {
            string aciklama = Arac.DescriptionAttr<CalismaDurumu>(source);
            int anahtar = (int)source;
            return new CalismaDurumuViewModel(anahtar, aciklama);
        }
    }
}
