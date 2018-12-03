using System;
using System.Collections.Generic;
using System.Text;
using DITestProject.Storage;

namespace DITestProject.InputHandlerRelease
{
    public class InputHandler : IInputHandler
    {
        protected IStorageService StorageService { get; private set; }

        public InputHandler(IStorageService storageService)
        {
            StorageService = storageService;
        }

        public void AddEntry(string value)
        {
            StorageService.AddEntry(DateTime.Now, "RELEASE_" + value);
        }

        public Dictionary<DateTime, string> ReadEntries()
        {
            return StorageService.ReadEntries();
        }

    }
}
