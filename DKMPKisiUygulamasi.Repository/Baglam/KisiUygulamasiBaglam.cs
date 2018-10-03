using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;
using DKMPKisiUygulamasi.Model.Somut.IletisimKlasor;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using DKMPKisiUygulamasi.Model.Somut.OgrenimKlasor;
using DKMPKisiUygulamasi.Model.Somut.TanimlayiciKlasor;
using DKMPKisiUygulamasi.Repository.IlklendirmeKlasoru;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKMPKisiUygulamasi.Repository.Baglam
{
    public class KisiUygulamasiBaglam : DbContext
    {
        public KisiUygulamasiBaglam() : base("KisiUygulamasiBaglam")
        {

            Database.SetInitializer(new KisiIlklendirme());
            Database.Initialize(true);
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<KisiUygulamasiBaglam>());
            // Database.Log = s => Debug.WriteLine(s);            

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here                      

        }

        public DbSet<CalisanGorevlendirme> CalisanGorevlendirmeListe { get; set; }

        public DbSet<Gorevi> Gorevler { get; set; }

        public DbSet<KisiIletisim> KisiIletisimler { get; set; }

        public DbSet<Calisan> Calisanlar { get; set; }
        public DbSet<Unvan> Unvanlar { get; set; }
        public DbSet<OgrenimDurumu> OgrenimDurumlari { get; set; }

        public DbSet<KisiOgrenim> KisiOgrenimListe { get; set; }

        public DbSet<Universite> UniversiteListe { get; set; }
        
    }
}
