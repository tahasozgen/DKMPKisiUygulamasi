using DKMPKisiUygulamasi.Model.EnumKlasoru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.Somut.SorguKlasor
{
    class Ozdeyis
    {
        public string Sozce { get; set; }

        public SorguNitelik Nitelik { get; set; }

        public Ozdeyis()
        {
            this.Sozce = string.Empty;
            this.Nitelik = SorguNitelik.Tanimsiz;
        }

        public Ozdeyis(string sozce, SorguNitelik nitelik) : this()
        {
            this.Sozce = sozce;
            this.Nitelik = nitelik;
        }



    }
}
