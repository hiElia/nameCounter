using System;
using System.IO;
using ServiceLayer; 

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
            
            //todo : dependency injection 
            var counterService = new CounterService();

            string fileName = counterService.ExtractFileName(path);            

            int counter = counterService.GetNumberOfTextAppearance(path, fileName);
            Console.WriteLine("found " + counter);
        }

        static void Main(string[] args)
        {
            Program program = new Program(args);
            program.Run();
        }
    }
}
