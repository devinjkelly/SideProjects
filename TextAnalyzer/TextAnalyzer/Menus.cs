using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer
{
    class Menus
    {
        public void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Text Analyzer");
            Console.WriteLine("------------------------");
            Console.WriteLine("This is a text analyzer application " +
                           "\n where we are looking to help understand" +
                           "\n text properties just a bit more.");
            Console.WriteLine("Below there are several options to select from:");
            Console.WriteLine("1: Alice's Adventures in Wonderland");
            Console.WriteLine("2: Dr. Jekyll and Mr. Hyde");
            Console.WriteLine("3: Choose your own Text File");
            Console.WriteLine("------------------------");


        }

        public void PrintTextAnalyzerUserSelection()
        {
            Console.Clear();
            Console.WriteLine("Thank you for your selection");
            Console.WriteLine("------------------------");
            Console.WriteLine("Below there are several options to select from:");
            Console.WriteLine("1: Pull out each word and how many times its used.");
            Console.WriteLine("2: Find a specific word and it's count");
            Console.WriteLine("3: Highlight a word in a text");
            Console.WriteLine("4: Find each question in the text.");
            Console.WriteLine("5: COMING SOON");
            Console.WriteLine("6: COMING SOON");
            Console.WriteLine("7: COMING SOON");
            Console.WriteLine("------------------------");

        }

    }
}
