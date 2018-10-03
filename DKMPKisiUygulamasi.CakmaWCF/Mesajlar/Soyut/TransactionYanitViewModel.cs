using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.Mesajlar.Soyut
{
    public abstract class TransactionYanitViewModel : IslemBaz
    {
        public int IslemId { get; private set; }

        public new bool BasariliMi
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

        public TransactionYanitViewModel() : base()
        {
            this.IslemId = int.MinValue;
        }

        public TransactionYanitViewModel(bool basariliMi) : this()
        {
            this.BasariliMi = basariliMi;
        }

        public TransactionYanitViewModel(int islemId) : this()
        {
            this.IslemId = islemId;
        }

        public TransactionYanitViewModel(int islemId, string mesajKodu) : base(mesajKodu)
        {
            this.IslemId = islemId;
        }

        public TransactionYanitViewModel(Exception hata) : this()
        {
            if (hata != null)
            {
                this.kurHata(hata);
            }
        }

        public TransactionYanitViewModel(DKMPHataAltyapi.Soyut.HataBase hata) : this()
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

     
        internal void kurHata(DKMPHataAltyapi.Soyut.HataBase hata)
        {
            if (hata != null)
            {
                this.IslemId = int.MinValue;
                this.Mesaj = hata.HataMesaji.OlayKodu;
            }
        }



    }
}
