using System;
using System.IO;

namespace ServiceLayer
{
    public class CounterService
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
                if (line.Contains(searchTerm)) //What if there are multiple number of the name in every line
                    counter++;
            }
            return counter;
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
