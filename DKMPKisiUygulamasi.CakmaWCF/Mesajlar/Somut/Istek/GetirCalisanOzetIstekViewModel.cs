
using DKMPKisiUygulamasi.CakmaWCF.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.Mesajlar.Somut.Istek
{
    public class GetirCalisanOzetIstekViewModel : IstekBazViewModel
    {
        public DateTime? Tarihi { get; set; }

        public string SorguSozcesi { get; set; }

        protected GetirCalisanOzetIstekViewModel() : base()
        {
            this.Tarihi = null;
            this.SorguSozcesi = string.Empty;
        }

        public GetirCalisanOzetIstekViewModel(int kullaniciId,DateTime tarihi) : base(kullaniciId)
        {
            this.Tarihi = tarihi;
        }

        public GetirCalisanOzetIstekViewModel(int kullaniciId, string sorguSozcesi) : base(kullaniciId)
        {
            this.SorguSozcesi = sorguSozcesi;
        }

        internal bool girildiMiTarih
        {
            get
            {
                return this.Tarihi != null;
            }
        }
        internal bool girildiMiSozce
        {
            get
            {
                return !String.IsNullOrEmpty(this.SorguSozcesi);
            }
        }

    }
}
