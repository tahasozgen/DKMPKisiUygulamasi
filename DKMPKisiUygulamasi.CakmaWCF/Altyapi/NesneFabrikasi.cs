using DKMPKisiUygulamasi.Model.IsKatmani.Somut;
using DKMPKisiUygulamasi.Model.IsKatmani.Soyut;
using DKMPKisiUygulamasi.Model.RepositoryKlasoru;
using DKMPKisiUygulamasi.Repository.Somut;
using DKMPKisiUygulamasi.Servis.Somut;
using DKMPKisiUygulamasi.Servis.Soyut;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.Altyapi
{
    class NesneFabrikasiBirimTesti
    {
        private static NesneFabrikasiBirimTesti instance;
        private Container container = null;

        private NesneFabrikasiBirimTesti()
        {
            try
            {
                this.container = new Container(_ =>
                {
                    //Repository
                    _.For<IUnitOfWork>().Use<NorthwindContext>();
                    _.For<ICalisanGorevRepository>().Use<CalisanGorevRepository>().Ctor<IUnitOfWork>().Is(NorthwindContextSingleton.Instance.context);
                    _.For<ICalisanRepository>().Use<CalisanRepository>().Ctor<IUnitOfWork>().Is(NorthwindContextSingleton.Instance.context);
                    _.For<IGorevRepository>().Use<GorevRepository>();
                    _.For<IKisiIletisimRepository>().Use<KisiIletisimRepository>().Ctor<IUnitOfWork>().Is(NorthwindContextSingleton.Instance.context);
                    _.For<IKisiOgrenimRepository>().Use<KisiOgrenimRepository>().Ctor<IUnitOfWork>().Is(NorthwindContextSingleton.Instance.context);
                    _.For<IOgrenimDurumuRepository>().Use<OgrenimDurumuRepository>().Ctor<IUnitOfWork>().Is(NorthwindContextSingleton.Instance.context);
                    _.For<IUnvanRepository>().Use<UnvanRepository>();

                    //model
                    _.For<ICalisanIsKurali>().Use<CalisanIsKurali>();
                    _.For<IGorevlendirmeIsKurali>().Use<GorevlendirmeIsKurali>();
                    _.For<IKisiIletisimIsKurali>().Use<KisiIletisimIsKurali>();
                    _.For<IOgrenimIsKurali>().Use<OgrenimIsKurali>();
                    _.For<ITanimlayiciVarlikIsKurali>().Use<TanimlayiciVarlikIsKurali>();

                    //servis
                    _.For<ICalisanServis>().Use<CalisanServis>();
                    _.For<IGorevlendirmeServis>().Use<GorevlendirmeServis>();
                    _.For<IKisiIletisimServis>().Use<KisiIletisimServis>();
                    _.For<IOgrenimServis>().Use<OgrenimServis>();
                    _.For<ITanimlayiciVarlikServis>().Use<TanimlayiciVarlikServis>();


                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        //private bool varMiTumKurulumlar()
        //{
        //    container.HasImplementationsFor(IOdenekTransferiIsKurali)
        //}

        private void yazHata(Exception hata)
        {
            if (hata != null)
            {
                HataServis hataiskurali = new HataServis();
                hataiskurali.YazHata(hata);
            }
        }

        internal static NesneFabrikasiBirimTesti Ornek
        {
            get
            {
                if (instance == null)
                {
                    instance = new NesneFabrikasiBirimTesti();
                }
                return instance;
            }
        }

        internal T AlOrnek<T>()
        {

            try
            {
                if (typeof(T) == null)
                {
                    T itemStored = default(T);
                    return itemStored;
                }

                var myInstance = this.container.GetInstance<T>();

                if (myInstance != null)
                {
                    return myInstance;
                }
                else
                {
                    throw new DKMPHataAltyapi.ServisHata("ornek bos geliyor", DKMPHataAltyapi.Enum.HataCiddiyetiEnum.Kritik);
                }

            }
            catch (DKMPHataAltyapi.ServisHata hata)
            {
                throw hata;

                //IHataIsKurali hataik = new HataIsKurali();
                //hataik.RaporlaHata(hata);

                //itemStored = default(T);
            }
            catch (StructureMapConfigurationException hata)
            {
                this.yazHata(hata);
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }

            return default(T);
        }

    }
}
