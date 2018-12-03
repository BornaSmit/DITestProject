using System;
using System.Collections.Generic;
using System.Text;

namespace DITestProject.InputHandlerRelease
{
    public interface IInputHandler
    {
        void AddEntry(string value);

        Dictionary<DateTime, string> ReadEntries();
    }
}
