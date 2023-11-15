using CSVPrinter.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVPrinter.Readers
{
    internal class FileReader : IReader<string, string>
    {
        IEnumerable<string> IReader<string, string>.Read(string arg)
        {
            if (!File.Exists(arg))
                throw new Exception("File path dose not exist");

            var lines = new List<string>();

            using (var reader = new StreamReader(arg))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (!string.IsNullOrWhiteSpace(line))
                        lines.Add(line);
                }
            }

            return lines;
        }
    }
}
