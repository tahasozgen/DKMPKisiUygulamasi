using AutoMapper;
using DKMPKisiUygulamasi.CakmaWCF.Somut;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.GorevKlasoru;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.KisiKlasor;
using DKMPKisiUygulamasi.CakmaWCF.ViewModelKlasor.Somut.VarlikKlasor.TanimlayiciKlasor;
using DKMPKisiUygulamasi.Model.IsKatmani.Somut;
using DKMPKisiUygulamasi.Model.SabitlerMesajlar;
using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;
using DKMPKurumCografyaUygulamasi.Servis.Somut;
using DKMPKurumCografyaUygulamasi.Servis.ViewModel.VarlikKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.Altyapi.CevirmeKlasoru.ResolverKlasoru
{
    class CalisanGorevlendirmeResolver : ITypeConverter<CalisanGorevlendirme, CalisanGorevlendirmeViewModel>
    {
        public CalisanGorevlendirmeViewModel Convert(CalisanGorevlendirme source, CalisanGorevlendirmeViewModel destination, ResolutionContext context)
        {
            if (source != null)
            {
                
                Cevir cevir = new Cevir();
                KurumCografyaServis servis = new KurumCografyaServis(Sabitler.KurumCografyaServisBaglantiCumlesi);
                int anahtar = source.Anahtar;
                CalisanViewModel calisani = cevir.cevir(source.Calisani);
                GoreviViewModel gorev = cevir.cevir(source.Gorev);
                UnvanViewModel unvani = cevir.cevir(source.Unvani);
                string baslangic = source.Baslangic.ToShortDateString();
                bool asilMi = source.AsilMi;
                string aciklama = source.Aciklama;
                bool resmiMi = source.ResmiMi;
                DateTime bitisTarihi = source.Bitis ?? DateTime.MinValue;
                string bitis = Arac.GetirTarihSozce(source.Bitis);
                HizmetSonlanisNedeniViewModel sonlanisNedeni = cevir.cevir(source.SonlanisNedeni);

                return new CalisanGorevlendirmeViewModel(anahtar, calisani, null, null, gorev, unvani, baslangic, asilMi, aciklama, resmiMi, bitis, sonlanisNedeni);
            }
            else
                return null;
        }

    }
}
