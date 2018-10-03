using DKMPKisiUygulamasi.Servis.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Servis.Mesajlar.Somut.Istek.CalisanKlasor
{
    [DataContract]
    public class EkleCalisanIstek : IstekBaz
    {
        [DataMember]
        public int? AkademikUnvanId { get; set; }

        [DataMember]
        public string Adi { get; set; }

        [DataMember]
        public string KizlikSoyadi { get; set; }

        [DataMember]
        public string Soyadi { get; set; }

        [DataMember]
        public int? CinsiyetId { get; set; }

        [DataMember]
        public int? KanGrubuId { get; set; }

        [DataMember]
        public int? PhDegerId { get; set; }

        [DataMember]
        public int? MedeniDurumId { get; set; }

        [DataMember]
        public string TurCumKimlikNo { get; set; }

        [DataMember]
        public string DogumTarihi { get; set; }

        [DataMember]
        public string IbanNo { get; set; }

        [DataMember]
        public byte[] Resim { get; set; }

        [DataMember]
        public string SicilNo { get; set; }

        [DataMember]
        public int? KadrosuId { get; set; }

        [DataMember]
        public int? SinifId { get; set; }
      
        public EkleCalisanIstek()
        {
            this.AkademikUnvanId = 3;

        }

        public EkleCalisanIstek(int kullaniciId) : this()
        {
            this.KullaniciId = kullaniciId;
        }

        public EkleCalisanIstek(int akademikUnvanId, string adi, string kizlikSoyadi, string soyadi, int cinsiyetId, int kanGrubuId,
            int phDegerId, int medeniDurumId, string turCumKimlikNo, string dogumTarihi, string ibanNo, byte[] resim,
            string sicilNo, int kadrosuId, int sinifId) : this()
        {
            this.AkademikUnvanId = akademikUnvanId;
            this.Adi = adi;
            this.KizlikSoyadi = kizlikSoyadi;
            this.Soyadi = soyadi;
            this.CinsiyetId = cinsiyetId;
            this.KanGrubuId = kanGrubuId;
            this.PhDegerId = phDegerId;
            this.MedeniDurumId = medeniDurumId;
            this.TurCumKimlikNo = turCumKimlikNo;
            this.DogumTarihi = dogumTarihi;
            this.IbanNo = ibanNo;
            this.Resim = resim;
            this.SicilNo = sicilNo;
            this.KadrosuId = kadrosuId;
            this.SinifId = sinifId;
        }

    }
}
