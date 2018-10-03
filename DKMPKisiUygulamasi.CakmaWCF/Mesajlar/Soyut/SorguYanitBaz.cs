using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.Mesajlar.Soyut
{
    public abstract class SorguYanitBaz<T> : YanitBaz
    {
        public IEnumerable<T> Liste { get; protected set; }
        private bool _basariliMi;

        protected SorguYanitBaz() : base()
        {
            this.Liste = new List<T>();
        }

        public SorguYanitBaz(bool basariliMi) : base(basariliMi)
        {
            this.Liste = new List<T>();
        }

        public SorguYanitBaz(bool basariliMi, string mesaj) : base(basariliMi, mesaj)
        {
            this.Liste = new List<T>();
        }

        public SorguYanitBaz(IEnumerable<T> liste) : base(true)
        {
            this.Liste = liste;
            this.BasariliMi = liste != null;
        }

        public SorguYanitBaz(Exception hata) : base(hata)
        {
            this.Liste = new List<T>();
        }

        public SorguYanitBaz(DKMPHataAltyapi.ServisHata hata) : base(hata)
        {
            this.Liste = new List<T>();
        }

        public void Ekle(T deger)
        {

            if (deger != null)
            {
                List<T> liste = this.Liste == null ? new List<T>() : this.Liste.ToList();

                liste.Add(deger);

                this.Liste = liste;
                this.BasariliMi = true;

            }
        }

        public T TekNesne
        {
            get
            {
                if (this.Liste != null && this.Liste.Any())
                    return this.Liste.ElementAt(0);
                else
                    return default(T);
            }
        }

        public bool TekNesneMi
        {
            get
            {
                if (this.Liste != null && this.Liste.Any())
                    return this.Liste.ToList().Count() == 1;
                else
                    return false;
            }
        }

        public int NesneSayisi
        {
            get
            {
                if (this.Liste != null)
                    return this.Liste.Count();
                else
                    return 0;
            }
        }

        public new bool BasariliMi
        {
            set
            {
                this._basariliMi = value;
            }
            get
            {
                if (this.Liste == null)
                    return false;
                else
                    return this._basariliMi;
            }
        }

    }
}
