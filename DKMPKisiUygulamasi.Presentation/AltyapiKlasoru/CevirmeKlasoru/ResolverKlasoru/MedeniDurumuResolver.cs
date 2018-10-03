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
    class MedeniDurumuResolver : ITypeConverter<MedeniDurumu, MedeniDurumuViewModel>
    {
        public MedeniDurumuViewModel Convert(MedeniDurumu source, MedeniDurumuViewModel destination, ResolutionContext context)
        {
            string aciklama = Arac.DescriptionAttr<MedeniDurumu>(source);
            int anahtar = (int)source;
            return new MedeniDurumuViewModel(anahtar, aciklama);
        }
    }
}
