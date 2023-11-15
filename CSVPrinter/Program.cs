using CSVPrinter.Interfaces;
using CSVPrinter.Mappers;
using CSVPrinter.Readers;
using CSVPrinter.Validators;
using CSVPrinter.Writers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;

namespace CSVPrinter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var validators = new List<IValidator>();
            validators.Add(new DeviceNameValidator());
            validators.Add(new SerialNumberValidator());

            var printService = new PrintService(validators, new FileReader(), new ConsoleWriter(), new CSVToDeviceMapper());
            var printArguments = new Dictionary<string, string>();

            Console.WriteLine("Starting print service");

            while (true)
            {
                Console.WriteLine("Enter file path");
                Console.WriteLine("Empty for default path");
                Console.WriteLine("Exit to close");
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                    input = "../../../../CSVPrinter.Tests/TestFiles/Devices.csv";

                if (input.ToLower() == "exit")
                    return;

                printArguments.Add("ReaderFilePath", input);

                printService.Print(printArguments);
            }
        }
    }
}