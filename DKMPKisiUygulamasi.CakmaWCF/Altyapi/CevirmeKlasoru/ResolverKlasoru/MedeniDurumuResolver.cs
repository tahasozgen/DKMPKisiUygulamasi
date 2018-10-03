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
