using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZealandDrive.Model;

namespace ZealandDrive.Persistens
{
    public enum PersistenceType
    {
        File,
        Database
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
    }
}
