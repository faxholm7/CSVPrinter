using CSVPrinter.Interfaces;
using CSVPrinter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVPrinter.Validators
{
    public class DeviceNameValidator : IValidator
    {
        public bool Validate(Device device)
        {
            if (string.IsNullOrWhiteSpace(device.Name))
                return false;            

            if (device.Name.Any(x => char.IsDigit(x)))
                return false;

            return true;
        }
    }
}
