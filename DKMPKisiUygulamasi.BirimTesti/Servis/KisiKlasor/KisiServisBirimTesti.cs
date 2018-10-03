using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DKMPKisiUygulamasi.BirimTesti.Altyapi;
using DKMPKisiUygulamasi.CakmaWCF.Soyut;
using DKMPKurumCografyaUygulamasi.Model.Somut.HataKlasoru;
using DKMPKisiUygulamasi.CakmaWCF.Mesajlar.Somut.Yanit;
using System.Linq;
using DKMPKisiUygulamasi.CakmaWCF.Mesajlar.Somut.Istek;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.RaporKlasor;

namespace DKMPKisiUygulamasi.BirimTesti.Servis.KisiKlasor
{
    [TestClass]
    public class KisiServisBirimTesti: HataEleAlma
    {

        private static IKisiServis _kisiServis;

        [ClassInitialize]
        public static void SinifIlklendirici(TestContext context)
        {
            IKisiServis kisiServis = NesneFabrikasiBirimTesti.Ornek.AlOrnek<IKisiServis>();

            if (kisiServis == null )
                throw new BosReferansHatasi(nameof(IKisiServis));

            _kisiServis = kisiServis;
            
        }

        [TestInitialize]
        public void FonksiyonIlklendirici()
        {
            try
            {
                this.KurSayac(DKMPHataAltyapi.Enum.Sayac.Baslangic);

                Assert.AreNotEqual(null, _kisiServis);

            }
            catch (AssertFailedException hata)
            {
                this.YazHata(hata);
                Assert.Fail();
            }
            catch (Exception hata)
            {
                this.YazHata(hata);
                Assert.Fail();
            }

        }

        [TestCleanup]
        public void FonksiyonSonlandirici()
        {
            try
            {
                this.KurSayac(DKMPHataAltyapi.Enum.Sayac.Bitis);
                Assert.AreEqual(false, this.AlindiMiHata());
            }
            catch (AssertFailedException)
            {
                Assert.Fail();
            }
            catch (Exception hata)
            {
                this.YazHata(hata);
                Assert.Fail();
            }
        }
        



        [TestMethod TestCategory("Servis")]
        public void IlklendirEkleCalisanIletisimGorevEgitim_test01()
        {
            IlklendirEkleCalisanIletisimGorevEgitimViewModel model = null;

            try
            {
                model = _kisiServis.IlklendirEkleCalisanIletisimGorevEgitim();

                Assert.AreNotEqual(null, model);
                Assert.AreEqual(true, model.BasariliMi);
                Assert.AreNotEqual(null, model.BirimListe);
                Assert.AreEqual(true, model.BirimListe.Any());
            }
            catch (AssertFailedException hata)
            {
                this.YazHata(hata);
                Assert.Fail();
            }
            catch (Exception hata)
            {
                this.YazHata(hata);
                Assert.Fail();
            }

        }
        
        /// <summary>
        /// Tarihe göre çalışan özetinin getirildiği test yordamı.
        /// Yazım tarihi: 25.09.2018
        /// </summary>
        [TestMethod TestCategory("Servis")]
        public void GetirCalisanOzet_test01()
        {
            GetirCalisanOzetYanitViewModel yanit = null;
            GetirCalisanOzetIstekViewModel istek = null;
            int kullaniciId = 3;
            DateTime tarih = DateTime.Now;
            int beklenenMinimumDeger = 10;


            try
            {
                istek = new GetirCalisanOzetIstekViewModel(kullaniciId, tarih);
                yanit = _kisiServis.GetirCalisanOzet(istek);

                Assert.AreNotEqual(null, yanit);
                Assert.AreEqual(true, yanit.BasariliMi);
                Assert.AreNotEqual(null, yanit.NesneSayisi >= beklenenMinimumDeger);
                                
            }
            catch (AssertFailedException hata)
            {
                this.YazHata(hata);
                Assert.Fail();
            }
            catch (Exception hata)
            {
                this.YazHata(hata);
                Assert.Fail();
            }

        }

