using AutoMapper;
using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using DKMPKisiUygulamasi.Model.Somut.OgrenimKlasor;
using DKMPKisiUygulamasi.Model.Somut.RaporKlasor;
using DKMPKisiUygulamasi.Model.Somut.TanimlayiciKlasor;
using DKMPKisiUygulamasi.CakmaWCF.AltyapiKlasoru.CevirmeKlasoru.ResolverKlasoru;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.GorevKlasoru;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.KisiIletisimKlasor;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.RaporKlasor;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.TanimlayiciKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DKMPKurumCografyaUygulamasi.Servis.ViewModel.VarlikKlasor;
using DKMPKisiUygulamasi.Model.SabitlerMesajlar;
using DKMPKisiUygulamasi.Model.IsKatmani.Somut;
using DKMPKisiUygulamasi.Model.Somut.IletisimKlasor;
using DKMPKisiUygulamasi.CakmaWCF.Altyapi.CevirmeKlasoru.ResolverKlasoru;
using DKMPKurumCografyaUygulamasi.Servis.Somut;

namespace DKMPKisiUygulamasi.CakmaWCF.Somut
{
    public class Cevir
    {
        private MapperConfiguration _config = null;
        private IMapper _iMapper = null;
        private HataServis _hataServis = null; 

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
                cfg.CreateMap<RhDegeri, RhDegeriViewModel>().ConvertUsing<PhDegeriResolver>();
                cfg.CreateMap<Sinif, SinifViewModel>().ConvertUsing<SinifResolver>();
                cfg.CreateMap<IletisimTuru, IletisimTuruViewModel>().ConvertUsing<IletisimTuruResolver>();

                cfg.CreateMap<CalisanGorevlendirme, CalisanGorevlendirmeViewModel>().ConvertUsing<CalisanGorevlendirmeResolver>();                

                cfg.CreateMap<Gorevi, GoreviViewModel>();/*.ConvertUsing<GoreviResolver>()*/
                cfg.CreateMap<Calisan, CalisanViewModel>().ConvertUsing<CalisanResolver>();
                                
