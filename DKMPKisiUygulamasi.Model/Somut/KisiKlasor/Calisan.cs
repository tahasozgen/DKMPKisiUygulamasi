using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.SabitlerMesajlar;
using DKMPKisiUygulamasi.Model.Somut.TanimlayiciKlasor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.Somut.KisiKlasor
{
    public class Calisan : Kisi
    {
        [StringLength(15)]
        public string SicilNo { get; set; }

        [Required]
        public Kadrosu KadroDurumu { get; set; }

        [Required]
        public Sinif Sinifi { get; set; }

        [Required]
        public CalismaDurumu EsCalismaDurumu { get; set; }

        private Calisan() : base()        
        {
            this.SicilNo = string.Empty;
            this.KadroDurumu = Kadrosu.Tanimsiz;
            this.Sinifi = Sinif.Tanimsiz;
            this.EsCalismaDurumu = CalismaDurumu.Tanimsiz;
        }

        public Calisan(int anahtar) : this()
        {
            this.Anahtar = anahtar;
        }
        public Calisan(string adi, string soyadi) : this()
        {
            this.Adi = adi;
            this.Soyadi = soyadi;         
        }

        public Calisan(string adi, string soyadi,Cinsiyeti cinsiyeti) : this(adi, soyadi)
        {
            this.Cinsi = cinsiyeti;        
        }

        public Calisan(string adi, string soyadi, Cinsiyeti cinsiyeti,AkademikUnvani unvani) : this(adi, soyadi, cinsiyeti)
        {
            this.Unvani = unvani;

        }

        public Calisan(string adi, string soyadi, Cinsiyeti cinsiyeti, AkademikUnvani unvani, KanGrubu kaninGrubu, RhDegeri phDeger, MedeniDurumu medeniHali, string turCumKimlikNo, DateTime dogumTarihi, string sicilNo, Kadrosu kadroDurumu, Sinif sinifi) : this(adi, soyadi, cinsiyeti)
        {
            this.Unvani = unvani;
            this.KaninGrubu = kaninGrubu;
            this.RhDeger = phDeger;
            this.MedeniHali = medeniHali;
            this.TurCumKimlikNo = turCumKimlikNo;
            this.DogumTarihi = dogumTarihi;
            this.SicilNo = sicilNo;
            this.KadroDurumu = kadroDurumu;
            this.Sinifi = sinifi;
        }

        public Calisan(string adi, string soyadi, Cinsiyeti cinsiyeti, AkademikUnvani unvani, KanGrubu kaninGrubu, RhDegeri phDeger, MedeniDurumu medeniHali, string turCumKimlikNo, DateTime dogumTarihi, string sicilNo, Kadrosu kadroDurumu, Sinif sinifi,string ibanNo, byte[] vesikalik) : this( adi,  soyadi,  cinsiyeti,  unvani,  kaninGrubu,  phDeger,  medeniHali,  turCumKimlikNo,  dogumTarihi,  sicilNo,  kadroDurumu,  sinifi)
        {
            this.IbanNo = ibanNo;
            this.Vesikalik = vesikalik;
        }

    }
}
