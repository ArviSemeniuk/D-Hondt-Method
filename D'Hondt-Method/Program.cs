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
            Dictionary<int, int> votes = new Dictionary<int, int>();
            int partyID = 1; // The key for the votes dict

            foreach (string party in electionResults)
            {
                string[] result = party.Split(',');
                votes.Add(partyID, Int32.Parse(result[1]));
                partyID++;
            }

            foreach (KeyValuePair<int, int> kvp in votes)
            {
                Console.WriteLine($"Key = {kvp.Key} Value = {kvp.Value}");
            }
        }
    }
}