using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.TanimlayiciKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor
{
    public class KisiOgrenimViewModel
    {
        public int? Anahtar { get; private set; }

        public CalisanViewModel Calisani { get; private set; }

        public virtual OgrenimDurumuViewModel OgrenimDurumu { get; private set; }
        
        public UniversiteViewModel Universitesi { get; private set; }
                

        public string OgrenimAdi
        {
            get
            {
                return (this.OgrenimDurumu != null) ? this.OgrenimDurumu.Adi : string.Empty;

            }
        }
    }
}
