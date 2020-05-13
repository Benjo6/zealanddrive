using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZealandDrive.Model.Persistens
{
    public enum PersistenceType
    {
        Simple,
        File,
        Database
    };


    class PersitenceFactory
    {
        public static IPersistens<User> GetPersistency(PersistenceType peristenceType)
        {
            switch (peristenceType)
            {
                case PersistenceType.Simple: return new SimpelPersistens();

                // File
                case PersistenceType.File: return new FilePersistence();

                // Database
                case PersistenceType.Database: return new DBPersistence();

                default: return new SimpelPersistens();
            }


        }
    }
}
