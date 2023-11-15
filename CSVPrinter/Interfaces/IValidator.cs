using CSVPrinter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVPrinter.Interfaces
{
    internal interface IValidator
    {
        public bool Validate(Device device);
    }
}
