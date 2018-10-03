using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.Somut.OgrenimKlasor
{
    public class Universite
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Anahtar { get; set; }

        [Required]
        [StringLength(150)]
        public string Adi { get; set; }

        private Universite()
        {
            this.Anahtar = int.MinValue;
            this.Adi = null;
        }

        public Universite(int anahtar, string adi):this()
        {
            this.Adi = adi;
            this.Anahtar = anahtar;
        }

    }
}
