using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;
using DKMPKisiUygulamasi.Model.Somut.IletisimKlasor;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using DKMPKisiUygulamasi.Model.Somut.RaporKlasor;
using DKMPKurumCografyaUygulamasi.Servis.ViewModel.VarlikKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.IsKatmani.Soyut
{
    public interface IGorevlendirmeIsKurali
    {        

        int EkleGorevlendirme(CalisanGorevlendirme deger);

        int GunleGorev(CalisanGorevlendirme deger);

        int SonlandirMevcutGorevi(int calisanId, DateTime bitisTarihi, int hizmetSonlanisNedenId, string aciklama);

        CalisanGorevlendirme GetirMevcutGorevi(int calisanId, bool getirilsinMiSadeceResmiGorevler);

        IEnumerable<Gorevi> GetirGorevListe(bool getirilsinMiTumu);

        IEnumerable<CalisanRaporBir> GetirCalisanRaporBir(IEnumerable<BirimViewModel> birimVmListe );

        IEnumerable<CalisanGorevlendirme> GetirCalisanGorevlendirmeListe(DateTime tarih);

        int HesaplaKidemYili(int calisanId);

        IEnumerable<CalisanOzet> GetirCalisanOzet(DateTime tarihi);

        IEnumerable<CalisanOzet> GetirCalisanOzetListe(IEnumerable<Calisan> calisanListe);


    }
}
