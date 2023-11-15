using CSVPrinter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVPrinter.Interfaces
{
    internal interface IDeviceMapper<InputType>
    {
        public Device Map(InputType input);
    }
}
