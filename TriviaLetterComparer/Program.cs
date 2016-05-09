using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaLetterComparer
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordExtractor = new WordExtractor();

            Console.WriteLine("Reading States");
            var states = wordExtractor.Extract("Resources/States.txt");

            Console.WriteLine("Reading words");
            var words = wordExtractor.Extract("Resources/Words.txt");

            var wordMatcher = new WordMatcher();

            Console.WriteLine("Processing words...");
            using (var fs = new FileStream("output.txt", FileMode.Create))
            using (var tw = new StreamWriter(fs))
            {
                int count = 0;
                foreach (var word in words)
                {
                    if (word == "mackerel")
                    {
                        Console.WriteLine("!");
                    }
                    var finds = wordMatcher.FindWordsMatchingNotLetters(states, word);
                    if (finds.Count() == 50)
                    {
                        string line = string.Format("All match - {0}", word);
                        tw.WriteLine(line);
                    }
                    else if(finds.Count() == 1)
                    {
                        string line = string.Format("{0} - {1}", finds.First(), word);
                        tw.WriteLine(line);
                    }
                    count++;
                    if (count % 50 == 0)
                    {
                        Console.WriteLine("{0} of {1} complete.", count, words.Count);
                    }
                }
            }
        }
    }
}
