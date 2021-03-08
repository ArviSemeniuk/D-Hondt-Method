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
            SortedList<int, int> originalVote = new SortedList<int, int>();
            int partyID = 1;
            int seats = 0;

            foreach (string party in electionResults)
            {
                string[] res = party.Split(',');
                votes.Add(partyID, Int32.Parse(res[1]));
                seatsWon.Add(partyID, seats);
                originalVote.Add(partyID, Int32.Parse(res[1]));
                partyID++;
            }

            Allocation(votes, seatsWon, originalVote);
        }

        static void Allocation(SortedList<int, int> votes, SortedList<int, int> seatsWon, SortedList<int, int> orginal)
        {
            int availableSeats = 5;

            for (int i = 1; i <= availableSeats; i++)
            {
                var orderByValue = votes.OrderByDescending(kvp => kvp.Value);
                int topVote = orderByValue.ElementAt(0).Key;
                int secondVote = orderByValue.ElementAt(1).Key;

                if (votes[topVote] > votes[secondVote])
                {
                    seatsWon[topVote] = seatsWon[topVote] + 1;
                    votes[topVote] = orginal[topVote] / (seatsWon[topVote] + 1);
                }
            }

            foreach (var seats in seatsWon)
            {
                Console.WriteLine(seats);
            }
        }
    }
}