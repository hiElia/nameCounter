using System;
using System.IO;

namespace NameCounter
{
    class Program
    {
        public static string[] args;
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
            //todo: what can fail here? null reference
            int position = path.IndexOf('.');
            string name = path.Substring(0, position);
            return name; 
        }

        private int GetNumberOfTextAppearance(string path, string name)
        {
            var fileStream = File.Open(path, FileMode.Open);
            System.IO.StreamReader file = new System.IO.StreamReader(fileStream);

            string line;
            int counter = 0;
            while (true)
            {
                line = file.ReadLine();
                if (line == null) break; //What if the file continues after empty line
                if (line.Contains(name)) //What if there are multiple number of the name in every line
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
