using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSVDuplicateRecordRemover
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> csvResults = new List<string>(); // The initial results read from the input CSV file.
            List<string> removeDuplicatesList = new List<string>();  // The results of the input CSV file without duplicate rows.
            var outputCsv = new StringBuilder();  // The StringBuilder that will be used to write to the CSV file.
            string pathToCsvFile = @"C:\Users\Jason\Desktop\csv-duplicate-record-remover\CSVDuplicateRecordRemover\DuplicateRemoverSampleInput.csv"; // The path to the input CSV file.
            string pathToOutputCsvFile = @"C:\Users\Jason\Desktop\csv-duplicate-record-remover\CSVDuplicateRecordRemover\ResultWithoutDuplicates.csv";  // The path to the output CSV file.

            // Read the input CSV file, and add each row to the csvResults list.
            using (var reader = new StreamReader(pathToCsvFile))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    csvResults.Add(line);
                }
            }

            // Create a new list from the csvResults list, removing all duplicates.
            removeDuplicatesList = csvResults.Distinct().ToList();

            // Append each row from removeDuplicatesList to the outputCsv string.
            foreach (var row in removeDuplicatesList)
            {
                outputCsv.AppendLine(row);
            }

            // Write the outputCsv string to a new CSV file.
            File.WriteAllText(pathToOutputCsvFile, outputCsv.ToString());

            Console.WriteLine("The CSV File Without Duplicate Rows Has Been Written to: {0}", pathToOutputCsvFile);

            Console.ReadLine();
        }
    }
}
