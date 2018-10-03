using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DKMPKisiUygulamasi.BirimTesti.Altyapi;
using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using DKMPKisiUygulamasi.CakmaWCF.Somut;

namespace DKMPKisiUygulamasi.BirimTesti.Presentation
{
    [TestClass]
    public class CevirBirimTesti : HataEleAlma
    {

        private static Cevir _cevir;

        [ClassInitialize]
        public static void SinifIlklendirici(TestContext context)
        {
            _cevir = new Cevir();
        }

        [TestInitialize]
        public void FonksiyonIlklendirici()
        {
            try
            {
                this.KurSayac(DKMPHataAltyapi.Enum.Sayac.Baslangic);
                Assert.AreNotEqual(null, _cevir);

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
                //this.KurSayac(DKMPHataAltyapi.Enum.Sayac.Bitis);
                //Assert.AreEqual(false, this.AlindiMiHata());
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

        [TestMethod TestCategory("Presenter")]
        public void cevir_Test1()
        {

            
            CalisanGorevlendirme deger = null;
            Calisan calisan = null;

            try
            {

                //deger = RastgeleGetir.CalisanGorevlendirmesi;
                //calisan = RastgeleGetir.Calisani;
                //deger.Calisani = calisan;
                //sonuc = _cevir.cevir(deger);

                //Assert.AreNotEqual(null, sonuc);                
                //Assert.AreEqual(true, sonuc.Anahtar == deger.Anahtar);
                //Assert.AreEqual(true, sonuc.CalisanAdi.Equals(calisan.Adi));
                //Assert.AreEqual(true, sonuc.CalisanSoyadi.Equals(calisan.Soyadi));


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
