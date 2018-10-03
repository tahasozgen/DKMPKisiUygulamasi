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
    class SinifResolver : ITypeConverter<Sinif, SinifViewModel>
    {
        public SinifViewModel Convert(Sinif source, SinifViewModel destination, ResolutionContext context)
        {
            string aciklama = Arac.GetirKisaltma(source);
            int anahtar = (int)source;
            return new SinifViewModel(anahtar, aciklama);
        }
    }
}
