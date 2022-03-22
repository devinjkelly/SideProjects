using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer
{
    class UserPrompts
    {
        public int PromptForSelection(string message, int minimum, int maximum, int? defaultValue = null)
        {
            string defaultPrompt = defaultValue.HasValue ? $"[{defaultValue}]: " : ": ";
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write($"{message}{defaultPrompt}");
                Console.ResetColor();
                string userInput = Console.ReadLine();

                if(userInput.Trim().Length == 0 && defaultValue.HasValue)
                {
                    return defaultValue.Value;
                }

                if(int.TryParse(userInput, out int selection) && selection >= minimum && selection <= maximum)
                {
                    return selection;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Number is out of range, please try again");
                Console.ResetColor();
            }
        }

        public string PromptForSearchWord(string message, string defaultValue = null)
        {
            string defaultPrompt = defaultValue == null ? ": " : $"[{defaultValue}]";
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write($"{message}{defaultPrompt}");
            Console.ResetColor();
            string userInput = Console.ReadLine();
            if(userInput.Length == 0 && defaultValue != null)
            {
                return defaultValue;
            }
            return userInput;
        }



    }
}
