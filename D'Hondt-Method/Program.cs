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
            int lineNumber = 4;
            List<string> electionResults = new List<string>();

            StreamReader lines = new StreamReader("Assessment1Data.txt");

            for(int i = 1; i < lineNumber; i++)
            {
                lines.ReadLine();
            }
            while((line = lines.ReadLine()) != null)
            {
                electionResults.Add(line);
            }
            foreach(string party in electionResults)
            {
                Console.WriteLine(party);
            }
        }
    }
}