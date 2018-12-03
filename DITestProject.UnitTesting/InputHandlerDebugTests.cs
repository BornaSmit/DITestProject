using DITestProject.InputHandlerDebug;
using DITestProject.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DITestProject.UnitTesting
{
    public class InputHandlerDebugTests
    {
        [Fact]
        public void InputHandlerDebug_AddEntry_TestValueString_DictionaryShouldContainTestValueString()
        {
            InputHandler inputHandler = new InputHandler(new StorageService());

            DateTime currentDateTime = DateTime.Now;
            inputHandler.AddEntry("TestValue");

            var data = inputHandler.ReadEntries();

            Assert.True(data.ContainsValue("TestValue"));

        }

        [Fact]
        public void InputHandlerDebug_ReadEntries_ShouldReturnDictionaryWithKeyDateTimeAndValueString()
        {
            InputHandler inputHandler = new InputHandler(new StorageService());

            var data = inputHandler.ReadEntries();

            Assert.IsType<Dictionary<DateTime, string>>(data);

        }

    }
}
