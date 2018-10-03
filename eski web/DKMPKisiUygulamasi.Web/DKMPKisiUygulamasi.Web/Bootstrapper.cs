using System.Web.Mvc;
using DKMPKisiUygulamasi.CakmaWCF.Soyut;
using DKMPKisiUygulamasi.CakmaWCF.Somut;
using DKMPKisiUygulamasi.Web.Controllers;

namespace DKMPKisiUygulamasi.Web
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            ControllerBuilder.Current
                .SetControllerFactory(new StructureMapControllerFactory());

            ObjectFactory.Initialize(x =>
            {
                x.AddConfigurationFromXmlFile("StructureMap.xml");
            });
        }
    }
}