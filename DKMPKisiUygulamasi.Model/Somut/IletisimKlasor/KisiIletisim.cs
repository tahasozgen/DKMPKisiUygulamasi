using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.SabitlerMesajlar;
using DKMPKisiUygulamasi.Model.Somut.HataKlasoru;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.Somut.IletisimKlasor
{
    public class KisiIletisim
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Anahtar { get; set; }

        public int? KisiId { get; set; }

        [Required]
        [ForeignKey("KisiId")]
        public virtual Kisi Kisisi{ get; set; }

        [Required]
        [StringLength(200)]
        public string Deger { get; set; }

        [Required]
        public IletisimTuru Turu { get; set; }

        [Required]
        public DateTime EklenmeTarihi { get; set; }

        public KisiIletisim()
        {
            this.Anahtar = int.MinValue;
            this.KisiId = null;
            this.Kisisi = null;
            this.Deger = null;
            this.Turu = IletisimTuru.Tanimsiz;
            this.EklenmeTarihi = Sabitler.BosTarih;
        }

        public KisiIletisim(int anahtar) : this()
        {
            this.Anahtar = anahtar;
        }

        private KisiIletisim(string deger, IletisimTuru turu) : this()
        {
          
            if (turu == IletisimTuru.Tanimsiz)
                throw new ArgumentException();
            if(String.IsNullOrEmpty(deger))
                throw new ArgumentNullException();

            this.Deger = deger;
            this.Turu = turu;
            this.EklenmeTarihi = DateTime.Now;
        }

        public KisiIletisim(string deger, IletisimTuru turu,Kisi kisisi) : this(deger, turu)
        {
            if (kisisi == null)
                throw new ArgumentNullException();

            this.KisiId = kisisi.Anahtar;
            this.Kisisi = kisisi;
        }

        public KisiIletisim(string deger, IletisimTuru turu, int kisiId) : this(deger, turu)
        {
            if (kisiId == int.MinValue)
                throw new ArgumentException();

            this.KisiId = kisiId;
        }

    }
}
