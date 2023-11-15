using CSVPrinter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVPrinter.Writers
{
    internal class ConsoleWriter : IWriter<string>
    {
        public void Write(string value)
        {
            Console.WriteLine(value);
        }
    }
}
