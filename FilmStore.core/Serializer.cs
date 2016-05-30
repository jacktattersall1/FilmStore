using System;
using System.Collections.Generic;
using FilmStore.core.Interfaces;
using System.IO;
using System.Runtime.Serialization;

namespace FilmStore.core
{
    public class Serializer : ISerializer
    {
        private string path = @"C:\Users\jackt\OneDrive\Documents\FilmStoreSeralizes\object.xml";

        public ICollection<Film> Read()
        {
            if (!File.Exists(path))
                return new HashSet<Film>();

            using(FileStream fs = new FileStream(path, FileMode.Open))
            {
                var serializer = new NetDataContractSerializer();
            }
        }

        public void Write(ICollection<Film> films)
        {
            throw new NotImplementedException();
        }
    }
}