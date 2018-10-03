
using DKMPKisiUygulamasi.Model.EnumKlasoru;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DKMPKisiUygulamasi.Model.Somut.OgrenimKlasor
{
    public class OgrenimDurumu
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Anahtar { get; set; }

        [Required]
        [StringLength(150)]
        public string Adi { get; set; }

        [Required]
        public EgitimDuzeyi Duzeyi { get; set; }

        public OgrenimDurumu()
        {
            this.Anahtar = int.MinValue;
            this.Adi = string.Empty;
            this.Duzeyi = EgitimDuzeyi.Tanimsiz;
        }

        public OgrenimDurumu(int anahtar):this()
        {
            this.Anahtar = anahtar;
        }

        public OgrenimDurumu(string adi, EgitimDuzeyi duzeyi) : this()
        {
            this.Adi = adi;
            this.Duzeyi = duzeyi;
        }


    }
}
