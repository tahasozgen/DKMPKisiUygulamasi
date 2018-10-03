using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.IsKatmani.Somut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.Somut.SorguKlasor
{
    class SorguAnaliz
    {
        private List<Ozdeyis> _ozdeyisListe = new List<Ozdeyis>();
        
        public SorguAnaliz()
        {
            this._ozdeyisListe = this.doldurOzdeyis();
        }

        private List<Ozdeyis> doldurOzdeyis()
        {
            List<Ozdeyis> ozdeyisListe = new List<Ozdeyis>();

            ozdeyisListe.Add(new Ozdeyis("prof",SorguNitelik.Akademik));
            ozdeyisListe.Add(new Ozdeyis("dr", SorguNitelik.Akademik));
            ozdeyisListe.Add(new Ozdeyis("doktor", SorguNitelik.Akademik));
            ozdeyisListe.Add(new Ozdeyis("yüksek mühendis", SorguNitelik.Akademik));
            ozdeyisListe.Add(new Ozdeyis("doçent", SorguNitelik.Akademik));
            ozdeyisListe.Add(new Ozdeyis("doç.dr", SorguNitelik.Akademik));

            ozdeyisListe.Add(new Ozdeyis("erkek", SorguNitelik.Cinsiyet));
            ozdeyisListe.Add(new Ozdeyis("kadın", SorguNitelik.Cinsiyet));
            ozdeyisListe.Add(new Ozdeyis("bayan", SorguNitelik.Cinsiyet));
            ozdeyisListe.Add(new Ozdeyis("bay", SorguNitelik.Cinsiyet));
            ozdeyisListe.Add(new Ozdeyis("eril", SorguNitelik.Cinsiyet));
            ozdeyisListe.Add(new Ozdeyis("dişi", SorguNitelik.Cinsiyet));

            ozdeyisListe.Add(new Ozdeyis("a rh+", SorguNitelik.KanRh));
            ozdeyisListe.Add(new Ozdeyis("b rh+", SorguNitelik.KanRh));
            ozdeyisListe.Add(new Ozdeyis("o rh+", SorguNitelik.KanRh));
            ozdeyisListe.Add(new Ozdeyis("ab rh+", SorguNitelik.KanRh));
            ozdeyisListe.Add(new Ozdeyis("a rh-", SorguNitelik.KanRh));
            ozdeyisListe.Add(new Ozdeyis("b rh-", SorguNitelik.KanRh));
            ozdeyisListe.Add(new Ozdeyis("o rh-", SorguNitelik.KanRh));
            ozdeyisListe.Add(new Ozdeyis("ab rh-", SorguNitelik.KanRh));

            ozdeyisListe.Add(new Ozdeyis("evli", SorguNitelik.MedeniHali));
            ozdeyisListe.Add(new Ozdeyis("bekar", SorguNitelik.MedeniHali));
            ozdeyisListe.Add(new Ozdeyis("boşanmış", SorguNitelik.MedeniHali));

            ozdeyisListe.Add(new Ozdeyis("memur", SorguNitelik.Kadro));
            ozdeyisListe.Add(new Ozdeyis("işçi", SorguNitelik.Kadro));

            ozdeyisListe.Add(new Ozdeyis("teknik hizmet", SorguNitelik.Sinif));
            ozdeyisListe.Add(new Ozdeyis("teknik hizmetler", SorguNitelik.Sinif));
            ozdeyisListe.Add(new Ozdeyis("genel idare", SorguNitelik.Sinif));
            ozdeyisListe.Add(new Ozdeyis("genel idare hizmet", SorguNitelik.Sinif));
                        
            return ozdeyisListe;
        }

        internal bool nitelikteMiSorgu(string sorguSozcesi, SorguNitelik nitelik)
        {
            try
            {
                if (!String.IsNullOrEmpty(sorguSozcesi))
                {
                    sorguSozcesi = Arac.KucultveKirp(sorguSozcesi);

                    if (Arac.TurkiyeCumhuriyetiKimlikNoMu(sorguSozcesi))
                        return nitelik == SorguNitelik.TurkiyeCumhuriyetiKimlikNo;

                    if (this.tarihMiSorgu(sorguSozcesi))
                        return nitelik == SorguNitelik.DogumTarihi;

                    if (this.sicilMiSorgu(sorguSozcesi))
                        return nitelik == SorguNitelik.SicilNo;

                    if(this.varMiSayiSozcede(sorguSozcesi)) //ad soyad kızlık soyadı olamaz.                    
                        return nitelik == SorguNitelik.Adi || nitelik == SorguNitelik.Soyadi || nitelik == SorguNitelik.KizlikSoyadi;
                    
                    Ozdeyis deyis = this._ozdeyisListe.FirstOrDefault(p => p.Sozce.Equals(sorguSozcesi));

                    if (deyis == null)
                    {
                        this._ozdeyisListe.Add(new Ozdeyis(sorguSozcesi, SorguNitelik.YeniGelen));
                        //TODO: veritabanına yazılacak
                        return false;
                    }
                    else
                    {
                        if (nitelik == SorguNitelik.Adi || nitelik == SorguNitelik.Soyadi)
                            return deyis.Nitelik == nitelik || deyis.Nitelik == SorguNitelik.YeniGelen;
                        else
                            return deyis.Nitelik == nitelik;
                    }
                        

                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal AkademikUnvani getirAkademikUnvani(string sorguSozcesi)
        {

            AkademikUnvani unvani = AkademikUnvani.Tanimsiz;

            if(this.nitelikteMiSorgu(sorguSozcesi,SorguNitelik.Akademik))
            {
                sorguSozcesi = Arac.KucultveKirp(sorguSozcesi);


                if (sorguSozcesi.StartsWith("dr") || sorguSozcesi.StartsWith("doktor"))
                    unvani = AkademikUnvani.Doktor;
                else if (sorguSozcesi.StartsWith("yüksek mühendis"))
                    unvani = AkademikUnvani.YuksekMuhendis;
                else if (sorguSozcesi.StartsWith("doçent") || sorguSozcesi.StartsWith("doç.dr"))
                    unvani = AkademikUnvani.Docent;
                else if (sorguSozcesi.StartsWith("prof"))
                    unvani = AkademikUnvani.Profesor;
            }

            return unvani;
        }      

        internal Cinsiyeti getirCinsiyeti(string sorguSozcesi)
        {
            Cinsiyeti unvani = Cinsiyeti.Tanimsiz;

            if (this.nitelikteMiSorgu(sorguSozcesi,SorguNitelik.Cinsiyet))
            {
                sorguSozcesi = Arac.KucultveKirp(sorguSozcesi);
                
                if (sorguSozcesi.StartsWith("erkek") || sorguSozcesi.StartsWith("bay") || sorguSozcesi.StartsWith("eril"))
                    unvani = Cinsiyeti.Erkek;
                else if (sorguSozcesi.StartsWith("kadın") || sorguSozcesi.StartsWith("bayan") || sorguSozcesi.StartsWith("dişi"))
                    unvani = Cinsiyeti.Kadin;             
            }

            return unvani;
        }              
        
        private bool tarihMiSorgu(string sorguSozcesi)
        {
            try
            {
                sorguSozcesi = Arac.KucultveKirp(sorguSozcesi);
                DateTime tarih = Convert.ToDateTime(sorguSozcesi);
            }
            catch (Exception)
            {
                return false;
            }

            return true;

        }

        private bool sicilMiSorgu(string sorguSozcesi)
        {
            try
            {
                sorguSozcesi = Arac.KucultveKirp(sorguSozcesi);
                int sonuc = Convert.ToInt32(sorguSozcesi);
            }
            catch (Exception)
            {
                return false;
            }

            return true;

        }

        private bool varMiSayiSozcede(string sorguSozcesi)
        {
            return sorguSozcesi.Any(char.IsDigit);
        }

    }
}
