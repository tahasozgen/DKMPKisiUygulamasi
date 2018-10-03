using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.IsKatmani.Somut;
using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;
using DKMPKisiUygulamasi.Model.Somut.IletisimKlasor;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using DKMPKisiUygulamasi.Model.Somut.OgrenimKlasor;
using DKMPKisiUygulamasi.Model.Somut.TanimlayiciKlasor;
using DKMPKisiUygulamasi.Repository.Baglam;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DKMPKisiUygulamasi.Repository.IlklendirmeKlasoru
{
    public class KisiIlklendirme : System.Data.Entity.DropCreateDatabaseIfModelChanges<KisiUygulamasiBaglam>
    {

        private void yazHata(Exception hata)
        {
            if (hata != null)
            {
                HataIsKurali hataik = new HataIsKurali();
                hataik.YazHata(hata);
            }
        }

        protected override void Seed(KisiUygulamasiBaglam context)
        {
            this.doldurGercekVeritabani(context);
        }
        
        private void doldurTestVeritabani(KisiUygulamasiBaglam baglam)
        {
            try
            {

                if (baglam == null)
                    throw new ArgumentNullException();

                #region ünvanlar

                var fonksiyonelSiniflandirmaListesi = new List<Unvan>
            {
              
                //1
                new Unvan("apk uzmanı"),
                //2
                new Unvan("araştırmacı"),                
                //3
                new Unvan("arkeolog"),
                //4
                new Unvan("bakanlık müşaviri"),
                //5                
                new Unvan("bilgisayar işletmeni"),
                //6
                new Unvan("bilgisayar işletmeni"),
                //7
                new Unvan("biyolog"),                                
                //8
                new Unvan("çevre mühendisi"),
                //9               
                new Unvan("daimi işçi"),
                //10
                new Unvan("daire başkanı"),
                //11
                new Unvan("genel müdür"),
                //12
                new Unvan("genel müdür yardımcısı"),
                //13
                new Unvan("harita mühendisi"),
                //14
                new Unvan("hukuk müşaviri"),
                //15
                new Unvan("inşaat mühendisi"),                  
                //16
                new Unvan("istatistikçi"),                                  
                //17
                new Unvan("jeodezi mühendisi"),                             
                //18
                new Unvan("jeofizik mühendisi"),
                //19
                new Unvan("jeoloji mühendisi"),                         
                //20
                new Unvan("kimya mühendisi"),                                
                //21
                new Unvan("maden mühendisi"),                                
                //22
                new Unvan("makine mühendisi"),
                //23
                new Unvan("memur"),
                //24
                new Unvan("mimar"),                                
                //25
                new Unvan("tarım ve orman uzman yardımcısı"),
                //26
                new Unvan("tarım ve orman uzmanı"),
                //27
                new Unvan("orman endüstri mühendisi"),
                //28
                new Unvan("orman mühendisi"),                                
                //29
                new Unvan("peyzaj mimarı"),                                
                //30
                new Unvan("su ürünleri mühendisi"),
                //31
                new Unvan("şef"),
                //32
                new Unvan("şehir plancısı"),
                //33
                new Unvan("şube müdürü"),
                //34
                new Unvan("tekniker"),
                //35
                new Unvan("teknisyen"),                                
                //36
                new Unvan("veri hazırlama ve kontrol işletmeni"),
                //37
                new Unvan("veteriner hekim"),
                //38
                new Unvan("ziraat mühendisi"),
            };

                fonksiyonelSiniflandirmaListesi.ForEach(s => baglam.Unvanlar.Add(s));
                baglam.SaveChanges();

                #endregion

                #region görevi

                var gorevListe = new List<Gorevi>
            {                   
                //1
                new Gorevi("apk uzmanı"),                                                           
                //2
                new Gorevi("araştırmacı"),                     
                //3
                new Gorevi("arkeolog"),
                //4
                new Gorevi("bakanlık döner sermaye müdürü"),
                //5
                new Gorevi("bakanlık müşaviri"),
                //6
                new Gorevi("basın ve halkla ilişkiler müşaviri"),
                //7
                new Gorevi("bilgisayar işletmeni","bilgisayar iş."),
                //8
                new Gorevi("biyolog"),
                //9
                new Gorevi("bölge müdürü",true),                                
                //10
                new Gorevi("büro memuru"),                                
                //11
                new Gorevi("çevre mühendisi"),                    
                //12
                new Gorevi("daire başkanı",true),
                //13
                new Gorevi("evrak memuru"),                                
                //14
                new Gorevi("genel müdür",true),
                //15
                new Gorevi("genel müdür yardımcısı","genel müdür yard.",true),                                
                //16
                new Gorevi("harita mühendisi"),
                //17
                new Gorevi("hukuk müşaviri"),
                //18
                new Gorevi("inşaat mühendisi"),
                //19
                new Gorevi("istatistikçi"),
                //20
                new Gorevi("jeodezi mühendisi"),                                
                //21
                new Gorevi("jeofizik mühendisi"),                                
                //22
                new Gorevi("jeoloji mühendisi"),                                
                //23
                new Gorevi("kat görevlisi"),
                //24
                new Gorevi("kimya mühendisi"),
                //25
                new Gorevi("makam odacısı"),
                //26
                new Gorevi("makine mühendisi"),
                //27
                new Gorevi("memur"),
                //28
                new Gorevi("mimar"),                                
                //29
                new Gorevi("tarım ve orman uzman yardımcısı","tarım ve orman uzm. yrd."),
                //30
                new Gorevi("tarım ve orman uzmanı"),
                //31
                new Gorevi("orman endüstri mühendisi","orm. end. mühendisi"),
                //32
                new Gorevi("orman mühendisi"),
                //33
                new Gorevi("peyzaj mimarı"),
                //34
                new Gorevi("satınalma memuru"),
                //35
                new Gorevi("sekreter"),
                //36
                new Gorevi("su ürünleri mühendisi","su ürünleri müh."),
                //37
                new Gorevi("şehir plancısı"),
                //38
                new Gorevi("şoför"),
                //39
                new Gorevi("şube müdürü"),                                
                //40
                new Gorevi("taşınır kayıt ve kontrol yetkilisi","taş.kay.ve kont.yet."),                                
                //41
                new Gorevi("tekniker"),
                //42
                new Gorevi("teknisyen"),                                
                //43
                new Gorevi("veri hazırlama kontrol işletmeni","ver. haz. kont. işl."),
                //44
                new Gorevi("veteriner hekim"),
                //45
                new Gorevi("ziraat mühendisi"),

            };


                gorevListe.ForEach(s => baglam.Gorevler.Add(s));
                baglam.SaveChanges();

                #endregion

                #region üniversiteler

                List<Universite> liste = this.okuUniversiteListe();

                liste.ForEach(s => baglam.UniversiteListe.Add(s));
                baglam.SaveChanges();

                #endregion

                #region öğrenim durumu


                var ogrenimDurumuListe = new List<OgrenimDurumu>
            {                   
                //1
                new OgrenimDurumu("açık öğretim",EgitimDuzeyi.Lisans),
                //2
                new OgrenimDurumu("arkeolog",EgitimDuzeyi.Lisans),
                //3
                new OgrenimDurumu("bilgisayar mühendisi",EgitimDuzeyi.Lisans),
                //4
                new OgrenimDurumu("biyoloji",EgitimDuzeyi.Lisans),
                //5
                new OgrenimDurumu("biyoloji",EgitimDuzeyi.YuksekLisans),
                //6
                new OgrenimDurumu("büro yönetimi",EgitimDuzeyi.YuksekOkul),
                //7
                new OgrenimDurumu("çevre mühendisi",EgitimDuzeyi.Lisans),
                //8           
                new OgrenimDurumu("fransız dili edebiyatı",EgitimDuzeyi.Lisans),
                //9
                new OgrenimDurumu("halkla ilişkiler",EgitimDuzeyi.YuksekOkul),
                //10
                new OgrenimDurumu("harita mühendisi",EgitimDuzeyi.Lisans),
                //11
                new OgrenimDurumu("hidrojeoloji mühendisi",EgitimDuzeyi.Lisans),
                //12
                new OgrenimDurumu("hukuk fakültesi",EgitimDuzeyi.Lisans),               
                //13
                new OgrenimDurumu("iktisat fakültesi",EgitimDuzeyi.Lisans),
                //14
                new OgrenimDurumu("iletişim fakültesi",EgitimDuzeyi.Lisans),
                //15
                new OgrenimDurumu("ilkokul",EgitimDuzeyi.Ilkokul),
                //16
                new OgrenimDurumu("ilköğretim",EgitimDuzeyi.Ortaokul),
                //17 
                new OgrenimDurumu("insan kaynakları",EgitimDuzeyi.YuksekOkul),
                //18
                new OgrenimDurumu("insan kaynakları",EgitimDuzeyi.Lisans),
                //19
                new OgrenimDurumu("inşaat mühendisi",EgitimDuzeyi.Lisans),
                //20
                new OgrenimDurumu("istatistikçi",EgitimDuzeyi.Lisans),      
                //21
                new OgrenimDurumu("iş idaresi",EgitimDuzeyi.YuksekOkul),
                //22
                new OgrenimDurumu("işletme",EgitimDuzeyi.Lisans),
                //23
                new OgrenimDurumu("jeodezi mühendisi",EgitimDuzeyi.Lisans),
                //24
                new OgrenimDurumu("jeofizik mühendisi",EgitimDuzeyi.Lisans),
                //25
                new OgrenimDurumu("jeoloji mühendisi",EgitimDuzeyi.Lisans),
                //26
                new OgrenimDurumu("kamu yönetimi",EgitimDuzeyi.YuksekOkul),
                //27
                new OgrenimDurumu("kimya mühendisi",EgitimDuzeyi.Lisans),
                //28
                new OgrenimDurumu("lise",EgitimDuzeyi.Lise),
                //29
                new OgrenimDurumu("maden mühendisi",EgitimDuzeyi.Lisans),
                //30
                new OgrenimDurumu("makine mühendisi",EgitimDuzeyi.Lisans),
                //31
                new OgrenimDurumu("maliye",EgitimDuzeyi.Lisans),
                //32
                new OgrenimDurumu("meslek yüksekokulu",EgitimDuzeyi.YuksekOkul),
                //33
                new OgrenimDurumu("mimar",EgitimDuzeyi.Lise),
                //34
                new OgrenimDurumu("muhasebe",EgitimDuzeyi.YuksekOkul),
                //35
                new OgrenimDurumu("orman endüstri mühendisi",EgitimDuzeyi.Lisans),
                //36
                new OgrenimDurumu("orman mühendisi",EgitimDuzeyi.Lisans),
                //37
                new OgrenimDurumu("ortaokul",EgitimDuzeyi.Ortaokul),
                //38
                new OgrenimDurumu("peyzaj mimarı",EgitimDuzeyi.Lisans),
                //39
                new OgrenimDurumu("su ürünleri mühendisi",EgitimDuzeyi.Lisans),   
                //40
                new OgrenimDurumu("şehir plancısı",EgitimDuzeyi.Lisans),   
                //41
                new OgrenimDurumu("teknik programcı",EgitimDuzeyi.YuksekOkul),   
                //42
                new OgrenimDurumu("turizm yüksek okulu",EgitimDuzeyi.YuksekOkul),   
                //43
                new OgrenimDurumu("türk dili ve edebiyatı",EgitimDuzeyi.Lisans),
                //44
                new OgrenimDurumu("veteriner hekim",EgitimDuzeyi.Lisans),
                //45
                new OgrenimDurumu("ziraat mühendisi",EgitimDuzeyi.Lisans),

            };

                ogrenimDurumuListe.ForEach(s => baglam.OgrenimDurumlari.Add(s));
                baglam.SaveChanges();

                #endregion

                #region çalışan

                var calisanListe = new List<Calisan>
            {                   
                //1
                new Calisan("ad1", "soyad1", Cinsiyeti.Erkek, AkademikUnvani.Bos, KanGrubu.A, RhDegeri.Arti , MedeniDurumu.Bekar, "47407384838",DateTime.Now, "11", Kadrosu.DaimiIsci, Sinif.GenelIdareHizmetSinifi),
                //2
                new Calisan("ad2", "soyad2", Cinsiyeti.Kadin, AkademikUnvani.Avukat, KanGrubu.AB, RhDegeri.Eksi , MedeniDurumu.Evli, "18131814748",DateTime.Now, "22", Kadrosu.Memur, Sinif.TeknikHizmetler),
                //3
                new Calisan("ad3", "soyad3", Cinsiyeti.Erkek, AkademikUnvani.Docent , KanGrubu.B, RhDegeri.Arti , MedeniDurumu.Bosanmis, "16342971496",DateTime.Now, "33", Kadrosu.DaimiIsci, Sinif.GenelIdareHizmetSinifi),
                //4
                new Calisan("ad4", "soyad4", Cinsiyeti.Kadin, AkademikUnvani.Doktor, KanGrubu.Sifir, RhDegeri.Eksi , MedeniDurumu.Bekar, "19819615404",DateTime.Now, "44", Kadrosu.Memur, Sinif.TeknikHizmetler),
                //5
                new Calisan("ad5", "soyad5", Cinsiyeti.Erkek, AkademikUnvani.Profesor, KanGrubu.A, RhDegeri.Arti , MedeniDurumu.Evli, "11629877652",DateTime.Now, "55", Kadrosu.DaimiIsci, Sinif.GenelIdareHizmetSinifi),
                //6
                new Calisan("ad6", "soyad6", Cinsiyeti.Kadin, AkademikUnvani.YuksekMuhendis, KanGrubu.AB, RhDegeri.Eksi , MedeniDurumu.Bosanmis, "10534315754",DateTime.Now, "66", Kadrosu.Memur, Sinif.TeknikHizmetler),
                //7
                new Calisan("ad7", "soyad7", Cinsiyeti.Erkek, AkademikUnvani.Bos, KanGrubu.B, RhDegeri.Arti , MedeniDurumu.Bekar, "50251299722",DateTime.Now, "77", Kadrosu.DaimiIsci, Sinif.GenelIdareHizmetSinifi),
                //8           
                new Calisan("ad8", "soyad8", Cinsiyeti.Kadin, AkademikUnvani.Avukat, KanGrubu.Sifir, RhDegeri.Eksi , MedeniDurumu.Evli, "18350859582",DateTime.Now, "88", Kadrosu.Memur, Sinif.TeknikHizmetler),
                //9
                new Calisan("ad9", "soyad9", Cinsiyeti.Erkek, AkademikUnvani.Docent, KanGrubu.A, RhDegeri.Arti , MedeniDurumu.Bosanmis, "28690402584",DateTime.Now, "99", Kadrosu.DaimiIsci, Sinif.GenelIdareHizmetSinifi),
                //10
                new Calisan("ad10", "soyad10", Cinsiyeti.Kadin, AkademikUnvani.Doktor, KanGrubu.AB, RhDegeri.Eksi , MedeniDurumu.Bekar, "26638017890",DateTime.Now, "1010", Kadrosu.Memur, Sinif.TeknikHizmetler),

            };

                calisanListe.ForEach(s => baglam.Calisanlar.Add(s));
                baglam.SaveChanges();

                #endregion

                #region görevlendirme

                //CalisanGorevlendirme

                Calisan calisan1 = baglam.Calisanlar.First(p => p.Anahtar == 1);
                Calisan calisan2 = baglam.Calisanlar.First(p => p.Anahtar == 2);
                Calisan calisan3 = baglam.Calisanlar.First(p => p.Anahtar == 3);
                Calisan calisan4 = baglam.Calisanlar.First(p => p.Anahtar == 4);
                Calisan calisan5 = baglam.Calisanlar.First(p => p.Anahtar == 5);
                Calisan calisan6 = baglam.Calisanlar.First(p => p.Anahtar == 6);
                Calisan calisan7 = baglam.Calisanlar.First(p => p.Anahtar == 7);
                Calisan calisan8 = baglam.Calisanlar.First(p => p.Anahtar == 8);
                Calisan calisan9 = baglam.Calisanlar.First(p => p.Anahtar == 9);
                Calisan calisan10 = baglam.Calisanlar.First(p => p.Anahtar == 10);

                Gorevi gorevi1 = baglam.Gorevler.First(p => p.Anahtar == 1);
                Gorevi gorevi2 = baglam.Gorevler.First(p => p.Anahtar == 2);
                Gorevi gorevi3 = baglam.Gorevler.First(p => p.Anahtar == 3);
                Gorevi gorevi4 = baglam.Gorevler.First(p => p.Anahtar == 4);
                Gorevi gorevi5 = baglam.Gorevler.First(p => p.Anahtar == 5);
                Gorevi gorevi6 = baglam.Gorevler.First(p => p.Anahtar == 6);
                Gorevi gorevi7 = baglam.Gorevler.First(p => p.Anahtar == 7);
                Gorevi gorevi8 = baglam.Gorevler.First(p => p.Anahtar == 8);
                Gorevi gorevi9 = baglam.Gorevler.First(p => p.Anahtar == 9);
                Gorevi gorevi10 = baglam.Gorevler.First(p => p.Anahtar == 10);

                Unvan unvani1 = baglam.Unvanlar.First(p => p.Anahtar == 1);
                Unvan unvani2 = baglam.Unvanlar.First(p => p.Anahtar == 2);
                Unvan unvani3 = baglam.Unvanlar.First(p => p.Anahtar == 3);
                Unvan unvani4 = baglam.Unvanlar.First(p => p.Anahtar == 4);
                Unvan unvani5 = baglam.Unvanlar.First(p => p.Anahtar == 5);
                Unvan unvani6 = baglam.Unvanlar.First(p => p.Anahtar == 6);
                Unvan unvani7 = baglam.Unvanlar.First(p => p.Anahtar == 7);
                Unvan unvani8 = baglam.Unvanlar.First(p => p.Anahtar == 8);
                Unvan unvani9 = baglam.Unvanlar.First(p => p.Anahtar == 9);
                Unvan unvani10 = baglam.Unvanlar.First(p => p.Anahtar == 10);

                var gorevlendirmeListe = new List<CalisanGorevlendirme>
                {                   
                    //1
                    new CalisanGorevlendirme(calisan1, gorevi1, unvani1, 30),
                    //2
                    new CalisanGorevlendirme(calisan2, gorevi2, unvani2, 31),
                    //3
                    new CalisanGorevlendirme(calisan3, gorevi3, unvani3, 32),
                    //4
                    new CalisanGorevlendirme(calisan4, gorevi4, unvani4, 33),
                    //5
                    new CalisanGorevlendirme(calisan5, gorevi5, unvani5, 34),
                    //6
                    new CalisanGorevlendirme(calisan6, gorevi6, unvani6, 35),
                    //7
                    new CalisanGorevlendirme(calisan7, gorevi7, unvani7, 36),
                    //8           
                    new CalisanGorevlendirme(calisan8, gorevi8, unvani8, 37),
                    //9
                    new CalisanGorevlendirme(calisan9, gorevi9, unvani9, 38),
                    //10
                    new CalisanGorevlendirme(calisan10, gorevi10, unvani10, 39),

                };

                gorevlendirmeListe.ForEach(s => baglam.CalisanGorevlendirmeListe.Add(s));
                baglam.SaveChanges();


                #endregion

                #region kişi öğrenim

              

                OgrenimDurumu ogrenim1 = baglam.OgrenimDurumlari.First(p => p.Anahtar == 1);
                OgrenimDurumu ogrenim2 = baglam.OgrenimDurumlari.First(p => p.Anahtar == 2);
                OgrenimDurumu ogrenim3 = baglam.OgrenimDurumlari.First(p => p.Anahtar == 3);
                OgrenimDurumu ogrenim4 = baglam.OgrenimDurumlari.First(p => p.Anahtar == 4);
                OgrenimDurumu ogrenim5 = baglam.OgrenimDurumlari.First(p => p.Anahtar == 5);
                OgrenimDurumu ogrenim6 = baglam.OgrenimDurumlari.First(p => p.Anahtar == 6);
                OgrenimDurumu ogrenim7 = baglam.OgrenimDurumlari.First(p => p.Anahtar == 7);
                OgrenimDurumu ogrenim8 = baglam.OgrenimDurumlari.First(p => p.Anahtar == 8);
                OgrenimDurumu ogrenim9 = baglam.OgrenimDurumlari.First(p => p.Anahtar == 9);
                OgrenimDurumu ogrenim10 = baglam.OgrenimDurumlari.First(p => p.Anahtar == 10);


                var kisiOgrenimListe = new List<KisiOgrenim>
            {                   
                //1
                new KisiOgrenim(calisan1,ogrenim1),
                //2
                new KisiOgrenim(calisan2,ogrenim2),
                //3
                new KisiOgrenim(calisan3,ogrenim3),
                //4
                new KisiOgrenim(calisan4,ogrenim4),
                //5
                new KisiOgrenim(calisan5,ogrenim5),
                //6
                new KisiOgrenim(calisan6,ogrenim6),
                //7
                new KisiOgrenim(calisan7,ogrenim7),
                //8           
                new KisiOgrenim(calisan8,ogrenim8),
                //9
                new KisiOgrenim(calisan9,ogrenim9),
                //10
                new KisiOgrenim(calisan10,ogrenim10),

            };

                kisiOgrenimListe.ForEach(s => baglam.KisiOgrenimListe.Add(s));
                baglam.SaveChanges();

                #endregion

                #region kişi iletişim


                var kisiIletisimListe = new List<KisiIletisim>
            {                   
                //1
                new KisiIletisim("12",IletisimTuru.Adres,1),
                //2
                new KisiIletisim("13",IletisimTuru.BakanlikEposta,2),
                //3
                new KisiIletisim("14",IletisimTuru.CepTelefonu,3),
                //4
                new KisiIletisim("15",IletisimTuru.Dahili,4),
                //5
                new KisiIletisim("16",IletisimTuru.EvTelefonu,5),
                //6
                new KisiIletisim("17",IletisimTuru.NormalEPosta,6),
                //7
                new KisiIletisim("18",IletisimTuru.Adres,7),
                //8           
                new KisiIletisim("19",IletisimTuru.BakanlikEposta,8),
                //9
                new KisiIletisim("20",IletisimTuru.CepTelefonu,9),
                //10
                new KisiIletisim("21",IletisimTuru.Dahili,10),

            };

                kisiIletisimListe.ForEach(s => baglam.KisiIletisimler.Add(s));
                baglam.SaveChanges();

                #endregion

            }
            catch (ArgumentNullException hata)
            {
                this.yazHata(hata);
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }

        }

        private void doldurGercekVeritabani(KisiUygulamasiBaglam baglam)
        {
            try
            {

                if (baglam == null)
                    throw new ArgumentNullException();

                #region ünvanlar

                var fonksiyonelSiniflandirmaListesi = new List<Unvan>
            {
              
                //1
                new Unvan("apk uzmanı"),
                //2
                new Unvan("araştırmacı"),                
                //3
                new Unvan("arkeolog"),
                //4
                new Unvan("bakanlık müşaviri"),
                //5                
                new Unvan("bilgisayar işletmeni"),
                //6
                new Unvan("bilgisayar işletmeni"),
                //7
                new Unvan("biyolog"),                                
                //8
                new Unvan("çevre mühendisi"),
                //9               
                new Unvan("daimi işçi"),
                //10
                new Unvan("daire başkanı"),
                //11
                new Unvan("genel müdür"),
                //12
                new Unvan("genel müdür yardımcısı"),
                //13
                new Unvan("harita mühendisi"),
                //14
                new Unvan("hukuk müşaviri"),
                //15
                new Unvan("inşaat mühendisi"),                  
                //16
                new Unvan("istatistikçi"),                                  
                //17
                new Unvan("jeodezi mühendisi"),                             
                //18
                new Unvan("jeofizik mühendisi"),
                //19
                new Unvan("jeoloji mühendisi"),                         
                //20
                new Unvan("kimya mühendisi"),                                
                //21
                new Unvan("maden mühendisi"),                                
                //22
                new Unvan("makine mühendisi"),
                //23
                new Unvan("memur"),
                //24
                new Unvan("mimar"),                                
                //25
                new Unvan("tarım ve orman uzman yardımcısı"),
                //26
                new Unvan("tarım ve orman uzmanı"),
                //27
                new Unvan("orman endüstri mühendisi"),
                //28
                new Unvan("orman mühendisi"),                                
                //29
                new Unvan("peyzaj mimarı"),                                
                //30
                new Unvan("su ürünleri mühendisi"),
                //31
                new Unvan("şef"),
                //32
                new Unvan("şehir plancısı"),
                //33
                new Unvan("şube müdürü"),
                //34
                new Unvan("tekniker"),
                //35
                new Unvan("teknisyen"),                                
                //36
                new Unvan("veri hazırlama ve kontrol işletmeni"),
                //37
                new Unvan("veteriner hekim"),
                //38
                new Unvan("ziraat mühendisi"),
            };

                fonksiyonelSiniflandirmaListesi.ForEach(s => baglam.Unvanlar.Add(s));
                baglam.SaveChanges();

                #endregion

                #region görevi

                var gorevListe = new List<Gorevi>
                {                   
                    //1
                    new Gorevi("apk uzmanı"),                                                           
                    //2
                    new Gorevi("araştırmacı"),                     
                    //3
                    new Gorevi("arkeolog"),
                    //4
                    new Gorevi("bakanlık döner sermaye müdürü"),
                    //5
                    new Gorevi("bakanlık müşaviri"),
                    //6
                    new Gorevi("basın ve halkla ilişkiler müşaviri"),
                    //7
                    new Gorevi("bilgisayar işletmeni","bilgisayar iş."),
                    //8
                    new Gorevi("biyolog"),
                    //9
                    new Gorevi("bölge müdürü",true),                                
                    //10
                    new Gorevi("büro memuru"),                                
                    //11
                    new Gorevi("çevre mühendisi"),                    
                    //12
                    new Gorevi("daire başkanı",true),
                    //13
                    new Gorevi("evrak memuru"),                                
                    //14
                    new Gorevi("genel müdür",true),
                    //15
                    new Gorevi("genel müdür yardımcısı","genel müdür yard.",true),                                
                    //16
                    new Gorevi("harita mühendisi"),
                    //17
                    new Gorevi("hukuk müşaviri"),
                    //18
                    new Gorevi("inşaat mühendisi"),
                    //19
                    new Gorevi("istatistikçi"),
                    //20
                    new Gorevi("jeodezi mühendisi"),                                
                    //21
                    new Gorevi("jeofizik mühendisi"),                                
                    //22
                    new Gorevi("jeoloji mühendisi"),                                
                    //23
                    new Gorevi("kat görevlisi"),
                    //24
                    new Gorevi("kimya mühendisi"),
                    //25
                    new Gorevi("makam odacısı"),
                    //26
                    new Gorevi("makine mühendisi"),
                    //27
                    new Gorevi("memur"),
                    //28
                    new Gorevi("mimar"),                                
                    //29
                    new Gorevi("tarım ve orman uzman yardımcısı","tarım ve orman uzm. yrd."),
                    //30
                    new Gorevi("tarım ve orman uzmanı"),
                    //31
                    new Gorevi("orman endüstri mühendisi","orm. end. mühendisi"),
                    //32
                    new Gorevi("orman mühendisi"),
                    //33
                    new Gorevi("peyzaj mimarı"),
                    //34
                    new Gorevi("satınalma memuru"),
                    //35
                    new Gorevi("sekreter"),
                    //36
                    new Gorevi("su ürünleri mühendisi","su ürünleri müh."),
                    //37
                    new Gorevi("şehir plancısı"),
                    //38
                    new Gorevi("şoför"),
                    //39
                    new Gorevi("şube müdürü"),                                
                    //40
                    new Gorevi("taşınır kayıt ve kontrol yetkilisi","taş.kay.ve kont.yet."),                                
                    //41
                    new Gorevi("tekniker"),
                    //42
                    new Gorevi("teknisyen"),                                
                    //43
                    new Gorevi("veri hazırlama kontrol işletmeni","ver. haz. kont. işl."),
                    //44
                    new Gorevi("veteriner hekim"),
                    //45
                    new Gorevi("ziraat mühendisi"),

                };
                
                gorevListe.ForEach(s => baglam.Gorevler.Add(s));
                baglam.SaveChanges();

                #endregion

                #region üniversiteler

                //List<Universite> liste = this.okuUniversiteListe();

                //liste.ForEach(s => baglam.UniversiteListe.Add(s));
                //baglam.SaveChanges();

                #endregion

                #region öğrenim durumu


                var ogrenimDurumuListe = new List<OgrenimDurumu>
            {                   
                //1
                new OgrenimDurumu("açık öğretim",EgitimDuzeyi.Lisans),
                //2
                new OgrenimDurumu("arkeolog",EgitimDuzeyi.Lisans),
                //3
                new OgrenimDurumu("bilgisayar mühendisi",EgitimDuzeyi.Lisans),
                //4
                new OgrenimDurumu("biyoloji",EgitimDuzeyi.Lisans),
                //5
                new OgrenimDurumu("biyoloji",EgitimDuzeyi.YuksekLisans),
                //6
                new OgrenimDurumu("büro yönetimi",EgitimDuzeyi.YuksekOkul),
                //7
                new OgrenimDurumu("çevre mühendisi",EgitimDuzeyi.Lisans),
                //8           
                new OgrenimDurumu("fransız dili edebiyatı",EgitimDuzeyi.Lisans),
                //9
                new OgrenimDurumu("halkla ilişkiler",EgitimDuzeyi.YuksekOkul),
                //10
                new OgrenimDurumu("harita mühendisi",EgitimDuzeyi.Lisans),
                //11
                new OgrenimDurumu("hidrojeoloji mühendisi",EgitimDuzeyi.Lisans),
                //12
                new OgrenimDurumu("hukuk fakültesi",EgitimDuzeyi.Lisans),               
                //13
                new OgrenimDurumu("iktisat fakültesi",EgitimDuzeyi.Lisans),
                //14
                new OgrenimDurumu("iletişim fakültesi",EgitimDuzeyi.Lisans),
                //15
                new OgrenimDurumu("ilkokul",EgitimDuzeyi.Ilkokul),
                //16
                new OgrenimDurumu("ilköğretim",EgitimDuzeyi.Ortaokul),
                //17 
                new OgrenimDurumu("insan kaynakları",EgitimDuzeyi.YuksekOkul),
                //18
                new OgrenimDurumu("insan kaynakları",EgitimDuzeyi.Lisans),
                //19
                new OgrenimDurumu("inşaat mühendisi",EgitimDuzeyi.Lisans),
                //20
                new OgrenimDurumu("istatistikçi",EgitimDuzeyi.Lisans),      
                //21
                new OgrenimDurumu("iş idaresi",EgitimDuzeyi.YuksekOkul),
                //22
                new OgrenimDurumu("işletme",EgitimDuzeyi.Lisans),
                //23
                new OgrenimDurumu("jeodezi mühendisi",EgitimDuzeyi.Lisans),
                //24
                new OgrenimDurumu("jeofizik mühendisi",EgitimDuzeyi.Lisans),
                //25
                new OgrenimDurumu("jeoloji mühendisi",EgitimDuzeyi.Lisans),
                //26
                new OgrenimDurumu("kamu yönetimi",EgitimDuzeyi.YuksekOkul),
                //27
                new OgrenimDurumu("kimya mühendisi",EgitimDuzeyi.Lisans),
                //28
                new OgrenimDurumu("lise",EgitimDuzeyi.Lise),
                //29
                new OgrenimDurumu("maden mühendisi",EgitimDuzeyi.Lisans),
                //30
                new OgrenimDurumu("makine mühendisi",EgitimDuzeyi.Lisans),
                //31
                new OgrenimDurumu("maliye",EgitimDuzeyi.Lisans),
                //32
                new OgrenimDurumu("meslek yüksekokulu",EgitimDuzeyi.YuksekOkul),
                //33
                new OgrenimDurumu("mimar",EgitimDuzeyi.Lise),
                //34
                new OgrenimDurumu("muhasebe",EgitimDuzeyi.YuksekOkul),
                //35
                new OgrenimDurumu("orman endüstri mühendisi",EgitimDuzeyi.Lisans),
                //36
                new OgrenimDurumu("orman mühendisi",EgitimDuzeyi.Lisans),
                //37
                new OgrenimDurumu("ortaokul",EgitimDuzeyi.Ortaokul),
                //38
                new OgrenimDurumu("peyzaj mimarı",EgitimDuzeyi.Lisans),
                //39
                new OgrenimDurumu("su ürünleri mühendisi",EgitimDuzeyi.Lisans),   
                //40
                new OgrenimDurumu("şehir plancısı",EgitimDuzeyi.Lisans),   
                //41
                new OgrenimDurumu("teknik programcı",EgitimDuzeyi.YuksekOkul),   
                //42
                new OgrenimDurumu("turizm yüksek okulu",EgitimDuzeyi.YuksekOkul),   
                //43
                new OgrenimDurumu("türk dili ve edebiyatı",EgitimDuzeyi.Lisans),
                //44
                new OgrenimDurumu("veteriner hekim",EgitimDuzeyi.Lisans),
                //45
                new OgrenimDurumu("ziraat mühendisi",EgitimDuzeyi.Lisans),

            };

                ogrenimDurumuListe.ForEach(s => baglam.OgrenimDurumlari.Add(s));
                baglam.SaveChanges();

                #endregion

                #region çalışan

                var calisanListe = new List<Calisan>
                {                   
                    //1
                    new Calisan("Osman", "DEMİREL", Cinsiyeti.Erkek, AkademikUnvani.Bos, KanGrubu.A, RhDegeri.Arti , MedeniDurumu.Tanimsiz, "18340798976",Arac.CevirTarihe("28.08.1967"), "5098", Kadrosu.Memur, Sinif.GenelIdareHizmetSinifi),
                    //2
                    new Calisan("Etem", "BOZ", Cinsiyeti.Erkek, AkademikUnvani.Bos, KanGrubu.B, RhDegeri.Arti , MedeniDurumu.Tanimsiz, "38998266900" , Arac.CevirTarihe("8.07.1968"), "5101", Kadrosu.Memur, Sinif.GenelIdareHizmetSinifi),
                    //3
                    new Calisan("Yusuf", "KANDAZOĞLU", Cinsiyeti.Erkek, AkademikUnvani.Bos , KanGrubu.A, RhDegeri.Arti , MedeniDurumu.Tanimsiz, "61468353848",Arac.CevirTarihe("20.12.1968"), "14199", Kadrosu.Memur, Sinif.GenelIdareHizmetSinifi),
                    //4
                    new Calisan("Hayrettin", "YILDIRIM", Cinsiyeti.Erkek, AkademikUnvani.Bos, KanGrubu.Sifir, RhDegeri.Arti , MedeniDurumu.Tanimsiz, "67600240410",Arac.CevirTarihe("10.02.1965"), "5504", Kadrosu.Memur, Sinif.GenelIdareHizmetSinifi),
                    //5
                    new Calisan("Didem", "OĞUZ", Cinsiyeti.Kadin, AkademikUnvani.Bos, KanGrubu.Sifir, RhDegeri.Arti , MedeniDurumu.Evli, "33568404362",Arac.CevirTarihe("24.07.1980"), "14404", Kadrosu.Memur, Sinif.GenelIdareHizmetSinifi),
                    //6
                    new Calisan("Mefa", "HARMAN", Cinsiyeti.Erkek, AkademikUnvani.Bos, KanGrubu.A, RhDegeri.Arti , MedeniDurumu.Evli, "10534315754",Arac.CevirTarihe("8.06.1964"), "13911", Kadrosu.Memur, Sinif.GenelIdareHizmetSinifi),
                   
                };

                foreach(Calisan calisan in calisanListe)
                {
                    if (calisan == null)
                        throw new ApplicationException();

                    calisan.Adi = Arac.KucultveKirp(calisan.Adi);
                    calisan.Soyadi = Arac.KucultveKirp(calisan.Soyadi);

                    baglam.Calisanlar.Add(calisan);
                    baglam.SaveChanges();

                }
                
                #endregion

                #region görevlendirme

                //CalisanGorevlendirme

                var gorevlendirmeListe = new List<CalisanGorevlendirme>
                {                   
                    //1
                    new CalisanGorevlendirme(1, 2, 1, 1, DateTime.Now),
                    //2
                    new CalisanGorevlendirme(2, 3, 2, 2, DateTime.Now),
                    //3
                    new CalisanGorevlendirme(3, 4, 3, 3, DateTime.Now),
                    //4
                    new CalisanGorevlendirme(4, 5, 4, 4, DateTime.Now),
                    //5
                    new CalisanGorevlendirme(5, 6, 5, 5, DateTime.Now),
                    //6
                    new CalisanGorevlendirme(6, 7, 6, 6, DateTime.Now),              

                };

                gorevlendirmeListe.ForEach(s => baglam.CalisanGorevlendirmeListe.Add(s));
                baglam.SaveChanges();


                #endregion

                #region kişi öğrenim

                Calisan osman = baglam.Calisanlar.First(p => p.Anahtar == 1);
                Calisan etem = baglam.Calisanlar.First(p => p.Anahtar == 2);
                Calisan yusuf = baglam.Calisanlar.First(p => p.Anahtar == 3);
                Calisan hayrettin = baglam.Calisanlar.First(p => p.Anahtar == 4);
                Calisan didem = baglam.Calisanlar.First(p => p.Anahtar == 5);
                Calisan mefa = baglam.Calisanlar.First(p => p.Anahtar == 6);             

                OgrenimDurumu orman = baglam.OgrenimDurumlari.First(p => p.Anahtar == 36);
                OgrenimDurumu iktisat = baglam.OgrenimDurumlari.First(p => p.Anahtar == 13);
                OgrenimDurumu isletme = baglam.OgrenimDurumlari.First(p => p.Anahtar == 23);                

                var kisiOgrenimListe = new List<KisiOgrenim>
                {                   
                    //1
                    new KisiOgrenim(osman,orman),
                    //2
                    new KisiOgrenim(etem,orman),
                    //3
                    new KisiOgrenim(yusuf,orman),
                    //4
                    new KisiOgrenim(hayrettin,orman),
                    //5
                    new KisiOgrenim(didem,isletme),
                    //6
                    new KisiOgrenim(mefa,iktisat),                  

                };

                kisiOgrenimListe.ForEach(s => baglam.KisiOgrenimListe.Add(s));
                baglam.SaveChanges();

                #endregion

                #region kişi iletişim
                
                var kisiIletisimListe = new List<KisiIletisim>
                {                   
                    //1
                    new KisiIletisim("12",IletisimTuru.Adres,1),
                    //2
                    new KisiIletisim("13",IletisimTuru.BakanlikEposta,2),
                    //3
                    new KisiIletisim("14",IletisimTuru.CepTelefonu,3),
                    //4
                    new KisiIletisim("15",IletisimTuru.Dahili,4),
                    //5
                    new KisiIletisim("16",IletisimTuru.EvTelefonu,5),
                    //6
                    new KisiIletisim("17",IletisimTuru.NormalEPosta,6),
                    //7
                    new KisiIletisim("18",IletisimTuru.Adres,7),
                    //8           
                    new KisiIletisim("19",IletisimTuru.BakanlikEposta,8),
                    //9
                    new KisiIletisim("20",IletisimTuru.CepTelefonu,9),
                    //10
                    new KisiIletisim("21",IletisimTuru.Dahili,10),

                };

                kisiIletisimListe.ForEach(s => baglam.KisiIletisimler.Add(s));
                baglam.SaveChanges();

                #endregion
            }
            catch (ArgumentNullException hata)
            {
                this.yazHata(hata);
            }
            catch (Exception hata)
            {
                this.yazHata(hata);
            }
        }

        private bool ekleCalisan(KisiUygulamasiBaglam repository,AkademikUnvani unvani, string adi, string soyadi, DateTime dogumTarihi, Cinsiyeti cinsiyeti, string turCumKimlikNo, KanGrubu kaninGrubu, RhDegeri rhDeger, string sicilNo, Kadrosu kadroDurumu, Sinif sinifi, string dahili, string bakanlikEposta,string cepTelefonu)
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

                HataIsKurali iskurali = new HataIsKurali();
                iskurali.YazHata(hata);

            }
            catch (Exception hata)
            {

                HataIsKurali iskurali = new HataIsKurali();
                iskurali.YazHata(hata);

            }

            return false;

        }
        
        private List<Universite> okuUniversiteListe()
        {
            string connetionString = null;
            SqlConnection cnn = null;
            SqlCommand cmd = null;
            List<Universite> universiteListe = new List<Universite>();
            int id = int.MinValue;
            string adi = null;
            Universite universite = null;

            connetionString = "Data Source=DESKTOP-JP3T3G6;Initial Catalog=DKMPKisi;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cnn = new SqlConnection(connetionString);

            cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Customers";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            try
            {
                cnn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Check is the reader has any rows at all before starting to read.
                    if (reader.HasRows)
                    {
                        // Read advances to the next row.
                        while (reader.Read())
                        {

                            // To avoid unexpected bugs access columns by name.
                            id = reader.GetInt32(reader.GetOrdinal("id"));
                            adi = reader.GetString(reader.GetOrdinal("name"));

                            universite = new Universite(id, adi);
                            universiteListe.Add(universite);
                        }

                    }

                }


                cnn.Close();

                return universiteListe;
            }
            catch (Exception)
            {        
                    
            }

            return new List<Universite>();

        }
        

    }

}
