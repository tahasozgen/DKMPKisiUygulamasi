using DKMPKisiUygulamasi.Model.EnumKlasoru;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.RepositoryKlasoru
{
    public interface ICalisanRepository
    {
        int EkleCalisanveDonAnahtar(Calisan deger);

        IEnumerable<Calisan> GetirCalisanListe(AkademikUnvani unvani);

        IEnumerable<Calisan> GetirCalisanListe(string adi);
        
        IEnumerable<Calisan> GetirCalisanListe(string adi, string soyadi);        

        IEnumerable<Calisan> GetirCalisanListeSoyadinaGore(string soyadi);

        IEnumerable<Calisan> GetirCalisanListe(Cinsiyeti cinsi);

        IEnumerable<Calisan> GetirCalisanListe(DateTime dogumTarihi);

        IEnumerable<Calisan> GetirCalisanListe(bool tumuGetirilsinMi);

        Calisan GetirCalisan(string tcKimlikNo);

        Calisan GetirCalisan(int calisanId);

        Calisan GetirCalisanSicileGore(string sicilNo);

        
    }
}
