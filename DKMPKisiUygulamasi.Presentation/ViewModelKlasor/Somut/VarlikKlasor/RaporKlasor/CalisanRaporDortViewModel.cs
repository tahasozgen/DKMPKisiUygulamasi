using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.RaporKlasor
{
    public class CalisanRaporDortViewModel : CalisanRaporSayiViewModelBaz
    {
        public KadrosuViewModel Kadrosu { get; private set; }

        private CalisanRaporDortViewModel():base()
        {

        }

        public CalisanRaporDortViewModel(KadrosuViewModel kadrosu) : this()
        {
            if (kadrosu == null)
                throw new ArgumentException();

            this.CalisanSayisi++;

        }
        public CalisanRaporDortViewModel(KadrosuViewModel kadrosu, int calisanSayisi) : this(kadrosu)
        {
            this.CalisanSayisi = calisanSayisi;
        }
    }
}
