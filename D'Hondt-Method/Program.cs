using System;
using System.Linq;
using System.IO;
using System.Collections;
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
            SortedList<int, int> votes = new SortedList<int, int>();
            SortedList<int, int> seatsWon = new SortedList<int, int>();
            int partyID = 1;
            int seats = 0;

            foreach (string party in electionResults)
            {
                string[] res = party.Split(',');
                votes.Add(partyID, Int32.Parse(res[1]));
                seatsWon.Add(partyID, seats);
                partyID++;
            }

            // Console.WriteLine(votes[1]); // Output: 452321
            // Console.WriteLine(seatsWon[1]); // Output: 0
            // int x = votes[1] /= 2; 
            // Console.WriteLine(x); // Output: 226160
            //votes[1] /= 3;

            //var orderByValue = votes.OrderByDescending(kvp => kvp.Value);
            //int top = orderByValue.ElementAt(0).Key;
            //votes[top] /= 2;
            //Console.WriteLine(votes[top]);
            
        }

        static void Allocation(Dictionary<string, int> partyVotes, List<string> names, List<int> originalVote)
        {
            int seatsAvailable = 5;
            int seatsWon = 0;

            for (int i = 1; i < seatsAvailable; i++)
            {
   
                //while (partyVotes[] > partyVotes[])
                {
                    seatsWon++;
                    partyVotes[names[0]] = partyVotes[names[0]] / (seatsWon + 1);
                }
            }
        }
    }
}