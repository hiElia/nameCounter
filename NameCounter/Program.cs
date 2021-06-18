using System;
using System.IO;

namespace NameCounter
{
    class Program
    {
        public static string[] args;
        //todo: why is there program under program
        Program(string[] args)
        {
            Program.args = args;
        }
        private void Run()
        {
            var path = args[0]; 
            string fileName = ExtractFileName(path);         
            int counter = GetNumberOfTextAppearance(path, fileName);            
            Console.WriteLine("found " + counter);
        }

        private string ExtractFileName(string path)
        {
            var fileNameWithExtention = Path.GetFileName(path);
            //todo: what can fail here? null reference
            int position = fileNameWithExtention.IndexOf('.');
            string name = fileNameWithExtention.Substring(0, position);
            return name; 
        }

        private int GetNumberOfTextAppearance(string path, string searchTerm)
        {
            var fileStream = File.Open(path, FileMode.Open);
            System.IO.StreamReader file = new System.IO.StreamReader(fileStream);

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

        static void Main(string[] args)
        {
            Program program = new Program(args);
            program.Run();
        }
    }
}
