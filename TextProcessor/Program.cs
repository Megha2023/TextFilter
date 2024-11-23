using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextProcessor
{
    internal class Program
    {
        static void Main()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\input.txt"; 

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Input file not found.");
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
                return;
            }

            string content = File.ReadAllText(filePath);
            var filters = new List<ITextFilter> { new VowelMiddleFilter(), new LengthFilter(), new LetterTFilter() };
            var processor = new TextProcessor(filters);

            string result = processor.Process(content);
            Console.WriteLine("Filtered Result:");
            Console.WriteLine(result);
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey(); 
        }
    }

}
