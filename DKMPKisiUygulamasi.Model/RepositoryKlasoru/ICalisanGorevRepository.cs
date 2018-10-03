using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.RepositoryKlasoru
{
    public interface ICalisanGorevRepository
    {
        int GunleGorev(CalisanGorevlendirme deger);

        int EkleGorevveDonAnahtar(CalisanGorevlendirme deger);

        IEnumerable<CalisanGorevlendirme> GetirGorevlendirmeListe(int calisanId);

        IEnumerable<CalisanGorevlendirme> GetirGorevlendirmeListeBirimeGore(int birimId);

        IEnumerable<CalisanGorevlendirme> GetirGorevlendirmeListe(DateTime tarihi);

    }
}
