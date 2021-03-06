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
            Dictionary<string, int> partyVotes = new Dictionary<string, int>();
            List<string> names = new List<string>();
            
            foreach (string party in electionResults)
            {
                string[] temp = party.Split(",");
                partyVotes.Add(temp[0], Int32.Parse(temp[1]));
            }

            foreach (KeyValuePair<string, int> kvp in partyVotes)
            {
                names.Add(kvp.Key);
            }
            //Console.WriteLine(names[0]); //Brexit Party
            //Console.WriteLine(partyVotes[names[0]]); //452321
        }
    }
}