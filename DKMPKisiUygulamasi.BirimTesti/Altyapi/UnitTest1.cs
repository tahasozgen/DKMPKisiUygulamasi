using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DKMPKisiUygulamasi.Model.Somut.GorevKlasoru;
using System.Collections.Generic;
using DKMPKisiUygulamasi.Repository.Baglam;
using System.Linq;
using DKMPKisiUygulamasi.Model.Somut.KisiKlasor;
using DKMPKisiUygulamasi.Model.Somut.TanimlayiciKlasor;
using System.Data.Entity;
using System.Data;
using DKMPKisiUygulamasi.Model.Somut.IletisimKlasor;
using DKMPKisiUygulamasi.Model.EnumKlasoru;

namespace DKMPKisiUygulamasi.BirimTesti.Altyapi
{
    [TestClass]
    public class UnitTest1  :HataEleAlma
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                
                //KisiUygulamasiBaglam baglam = new KisiUygulamasiBaglam();

                //Calisan osman = baglam.Calisanlar.First(p => p.Anahtar == 1);
                //Calisan etem = baglam.Calisanlar.First(p => p.Anahtar == 2);
                //Calisan yusuf = baglam.Calisanlar.First(p => p.Anahtar == 3);
                //Calisan hayrettin = baglam.Calisanlar.First(p => p.Anahtar == 4);
                //Calisan didem = baglam.Calisanlar.First(p => p.Anahtar == 5);
                //Calisan mefa = baglam.Calisanlar.First(p => p.Anahtar == 6);


                //var kisiIletisimListe = new List<KisiIletisim>
                //{                   
                //    //1
                //    new KisiIletisim("12",IletisimTuru.Adres,osman),
                //    //2
                //    new KisiIletisim("13",IletisimTuru.BakanlikEposta,etem),
                //    //3
                //    new KisiIletisim("14",IletisimTuru.CepTelefonu,yusuf),
                //    //4
                //    new KisiIletisim("15",IletisimTuru.Dahili,hayrettin),
                //    //5
                //    new KisiIletisim("16",IletisimTuru.EvTelefonu,didem),
                //    //6
                //    new KisiIletisim("17",IletisimTuru.NormalEPosta,mefa),                  

                //};

                //kisiIletisimListe.ForEach(s => baglam.KisiIletisimler.Add(s));
                //baglam.SaveChanges();

            }
            catch (Exception hata)
            {
                this.YazHata(hata);
                Assert.Fail();
            }
        }

        private void KillConnectionsToTheDatabase(Database database)
        {
            var databaseName = database.Connection.Database;
            const string sqlFormat = @"
             USE master; 

             DECLARE @databaseName VARCHAR(50);
             SET @databaseName = '{0}';

             declare @kill varchar(8000) = '';
             select @kill=@kill+'kill '+convert(varchar(5),spid)+';'
             from master..sysprocesses 
             where dbid=db_id(@databaseName);

             exec (@kill);";

            var sql = string.Format(sqlFormat, databaseName);
            using (var command = database.Connection.CreateCommand())
            {
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                command.Connection.Open();

                command.ExecuteNonQuery();

                command.Connection.Close();
            }
        }
    }
}
