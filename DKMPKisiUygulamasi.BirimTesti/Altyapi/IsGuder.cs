using DKMPKisiUygulamasi.Model.RepositoryKlasoru;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using DKMPKisiUygulamasi.Repository.Somut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.BirimTesti.Altyapi
{
    class IsGuder
    {

        private ICalisanRepository _calisanRepository;

        public IsGuder()
        {
            this._calisanRepository = NesneFabrikasiBirimTesti.Ornek.AlOrnek<ICalisanRepository>();

            if (this._calisanRepository == null)
                throw new ApplicationException();
        }

        public Calisan getirCalisan(int calisanId)
        {
            return this._calisanRepository.GetirCalisan(calisanId);
        }
    }
}