        /// <summary>
        /// Sorgulama sözcesine göre çalışan özetinin getirildiği test yordamı. Sorgulama sözcesi addır. 
        /// Yazım tarihi: 25.09.2018
        /// </summary>
        [TestMethod TestCategory("Servis")]
        public void GetirCalisanOzet_test02()
        {
            GetirCalisanOzetYanitViewModel yanit = null;
            GetirCalisanOzetIstekViewModel istek = null;
            int kullaniciId = 3;
            DateTime tarih = DateTime.Now;
            int beklenenMinimumDeger = 1;
            string sorguSozce = "ad1";
            CalisanOzetViewModel ozet = null;

            try
            {
                istek = new GetirCalisanOzetIstekViewModel(kullaniciId, sorguSozce);
                yanit = _kisiServis.GetirCalisanOzet(istek);

                Assert.AreNotEqual(null, yanit);
                Assert.AreEqual(true, yanit.BasariliMi);
                Assert.AreNotEqual(null, yanit.NesneSayisi >= beklenenMinimumDeger);

                ozet = yanit.TekNesne;
                Assert.AreNotEqual(null, ozet.Ogrenimi);
                Assert.AreNotEqual(null, ozet.Ogrenimi.OgrenimDurumu);
                Assert.AreNotEqual(null, ozet.Gorevlendirme);
                Assert.AreNotEqual(null, ozet.Gorevlendirme.Unvani);
                Assert.AreEqual(false, String.IsNullOrEmpty(ozet.Sinifi));

            }
            catch (AssertFailedException hata)
            {
                this.YazHata(hata);
                Assert.Fail();
            }
            catch (Exception hata)
            {
                this.YazHata(hata);
                Assert.Fail();
            }

        }

        /// <summary>
        /// Sorgulama sözcesine göre çalışan özetinin getirildiği test yordamı. Sorgulama sözcesi soyaddır. 
        /// Yazım tarihi: 25.09.2018
        /// </summary>
        [TestMethod TestCategory("Servis")]
        public void GetirCalisanOzet_test03()
        {
            GetirCalisanOzetYanitViewModel yanit = null;
            GetirCalisanOzetIstekViewModel istek = null;
            int kullaniciId = 3;
            DateTime tarih = DateTime.Now;
            int beklenenMinimumDeger = 1;
            string sorguSozce = "soyad6";
            CalisanOzetViewModel ozet = null;

            try
            {
                istek = new GetirCalisanOzetIstekViewModel(kullaniciId, sorguSozce);
                yanit = _kisiServis.GetirCalisanOzet(istek);

                Assert.AreNotEqual(null, yanit);
                Assert.AreEqual(true, yanit.BasariliMi);
                Assert.AreNotEqual(null, yanit.NesneSayisi >= beklenenMinimumDeger);

                ozet = yanit.TekNesne;
                Assert.AreNotEqual(null, ozet.Ogrenimi);
                Assert.AreNotEqual(null, ozet.Ogrenimi.OgrenimDurumu);

            }
            catch (AssertFailedException hata)
            {
                this.YazHata(hata);
                Assert.Fail();
            }
            catch (Exception hata)
            {
                this.YazHata(hata);
                Assert.Fail();
            }

        }

        /// <summary>
        /// Sorgulama sözcesine göre çalışan özetinin getirildiği test yordamı. Sorgulama sözcesi Türkiye Cumhuriyeti kimlik nosudur. 
        /// Yazım tarihi: 25.09.2018
        /// </summary>
        [TestMethod TestCategory("Servis")]
        public void GetirCalisanOzet_test04()
        {
            GetirCalisanOzetYanitViewModel yanit = null;
            GetirCalisanOzetIstekViewModel istek = null;
            int kullaniciId = 3;
            DateTime tarih = DateTime.Now;
            int beklenenMinimumDeger = 1;
            string sorguSozce = "10534315754";
            CalisanOzetViewModel ozet = null;

            try
            {
                istek = new GetirCalisanOzetIstekViewModel(kullaniciId, sorguSozce);
                yanit = _kisiServis.GetirCalisanOzet(istek);

                Assert.AreNotEqual(null, yanit);
                Assert.AreEqual(true, yanit.BasariliMi);
                Assert.AreNotEqual(null, yanit.NesneSayisi >= beklenenMinimumDeger);

                ozet = yanit.TekNesne;
                Assert.AreNotEqual(null, ozet.Ogrenimi);
                Assert.AreNotEqual(null, ozet.Ogrenimi.OgrenimDurumu);

            }
            catch (AssertFailedException hata)
            {
                this.YazHata(hata);
                Assert.Fail();
            }
            catch (Exception hata)
            {
                this.YazHata(hata);
                Assert.Fail();
            }

        }

