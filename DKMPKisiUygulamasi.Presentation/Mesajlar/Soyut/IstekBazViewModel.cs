using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.Mesajlar.Soyut
{
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
