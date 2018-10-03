using DKMPKisiUygulamasi.CakmaWCF.Mesajlar.Somut.Istek;
using DKMPKisiUygulamasi.CakmaWCF.Mesajlar.Somut.Yanit;
using DKMPKisiUygulamasi.CakmaWCF.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DKMPKisiUygulamasi.Web.Controllers
{
    public class KisiController : Controller
    {
        private readonly IKisiServis _kisiServis;

        private readonly IHataServis _hataServis;

        public KisiController(IKisiServis kisiServis, IHataServis hataServis)
        {
            this._kisiServis = kisiServis;
            this._hataServis = hataServis;
        }

        // GET: Kisi
        public ActionResult Index()
        {

            try
            {
                GetirCalisanOzetIstekViewModel istek = null;
                GetirCalisanOzetYanitViewModel yanit = null;

                istek = new GetirCalisanOzetIstekViewModel(3, DateTime.Now);

                yanit = this._kisiServis.GetirCalisanOzet(istek);

                if (yanit == null)
                    throw new ApplicationException();

                if (!yanit.BasariliMi)
                    throw new ApplicationException();

                return View(yanit);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return View(new GetirCalisanOzetYanitViewModel(false));
        }

        [HttpPost]
        public ActionResult Index(GetirCalisanOzetYanitViewModel model)
        {

            try
            {
                GetirCalisanOzetIstekViewModel istek = null;
                GetirCalisanOzetYanitViewModel yanit = null;

                istek = new GetirCalisanOzetIstekViewModel(3, model.SorguSozcesi);

                yanit = this._kisiServis.GetirCalisanOzet(istek);

                if (yanit == null)
                    throw new ApplicationException();

                if (!yanit.BasariliMi)
                    throw new ApplicationException();

                return View(yanit);
            }
            catch (Exception hata)
            {
                this._hataServis.YazHata(hata);
            }

            return View(new GetirCalisanOzetYanitViewModel(false));
        }

        public ActionResult EkleCalisanToplu()
        {

            try
            {
                IlklendirEkleCalisanIletisimGorevEgitimViewModel vm = null;

                vm = this._kisiServis.IlklendirEkleCalisanIletisimGorevEgitim();

                if (vm == null)
                    throw new ApplicationException();

                if (!vm.BasariliMi)
                    throw new ApplicationException();

                return View(vm);

            }
            catch (Exception hata)
            {
                //sıçtık hacılar
                this._hataServis.YazHata(hata);

            }

            return View(new IlklendirEkleCalisanIletisimGorevEgitimViewModel(false));

        }

        [HttpPost]
        public ActionResult EkleCalisanToplu(IlklendirEkleCalisanIletisimGorevEgitimViewModel model)
        {

            try
            {

                EkleCalisanIletisimGorevEgitimYanitViewModel sonucVm = null;

                sonucVm = this._kisiServis.Ekle(model);

                if (sonucVm == null)
                    throw new ApplicationException();

                if (!sonucVm.BasariliMi)
                    throw new ApplicationException();

                return View(sonucVm);

            }
            catch (Exception hata)
            {
                //sıçtık hacılar
                this._hataServis.YazHata(hata);
            }

            return View(new IlklendirEkleCalisanIletisimGorevEgitimViewModel(false));

        }
        
        public ActionResult SorgulaKisi()
        {
            try
            {
                SorgulaCalisanIstekViewModel vm = null;

                vm = new SorgulaCalisanIstekViewModel(int.MinValue, null);

                return View(vm);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}