        /// <summary>
        /// Sorgulama sözcesinin soyad4'e göre çalışan özetinin getirildiği test yordamı. Sorgulama sözcesi soyaddır. 
        /// Tek yanıt dönmesi beklenir. 
        /// Yazım tarihi: 25.09.2018
        /// </summary>
        [TestMethod TestCategory("Servis")]
        public void GetirCalisanOzet_test05()
        {
            GetirCalisanOzetYanitViewModel yanit = null;
            GetirCalisanOzetIstekViewModel istek = null;
            int kullaniciId = 3;            
            string sorguSozce = "soyad4";           

            try
            {
                istek = new GetirCalisanOzetIstekViewModel(kullaniciId, sorguSozce);
                yanit = _kisiServis.GetirCalisanOzet(istek);

                Assert.AreNotEqual(null, yanit);
                Assert.AreEqual(true, yanit.BasariliMi);
                Assert.AreEqual(true, yanit.TekNesneMi);       

            }
            catch (AssertFailedException hata)
            {
                this.YazHata(hata);
                Assert.Fail();
            }
            catch (Exception hata)
            {
                this.YazHata(hata);
                Assert.Fail();
            }

        }

        /// <summary>
        /// DKMPKISI-HATA-101 hatasını çözmek için yazılan test.
        /// Yazım tarihi: 25.09.2018
        /// </summary>
        [TestMethod TestCategory("Servis")]
        public void GetirCalisanOzet_test06()
        {
            GetirCalisanOzetYanitViewModel yanit = null;
            GetirCalisanOzetIstekViewModel istek = null;
            int kullaniciId = 3;
            string sorguSozce = "soyad4";
            string beklenenDogumTarihi = "25.09.2018";
            CalisanOzetViewModel ozet = null;
            
            try
            {
                istek = new GetirCalisanOzetIstekViewModel(kullaniciId, sorguSozce);
                yanit = _kisiServis.GetirCalisanOzet(istek);

                Assert.AreNotEqual(null, yanit);
                Assert.AreEqual(true, yanit.BasariliMi);
                Assert.AreEqual(true, yanit.TekNesneMi);

                ozet = yanit.TekNesne;
                Assert.AreNotEqual(null, ozet);
                Assert.AreEqual(false, String.IsNullOrEmpty( ozet.DogumTarihi));
                Assert.AreEqual(true, ozet.DogumTarihi.Equals(beklenenDogumTarihi));

            }
            catch (AssertFailedException hata)
            {
                this.YazHata(hata);
                Assert.Fail();
            }
            catch (Exception hata)
            {
                this.YazHata(hata);
                Assert.Fail();
            }

        }

        /// <summary>
        /// DKMPKISI-HATA-100 hatasını çözmek için yazılan test.
        /// Yazım tarihi: 25.09.2018
        /// </summary>
        [TestMethod TestCategory("Servis")]
        public void GetirCalisanOzet_test07()
        {
            GetirCalisanOzetYanitViewModel yanit = null;
            GetirCalisanOzetIstekViewModel istek = null;
            int kullaniciId = 3;
            string sorguSozce = "soyad4";
            string beklenenAdSoyad = "Ad4 Soyad4";
            CalisanOzetViewModel ozet = null;

            try
            {
                istek = new GetirCalisanOzetIstekViewModel(kullaniciId, sorguSozce);
                yanit = _kisiServis.GetirCalisanOzet(istek);

                Assert.AreNotEqual(null, yanit);
                Assert.AreEqual(true, yanit.BasariliMi);
                Assert.AreEqual(true, yanit.TekNesneMi);

                ozet = yanit.TekNesne;
                Assert.AreNotEqual(null, ozet);
                Assert.AreEqual(false, String.IsNullOrEmpty(ozet.AdiSoyadi));
                Assert.AreEqual(true, ozet.AdiSoyadi.Equals(beklenenAdSoyad));

            }
            catch (AssertFailedException hata)
            {
                this.YazHata(hata);
                Assert.Fail();
            }
            catch (Exception hata)
            {
                this.YazHata(hata);
                Assert.Fail();
            }

        }

