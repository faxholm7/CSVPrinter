using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSVPrinter.Models;
using CSVPrinter.Validators;
using Xunit;

namespace CSVPrinter.Tests.Validators.DeviceNameValidatorTests
{
    public class Validate
    {
        private readonly DeviceNameValidator _deviceNameValidator;

        public Validate()
        {
            _deviceNameValidator = new DeviceNameValidator();
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData(" ", false)]
        public void DeviceNameIsNullOrWhiteSpace_ReturnsFalse(string deviceName, bool expected)
        {
            //Arrange
            var device = new Device(serialNumber: "", name: deviceName, information: "");

            //Act
            var result = _deviceNameValidator.Validate(device);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12345", false)]
        [InlineData("67890", false)]
        [InlineData("Inva1idNam3", false)]
        public void DeviceNameIsNumeric_ReturnsFalse(string deviceName, bool expected)
        {
            //Arrange
            var device = new Device(serialNumber: "", name: deviceName, information: "");

            //Act
            var result = _deviceNameValidator.Validate(device);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("ValidName", true)]
        [InlineData("VALIDNAME", true)]
        public void DeviceNameIsNotNullOrWhiteSpaceAndNotNumeric_ReturnsTrue(string deviceName, bool expected)
        {
            //Arrange
            var device = new Device(serialNumber: "", name: deviceName, information: "");

            //Act
            var result = _deviceNameValidator.Validate(device);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
