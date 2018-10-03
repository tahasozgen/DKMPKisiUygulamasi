using DKMPKisiUygulamasi.Servis.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Yanit.GorevlendirmeKlasor
{
    [DataContract]
    public class GorevlendirCalisanYanit : TransactionYanitBaz
    {
        private GorevlendirCalisanYanit() : base()
        {
        }

        public GorevlendirCalisanYanit(bool basariliMi) : base(basariliMi)
        {
            
        }

        public GorevlendirCalisanYanit(int islemId) : base(islemId)
        {
        }

        public GorevlendirCalisanYanit(int islemId, string mesajKodu) : base( islemId,  mesajKodu)
        {
        }

        public GorevlendirCalisanYanit(Exception hata) : base(hata)
        {

        }

        public GorevlendirCalisanYanit(DKMPHataAltyapi.ModelHata hata) : base(hata)
        {

        }

    }
}
