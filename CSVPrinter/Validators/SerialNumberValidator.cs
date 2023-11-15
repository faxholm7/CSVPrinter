using CSVPrinter.Interfaces;
using CSVPrinter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVPrinter.Validators
{
    public class SerialNumberValidator : IValidator
    {
        public bool Validate(Device device)
        {
            if(string.IsNullOrWhiteSpace(device.SerialNumber))
                return false;

            if (device.SerialNumber.Length != 10)
                return false;

            if(!device.SerialNumber.All(x => char.IsLetterOrDigit(x)))
                return false;

            return true;
        }
    }
}
