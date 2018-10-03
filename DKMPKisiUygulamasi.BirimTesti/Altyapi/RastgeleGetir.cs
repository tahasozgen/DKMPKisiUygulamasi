using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;
using DKMPKisiUygulamasi.Model.Somut.IletisimKlasor;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using DKMPKisiUygulamasi.Model.Somut.OgrenimKlasor;
using DKMPKisiUygulamasi.Model.Somut.RaporKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.BirimTesti.Altyapi
{
    public class RastgeleGetir
    {
        private static Random _rnd = new Random();
        private static readonly object syncLock = new object();

        public static int GetirRastgeleIlId()
        {
            lock (syncLock)
            {
                int index = _rnd.Next(0, 2);
                int[] illerId = new int[3] { 4, 5, 6 };

                return illerId[index];
            }          
        }
           
        public static DateTime Tarih
        {
            get
            {
                lock (syncLock)
                {
                    int yil = Yil1990Oncesi;
                    int ay = _rnd.Next(1, 12);
                    int gun = _rnd.Next(1, 27);
                    return new DateTime(yil, ay, gun);
                }

            }

        }

        public static DateTime GetirTarih(int baslangicYili, int bitisYili)
        {
            lock (syncLock)
            {
                int yil = _rnd.Next(baslangicYili, bitisYili);
                int ay = _rnd.Next(1, 12);
                int gun = _rnd.Next(1, 27);
                return new DateTime(yil, ay, gun);
            }

        }

        public static int Sayi
        {
            get
            {
                lock (syncLock)
                {
                    return _rnd.Next();
                }

            }

        }      
        
        public static int GetirSayi(int asgari, int azami)
        {
            lock (syncLock)
            {
                return _rnd.Next(asgari, azami);
            }

        }

        public static int Yil1990Oncesi
        {
            get
            {
                lock (syncLock)
                {
                    int baslangicYili = 1800;
                    int bitisYili = 1990;
                    return _rnd.Next(baslangicYili, bitisYili);
                }

            }

        }

        public static string GetirRastgeleSozce(string onSozce)
        {
            int i = Sayi;
            return new StringBuilder(onSozce + i.ToString()).ToString();
        }  

        public static string Sozce
        {
            get
            {
                return RastgeleGetir.Sayi.ToString();
            }
        }
        
        public static EgitimDuzeyi EgitiminDuzeyi
        {
            get
            {
                lock (syncLock)
                {
                    int[] dizi = new int[9] { 3, 10, 17, 24, 31, 38, 45, 52, 59 };
                    int index = _rnd.Next(0, 8); ;
                    return (EgitimDuzeyi)dizi[index];
                }
            }
        }

        public static IletisimTuru IletisiminTuru
        {
            get
            {
                lock (syncLock)
                {
                    int[] dizi = new int[6] { 3, 10, 17, 24, 31, 38 };
                    int index = _rnd.Next(0, 5); ;
                    return (IletisimTuru)dizi[index];
                }
            }
        }

        public static CalisanGorevlendirme CalisanGorevlendirmesi
        {
            get
            {
                int calisanId = Sayi;
                int birimId = Sayi;
                int gorevId = Sayi;
                int unvanId = Sayi;
                DateTime baslangic = Tarih;
                bool asilMi = false;
                string aciklama = Sozce;
                bool resmiMi = false;
                int anahtar = Sayi;

                CalisanGorevlendirme calisma = new CalisanGorevlendirme(calisanId,birimId,gorevId,unvanId,baslangic,asilMi, aciklama,resmiMi);
                calisma.Anahtar = anahtar;

                return calisma;

            }
        }

        public static Calisan Calisani
        {
            get
            {
                string adi = Sozce;
                string soyadi = Sozce;
                Cinsiyeti cinsiyeti = Cinsiyeti.Erkek;
                AkademikUnvani unvani = AkademikUnvani.Docent;
                KanGrubu kaninGrubu = KanGrubu.AB;
                RhDegeri phDeger = RhDegeri.Arti;
                MedeniDurumu medeniHali = MedeniDurumu.Evli;
                string turCumKimlikNo = Sozce;
                DateTime dogumTarihi = Tarih;
                string sicilNo = Sozce;
                Kadrosu kadroDurumu = Kadrosu.DaimiIsci;
                Sinif sinifi = Sinif.GenelIdareHizmetSinifi;
                string ibanNo = Sozce;
                byte[] vesikalik = null;

                int anahtar = Sayi;
                Calisan calisan = new Calisan(adi, soyadi, cinsiyeti, unvani, kaninGrubu , phDeger, medeniHali, turCumKimlikNo, dogumTarihi, sicilNo, kadroDurumu, sinifi,ibanNo,vesikalik);
                calisan.Anahtar = anahtar;

                return calisan;

            }
        }

        public static OgrenimDurumu OgreniminDurumu
        {
            get
            {
                return new OgrenimDurumu(Sozce, EgitiminDuzeyi);
            }
        }

        public static KisiOgrenim Ogrenim
        {
            get
            {                
                return new KisiOgrenim(Calisani, OgreniminDurumu);
            }
        }

        public static KisiIletisim KisiIletisimi
        {
            get
            {
                return new KisiIletisim(Sozce, IletisiminTuru,Sayi);                
            }
        }

        public static CalisanOzet CalisanOzeti
        {
            get
            {
                return new CalisanOzet(CalisanGorevlendirmesi, Ogrenim, KisiIletisimi, KisiIletisimi, KisiIletisimi);
            }
        }

    }
}
