using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Model.IsKatmani.Soyut
{
    public interface ICalisanIsKurali
    {

        Calisan GetirCalisan(int calisanId);

        IEnumerable<Calisan> SorgulaCalisan(string sorguSozcesi);

        IEnumerable<Calisan> SorgulaCalisan(DateTime tarih);

        int EkleCalisan(Calisan deger);

        
    }
}
