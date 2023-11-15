using CSVPrinter.Mappers;
using CSVPrinter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CSVPrinter.Tests.Mappers
{
    public class CSVToDeviceMapperTests
    {
        [Fact]
        public void Map_ValidInput_ReturnsDevice()
        {
            // Arrange
            var deviceMapper = new CSVToDeviceMapper();
            var input = "123,DeviceName,DeviceInformation";

            // Act
            var result = deviceMapper.Map(input);

            // Assert
            Assert.Equal("123", result.SerialNumber);
            Assert.Equal("DeviceName", result.Name);
            Assert.Equal("DeviceInformation", result.Information);
        }
    }
}
