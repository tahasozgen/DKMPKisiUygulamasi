using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.SabitlerMesajlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.IsKatmani.Somut
{
    public class Arac
    {

        public static string KucultveKirp(string sozce)
        {
            return (String.IsNullOrEmpty(sozce)) ? sozce : sozce.Trim().ToLower(Sabitler.TurkKulturu);
        }

        /// <summary>
        /// Verili sınıfın tam yolunu dönen yordam. 
        /// </summary>
        /// <typeparam name="T">Sınıf parametresi</typeparam>
        /// <returns></returns>
        public static string AlSinifYolu<T>()
        {
            Type typeOfAction = typeOfAction = typeof(T);

            StringBuilder sb = new StringBuilder(typeOfAction.Namespace + "." + typeOfAction.Name);

            return sb.ToString();
        }

        public static string AlHataLokasyonu<T>(int satirNo)
        {
            Type typeOfAction = typeOfAction = typeof(T);

            StringBuilder sb = new StringBuilder(typeOfAction.Namespace + "." + typeOfAction.Name + " satir no : " + satirNo);

            return sb.ToString();
        }

        public static bool TurkiyeCumhuriyetiKimlikNoMu(string tckimlikno)
        {
            bool returnvalue = false;
            if (tckimlikno.Length == 11)
            {
                Int64 atcno, btcno, tcno;
                long c1, c2, c3, c4, c5, c6, c7, c8, c9, q1, q2;
                tcno = Int64.Parse(tckimlikno);
                atcno = tcno / 100;
                btcno = tcno / 100;
                c1 = atcno % 10;
                atcno = atcno / 10;
                c2 = atcno % 10;
                atcno = atcno / 10;
                c3 = atcno % 10;
                atcno = atcno / 10;
                c4 = atcno % 10;
                atcno = atcno / 10;
                c5 = atcno % 10;
                atcno = atcno / 10;
                c6 = atcno % 10;
                atcno = atcno / 10;
                c7 = atcno % 10;
                atcno = atcno / 10;
                c8 = atcno % 10;
                atcno = atcno / 10;
                c9 = atcno % 10;
                atcno = atcno / 10;
                q1 = ((10 - ((((c1 + c3 + c5 + c7 + c9) * 3) + (c2 + c4 + c6 + c8)) % 10)) % 10);
                q2 = ((10 - (((((c2 + c4 + c6 + c8) + q1) * 3) + (c1 + c3 + c5 + c7 + c9)) % 10)) % 10);
                returnvalue = ((btcno * 100) + (q1 * 10) + q2 == tcno);
            }
            return returnvalue;
        }

        public static DateTime CevirTarihe(string sozce)
        {
            try
            {
                if (!String.IsNullOrEmpty(sozce))
                {
                    DateTime sonuc = Convert.ToDateTime(sozce);
                    return sonuc;
                }
            }
            catch (Exception)
            {

            }

            return Sabitler.BosTarih;
        }

        public static bool CevirBoola(string deger)
        {
            try
            {
                if (string.IsNullOrEmpty(deger))
                    throw new ArgumentNullException();

                return (deger.Equals(Sabitler.Bir.ToString())) ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string DescriptionAttr<T>(T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }

        public static string BuyutIlkHarfi(string input)
        {
            switch (input)
            {
                case null: return input;
                case "": return input;
                default: return input.First().ToString().ToUpper(Sabitler.TurkKulturu) + input.Substring(1);
            }
        }

        public static string GetirTarihSozce(DateTime? tarih)
        {
            DateTime bitisTarihi = tarih ?? DateTime.MinValue;

            return bitisTarihi != DateTime.MinValue ? bitisTarihi.ToShortDateString() : string.Empty;

        }

        public static string GetirKisaltma(Sinif sinifi)
        {
            string sonuc = string.Empty;

            if (sinifi == Sinif.GenelIdareHizmetSinifi)
                sonuc = "GIH";
            else if(sinifi == Sinif.TeknikHizmetler)
                sonuc = "TH";
            else if(sinifi == Sinif.Tanimsiz)
                sonuc = "Tanımsız";

            return sonuc;
        }

    }
}
