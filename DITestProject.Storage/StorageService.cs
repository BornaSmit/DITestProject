using System;
using System.Collections.Generic;
using System.Text;

namespace DITestProject.Storage
{
    public class StorageService : IStorageService
    {
        private Dictionary<DateTime, string> StorageDict = new Dictionary<DateTime, string>();

        public void AddEntry(DateTime key, string value)
        {
            StorageDict.Add(key, value);
        }

        public Dictionary<DateTime, string> ReadEntries()
        {
            return StorageDict;
        }

    }
}
