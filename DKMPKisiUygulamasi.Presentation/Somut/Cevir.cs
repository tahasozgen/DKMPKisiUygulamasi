using AutoMapper;
using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using DKMPKisiUygulamasi.Model.Somut.OgrenimKlasor;
using DKMPKisiUygulamasi.Model.Somut.RaporKlasor;
using DKMPKisiUygulamasi.Model.Somut.TanimlayiciKlasor;
using DKMPKisiUygulamasi.Presentation.AltyapiKlasoru.CevirmeKlasoru.ResolverKlasoru;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.GorevKlasoru;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.KisiIletisimKlasor;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.RaporKlasor;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.TanimlayiciKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.Somut
{
    public class Cevir
    {
        private MapperConfiguration _config = null;
        private IMapper _iMapper = null;

        public Cevir()
        {
            
            this._config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<AkademikUnvani, AkademikUnvaniViewModel>().ConvertUsing<AkademikUnvaniResolver>();
                cfg.CreateMap<AkrabalikDurumu, AkrabalikDurumuViewModel>().ConvertUsing<AkrabalikDurumuResolver>();
                cfg.CreateMap<CalismaDurumu, CalismaDurumuViewModel>().ConvertUsing<CalismaDurumuResolver>();
                cfg.CreateMap<Cinsiyeti, CinsiyetiViewModel>().ConvertUsing<CinsiyetiResolver>();
                cfg.CreateMap<EgitimDuzeyi, EgitimDuzeyiViewModel>().ConvertUsing<EgitimDuzeyiResolver>();
                cfg.CreateMap<HizmetSonlanisNedeni, HizmetSonlanisNedeniViewModel>().ConvertUsing<HizmetSonlanisNedeniResolver>();                                
                cfg.CreateMap<Kadrosu, KadrosuViewModel>().ConvertUsing<KadrosuResolver>();
                cfg.CreateMap<KanGrubu, KanGrubuViewModel>().ConvertUsing<KanGrubuResolver>();
                cfg.CreateMap<MedeniDurumu, MedeniDurumuViewModel>().ConvertUsing<MedeniDurumuResolver>();
                cfg.CreateMap<PhDegeri, PhDegeriViewModel>().ConvertUsing<PhDegeriResolver>();
                cfg.CreateMap<Sinif, SinifViewModel>().ConvertUsing<SinifResolver>();
                cfg.CreateMap<IletisimTuru, IletisimTuruViewModel>().ConvertUsing<IletisimTuruResolver>();

                cfg.CreateMap<CalisanGorevlendirme, CalisanGorevlendirmeViewModel>();
                cfg.CreateMap<Gorevi, GoreviViewModel>();/*.ConvertUsing<GoreviResolver>()*/
                cfg.CreateMap<Calisan, CalisanViewModel>();/*.ConvertUsingCalisanResolver > ();*/
                cfg.CreateMap<Kisi, KisiViewModel>();/*.ConvertUsing<OdenekTransferiResolver>();*/
                cfg.CreateMap<CalisanRaporBir, CalisanRaporBirViewModel>();/*.ConvertUsing<CalisanRaporBirResolver>();*/
                cfg.CreateMap<CalisanRaporUc, CalisanRaporUcViewModel>();/*.ConvertUsing<CalisanRaporBirResolver>();*/
                cfg.CreateMap<CalisanRaporDort, CalisanRaporDortViewModel>();
                cfg.CreateMap<OgrenimDurumu, OgrenimDurumuViewModel>();/*.ConvertUsing<OgrenimDurumuResolver>();*/
                cfg.CreateMap<Unvan, UnvanViewModel>();/*.ConvertUsing<UnvanResolver>();*/
                cfg.CreateMap<CalisanOzet, CalisanOzetViewModel>();
              
            });

            this._iMapper = this._config.CreateMapper();

        }

        internal CalisanGorevlendirmeViewModel cevir(CalisanGorevlendirme deger)
        {
            return (deger != null) ? this._iMapper.Map<CalisanGorevlendirme, CalisanGorevlendirmeViewModel>(deger) : null;

        }

        internal HizmetSonlanisNedeniViewModel cevir(HizmetSonlanisNedeni deger)
        {
            return (deger != null) ? this._iMapper.Map<HizmetSonlanisNedeni, HizmetSonlanisNedeniViewModel>(deger) : null;
        }

        internal List<HizmetSonlanisNedeniViewModel> cevir(List<HizmetSonlanisNedeni> liste)
        {
            IEnumerable<HizmetSonlanisNedeniViewModel> vmList = new List<HizmetSonlanisNedeniViewModel>();

            if (liste != null)
                vmList = liste.Select(Mapper.Map<HizmetSonlanisNedeni, HizmetSonlanisNedeniViewModel>);

            return vmList.ToList();

        }
        internal CalisanViewModel cevir(Calisan deger)
        {
            return (deger != null) ? this._iMapper.Map<Calisan, CalisanViewModel>(deger) : null;
        }

        internal List<CalisanViewModel> cevir(List<Calisan> liste)
        {
            IEnumerable<CalisanViewModel> vmList = new List<CalisanViewModel>();

            if (liste != null)
                vmList = liste.Select(Mapper.Map<Calisan, CalisanViewModel>);

            return vmList.ToList();

        }

        internal List<AkademikUnvaniViewModel> cevir(List<AkademikUnvani> liste)
        {
            IEnumerable<AkademikUnvaniViewModel> vmList = new List<AkademikUnvaniViewModel>();

            if (liste != null)
                vmList = liste.Select(Mapper.Map<AkademikUnvani, AkademikUnvaniViewModel>);

            return vmList.ToList();
        }        

        internal List<CalisanGorevlendirmeViewModel> cevir(List<CalisanGorevlendirme> liste)
        {
            IEnumerable<CalisanGorevlendirmeViewModel> vmList = new List<CalisanGorevlendirmeViewModel>();

            if (liste != null)
                vmList = liste.Select(Mapper.Map<CalisanGorevlendirme, CalisanGorevlendirmeViewModel>);

            return vmList.ToList();
        }
        
        internal List<CinsiyetiViewModel> cevir(List<Cinsiyeti> liste)
        {
            IEnumerable<CinsiyetiViewModel> vmList = new List<CinsiyetiViewModel>();

            if (liste != null)
                vmList = liste.Select(Mapper.Map<Cinsiyeti, CinsiyetiViewModel>);

            return vmList.ToList();
        }

        internal List<KanGrubuViewModel> cevir(List<KanGrubu> liste)
        {
            IEnumerable<KanGrubuViewModel> vmList = new List<KanGrubuViewModel>();

            if (liste != null)
                vmList = liste.Select(Mapper.Map<KanGrubu, KanGrubuViewModel>);

            return vmList.ToList();
        }

        internal List<PhDegeriViewModel> cevir(List<PhDegeri> liste)
        {
            IEnumerable<PhDegeriViewModel> vmList = new List<PhDegeriViewModel>();

            if (liste != null)
                vmList = liste.Select(Mapper.Map<PhDegeri, PhDegeriViewModel>);

            return vmList.ToList();
        }

        internal List<OgrenimDurumuViewModel> cevir(List<OgrenimDurumu> liste)
        {
            IEnumerable<OgrenimDurumuViewModel> vmList = new List<OgrenimDurumuViewModel>();

            if (liste != null)
                vmList = liste.Select(Mapper.Map<OgrenimDurumu, OgrenimDurumuViewModel>);

            return vmList.ToList();
        }

        internal List<UnvanViewModel> cevir(List<Unvan> liste)
        {
            IEnumerable<UnvanViewModel> vmList = new List<UnvanViewModel>();

            if (liste != null)
                vmList = liste.Select(Mapper.Map<Unvan, UnvanViewModel>);

            return vmList.ToList();
        }

        internal List<SinifViewModel> cevir(List<Sinif> liste)
        {
            IEnumerable<SinifViewModel> vmList = new List<SinifViewModel>();

            if (liste != null)
                vmList = liste.Select(Mapper.Map<Sinif, SinifViewModel>);

            return vmList.ToList();
        }

        internal List<MedeniDurumuViewModel> cevir(List<MedeniDurumu> liste)
        {
            IEnumerable<MedeniDurumuViewModel> vmList = new List<MedeniDurumuViewModel>();

            if (liste != null)
                vmList = liste.Select(Mapper.Map<MedeniDurumu, MedeniDurumuViewModel>);

            return vmList.ToList();
        }

        internal List<KadrosuViewModel> cevir(List<Kadrosu> liste)
        {
            IEnumerable<KadrosuViewModel> vmList = new List<KadrosuViewModel>();

            if (liste != null)
                vmList = liste.Select(Mapper.Map<Kadrosu, KadrosuViewModel>);

            return vmList.ToList();
        }

        internal List<CalisanRaporBirViewModel> cevir(List<CalisanRaporBir> liste)
        {
            IEnumerable<CalisanRaporBirViewModel> vmList = new List<CalisanRaporBirViewModel>();

            if (liste != null)
                vmList = liste.Select(Mapper.Map<CalisanRaporBir, CalisanRaporBirViewModel>);

            return vmList.ToList();
        }

        internal List<GoreviViewModel> cevir(List<Gorevi> liste)
        {
            IEnumerable<GoreviViewModel> vmList = new List<GoreviViewModel>();

            if (liste != null)
                vmList = liste.Select(Mapper.Map<Gorevi, GoreviViewModel>);

            return vmList.ToList();
        }

        internal List<CalisanOzetViewModel> cevir(List<CalisanOzet> liste)
        {
            IEnumerable<CalisanOzetViewModel> vmList = new List<CalisanOzetViewModel>();

            if (liste != null)
                vmList = liste.Select(Mapper.Map<CalisanOzet, CalisanOzetViewModel>);

            return vmList.ToList();
        }

    }
}
