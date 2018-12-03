using System;
using System.Collections.Generic;
using System.Text;

namespace DITestProject.Storage
{
    public interface IStorageService
    {
        void AddEntry(DateTime key, string value);

        Dictionary<DateTime, string> ReadEntries();
    }
}
