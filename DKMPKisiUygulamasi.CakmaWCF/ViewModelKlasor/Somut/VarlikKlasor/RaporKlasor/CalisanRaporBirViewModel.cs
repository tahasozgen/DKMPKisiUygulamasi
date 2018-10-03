
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.TanimlayiciKlasor;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.RaporKlasor
{
    public class CalisanRaporBirViewModel : CalisanRaporSayiViewModelBaz
    {
        public UnvanViewModel Unvani { get; private set; }

        private CalisanRaporBirViewModel():base()
        {

        }
      
        public CalisanRaporBirViewModel(UnvanViewModel unvani, int calisanSayisi) : this()
        {
            this.Unvani = unvani;
            this.CalisanSayisi = calisanSayisi;
        }
    }
}
