using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.SabitlerMesajlar;
using DKMPKisiUygulamasi.Model.Somut.TanimlayiciKlasor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.Somut.KisiKlasor
{
    public class Kisi
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Anahtar { get; set; }

        [Required]
        public AkademikUnvani Unvani { get; set; }

        [Required]
        [StringLength(100)]
        public string Adi { get; set; }

        [StringLength(200)]
        public string KizlikSoyadi { get; set; }

        [Required]
        [StringLength(200)]
        public string Soyadi { get; set; }

        [Required]
        public Cinsiyeti Cinsi { get; set; }

        public KanGrubu KaninGrubu { get; set; }

        public RhDegeri RhDeger { get; set; }
                
        public MedeniDurumu MedeniHali { get; set; }
                
        [StringLength(11)]
        public string TurCumKimlikNo { get; set; }
                
        public DateTime DogumTarihi { get; set; }

        [StringLength(11)]
        public string IbanNo { get; set; }

        public byte[] Vesikalik { get; set; }
        
        protected Kisi()
        {
            this.Adi = string.Empty;
            this.Anahtar = int.MinValue;
            this.Cinsi = Cinsiyeti.Tanimsiz;
            this.DogumTarihi = Sabitler.BosTarih;
            this.IbanNo = string.Empty;
            this.KaninGrubu = KanGrubu.Tanimsiz;
            this.KizlikSoyadi = string.Empty;
            this.MedeniHali = MedeniDurumu.Tanimsiz;
            this.RhDeger = RhDegeri.Tanimsiz;
            this.Soyadi = string.Empty;
            this.TurCumKimlikNo = Sabitler.BosTurkiyeCumhuriyetiKimlikNo;
            this.Unvani = AkademikUnvani.Bos;
            this.Vesikalik = null;            
        }

        public Kisi(int anahtar) : this()
        {
            this.Anahtar = anahtar;
          
        }

        public Kisi(string adi, string soyadi) : this()
        {
            this.Adi = adi;
            this.Soyadi = soyadi;
        }

    }
}
