using System;
using System.IO;
using System.Text.RegularExpressions;

namespace readFile
{
    class Program
    {
        static void Main(string[] args)
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(@"C:\Users\User\Desktop\Sample.txt");
                  //first line
                  line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    
                    Console.WriteLine(line);
                    //Read the next line
                    line = sr.ReadLine();
                                  

                                       

                }
                
            }

            catch (Exception e)
            {
                Console.WriteLine("could not find file " + e );
            }
            finally
            {
                Console.WriteLine("End of program");
            }
            int count;

            StreamReader streamReader = File.OpenText(@"C:\Users\User\Desktop\Sample.txt");
            using (StreamReader reader = streamReader)
            {
                //(.+?)(\.[^.] *$|$)
                //
                string contents = reader.ReadToEnd();
               // var reg = new Regex(@"[^\s]+");
                MatchCollection matches = Regex.Matches(contents, "Sample", RegexOptions.IgnoreCase);
                count = matches.Count;
                Console.WriteLine(" The word Sample" + " Found " + "{1}" + " Times on this file", contents, count);
            }






        }
    }
}
