using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZealandDrive.Model;
using ZealandDrive.Persistens.Bil;
using ZealandDrive.Persistens.Bruger;

namespace ZealandDrive.Persistens
{
    public enum PersistenceType
    {
        File,
        Database,
        CarDatabase
    };


    class PersitenceFactory
    {
        public static IPersistens<Users> GetPersistency(PersistenceType peristenceType)
        {
            switch (peristenceType)
            {

                // File
                case PersistenceType.File: return new FilePersistence();

                // Database
                case PersistenceType.Database: return new DBPersistence();


                default: return new FilePersistence();
            }


        }

        //public static IPersistens<Car> GetPersistens(PersistenceType persistenceType)
        //{
        //    switch (persistenceType)
        //    {
        //         case PersistenceType.Database: return new DBPersistenceCar();

        //    default: return new DBPersistenceCar();
        //    }
        //}
    }
}
