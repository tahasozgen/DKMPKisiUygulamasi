using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.Somut.GorevKlasoru
{
    public class Gorevi
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Anahtar { get; set; }

        [Required]
        [StringLength(150)]
        public string Adi { get; set; }

        [Required]
        public bool YoneticiMi { get; set; }
        
        [StringLength(25)]
        public string KisaAdi { get; set; }

        protected Gorevi()
        {
            this.Anahtar = int.MinValue;
            this.Adi = null;
            this.YoneticiMi = false;
            this.KisaAdi = null;
        }

        public Gorevi(int anahtar):this()
        {
            this.Anahtar = anahtar;            
        }

        public Gorevi(string adi) : this()
        {
            this.Adi = adi;
        }

        public Gorevi(string adi,bool yoneticiMi) : this(adi)
        {
            this.YoneticiMi = yoneticiMi;
        }

        public Gorevi(string adi, string kisaAdi) : this(adi)
        {
            this.KisaAdi = kisaAdi;
        }

        public Gorevi(string adi, string kisaAdi,bool yoneticiMi) : this(adi, kisaAdi)
        {
            this.YoneticiMi = yoneticiMi;
        }

        public Gorevi(int anahtar,string adi) : this(anahtar)
        {
            this.Adi = adi;
        }

        public Gorevi(int anahtar, string adi,bool yoneticiMi) : this(anahtar, adi)
        {
            this.YoneticiMi = yoneticiMi;
        }

    

    }
}
