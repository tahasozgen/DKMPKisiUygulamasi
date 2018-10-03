using DKMPKisiUygulamasi.Model.SabitlerMesajlar;
using DKMPKisiUygulamasi.Servis.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.GorevlendirmeKlasor
{
    [DataContract]
    public class GorevlendirCalisanIstek : IstekBaz
    {
        [DataMember]
        public int? CalisanId { get; set; }

        [DataMember]
        public int? BirimId { get; set; }

        [DataMember]
        public int? GorevId { get; set; }

        [DataMember]
        public int? IlId { get; set; }

        [DataMember]
        public string BaslangicTarihi { get; set; }

        [DataMember]
        public bool? AsilMi { get; set; }

        [DataMember]
        public string Aciklama { get; set; }

        [DataMember]
        public int? UnvanId { get; set; }

        [DataMember]
        public bool? ResmiMi { get; set; }
        
        private GorevlendirCalisanIstek() : base()
        {
            this.CalisanId = null;
            this.BirimId = null;
            this.GorevId = null;
            this.IlId = null;
            this.BaslangicTarihi = string.Empty;
            this.AsilMi = null;
            this.Aciklama = string.Empty;
            this.UnvanId = null;
            this.ResmiMi = null;
        }

        public GorevlendirCalisanIstek(int calisanId,int birimId, int gorevId,string baslangicTarihi,bool asilMi, string aciklama, int unvanId, bool resmiMi, int ilId )  : this()
        {
            this.CalisanId = calisanId;
            this.BirimId = birimId;
            this.GorevId = gorevId;
            this.BaslangicTarihi = baslangicTarihi;
            this.AsilMi = asilMi;
            this.Aciklama = aciklama;
            this.UnvanId = unvanId;
            this.ResmiMi = resmiMi;
            this.IlId = ilId;

        }

    }
}
