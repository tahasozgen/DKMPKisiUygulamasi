using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Soyut
{
    public class CalisanRaporSayiViewModelBaz
    {
        protected int? CalisanSayisi { get;  set; }

        protected CalisanRaporSayiViewModelBaz()
        {
            this.CalisanSayisi = null;
        }

        public CalisanRaporSayiViewModelBaz(int calisanSayisi):this()
        {
            if (calisanSayisi < 0)
                throw new ArgumentException();

            this.CalisanSayisi = calisanSayisi;

        }

        public string CalisanSayisiSozce
        {
            get
            {
                return this.CalisanSayisi != null ? this.CalisanSayisi.ToString() : string.Empty;
            }
        }
    }
}
