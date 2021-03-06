using System;
using System.IO;
using System.Collections.Generic;

namespace D_Hondt_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadFile();
        }

        static void ReadFile()
        {
            string line;
            List<string> electionResults = new List<string>();

            StreamReader lines = new StreamReader("Assessment1Data.txt");

            for (int i = 1; i < 4; i++)
            {
                lines.ReadLine();
            }
            while ((line = lines.ReadLine()) != null)
            {
                electionResults.Add(line);
            }
            ComputeResults(electionResults);
        }

        static void ComputeResults(List<string> electionResults)
        {
            // Spent 5 hours trying to figure this out...
            // No progress...
            // I want to die
        }
    }
}