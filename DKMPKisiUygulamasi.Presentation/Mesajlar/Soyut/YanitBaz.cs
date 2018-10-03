using DKMPKisiUygulamasi.Servis.Mesajlar.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.Mesajlar.Soyut
{
    public abstract class YanitBaz : IslemBaz
    {
        public bool BasariliMi { get; set; }

        public YanitBaz() : base()
        {
            this.BasariliMi = true;
            this.GectiMiIlkKontrolu = true;
            this.Hata = null;
        }

        public YanitBaz(bool basariliMi) : this()
        {
            this.BasariliMi = basariliMi;
        }

        public YanitBaz(bool basariliMi, string mesaj) : this(basariliMi)
        {
            this.Mesaj = mesaj;
        }

        public YanitBaz(Exception hata) : this()
        {
            if (hata != null)
            {
                this.Hata = hata;

                //if (hata is DKMPHataAltyapi.ModelHata)
                //{
                //    this.kurHata((DKMPHataAltyapi.ModelHata)hata);
                //
                if (false)
                {

                }
                else
                {
                    this.kurHata(hata);
                }


            }
        }

        public void IsaretleGecemediIlkKontrolu(string mesajKodu)
        {
            this.Mesaj = "İlk kontrolü geçemedi. " + mesajKodu;
            this.GectiMiIlkKontrolu = false;
            this.BasariliMi = false;
        }

        internal void kurHata(Exception hata)
        {
            if (hata != null)
            {
                this.Hata = hata;
                this.Mesaj = hata.Message;
                this.BasariliMi = false;
            }
        }

        //public YanitBaz(DKMPHataAltyapi.ModelHata hata) : this()
        //{
        //    if (hata != null)
        //    {
        //        this.Hata = hata;
        //        this.kurHata(hata);
        //    }
        //}

        //internal void kurHata(DKMPHataAltyapi.ModelHata hata)
        //{
        //    if (hata != null)
        //    {
        //        this.Hata = hata;
        //        this.Mesaj = hata.HataMesaji.Mesaj;
        //        this.BasariliMi = false;
        //    }
        //}

        /// <summary>
        /// Bazı işlemlerde hata olsa bile işleme devam edilebilir. Bu durumda işlem bitirilerek bilgi verilmelidir.
        /// </summary>
        /// <param name="hata"></param>
        //public void KurHataBasariyaEtkiEtmeyen(DKMPHataAltyapi.ModelHata hata)
        //{
        //    this.kurHata(hata);
        //    this.BasariliMi = true;
        //}

    }
}