                cfg.CreateMap<Kisi, KisiViewModel>();/*.ConvertUsing<OdenekTransferiResolver>();*/
                cfg.CreateMap<CalisanRaporBir, CalisanRaporBirViewModel>();/*.ConvertUsing<CalisanRaporBirResolver>();*/
                cfg.CreateMap<CalisanRaporUc, CalisanRaporUcViewModel>();/*.ConvertUsing<CalisanRaporBirResolver>();*/
                cfg.CreateMap<CalisanRaporDort, CalisanRaporDortViewModel>();
                cfg.CreateMap<OgrenimDurumu, OgrenimDurumuViewModel>();/*.ConvertUsing<OgrenimDurumuResolver>();*/
                cfg.CreateMap<Unvan, UnvanViewModel>();/*.ConvertUsing<UnvanResolver>();*/
                cfg.CreateMap<CalisanOzet, CalisanOzetViewModel>().ConvertUsing<CalisanOzetResolver>();                
                cfg.CreateMap<KisiOgrenim, KisiOgrenimViewModel>();
                cfg.CreateMap<Universite, UniversiteViewModel>();

            });

            this._iMapper = this._config.CreateMapper();
            this._hataServis = new HataServis();
        }

        //

        internal KisiIletisimViewModel cevir(KisiIletisim deger)
        {
            return (deger != null) ? this._iMapper.Map<KisiIletisim, KisiIletisimViewModel>(deger) : null;

        }


        internal KisiOgrenimViewModel cevir(KisiOgrenim deger)
        {
            return (deger != null) ? this._iMapper.Map<KisiOgrenim, KisiOgrenimViewModel>(deger) : null;

        }

        internal CalisanGorevlendirmeViewModel cevir(CalisanGorevlendirme deger,BirimViewModel birimVm, IlViewModel Ili)
        {

            if (deger != null)
            {
                CalisanGorevlendirmeViewModel ilk = this._iMapper.Map<CalisanGorevlendirme, CalisanGorevlendirmeViewModel>(deger);

                int anahtar = ilk.Anahtar ?? int.MinValue;
                bool asilMi = ilk.AsilMi ?? true;
                bool resmiMi = ilk.ResmiMi ?? true;

                CalisanGorevlendirmeViewModel netice = new CalisanGorevlendirmeViewModel(anahtar, ilk.Calisani, birimVm, Ili, ilk.Gorev, ilk.Unvani, ilk.Baslangic, asilMi, ilk.Aciklama, resmiMi);

                return netice;
            }
            else
                return null;

        }

        internal HizmetSonlanisNedeniViewModel cevir(HizmetSonlanisNedeni deger)
        {
            return this._iMapper.Map<HizmetSonlanisNedeni, HizmetSonlanisNedeniViewModel>(deger);
        }

        //IlViewModel
        internal List<SelectListItem> cevir(List<IlViewModel> liste)
        {
            try
            {
                List<SelectListItem> vmList = new List<SelectListItem>();                
                SelectListItem item = null;

                vmList.Add(Sabitler.SecinizSelectListItem);

                if (liste != null)
                {
                    foreach (IlViewModel deger in liste)
                    {                       
                        if (deger != null)
                        {
                            item = new SelectListItem();
                            item.Text = deger.Adi;
                            item.Value = (deger.Id != int.MinValue) ? deger.Id.ToString() : string.Empty;
                            vmList.Add(item);
                        }

                    }
                }

                return vmList;
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return new List<SelectListItem>();
        }
        internal List<SelectListItem> cevir(List<CalismaDurumu> liste)
        {
            try
            {
                List<SelectListItem> vmList = new List<SelectListItem>();
                CalismaDurumuViewModel vm = null;
                SelectListItem item = null;

                vmList.Add(Sabitler.SecinizSelectListItem);

                if (liste != null)
                {
                    foreach (CalismaDurumu deger in liste)
                    {
                        vm = this._iMapper.Map<CalismaDurumu, CalismaDurumuViewModel>(deger);

                        if (vm != null)
                        {
                            item = new SelectListItem();
                            item.Text = vm.Adi;
                            item.Value = (vm.Anahtar != null) ? vm.Anahtar.ToString() : string.Empty;
                            vmList.Add(item);
                        }

                    }
                }

                return vmList;
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return new List<SelectListItem>();
        }

        internal List<SelectListItem> cevir(List<HizmetSonlanisNedeni> liste)
        {
            try
            {
                List<SelectListItem> vmList = new List<SelectListItem>();
                HizmetSonlanisNedeniViewModel vm = null;
                SelectListItem item = null;

                vmList.Add(Sabitler.SecinizSelectListItem);

                if (liste != null)
                {
                    foreach (HizmetSonlanisNedeni deger in liste)
                    {
                        vm = this._iMapper.Map<HizmetSonlanisNedeni, HizmetSonlanisNedeniViewModel>(deger);

                        if (vm != null)
                        {
                            item = new SelectListItem();
                            item.Text = vm.Adi;
                            item.Value = (vm.Anahtar != null) ? vm.Anahtar.ToString() : string.Empty;
                            vmList.Add(item);
                        }

                    }
                }

                return vmList;
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return new List<SelectListItem>();

        }

        public CalisanViewModel cevir(Calisan deger)
        {
            return (deger != null) ? this._iMapper.Map<Calisan, CalisanViewModel>(deger) : null;
        }

        public List<CalisanViewModel> cevir(List<Calisan> liste)
        {
            List<CalisanViewModel> vmList = new List<CalisanViewModel>();

            if (liste != null)
            {
                foreach(Calisan deger in liste)
                {
                    vmList.Add(this.cevir(deger));
                }
            }

            return vmList;

        }

        internal List<SelectListItem> cevir(List<AkademikUnvani> liste)
        {
            List<SelectListItem> vmList = new List<SelectListItem>();
            AkademikUnvaniViewModel vm = null;
            SelectListItem item = null;

            if (liste != null)
            {
                foreach(AkademikUnvani deger in liste)
                {
                    vm = this._iMapper.Map<AkademikUnvani, AkademikUnvaniViewModel>(deger);

                    if(vm != null)
                    {
                        item = new SelectListItem();
                        item.Text = vm.Adi;
                        item.Value = (vm.Anahtar != null) ? vm.Anahtar.ToString() : string.Empty;
                        vmList.Add(item);
                    }

                }
            }

            return vmList;
        }        
        
        internal List<CalisanGorevlendirmeViewModel> cevir(List<CalisanGorevlendirme> liste)
        {
            IEnumerable<CalisanGorevlendirmeViewModel> vmList = new List<CalisanGorevlendirmeViewModel>();

            if (liste != null)
                vmList = liste.Select(Mapper.Map<CalisanGorevlendirme, CalisanGorevlendirmeViewModel>);

            return vmList.ToList();
        }
        
        internal List<SelectListItem> cevir(List<Cinsiyeti> liste)
        {
            List<SelectListItem> vmList = new List<SelectListItem>();
            CinsiyetiViewModel vm = null;
            SelectListItem item = null;

            vmList.Add(Sabitler.SecinizSelectListItem);

            if (liste != null)
            {
                foreach (Cinsiyeti deger in liste)
                {
                    vm = this._iMapper.Map<Cinsiyeti, CinsiyetiViewModel>(deger);

                    if (vm != null)
                    {
                        item = new SelectListItem();
                        item.Text = vm.Adi;
                        item.Value = (vm.Anahtar != null) ? vm.Anahtar.ToString() : string.Empty;
                        vmList.Add(item);
                    }

                }
            }

            return vmList;
        }

        internal CinsiyetiViewModel cevir(Cinsiyeti deger)
        {
            return this._iMapper.Map<Cinsiyeti, CinsiyetiViewModel>(deger);
        }

        internal AkademikUnvaniViewModel cevir(AkademikUnvani deger)
        {
            return this._iMapper.Map<AkademikUnvani, AkademikUnvaniViewModel>(deger);
        }

        internal KanGrubuViewModel cevir(KanGrubu deger)
        {
            return this._iMapper.Map<KanGrubu, KanGrubuViewModel>(deger);
        }

        internal List<SelectListItem> cevir(List<KanGrubu> liste)
        {
            
            List<SelectListItem> vmList = new List<SelectListItem>();
            KanGrubuViewModel vm = null;
            SelectListItem item = null;

            vmList.Add(Sabitler.SecinizSelectListItem);

            if (liste != null)
            {
                foreach (KanGrubu deger in liste)
                {
                    vm = this._iMapper.Map<KanGrubu, KanGrubuViewModel>(deger);

                    if (vm != null)
                    {
                        item = new SelectListItem();
                        item.Text = vm.Adi;
                        item.Value = (vm.Anahtar != null) ? vm.Anahtar.ToString() : string.Empty;
                        vmList.Add(item);
                    }

                }
            }

            return vmList;
        }

        internal List<SelectListItem> cevir(List<RhDegeri> liste)
        {
            List<SelectListItem> vmList = new List<SelectListItem>();
            RhDegeriViewModel vm = null;
            SelectListItem item = null;

            vmList.Add(Sabitler.SecinizSelectListItem);

            if (liste != null)
            {
                foreach (RhDegeri deger in liste)
                {
                    vm = this._iMapper.Map<RhDegeri, RhDegeriViewModel>(deger);

                    if (vm != null)
                    {
                        item = new SelectListItem();
                        item.Text = vm.Adi;
                        item.Value = (vm.Anahtar != null) ? vm.Anahtar.ToString() : string.Empty;
                        vmList.Add(item);
                    }

                }
            }

            return vmList;
        }

        internal RhDegeriViewModel cevir(RhDegeri deger)
        {
            return this._iMapper.Map<RhDegeri, RhDegeriViewModel>(deger);
        }

        internal MedeniDurumuViewModel cevir(MedeniDurumu deger)
        {
            return this._iMapper.Map<MedeniDurumu, MedeniDurumuViewModel>(deger);
        }

        internal KadrosuViewModel cevir(Kadrosu deger)
        {
            return this._iMapper.Map<Kadrosu, KadrosuViewModel>(deger);
        }

        internal SinifViewModel cevir(Sinif deger)
        {
            return this._iMapper.Map<Sinif, SinifViewModel>(deger);
        }

        internal List<SelectListItem> cevir(List<OgrenimDurumu> liste)
        {
            List<SelectListItem> vmList = new List<SelectListItem>();
            OgrenimDurumuViewModel vm = null;
            SelectListItem item = null;

            vmList.Add(Sabitler.SecinizSelectListItem);

            if (liste != null)
            {
                foreach (OgrenimDurumu deger in liste)
                {
                    vm = this._iMapper.Map<OgrenimDurumu, OgrenimDurumuViewModel>(deger);

                    if (vm != null)
                    {
                        item = new SelectListItem();
                        item.Text = vm.Adi;
                        item.Value = (vm.Anahtar != null) ? vm.Anahtar.ToString() : string.Empty;
                        vmList.Add(item);
                    }

                }
            }

            return vmList;
        }

        internal List<SelectListItem> cevir(List<Unvan> liste)
        {
            try
            {
                List<SelectListItem> vmList = new List<SelectListItem>();
                UnvanViewModel vm = null;
                SelectListItem item = null;

                vmList.Add(Sabitler.SecinizSelectListItem);

                if (liste != null)
                {
                    foreach (Unvan deger in liste)
                    {
                        vm = this._iMapper.Map<Unvan, UnvanViewModel>(deger);

                        if (vm != null)
                        {
                            item = new SelectListItem();
                            item.Text = vm.Adi;
                            item.Value = (vm.Anahtar != null) ? vm.Anahtar.ToString() : string.Empty;
                            vmList.Add(item);
                        }

                    }
                }

                return vmList;
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return new List<SelectListItem>();

        }

        internal UnvanViewModel cevir(Unvan deger)
        {
            return (deger != null) ? this._iMapper.Map<Unvan, UnvanViewModel>(deger) : null;
        }

        internal List<SelectListItem> cevir(List<Sinif> liste)
        {
            List<SelectListItem> vmList = new List<SelectListItem>();
            SinifViewModel vm = null;
            SelectListItem item = null;

            vmList.Add(Sabitler.SecinizSelectListItem);

            if (liste != null)
            {
                foreach (Sinif deger in liste)
                {
                    vm = this._iMapper.Map<Sinif, SinifViewModel>(deger);

                    if (vm != null)
                    {
                        item = new SelectListItem();
                        item.Text = vm.Adi;
                        item.Value = (vm.Anahtar != null) ? vm.Anahtar.ToString() : string.Empty;
                        vmList.Add(item);
                    }

                }
            }

            return vmList;
        }

        internal List<SelectListItem> cevir(List<MedeniDurumu> liste)
        {
            List<SelectListItem> vmList = new List<SelectListItem>();
            MedeniDurumuViewModel vm = null;
            SelectListItem item = null;

            vmList.Add(Sabitler.SecinizSelectListItem);

            if (liste != null)
            {
                foreach (MedeniDurumu deger in liste)
                {
                    vm = this._iMapper.Map<MedeniDurumu, MedeniDurumuViewModel>(deger);

                    if (vm != null)
                    {
                        item = new SelectListItem();
                        item.Text = vm.Adi;
                        item.Value = (vm.Anahtar != null) ? vm.Anahtar.ToString() : string.Empty;
                        vmList.Add(item);
                    }

                }
            }

            return vmList;
        }

        internal List<SelectListItem> cevir(List<Kadrosu> liste)
        {
            List<SelectListItem> vmList = new List<SelectListItem>();
            KadrosuViewModel vm = null;
            SelectListItem item = null;

            vmList.Add(Sabitler.SecinizSelectListItem);

            if (liste != null)
            {
                foreach (Kadrosu deger in liste)
                {
                    vm = this._iMapper.Map<Kadrosu, KadrosuViewModel>(deger);

                    if (vm != null)
                    {
                        item = new SelectListItem();
                        item.Text = vm.Adi;
                        item.Value = (vm.Anahtar != null) ? vm.Anahtar.ToString() : string.Empty;
                        vmList.Add(item);
                    }

                }
            }

            return vmList;
        }

        internal List<CalisanRaporBirViewModel> cevir(List<CalisanRaporBir> liste)
        {
            IEnumerable<CalisanRaporBirViewModel> vmList = new List<CalisanRaporBirViewModel>();

            if (liste != null)
                vmList = liste.Select(Mapper.Map<CalisanRaporBir, CalisanRaporBirViewModel>);

            return vmList.ToList();
        }
        
        internal List<SelectListItem> cevir(List<Gorevi> liste)
        {
            try
            {
                List<SelectListItem> vmList = new List<SelectListItem>();
                GoreviViewModel vm = null;
                SelectListItem item = null;

                vmList.Add(Sabitler.SecinizSelectListItem);

                if (liste != null)
                {
                    foreach (Gorevi deger in liste)
                    {
                        vm = this._iMapper.Map<Gorevi, GoreviViewModel>(deger);

                        if (vm != null)
                        {
                            item = new SelectListItem();
                            item.Text = vm.Adi;
                            item.Value = (vm.Anahtar != null) ? vm.Anahtar.ToString() : string.Empty;
                            vmList.Add(item);
                        }

                    }
                }

                return vmList;
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return new List<SelectListItem>();
        }

        internal GoreviViewModel cevir(Gorevi deger)
        {
            return (deger != null) ? this._iMapper.Map<Gorevi, GoreviViewModel>(deger) : null;
        }

        internal CalisanOzetViewModel cevir(CalisanOzet deger,BirimViewModel birimVm, IlViewModel ili)
        {
            return (deger != null) ? this._iMapper.Map<CalisanOzet, CalisanOzetViewModel>(deger) : null;
        }

        //TODO: productionda internal yapılacak. 

        public List<CalisanOzetViewModel> cevir(List<CalisanOzet> liste)
        {
            List<CalisanOzetViewModel> vmList = new List<CalisanOzetViewModel>();
            KurumCografyaServis kurumCografyaServis = new KurumCografyaServis(Sabitler.KurumCografyaServisBaglantiCumlesi);
            BirimViewModel birimVm = null;
            IlViewModel ilVm = null;
            int ilId = int.MinValue;

            if (liste != null)
            {
                foreach(CalisanOzet deger in liste)
                {
                    if (deger == null)
                        continue;

                    birimVm = kurumCografyaServis.GetirBirim(deger.Gorevlendirme.BirimId);
                    ilId = deger.Gorevlendirme.IlId ?? int.MinValue;

                    if(ilId != int.MinValue)
                        ilVm = kurumCografyaServis.GetirIl(ilId);

                    vmList.Add(this.cevir(deger, birimVm, ilVm));

                }

            }

            return vmList;
        }

        internal List<SelectListItem> cevir(List<BirimViewModel> liste)
        {
            List<SelectListItem> vmList = new List<SelectListItem>();         
            SelectListItem item = null;

            vmList.Add(Sabitler.SecinizSelectListItem);


            if (liste != null)
            {
                foreach (BirimViewModel deger in liste)
                {
                  
                    if (deger != null)
                    {
                        item = new SelectListItem();
                        item.Text = deger.BirimAdi;
                        item.Value = deger.BirimId.ToString();
                        vmList.Add(item);
                    }

                }
            }

            return vmList;
        }
    }
}
