using DKMPKisiUygulamasi.CakmaWCF.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.Mesajlar.Somut.Istek
{
    [DataContract]
    public class SorgulaCalisanIstekViewModel: IstekBazViewModel
    {
        [DataMember]
        public string SorguSozcesi { get; set; }

        private SorgulaCalisanIstekViewModel() : base()
        {
            this.SorguSozcesi = string.Empty;
        }

        public SorgulaCalisanIstekViewModel(int kullaniciId, string sorguSozcesi) : base(kullaniciId)
        {
            this.SorguSozcesi = sorguSozcesi;
        }

    }

}
