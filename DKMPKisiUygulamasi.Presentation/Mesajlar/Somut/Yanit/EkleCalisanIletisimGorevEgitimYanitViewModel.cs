using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.IslemKlasor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.Mesajlar.Somut.Yanit
{
    public class EkleCalisanIletisimGorevEgitimYanitViewModel : TransactionYanitViewModel
    {        
        public bool SonucCalisanEkleme { get; set; }
        public bool SonucEkleGorevlendirme { get; set; }
        public bool SonucEkleOgrenim { get; set; }
        public bool SonucEkleDahili { get; set; }
        public bool SonucEkleBakanlikEposta { get; set; }
        public bool SonucEkleCepTelefonu { get; set; }

        public EkleCalisanIletisimGorevEgitimYanitViewModel(bool islemSonuc) : base(islemSonuc)
        {
            this.SonucCalisanEkleme = false;
            this.SonucEkleGorevlendirme = false;
            this.SonucEkleOgrenim = false;
            this.SonucEkleDahili = false;
            this.SonucEkleCepTelefonu = false;
            this.SonucEkleBakanlikEposta = false;
        }

        public EkleCalisanIletisimGorevEgitimYanitViewModel(bool islemSonuc,bool sonucCalisanEkleme) : this(islemSonuc)
        {
            this.SonucCalisanEkleme = sonucCalisanEkleme;
        }

        public EkleCalisanIletisimGorevEgitimYanitViewModel(bool islemSonuc, bool sonucCalisanEkleme,bool sonucEkleGorevlendirme) : this(islemSonuc, sonucCalisanEkleme)
        {
            this.SonucEkleGorevlendirme = sonucEkleGorevlendirme;
        }

        public EkleCalisanIletisimGorevEgitimYanitViewModel(bool islemSonuc, bool sonucCalisanEkleme, bool sonucEkleGorevlendirme,bool sonucEkleOgrenim) : this( islemSonuc,  sonucCalisanEkleme,  sonucEkleGorevlendirme)
        {
            this.SonucEkleOgrenim = sonucEkleOgrenim;
        }

        public EkleCalisanIletisimGorevEgitimYanitViewModel(bool islemSonuc, bool sonucCalisanEkleme, bool sonucEkleGorevlendirme, bool sonucEkleOgrenim,bool sonucEkleDahili,bool sonucEkleCepTelefonu,bool sonucEkleBakanlikEposta) : this(islemSonuc, sonucCalisanEkleme, sonucEkleGorevlendirme, sonucEkleOgrenim)
        {
            this.SonucEkleDahili = sonucEkleDahili;
            this.SonucEkleCepTelefonu = sonucEkleCepTelefonu;
            this.SonucEkleBakanlikEposta = sonucEkleBakanlikEposta;
        }

        public EkleCalisanIletisimGorevEgitimYanitViewModel(Exception hata ) : base(hata)
        {
            this.SonucCalisanEkleme = false;
            this.SonucEkleGorevlendirme = false;
            this.SonucEkleOgrenim = false;
            this.SonucEkleDahili = false;
            this.SonucEkleCepTelefonu = false;
            this.SonucEkleBakanlikEposta = false;
        }

    }
}
