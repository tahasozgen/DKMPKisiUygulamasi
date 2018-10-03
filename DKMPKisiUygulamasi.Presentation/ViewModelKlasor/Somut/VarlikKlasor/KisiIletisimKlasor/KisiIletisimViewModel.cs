using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.KisiIletisimKlasor
{
    public class KisiIletisimViewModel
    {
        
        public int? Anahtar { get; private set; }
        
        public KisiViewModel Kisisi { get; private set; }
        
        public string Deger { get; private set; }
        
        public IletisimTuruViewModel Turu { get; private set; }

        private KisiIletisimViewModel()
        {
            this.Anahtar = null;
            this.Kisisi = null;
            this.Deger = string.Empty;
            this.Turu = null;
        }        
    }
}
