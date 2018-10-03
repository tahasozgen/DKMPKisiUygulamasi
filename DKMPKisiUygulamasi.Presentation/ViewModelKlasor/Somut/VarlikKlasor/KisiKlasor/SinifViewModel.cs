using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor
{
    public class SinifViewModel : SozlukViewModel
    {
        protected SinifViewModel() : base()
        {

        }

        public SinifViewModel(int anahtar, string adi) : base(anahtar,adi)
        {


        }
    }
}
