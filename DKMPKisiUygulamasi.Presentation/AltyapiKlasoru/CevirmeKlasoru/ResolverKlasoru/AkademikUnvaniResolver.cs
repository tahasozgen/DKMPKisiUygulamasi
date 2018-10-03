using AutoMapper;
using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;
using DKMPKisiUygulamasi.Presentation.Somut;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.GorevKlasoru;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.KisiIletisimKlasor;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.AltyapiKlasoru.CevirmeKlasoru.ResolverKlasoru
{
    class AkademikUnvaniResolver : ITypeConverter<AkademikUnvani, AkademikUnvaniViewModel>
    {
        public AkademikUnvaniViewModel Convert(AkademikUnvani source, AkademikUnvaniViewModel destination, ResolutionContext context)
        {
            
            string aciklama = Arac.DescriptionAttr<AkademikUnvani>(source);
            int anahtar = (int)source;
            return new AkademikUnvaniViewModel(anahtar, aciklama);
        }
    }

    class AkrabalikDurumuResolver : ITypeConverter<AkrabalikDurumu, AkrabalikDurumuViewModel>
    {
        public AkrabalikDurumuViewModel Convert(AkrabalikDurumu source, AkrabalikDurumuViewModel destination, ResolutionContext context)
        {
            string aciklama = Arac.DescriptionAttr<AkrabalikDurumu>(source);
            int anahtar = (int)source;
            return new AkrabalikDurumuViewModel(anahtar, aciklama);
        }
    }


    class IletisimTuruResolver : ITypeConverter<IletisimTuru, IletisimTuruViewModel>
    {
        public IletisimTuruViewModel Convert(IletisimTuru source, IletisimTuruViewModel destination, ResolutionContext context)
        {
            string aciklama = Arac.DescriptionAttr<IletisimTuru>(source);
            int anahtar = (int)source;
            return new IletisimTuruViewModel(anahtar, aciklama);
        }
    }
}
