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
            List<int> votes = new List<int>();
            int seats = 5; // number of seats that are to be allocated 

            foreach (string party in electionResults)
            {
                string[] results = party.Split(',', ';');
                votes.Add(Int32.Parse(results[1]));
            }
            //Console.WriteLine(votes[0]);
            for (int i = 0; i <= seats; i++)
            {
                if (votes[0] >= votes[i])
                {
                    votes[0] = votes[0] / 2; // 2 needs to be replaced with an int <variable> since it depends on how many seats the party has already got  
                }
                else
                {
                    votes[i] = votes[i] / 2; // some fixes need to be made here (incorrect division)
                }
            }
            foreach (int vote in votes)
            {
                Console.WriteLine(vote);
            }
            //Console.WriteLine(votes[0]);
        }
    }
}