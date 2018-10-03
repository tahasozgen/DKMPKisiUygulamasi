
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.TanimlayiciKlasor
{
    public class UnvanViewModel : SozlukViewModel
    {
        protected UnvanViewModel() : base()
        {

        }

        public UnvanViewModel(int anahtar, string adi) : base(anahtar,adi)
        {

        }
    }
}
