
using DKMPKisiUygulamasi.Model.Somut.TanimlayiciKlasor;
using DKMPKisiUygulamasi.Model.Soyut.CalisanKlasor;
using System;

namespace DKMPKisiUygulamasi.Model.Somut.RaporKlasor
{
    public class CalisanRaporBir: CalisanRaporSayiBaz
    {
        public Unvan Unvani{ get; set; }

        private CalisanRaporBir():base()
        {

        }

        public CalisanRaporBir(Unvan unvani) : this()
        {
            if (unvani == null)
                throw new ArgumentNullException();

            this.CalisanSayisi++;

        }
        public CalisanRaporBir(Unvan unvani,int calisanSayisi) : this(unvani)
        {
            this.CalisanSayisi = calisanSayisi;
        }

    }
}
