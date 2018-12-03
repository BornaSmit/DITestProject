using DITestProject.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DITestProject.UnitTesting
{
    public class StorageServiceTests
    {

        [Fact]
        public void StorageService_AddEntry_TestValueString_DictionaryShouldContainTestValueString()
        {
            StorageService storageService = new StorageService();

            DateTime currentDateTime = DateTime.Now;
            storageService.AddEntry(currentDateTime, "TestValue");

            var data = storageService.ReadEntries();

            Assert.True(data.ContainsValue("TestValue"));
        }

        [Fact]
        public void StorageService_ReadEntries_ShouldReturnDictionaryWithKeyDateTimeAndValueString()
        {
            StorageService storageService = new StorageService();

            var data = storageService.ReadEntries();

            Assert.IsType<Dictionary<DateTime, string>>(data);
        }
    }
}
