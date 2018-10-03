using DKMPKisiUygulamasi.Repository.Somut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.CakmaWCF.Altyapi
{
    class NorthwindContextSingleton
    {
        //TODO: ÖNEMLİ: productionda private
        public NorthwindContext context = null;
        private static NorthwindContextSingleton instance = null;
        private static readonly object padlock = new object();

        NorthwindContextSingleton()
        {
            this.context = new NorthwindContext();
        }

        public static NorthwindContextSingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new NorthwindContextSingleton();

                    }
                    return instance;
                }
            }
        }
    }
}
