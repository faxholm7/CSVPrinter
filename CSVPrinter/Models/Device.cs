using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVPrinter.Models
{
    public class Device
    {
        public Device(string serialNumber, string name, string information)
        {
            SerialNumber = serialNumber;
            Name = name;
            Information = information;
        }

        public string SerialNumber { get; }
        public string Name { get; }
        public string Information { get; }
    }
}
