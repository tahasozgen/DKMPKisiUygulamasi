using AutoMapper;
using DKMPKisiUygulamasi.CakmaWCF.Somut;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.GorevKlasoru;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.KisiIletisimKlasor;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.RaporKlasor;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.TanimlayiciKlasor;
using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.IsKatmani.Somut;
using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using DKMPKisiUygulamasi.Model.Somut.RaporKlasor;
using DKMPKurumCografyaUygulamasi.Servis.ViewModel.VarlikKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.AltyapiKlasoru.CevirmeKlasoru.ResolverKlasoru
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


    class CalisanOzetResolver : ITypeConverter<CalisanOzet, CalisanOzetViewModel>
    {
        public CalisanOzetViewModel Convert(CalisanOzet source, CalisanOzetViewModel destination, ResolutionContext context)
        {
            if (source != null)
            {
                Cevir cevir = new Cevir();
                CalisanGorevlendirmeViewModel gorevlendirme = cevir.cevir(source.Gorevlendirme,null,null);
                KisiOgrenimViewModel ogrenimi = cevir.cevir(source.Ogrenimi);
                KisiIletisimViewModel dahili = cevir.cevir(source.Dahili);
                KisiIletisimViewModel bakanlikEposta = cevir.cevir(source.BakanlikEposta);
                KisiIletisimViewModel cepTelefonu = cevir.cevir(source.CepTelefonu);
                int kidemYili = source.KidemYili ?? 0;


                return new CalisanOzetViewModel(gorevlendirme, ogrenimi, dahili, bakanlikEposta, cepTelefonu, kidemYili);
            }
            else
                return null;
        }      

    }
    //Calisan

    class CalisanResolver : ITypeConverter<Calisan, CalisanViewModel>
    {
        public CalisanViewModel Convert(Calisan source, CalisanViewModel destination, ResolutionContext context)
        {
            if (source != null)
            {
                Cevir cevir = new Cevir();
                string adi = Arac.BuyutIlkHarfi(source.Adi);
                string soyadi = Arac.BuyutIlkHarfi(source.Soyadi);
                CinsiyetiViewModel cinsiyeti = cevir.cevir(source.Cinsi);
                AkademikUnvaniViewModel unvani = cevir.cevir(source.Unvani);
                KanGrubuViewModel kaninGrubu = cevir.cevir(source.KaninGrubu);
                RhDegeriViewModel phDeger = cevir.cevir(source.RhDeger);
                MedeniDurumuViewModel medeniHali = cevir.cevir(source.MedeniHali);
                string turCumKimlikNo = source.TurCumKimlikNo.Trim();
                string dogumTarihi = source.DogumTarihi.ToShortDateString();
                string sicilNo = source.SicilNo;
                KadrosuViewModel kadroDurumu = cevir.cevir(source.KadroDurumu);
                SinifViewModel sinifi = cevir.cevir(source.Sinifi);
                string ibanNo = source.IbanNo;
                
                return new CalisanViewModel(adi, soyadi, cinsiyeti, unvani, kaninGrubu, phDeger, medeniHali, turCumKimlikNo, dogumTarihi, sicilNo, kadroDurumu, sinifi, ibanNo,null);
            }
            else
                return null;
        }

    }

}
