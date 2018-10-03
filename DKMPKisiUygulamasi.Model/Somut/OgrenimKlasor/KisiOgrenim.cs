using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.SabitlerMesajlar;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.Somut.OgrenimKlasor
{
    public class KisiOgrenim
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Anahtar { get; set; }

        public int? CalisanId { get; set; }

        [Required]
        [ForeignKey("CalisanId")]
        public virtual Calisan Calisani { get; set; }

        public int? OgrenimDurumuId { get; set; }

        [Required]
        [ForeignKey("OgrenimDurumuId")]
        public virtual OgrenimDurumu OgrenimDurumu { get; set; }
    
        public int? UniversiteId { get; set; }
        
        [ForeignKey("UniversiteId")]
        public virtual Universite Universitesi { get; set; }

        [Required]
        public DateTime EklenmeTarihi { get; set; }

        private KisiOgrenim()
        {
            this.Anahtar = int.MinValue;
            this.Calisani = null;
            this.CalisanId = null;
            this.OgrenimDurumu = null;
            this.OgrenimDurumuId = null;
            this.UniversiteId = null;
            this.Universitesi = null;
            this.EklenmeTarihi = Sabitler.BosTarih;
        }

        public KisiOgrenim(Calisan calisani, OgrenimDurumu ogrenimDurumu) :this()
        {
            if (calisani == null)
                throw new ArgumentNullException();

            if(ogrenimDurumu == null)
                throw new ArgumentNullException();
            
            this.Calisani = calisani;
            this.CalisanId = calisani.Anahtar;

            this.OgrenimDurumu = ogrenimDurumu;
            this.OgrenimDurumuId = ogrenimDurumu.Anahtar;

            this.EklenmeTarihi = DateTime.Now;
        }
        
        public KisiOgrenim(int calisanId, int ogrenimDurumuId) : this()
        {
            if (calisanId == int.MinValue)
                throw new ArgumentException();

            if (ogrenimDurumuId == int.MinValue)
                throw new ArgumentException();

            this.CalisanId = calisanId;
            this.OgrenimDurumuId = ogrenimDurumuId;
            this.EklenmeTarihi = DateTime.Now;
        }

        public KisiOgrenim(Calisan calisani, OgrenimDurumu ogrenimi, Universite universitesi) : this(calisani, ogrenimi)
        {

            if(universitesi != null)
            {
                this.UniversiteId = universitesi.Anahtar;
                this.Universitesi = universitesi;
            }

        }

        public KisiOgrenim(int calisanId, int ogrenimDurumuId,int universiteId) : this(calisanId, ogrenimDurumuId)
        {
            if (universiteId != int.MinValue)
            {
                this.UniversiteId = universiteId;
            }
            
        }

    }
}
