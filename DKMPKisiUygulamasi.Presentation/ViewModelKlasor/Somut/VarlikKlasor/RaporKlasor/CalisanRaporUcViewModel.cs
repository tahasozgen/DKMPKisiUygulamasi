﻿using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.TanimlayiciKlasor;
using DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Presentation.ViewModelKlasor.Somut.VarlikKlasor.RaporKlasor
{
    public class CalisanRaporUcViewModel : CalisanRaporSayiViewModelBaz
    {
        public OgrenimDurumuViewModel OgreniminDurumu { get; private set; }

        private CalisanRaporUcViewModel():base()
        {

        }

        public CalisanRaporUcViewModel(OgrenimDurumuViewModel ogrenimDurumu) : this()
        {
            if (ogrenimDurumu == null)
                throw new ArgumentNullException();

            this.CalisanSayisi++;

        }

        public CalisanRaporUcViewModel(OgrenimDurumuViewModel ogrenimDurumu, int calisanSayisi) : this(ogrenimDurumu)
        {
            this.CalisanSayisi = calisanSayisi;
        }
    }
}
