using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DKMPKisiUygulamasi.Model.SabitlerMesajlar
{
    public class Sabitler
    {

        public static SelectListItem SecinizSelectListItem
        {
            get
            {
                SelectListItem nesne = new SelectListItem();
                nesne.Selected = true;                
                nesne.Text = "Seçiniz";
                nesne.Value = "-9";
                return nesne;
            }

        }     

        public static int GunSayisiBirYildaki
        {
            get
            {
                return 364;
            }
        }

        public static int HataliArgumanKodu
        {
            get
            {
                return int.MinValue +2;
            }
        }

        public static int IsKuraliHatasiKodu
        {
            get
            {
                return int.MinValue + 3;
            }
        }

        public static int Bir
        {
            get
            {
                return 1;
            }
        }

        public static decimal BosDecimal
        {
            get
            {
                return -9999999999.999M;
            }
        }     

        public static DateTime BosTarih
        {
            get
            {
                return new DateTime(1800, 1, 1);
            }
        }

        public static CultureInfo TurkKulturu
        {
            get
            {
                CultureInfo TurkKulturu = new CultureInfo("tr-TR", false);

                return TurkKulturu;
            }
        }

        public static string BosTurkiyeCumhuriyetiKimlikNo
        {
            get
            {
                return "00000000000";
            }
        }

        public static int UygulamaId
        {
            get
            {
                return 104;
            }
        }

        public static string UygulamaKodu
        {
            get
            {
                return "DKMP-KIS";
            }
        }

        public static string HataServisBaglantiCumlesi
        {
            get
            {
                return @"Data Source=DESKTOP-JP3T3G6;Initial Catalog=DKMPHata;Integrated Security=True;";
            }
        }

        public const string KurumCografyaServisBaglantiCumlesi = @"Data Source=DESKTOP-JP3T3G6;Initial Catalog=DkmpKurumCografya;Integrated Security=True;";

        public const int KisiIletisimDiziUzunlugu = 3;

    }
}
