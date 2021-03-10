using System;
using System.Collections.Generic;
using System.IO;

namespace D_Hondt_Method
{
    class ReadFile
    {
        private List<string> _ElectionResults = new List<string>();
        private StreamReader _Lines = new StreamReader("../../../Assessment1Data.txt");
        private string _Line;
        private int _LineNumber;

        public List<string> ElectionResults
        {
            get { return _ElectionResults; }
            set { _ElectionResults = value; }
        }

        public StreamReader Lines
        {
            get { return _Lines; }
            set { _Lines = value; }
        }

        public string Line
        {
            get { return _Line; }
            set { _Line = value; }
        }

        public int LineNumber
        {
            get { return _LineNumber; }
            set { _LineNumber = value; }
        }
   

        public List<string> ReadResultsFromFile()
        {
            LineNumber = 4;

            for (int i = 1; i < LineNumber; i++)
                Lines.ReadLine();

            while ((Line = Lines.ReadLine()) != null)
                ElectionResults.Add(Line);

            Lines.DiscardBufferedData();
            Lines.BaseStream.Seek(0, SeekOrigin.Begin);

            return ElectionResults;
        }

        public int ReadAvailableSeats()
        {
            LineNumber = 2;
            int availableSeats;

            for (int i = 1; i < LineNumber; i++)
                Lines.ReadLine();

            availableSeats = Int32.Parse(Lines.ReadLine());

            Lines.DiscardBufferedData();
            Lines.BaseStream.Seek(0, SeekOrigin.Begin);

            return availableSeats;
        }

        public string ReadRegion()
        {
            string region;
            region = Lines.ReadLine();

            Lines.DiscardBufferedData();
            Lines.BaseStream.Seek(0, SeekOrigin.Begin);

            return region;
        }
    }
}