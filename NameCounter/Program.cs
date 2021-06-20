using System;
using System.IO;
using ServiceLayer;
using Microsoft.Extensions.DependencyInjection;

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

            //dependency injection 
            var serviceProvider = new ServiceCollection()
           .AddSingleton<ICounterService, CounterService>()
           .BuildServiceProvider();
            
            var counterService = serviceProvider.GetService<ICounterService>();
            
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
