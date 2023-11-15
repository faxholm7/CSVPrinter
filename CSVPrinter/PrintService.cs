using CSVPrinter.Interfaces;
using CSVPrinter.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSVPrinter
{
    internal class PrintService
    {
        private List<IValidator> _validators;
        private IReader<string, string> _reader;
        private IWriter<string> _writer;
        private IDeviceMapper<string> _mapper;

        public PrintService(List<IValidator> validators,
            IReader<string, string> reader,
            IWriter<string> writer,
            IDeviceMapper<string> mapper)
        {
            _validators = validators;
            _reader = reader;
            _writer = writer;
            _mapper = mapper;
        }

        public void Print(Dictionary<string, string> args)
        {
            var filePath = args["ReaderFilePath"];
            if (string.IsNullOrWhiteSpace(filePath))
                throw new Exception("Missing/Null/Empty argument: ReaderFilePath");

            //Get and validate devices
            var readEntries = _reader.Read(filePath);
            var devices = GetValidDevices(readEntries);

            //Make output
            var sb = new StringBuilder();
            foreach (var device in devices)
                sb.AppendLine(FormatDevice(device));

            //Write output string
            _writer.Write(sb.ToString());
        }

        private IEnumerable<Device> GetValidDevices(IEnumerable<string> entries)
        {
            foreach (var entry in entries)
            {
                var device = _mapper.Map(entry);
                if (_validators.All(x => x.Validate(device)))
                    yield return device;
            }
        }

        private string FormatDevice(Device device)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Device name: {device.Name}");
            sb.AppendLine($"Serial number: {device.SerialNumber}");

            if (!string.IsNullOrWhiteSpace(device.Information))
                sb.AppendLine($"More information: {device.Information}");

            return sb.ToString();
        }
    }
}
