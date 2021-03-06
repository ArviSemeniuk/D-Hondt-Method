using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D_Hondt_Method
{
    class ReadFile
    {
        public List<string> ReadResultsFromFile(string filename)
        {
            string line;
            List<string> electionResults = new List<string>();

            StreamReader lines = new StreamReader(filename);

            for (int i = 1; i < 4; i++)
                lines.ReadLine();

            while ((line = lines.ReadLine()) != null)
                electionResults.Add(line);

            return electionResults;
        }
    }
}
