using CSVPrinter.Models;
using CSVPrinter.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CSVPrinter.Tests.Validators.SerialNumberValidatorTests
{
    public class Validate
    {
        private readonly SerialNumberValidator _validator;

        public Validate()
        {
            _validator = new SerialNumberValidator();
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData(" ", false)]
        [InlineData("", false)]
        public void WhenSerialNumberIsNullOrWhiteSpace_ReturnsFalse(string serialNumber, bool expected)
        {
            // Arrange
            var device = new Device(serialNumber: serialNumber, name: "ValidName", information: "");

            var validator = new SerialNumberValidator();

            // Act
            var result = validator.Validate(device);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("123456789", false)] // 9 characters
        [InlineData("a1c2e3g4i", false)] // 9 characters
        [InlineData("12345678901", false)] // 11 characters
        [InlineData("a1c2e3g4i5j", false)] // 11 characters
        public void WhenSerialNumberIsNot10Characters_ReturnsFalse(string serialNumber, bool expected)
        {
            // Arrange
            var device = new Device(serialNumber: serialNumber, name: "ValidName", information: "");

            var validator = new SerialNumberValidator();

            // Act
            var result = validator.Validate(device);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("123456789!", false)] // contains non-alphanumeric character
        [InlineData("a c2e3g4i5", false)] // contains whitespace
        public void WhenSerialNumberContainsNonLetterOrDigit_ReturnsFalse(string serialNumber, bool expected)
        {
            // Arrange
            var device = new Device(serialNumber: serialNumber, name: "ValidName", information: "");

            var validator = new SerialNumberValidator();

            // Act
            var result = validator.Validate(device);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1234567890", true)]
        [InlineData("abcdefghij", true)]
        [InlineData("a1c2e3g4i5", true)]
        public void WhenSerialNumberIsValid_ReturnsTrue(string serialNumber, bool expected)
        {
            // Arrange
            var device = new Device(serialNumber: serialNumber, name: "ValidName", information: "");

            var validator = new SerialNumberValidator();

            // Act
            var result = validator.Validate(device);

            // Assert
            Assert.Equal(expected, result);
        }

    }
}
