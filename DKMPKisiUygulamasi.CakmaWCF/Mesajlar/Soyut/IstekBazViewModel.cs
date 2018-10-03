using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.Mesajlar.Soyut
{
    [DataContract]
    public class IstekBazViewModel
    {
        public int? KullaniciId { get; set; }

        protected IstekBazViewModel()
        {
            this.KullaniciId = null;
        }

        public IstekBazViewModel(int kullaniciId):this()
        {
            this.KullaniciId = kullaniciId;
        }
    }
}
