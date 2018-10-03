using DKMPKisiUygulamasi.Servis.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKMPKurumCografyaUygulamasi.Servis.ViewModel.VarlikKlasor;

namespace DKMPKisiUygulamasi.Servis.Somut
{
    class BirimServis
    {
        internal IEnumerable<BirimViewModel> getirBirimKullanicininGorebilecegi(int kullaniciId)
        {
            //TODO: yazılacak
            BakanlikBirimTuruViewModel bakanlikBirimTuruVM = new BakanlikBirimTuruViewModel(2, "genel müdürlük");
            string adi = "doğa koruma ve milli parklar genel müdürlüğü";
            int id = 2;

            BirimViewModel model = new BirimViewModel(bakanlikBirimTuruVM, id, adi);
            
            List<BirimViewModel> liste = new List<BirimViewModel>();

            liste.Add(model);

            return liste;

        }
    }
}
