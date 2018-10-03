using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Mesajlar.Soyut
{
    [DataContract]
    public abstract class TransactionYanitBaz : IslemBaz
    {
        [DataMember]
        public int IslemId { get; private set; }

        [DataMember]
        public bool BasariliMi
        {
            get
            {
                return this.IslemId > 0;
            }
            private set
            {
                bool arguman = value;

                this.IslemId = (arguman) ? 1 : int.MinValue;

            }
        }

        public TransactionYanitBaz() : base()
        {          
            this.IslemId = int.MinValue;
        }

        public TransactionYanitBaz(bool basariliMi) : this()
        {
            this.BasariliMi = basariliMi;
        }

        public TransactionYanitBaz(int islemId) : this()
        {
            this.IslemId = islemId;
        }
        
        public TransactionYanitBaz(int islemId, string mesajKodu) : base(mesajKodu)
        {
            this.IslemId = islemId;            
        }

        public TransactionYanitBaz(Exception hata) : this()
        {
            if (hata != null)
            {
                this.kurHata(hata);
            }
        }

        public TransactionYanitBaz(DKMPHataAltyapi.ModelHata hata) : this()
        {
            if (hata != null)
            {
                this.kurHata(hata);
            }
        }

        public void IsaretleGecemediIlkKontrolu(string hataKodu)
        {
            this.IslemId = int.MinValue;
            this.Mesaj = "İlk kontrolü geçemedi. " + hataKodu;
            this.GectiMiIlkKontrolu = false;
        }

        internal void kurHata(Exception hata)
        {
            if (hata != null)
            {
                this.IslemId = int.MinValue;
                this.Hata = hata;
                this.Mesaj = hata.Message;
            }
        }

        internal void kurHata(DKMPHataAltyapi.ModelHata hata)
        {
            if (hata != null)
            {
                this.IslemId = int.MinValue;
                this.Mesaj = hata.HataMesaji.OlayKodu;
            }
        }



    }
}
