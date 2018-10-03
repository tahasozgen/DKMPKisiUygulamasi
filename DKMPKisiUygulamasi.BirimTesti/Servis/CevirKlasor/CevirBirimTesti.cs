using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DKMPKisiUygulamasi.BirimTesti.Altyapi;
using DKMPKisiUygulamasi.CakmaWCF.Somut;
using DKMPKurumCografyaUygulamasi.Model.Somut.HataKlasoru;
using DKMPKisiUygulamasi.Model.Somut.RaporKlasor;
using System.Collections.Generic;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.RaporKlasor;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;

namespace DKMPKisiUygulamasi.BirimTesti.Servis.CevirKlasor
{
    [TestClass]
    public class CevirBirimTesti : HataEleAlma
    {

        private static Cevir _cevir;
        private static int _beklenenDeger;
        private static IsGuder _isGuder;

        [ClassInitialize]
        public static void SinifIlklendirici(TestContext context)
        {
            Cevir cevir = new Cevir();

            if (cevir == null)
                throw new BosReferansHatasi("");

            _cevir = cevir;
            _beklenenDeger = int.MinValue;
            _isGuder = new IsGuder();
        }

        [TestInitialize]
        public void FonksiyonIlklendirici()
        {
            try
            {
                this.KurSayac(DKMPHataAltyapi.Enum.Sayac.Baslangic);

                Assert.AreNotEqual(null, _cevir);
                Assert.AreNotEqual(null, _isGuder);

                _beklenenDeger = int.MinValue;
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

        [TestMethod TestCategory("Automapper")]
        public void cevir_test01()
        {

            List<CalisanOzet> liste = new List<CalisanOzet>();
            List<CalisanOzetViewModel> sonuc = null;
            
            try
            {
                _beklenenDeger = 3;

                liste.Add(RastgeleGetir.CalisanOzeti);
                liste.Add(RastgeleGetir.CalisanOzeti);
                liste.Add(RastgeleGetir.CalisanOzeti);

                sonuc = _cevir.cevir(liste);

                Assert.AreNotEqual(null, sonuc);
                Assert.AreEqual(_beklenenDeger, sonuc.Count);
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

        [TestMethod TestCategory("Automapper")]
        public void cevir_test02()
        {

            List<Calisan> liste = new List<Calisan>();
            List<CalisanViewModel> sonuc = null;

            try
            {
                _beklenenDeger = 3;

                liste.Add(RastgeleGetir.Calisani);
                liste.Add(RastgeleGetir.Calisani);
                liste.Add(RastgeleGetir.Calisani);

                sonuc = _cevir.cevir(liste);

                Assert.AreNotEqual(null, sonuc);
                Assert.AreEqual(_beklenenDeger, sonuc.Count);
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


        [TestMethod TestCategory("Automapper")]
        public void cevir_test03()
        {
            CalisanViewModel calisanVm = null;
            Calisan calisan = null;
            int calisanId = 1;

            try
            {
                calisan = _isGuder.getirCalisan(calisanId);

                Assert.AreNotEqual(null, calisan);

                calisanVm = _cevir.cevir(calisan);

                Assert.AreNotEqual(null, calisanVm);
                Assert.AreEqual(false, String.IsNullOrEmpty(calisanVm.SinifiSozce));
                Assert.AreEqual(false, String.IsNullOrEmpty(calisanVm.DogumTarihiSozce));
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
        /// 2 numaralı çalışanın doğum tarihinin gelip gelmediğini kontrol eden test yordamı.
        /// DKMPKISI-HATA-101
        /// tarih: 27.09.2018
        /// </summary>
        [TestMethod TestCategory("Automapper")]
        public void cevir_test04()
        {
            CalisanViewModel calisanVm = null;
            Calisan calisan = null;
            int calisanId = 2;


            try
            {
                calisan = _isGuder.getirCalisan(calisanId);

                Assert.AreNotEqual(null, calisan);

                calisanVm = _cevir.cevir(calisan);

                Assert.AreNotEqual(null, calisanVm);
                Assert.AreEqual(false, String.IsNullOrEmpty(calisanVm.DogumTarihiSozce));
                
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
