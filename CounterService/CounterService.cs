using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ServiceLayer
{
    public class CounterService : ICounterService
    {
        public int GetNumberOfTextAppearance(string path, string searchTerm)
        {
            var fileStream = File.Open(path, FileMode.Open);
            StreamReader file = new StreamReader(fileStream);

            string line;
            int counter = 0;
            while (true)
            {
                line = file.ReadLine();
                if (line == null) break; //What if the file continues after empty line
                counter += GetNumberOfTextAppearancePerLine(line, searchTerm); 
            }
            return counter;
        }

        private int GetNumberOfTextAppearancePerLine(string line, string searchTerm)
        {
            //Assumption
             //2. Multiple instances on a single line should be counted.

            if (string.IsNullOrEmpty(searchTerm))
                throw new ArgumentException("The text to search cannot be empty!");

            // Option 1
            // Count only appearance as a separate word, case insenstive, always separated by ' '

            List<string> words = line.Split(' ').ToList();
            var matchingWords = words.Where(w => string.Equals(w, searchTerm, StringComparison.InvariantCultureIgnoreCase));
            return matchingWords.Count();

            // Option 2.
            // Count all appearances                    
            //    List<int> indexes = new List<int>();
            //    for (int index = 0; ; index += searchTerm.Length)
            //    {
            //        index = line.IndexOf(searchTerm, index);
            //        if (index == -1)
            //             break;
            //        indexes.Add(index);
            //    }
            //return indexes.Count; 
        }
       
        public string ExtractFileName(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Path name can not be empty!"); 
            }
            var fileNameWithExtention = Path.GetFileName(path);
            int position = fileNameWithExtention.IndexOf('.');
            if (position <= 0)
            {
                throw new ArgumentException("Path name can not be empty!");
            }
            string name = fileNameWithExtention.Substring(0, position);
            return name;
        }

    }
}
