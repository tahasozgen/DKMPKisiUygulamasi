using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DKMPKisiUygulamasi.BirimTesti.Altyapi;
using DKMPKisiUygulamasi.Model.IsKatmani.Soyut;
using DKMPKurumCografyaUygulamasi.Model.Somut.HataKlasoru;
using DKMPKisiUygulamasi.Model.IsKatmani.Somut;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;

namespace DKMPKisiUygulamasi.BirimTesti.Model
{
    [TestClass]
    public class CalisanBirimTesti  :HataEleAlma
    {

        private static ICalisanIsKurali _calisanIsKurali;

        [ClassInitialize]
        public static void SinifIlklendirici(TestContext context)
        {
            try
            {
                ICalisanIsKurali calisanIsKurali = NesneFabrikasiBirimTesti.Ornek.AlOrnek<ICalisanIsKurali>();

                if (calisanIsKurali == null)
                    throw new BosReferansHatasi(Arac.AlSinifYolu<ICalisanIsKurali>());

                _calisanIsKurali = calisanIsKurali;
            }
            catch (Exception)
            {

                throw;
            }

        }

        [TestInitialize]
        public void FonksiyonIlklendirici()
        {
            try
            {

                this.KurSayac(DKMPHataAltyapi.Enum.Sayac.Baslangic);
                Assert.AreNotEqual(null, _calisanIsKurali);

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

        /// <summary>
        /// 2 numaralı çalışanın doğum tarihinin gelip gelmediğini kontrol eden test yordamı.
        /// DKMPKISI-HATA-101
        /// tarih: 27.09.2018
        /// </summary>
        [TestMethod TestCategory("Model")]
        public void GetirCalisan_test01()
        {
            int calisanId = 2;
            DateTime beklenenDogumTarihi = DateTime.MinValue;
            Calisan calisan = null;
            try
            {

                beklenenDogumTarihi = new DateTime(2018, 9, 25);

                calisan = _calisanIsKurali.GetirCalisan(calisanId);

                Assert.AreNotEqual(null, calisan);
                Assert.AreEqual(true, calisan.DogumTarihi.Date.Equals(beklenenDogumTarihi.Date));

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
