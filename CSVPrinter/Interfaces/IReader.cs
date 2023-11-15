using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVPrinter.Interfaces
{
    internal interface IReader<OutputType, ArgumentType>
    {
        public IEnumerable<OutputType> Read(ArgumentType arg);
    }
}
