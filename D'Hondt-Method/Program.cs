using System;
using System.Linq;
using System.Collections.Generic;

namespace D_Hondt_Method
{
    class Program
    {
        private static int _AvailableSeats;
        private static string _Region;
        private static SortedList<int, string> _PartySeats = new SortedList<int, string>();
        private static SortedList<int, string> _PartyName = new SortedList<int, string>();

        public static int AvailableSeats
        {
            get { return _AvailableSeats; }
            set { _AvailableSeats = value; }
        }

        public static string Region
        {
            get { return _Region; }
            set { _Region = value; }
        }

        public static SortedList<int, string> PartySeats
        {
            get { return _PartySeats; }
            set { _PartySeats = value; }
        }

        public static SortedList<int, string> PartyName
        {
            get { return _PartyName; }
            set { _PartyName = value; }
        }

        static void Main(string[] args)
        {
            ReadFile read = new ReadFile();

            AvailableSeats = read.ReadAvailableSeats();
            Region = read.ReadRegion();
            List<string> electionResults = read.ReadResultsFromFile();

            ComputeResults(electionResults);
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
                string seatsTemp = "";
                string[] res = party.Split(',');

                PartyName.Add(partyID, res[0]);
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
                PartySeats.Add(partyID, seatsTemp);
                
                partyID++;
            }

            Allocation(votes, seatsWon, originalVote);
        }

        static void Allocation(SortedList<int, int> votes, SortedList<int, int> seatsWon, SortedList<int, int> orginal)
        {
            for (int i = 1; i <= AvailableSeats; i++)
            {
                var orderByValue = votes.OrderByDescending(kvp => kvp.Value);
                int topVote = orderByValue.ElementAt(0).Key;

                seatsWon[topVote] = seatsWon[topVote] + 1;
                votes[topVote] = orginal[topVote] / (seatsWon[topVote] + 1);
            }

            DisplayResults(seatsWon);
        }

        static void DisplayResults(SortedList<int, int> seatsWon)
        {
            Console.WriteLine(Region);
            foreach (var seats in seatsWon)
            {
                if (seats.Value > 0)
                {
                    string partySeatsAllocated = "";
                    string[] sTemp = PartySeats[seats.Key].Split(',');
                    for (int i = 0; i < seats.Value; i++)
                    {
                        if (i == 0)
                        {
                            partySeatsAllocated = sTemp[i];
                        }
                        else
                        {
                            try // Prevents error if the number of seats in the .txt file is above 12
                            {
                                partySeatsAllocated = partySeatsAllocated + "," + sTemp[i];
                            }
                            catch { } 
                        }
                    }
                    Console.WriteLine(PartyName[seats.Key] + ": " + partySeatsAllocated);
                }
            }
        }
    }
}