using DITestProject.InputHandlerRelease;
using DITestProject.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DITestProject.UnitTesting
{
    public class InputHandlerReleaseTests
    {
        [Fact]
        public void InputHandlerDebug_AddEntry_TestValueString_DictionaryShouldContainTestValueStringPrependedByRELEASE()
        {
            InputHandler inputHandler = new InputHandler(new StorageService());

            inputHandler.AddEntry("TestValue");

            var data = inputHandler.ReadEntries();

            Assert.True(data.ContainsValue("RELEASE_TestValue"));

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
