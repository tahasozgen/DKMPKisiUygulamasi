using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Mesajlar.Soyut
{

    [DataContract]
    public abstract class IslemBaz
    {
        [DataMember]
        public string Mesaj { get; protected set; }

        [DataMember]
        public bool GectiMiIlkKontrolu { get; protected set; }

        [DataMember]
        public Exception Hata { get; set; }

        protected IslemBaz()
        {
            this.Mesaj = string.Empty;
            this.GectiMiIlkKontrolu = true;
            this.Hata = null;
        }

        public IslemBaz(string mesaj) : this()
        {
            this.Mesaj = mesaj;
        }
             

    }
}
