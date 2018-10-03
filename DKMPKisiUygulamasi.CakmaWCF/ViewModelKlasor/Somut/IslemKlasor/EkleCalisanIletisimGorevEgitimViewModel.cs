using DKMPKisiUygulamasi.CakmaWCF.Mesajlar.Soyut;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.IslemKlasor
{
    public class EkleCalisanIletisimGorevEgitimViewModel : IslemBaz
    {
        public int KullaniciId { get; set; }

        #region çalışan verileri
        public int? AkademikUnvaniId { get; set; }

        public string Adi { get; set; }

        public string KizlikSoyadi { get; set; }

        public string Soyadi { get; set; }

        public int? CinsId { get; set; }

        public int? KaninGrubuId { get; set; }

        public int? PhDegerId { get; set; }

        public int? MedeniHaliId { get; set; }

        public string TurCumKimlikNo { get; set; }

        public string DogumTarihi { get; set; }

        public string IbanNo { get; set; }

        public byte[] Vesikalik { get; set; }

        public string SicilNo { get; set; }

        public int? KadroDurumuId { get; set; }

        public int? SinifiId { get; set; }

        public int? EsCalismaDurumuId { get; set; }

        #endregion

        #region görevlendirme verileri
        public int? GorevId { get; set; }

        public int? UnvanId { get; set; }

        public int? BirimId { get; set; }

        public int? IlId { get; set; }

        public string Baslangic { get; set; }

        public bool? AsilMi { get; set; }

        public string Aciklama { get; set; }
  
        public bool? ResmiMi { get; set; }

        #endregion

        #region öğrenim durumu

        public int? OgrenimDurumuId { get; set; }

        public int? UniversiteId { get; set; }

        #endregion

        #region iletişim 

        public string Dahili { get; set; }
        
        public string CepTelefonu { get; set; }

        public string BakanlikEPosta { get; set; }

        #endregion

        #region listeler

        #endregion

    }
}
