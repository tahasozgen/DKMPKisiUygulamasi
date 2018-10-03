using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DKMPKisiUygulamasi.BirimTesti.Altyapi;
using DKMPKisiUygulamasi.Model.IsKatmani.Somut;

namespace DKMPKisiUygulamasi.BirimTesti.Model
{
    [TestClass]
    public class AracBirimTesti : HataEleAlma
    {        

        [ClassInitialize]
        public static void SinifIlklendirici(TestContext context)
        {
        
        }

        [TestInitialize]
        public void FonksiyonIlklendirici()
        {
            try
            {
                this.KurSayac(DKMPHataAltyapi.Enum.Sayac.Baslangic);
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

        [TestMethod TestCategory("Model")]
        public void CevirTarihe_test01()
        {
            string tarih = "28.08.1967";
            DateTime sonuc = DateTime.MinValue;
            int yil = 1967;
            int ay = 8;
            int gun = 28;
            try
            {
                sonuc = Arac.CevirTarihe(tarih);
                Assert.AreEqual(yil, sonuc.Year);
                Assert.AreEqual(ay, sonuc.Month);
                Assert.AreEqual(gun, sonuc.Day);

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

        
        [TestMethod TestCategory("Model")]
        public void CevirTarihe_test02()
        {
            string tarih = "8.07.1968";
            DateTime sonuc = DateTime.MinValue;
            int yil = 1968;
            int ay = 7;
            int gun = 8;
            try
            {
                sonuc = Arac.CevirTarihe(tarih);
                Assert.AreEqual(yil, sonuc.Year);
                Assert.AreEqual(ay, sonuc.Month);
                Assert.AreEqual(gun, sonuc.Day);

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
