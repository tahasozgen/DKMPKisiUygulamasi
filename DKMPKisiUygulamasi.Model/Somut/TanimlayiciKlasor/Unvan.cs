using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.Somut.TanimlayiciKlasor
{
    public class Unvan
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Anahtar { get; set; }

        [Required]
        [StringLength(150)]
        public string Adi { get; set; }

        protected Unvan()
        {
            this.Adi = null;
            this.Anahtar = int.MinValue;
        }

        public Unvan(int anahtar):this()
        {
            this.Anahtar = anahtar;
        }

        public Unvan(string adi) : this()
        {
            this.Adi = adi;
        }

        public Unvan(int anahtar,string adi):this(anahtar)
        {
            this.Adi = adi;            
        }


    }
}
