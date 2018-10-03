using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.Somut.IzinKlasoru
{
    public class Izin
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Anahtar { get; set; }

        [Required]
        public IzinTuru IzninTuru { get; set; }

        [Required]
        public DateTime Baslangic { get; set; }
                
        public DateTime Bitis { get; set; }

        [Required]
        public bool OnaylandiMi { get; set; }

        public int? CalisanId { get; set; }

        [Required]
        [ForeignKey("CalisanId")]
        public virtual Calisan Calisani { get; set; }

        public Izin()
        {
            this.Anahtar = int.MinValue;
            this.IzninTuru = IzinTuru.Tanimsiz;
            this.Baslangic = SabitlerMesajlar.Sabitler.BosTarih;
            this.Bitis = SabitlerMesajlar.Sabitler.BosTarih;
            this.OnaylandiMi = false;
            this.CalisanId = null;
            this.Calisani = null;
        }

    }

}
