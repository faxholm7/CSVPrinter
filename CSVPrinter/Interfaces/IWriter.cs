using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVPrinter.Interfaces
{
    internal interface IWriter<T>
    {
        public void Write(T value);
    }
}
