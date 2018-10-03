using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DKMPKisiUygulamasi.Repository.Baglam;
using DKMPKisiUygulamasi.Model.Somut.IletisimKlasor;
using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.IsKatmani.Somut;
using DKMPKisiUygulamasi.BirimTesti.Altyapi;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;

namespace DKMPKisiUygulamasi.BirimTesti.VeriDoldurmaKlasoru
{
    [TestClass]
    public class UnitTest1 : HataEleAlma
    {
        [TestMethod TestCategory("VeriDoldurma")]
        public void TestMethod1()
        {
            KisiUygulamasiBaglam baglam = new KisiUygulamasiBaglam();
            //this.ekleCalisan(baglam, AkademikUnvani.Bos, "nurettin", "taş", new DateTime(1966, 1, 2), Cinsiyeti.Erkek, "43636227946", KanGrubu.Tanimsiz, RhDegeri.Tanimsiz, "9941", Kadrosu.Memur, Sinif.GenelIdareHizmetSinifi, "6061", "ntas@ormansu.gov.tr", "05322001029");
            this.ekleCalisan(baglam, AkademikUnvani.Bos, "osman", "demirel", new DateTime(1967, 8, 28), Cinsiyeti.Erkek, "18340798976", KanGrubu.A, RhDegeri.Arti, "5098", Kadrosu.Memur, Sinif.GenelIdareHizmetSinifi, "5955", null, "05057801655");

        }

        private bool ekleCalisan(KisiUygulamasiBaglam repository, AkademikUnvani unvani, string adi, string soyadi, DateTime dogumTarihi, Cinsiyeti cinsiyeti, string turCumKimlikNo, KanGrubu kaninGrubu, RhDegeri rhDeger, string sicilNo, Kadrosu kadroDurumu, Sinif sinifi, string dahili, string bakanlikEposta, string cepTelefonu)
        {

            try
            {
                int etkilenenSayisi = int.MinValue;
                int calisanId = int.MinValue;
                Calisan calisan = null;
                KisiIletisim iletisim = null;

                if (repository == null)
                    throw new ArgumentNullException();

                calisan = new Calisan(adi, soyadi, cinsiyeti, unvani, kaninGrubu, rhDeger, MedeniDurumu.Tanimsiz, turCumKimlikNo, dogumTarihi, sicilNo, kadroDurumu, sinifi);
                repository.Calisanlar.Add(calisan);

                etkilenenSayisi = repository.SaveChanges();

                if (etkilenenSayisi != 1)
                    return false;

                repository.Entry(calisan).GetDatabaseValues();
                calisanId = calisan.Anahtar;

                if (calisanId < 0)
                    return false;

                iletisim = new KisiIletisim(dahili, IletisimTuru.Dahili, calisanId);
                repository.KisiIletisimler.Add(iletisim);
                etkilenenSayisi = repository.SaveChanges();

                if (etkilenenSayisi != 1)
                    return false;

                iletisim = new KisiIletisim(bakanlikEposta, IletisimTuru.BakanlikEposta, calisanId);
                repository.KisiIletisimler.Add(iletisim);
                etkilenenSayisi = repository.SaveChanges();

                if (etkilenenSayisi != 1)
                    return false;

                iletisim = new KisiIletisim(cepTelefonu, IletisimTuru.CepTelefonu, calisanId);
                repository.KisiIletisimler.Add(iletisim);
                etkilenenSayisi = repository.SaveChanges();

                if (etkilenenSayisi != 1)
                    return false;

                return true;

            }
            catch (ArgumentNullException hata)
            {

                this.YazHata(hata);

            }
            catch (Exception hata)
            {

                this.YazHata(hata);

            }

            return false;

        }
    }

  
}
