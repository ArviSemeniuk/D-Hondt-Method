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
            Dictionary<int, Tuple<int, int>> votes = new Dictionary<int, Tuple<int, int>>();
            int seatsWon = 0; // Variable to keep track of seats won by each party
            int partyID = 1; // The key for the votes dict

            foreach (string party in electionResults)
            {
                string[] result = party.Split(',');
                var votesAndSeats = new Tuple<int, int>(Int32.Parse(result[1]), seatsWon);
                votes.Add(partyID, votesAndSeats);
                partyID++;
            }

            foreach (KeyValuePair<int, Tuple<int, int>> kvp in votes)
            {
                Console.WriteLine($"Key = {kvp.Key} Value = {kvp.Value}");
            }
        }
    }
}