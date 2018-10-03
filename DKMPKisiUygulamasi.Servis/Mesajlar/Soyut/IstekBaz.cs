using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Mesajlar.Soyut
{
    [DataContract]
    public abstract class IstekBaz
    {
        [DataMember]
        public int? KullaniciId { get; set; }

        protected IstekBaz()
        {
            this.KullaniciId = null;
        }

        public IstekBaz(int kullaniciId):this()
        {
            this.KullaniciId = kullaniciId;
        }

    }

}
