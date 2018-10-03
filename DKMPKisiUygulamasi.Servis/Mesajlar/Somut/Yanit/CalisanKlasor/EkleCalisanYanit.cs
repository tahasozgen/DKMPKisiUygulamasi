using DKMPKisiUygulamasi.Servis.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.CalisanKlasor
{
    [DataContract]
    public class EkleCalisanYanit: TransactionYanitBaz
    {
        private EkleCalisanYanit() : base()
        {
        }

        public EkleCalisanYanit(bool basariliMi) : base()
        {
        }

        public EkleCalisanYanit(int islemId) : base(islemId)
        {
        }

        public EkleCalisanYanit(int islemId, string mesajKodu) : base( islemId,  mesajKodu)
        {
        }

        public EkleCalisanYanit(Exception hata) : base(hata)
        {
            
        }

        public EkleCalisanYanit(DKMPHataAltyapi.ModelHata hata) : base(hata)
        {
            
        }


    }
}
