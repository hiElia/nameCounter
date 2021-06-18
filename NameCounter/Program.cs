using System;
using System.IO;
using System.Text;

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
            var f = File.Open(args[0], FileMode.Open);
            int pos = args[0].IndexOf('.');
            string name = args[0].Substring(0, pos);            
            System.IO.StreamReader file = new System.IO.StreamReader(f);
            string line;
            //int counter = 0;
            int counter = GetNumberOfTextAppearance(file, name); 
            while (true)
            {
                line = file.ReadLine();
                if (line == null) break; //What if the file continues after empty line
                if (line.Contains(name)) //What if there are multiple number of the name in every line
                    counter++;
            }
            Console.WriteLine("found " + counter);
        }

        private int GetNumberOfTextAppearance(StreamReader file, string name)
        {
            string line;
            while (true)
            {
                line = file.ReadLine();
                if (line == null) break; //What if the file continues after empty line
                if (line.Contains(name)) //What if there are multiple number of the name in every line
                    counter++;
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program(args);
            program.Run();
        }
    }
}
