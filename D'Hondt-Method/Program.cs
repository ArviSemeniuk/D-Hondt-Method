using System;
using System.IO;
using System.Collections.Generic;

namespace D_Hondt_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadFile read = new ReadFile();
            List<string> data = read.ReadResultsFromFile("Assessment1Data.txt");
            ComputeResults(data);
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