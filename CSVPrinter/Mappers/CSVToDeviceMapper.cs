using CSVPrinter.Interfaces;
using CSVPrinter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVPrinter.Mappers
{
    public class CSVToDeviceMapper : IDeviceMapper<string>
    {
        public Device Map(string input)
        {
            var splitInput = input.Split(',');

            var infomation = string.Empty;

            if (splitInput.Length >= 3)
                infomation = splitInput[2];

            var device = new Device(
                serialNumber: splitInput[0],
                name: splitInput[1],
                information: infomation);

            return device;
        }
    }
}