        /// <summary>
        /// DKMPKISI-HATA-102 hatasını çözmek için yazılan test.
        /// Yazım tarihi: 01.10.2018
        /// </summary>
        [TestMethod TestCategory("Servis")]
        public void GetirCalisanOzet_test08()
        {
            GetirCalisanOzetYanitViewModel yanit = null;
            GetirCalisanOzetIstekViewModel istek = null;
            int kullaniciId = 3;
            string sorguSozce = "soyad4";
            string beklenenKanDegeri = "0 rh-";
            CalisanOzetViewModel ozet = null;

            try
            {
                istek = new GetirCalisanOzetIstekViewModel(kullaniciId, sorguSozce);
                yanit = _kisiServis.GetirCalisanOzet(istek);

                Assert.AreNotEqual(null, yanit);
                Assert.AreEqual(true, yanit.BasariliMi);
                Assert.AreEqual(true, yanit.TekNesneMi);

                ozet = yanit.TekNesne;
                Assert.AreNotEqual(null, ozet);
                Assert.AreEqual(false, String.IsNullOrEmpty(ozet.AdiSoyadi));
                Assert.AreEqual(true, ozet.KanGrubuveRh.Equals(beklenenKanDegeri));

            }
            catch (AssertFailedException hata)
            {
                this.YazHata(hata);
                Assert.Fail();
            }
            catch (Exception hata)
            {
                this.YazHata(hata);
                Assert.Fail();
            }

        }

        /// <summary>
        /// DKMPKISI-HATA-104 hatasını çözmek için yazılan test.
        /// Yazım tarihi: 01.10.2018
        /// </summary>
        [TestMethod TestCategory("Servis")]
        public void GetirCalisanOzet_test09()
        {
            GetirCalisanOzetYanitViewModel yanit = null;
            GetirCalisanOzetIstekViewModel istek = null;
            int kullaniciId = 3;
            string sorguSozce = "soyad4";
            string beklenenSinif = "TH";
            CalisanOzetViewModel ozet = null;

            try
            {
                istek = new GetirCalisanOzetIstekViewModel(kullaniciId, sorguSozce);
                yanit = _kisiServis.GetirCalisanOzet(istek);

                Assert.AreNotEqual(null, yanit);
                Assert.AreEqual(true, yanit.BasariliMi);
                Assert.AreEqual(true, yanit.TekNesneMi);

                ozet = yanit.TekNesne;
                Assert.AreNotEqual(null, ozet);
                Assert.AreEqual(false, String.IsNullOrEmpty(ozet.AdiSoyadi));
                Assert.AreEqual(true, ozet.Sinifi.Equals(beklenenSinif));

            }
            catch (AssertFailedException hata)
            {
                this.YazHata(hata);
                Assert.Fail();
            }
            catch (Exception hata)
            {
                this.YazHata(hata);
                Assert.Fail();
            }

        }


        /// <summary>
        /// DKMPKISI-HATA-108 hatasını çözmek için yazılan test.
        /// Yazım tarihi: 01.10.2018
        /// </summary>
        [TestMethod TestCategory("Servis")]
        public void GetirCalisanOzet_test10()
        {
            GetirCalisanOzetYanitViewModel yanit = null;
            GetirCalisanOzetIstekViewModel istek = null;
            int kullaniciId = 3;
            string sorguSozce = "osman";
            CalisanOzetViewModel ozet = null;
            string sicilNo = "5098";

            try
            {
                istek = new GetirCalisanOzetIstekViewModel(kullaniciId, sorguSozce);
                yanit = _kisiServis.GetirCalisanOzet(istek);

                Assert.AreNotEqual(null, yanit);
                Assert.AreEqual(true, yanit.BasariliMi);
                Assert.AreEqual(true, yanit.TekNesneMi);

                ozet = yanit.TekNesne;
                Assert.AreNotEqual(null, ozet);
                Assert.AreEqual(false, String.IsNullOrEmpty(ozet.AdiSoyadi));
                Assert.AreEqual(true, ozet.SicilNo.Equals(sicilNo));

            }
            catch (AssertFailedException hata)
            {
                this.YazHata(hata);
                Assert.Fail();
            }
            catch (Exception hata)
            {
                this.YazHata(hata);
                Assert.Fail();
            }

        }
    }
}
