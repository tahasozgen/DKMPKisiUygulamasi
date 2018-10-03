using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;
using DKMPKisiUygulamasi.Model.Somut.IletisimKlasor;
using DKMPKisiUygulamasi.Model.Somut.OgrenimKlasor;
using System;

namespace DKMPKisiUygulamasi.Model.Somut.RaporKlasor
{
    public class CalisanOzet
    {
        public CalisanGorevlendirme Gorevlendirme { get; set; }

        public KisiOgrenim Ogrenimi { get; set; }

        public KisiIletisim Dahili { get; set; }

        public KisiIletisim BakanlikEposta { get; set; }

        public KisiIletisim CepTelefonu { get; set; }     

        public int? KidemYili { get; set; }

        private CalisanOzet()
        {
            this.Dahili = null;
            this.BakanlikEposta = null;
            this.CepTelefonu = null;
            this.Gorevlendirme = null;
            this.Ogrenimi = null;
            this.KidemYili = null;
            
        }

        public CalisanOzet(CalisanGorevlendirme gorevlendirme, KisiOgrenim ogrenimi, KisiIletisim dahili, KisiIletisim bakanlikEposta, KisiIletisim cepTelefonu) :this()
        {
            this.Gorevlendirme = gorevlendirme;
            this.Ogrenimi = ogrenimi;
            this.Dahili = dahili;
            this.BakanlikEposta = bakanlikEposta;
            this.CepTelefonu = cepTelefonu;
            
        }

        public CalisanOzet(CalisanGorevlendirme gorevlendirme, KisiOgrenim ogrenimi, KisiIletisim dahili, KisiIletisim bakanlikEposta, KisiIletisim cepTelefonu, int kidemYili) : this(gorevlendirme, ogrenimi, dahili, bakanlikEposta, cepTelefonu)
        {
            this.KidemYili = kidemYili;
        }

        public string Kadrosu
        {
            get
            {
                return (this.Gorevlendirme != null && this.Gorevlendirme.Unvani != null && !String.IsNullOrEmpty(this.Gorevlendirme.Unvani.Adi)) ? this.Gorevlendirme.Unvani.Adi : string.Empty;                
            }
        }

        public int? KadroId
        {
            get
            {
                if (this.Gorevlendirme != null && this.Gorevlendirme.Unvani != null)
                    return this.Gorevlendirme.Unvani.Anahtar;
                else
                    return null;
            }
        }


    }
}
