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
            List<string> electionResults = read.ReadResultsFromFile();
            ComputeResults(electionResults);
            int availableSeats = read.ReadAvailableSeats();
            Console.WriteLine(availableSeats);
        }

        static void ComputeResults(List<string> electionResults)
        {
            SortedList<int, string> partySeats = new SortedList<int, string>();
            SortedList<int, string> partyName = new SortedList<int, string>();
            SortedList<int, int> votes = new SortedList<int, int>();
            SortedList<int, int> seatsWon = new SortedList<int, int>();
            SortedList<int, int> originalVote = new SortedList<int, int>();
            
            int partyID = 1;
            int seats = 0;

            foreach (string party in electionResults)
            {
                string seatsTemp = "";
                string[] res = party.Split(',');

                partyName.Add(partyID, res[0]);
                votes.Add(partyID, Int32.Parse(res[1]));
                seatsWon.Add(partyID, seats);
                originalVote.Add(partyID, Int32.Parse(res[1]));

                for (int i = 2; i < res.Length; i++)
                {
                    if (i==2){
                        seatsTemp = res[i];
                    }
                    else {
                        seatsTemp = seatsTemp +","+ res[i];
                    }
                }

                seatsTemp = seatsTemp.Remove(seatsTemp.Length - 1, 1); // Removes semicolon from the end of the string
                partySeats.Add(partyID, seatsTemp);
                
                partyID++;
            }

            Allocation(partyName, partySeats, votes, seatsWon, originalVote);
        }

        static void Allocation(SortedList<int, string> partyName, SortedList<int, string> partySeats, SortedList<int, int> votes, SortedList<int, int> seatsWon, SortedList<int, int> orginal)
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

            DisplayResults(seatsWon, partySeats, partyName);
        }

        static void DisplayResults(SortedList<int, int> seatsWon, SortedList<int, string> partySeats, SortedList<int, string> partyName)
        {
            Console.WriteLine("East Midlands (European Parliament Constituency)");
            foreach (var seats in seatsWon)
            {
                if (seats.Value > 0)
                {
                    string partySeatsAllocated = "";
                    string[] sTemp = partySeats[seats.Key].Split(',');
                    for (int i = 0; i < seats.Value; i++)
                    {
                        if (i == 0)
                        {
                            partySeatsAllocated = sTemp[i];
                        }
                        else
                        {
                            partySeatsAllocated = partySeatsAllocated + "," + sTemp[i];
                        }

                    }
                    Console.WriteLine(partyName[seats.Key] + ": " + partySeatsAllocated);
                }
            }
        }
    }
}