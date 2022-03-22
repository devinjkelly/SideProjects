using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextAnalyzer
{
    class ConsoleBase
    {
        private readonly Menus menu = new Menus();
        private readonly UserPrompts prompts = new UserPrompts();
        private static string CurrDir = Environment.CurrentDirectory;
        private static string mainProjDir = Directory.GetParent(CurrDir).Parent.Parent.Parent.FullName;
        private string NewMainProjDir = mainProjDir.Replace("\\", "/");
        private string TestTextFile;
        private bool Analysis1 { get; set; } = false;
        private bool Analysis2 { get; set; } = false;
        private bool Analysis3 { get; set; } = false;
        private bool Analysis4 { get; set; } = false;
        private string SearchWord { get; set; }
        Dictionary<string, int> wordMeasurementDictionary { get; set; } = new Dictionary<string, int>();

        public void Run()
        {
            while (true)
            {
                menu.PrintMainMenu();
                int menuSelection = prompts.PromptForSelection("Please choose an option", 0, 3);

                if (menuSelection == 0)
                {
                    //Exit the loop
                    break;

                }
                if (menuSelection == 1)
                {

                    TestTextFile = $"{NewMainProjDir}/TextAnalyzer/alices_adventures_in_wonderland.txt";
                    TextAnalyizesRun();
                }
                if (menuSelection == 2)
                {
                    TestTextFile = $"{NewMainProjDir}/TextAnalyzer/dr_jekyll_mr_hyde.txt";
                    TextAnalyizesRun();
                }
                if (menuSelection == 3)
                {
                    Console.WriteLine("What is the fully qualified name of the file that should be analyzed?");
                    TestTextFile = Console.ReadLine();
                    TextAnalyizesRun();
                }
            }
        }

        private void TextAnalyizesRun()
        {
            while (true)
            {
                menu.PrintTextAnalyzerUserSelection();
                int analysisSelection = prompts.PromptForSelection("Please choose an option", 0, 4);
                if (analysisSelection == 0)
                {
                    break;
                }
                if (analysisSelection == 1)
                {
                    //Runs to see all words and each word's count.
                    Analysis1 = true;
                    StreamReading();
                    DictionaryAndListResults();
                    Console.ReadLine();
                    wordMeasurementDictionary.Clear();
                }
                if (analysisSelection == 2)
                {
                    //Search for a word and give its count.
                    Analysis2 = true;
                    SearchWord = prompts.PromptForSearchWord("Please type the word you'd like to search");
                    StreamReading();
                    DictionaryAndListResults();
                    Console.ReadLine();
                    wordMeasurementDictionary.Clear();
                    Analysis2 = false;
                }
                if (analysisSelection == 3)
                {
                    //Search for a word and highlight it in the story.
                    Analysis3 = true;
                    SearchWord = prompts.PromptForSearchWord("Please type the word you'd like to highlight");
                    StreamReading();                    
                    Console.ReadLine();
                }
                if (analysisSelection == 4)
                {
                    Analysis4 = true;
                    StreamReading();
                    DictionaryAndListResults();
                    Console.ReadLine();
                }
            }

        }

        private void StreamReading()
        {            
            List<string> symbolString = new List<string>() { ",", ".", "/", ";", "'", "[", "]", "\\", "-", "=", "<", ">", "?", ":", "\"", "{", "}", "|", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", " ", "_", "+" };
            Dictionary<string, int> questionDictionary = new Dictionary<string, int>();
            string[] lineHolder = new string[] { };
            string[] questionHolder = new string[] { };
            try
            {
                using (StreamReader sr = new StreamReader(TestTextFile))
                {
                    int j = 0;
                    while (!sr.EndOfStream)
                    {
                        j++;
                        string line = sr.ReadLine();
                        string lineLower = line.ToLower();

                        if (Analysis1)
                        {
                            //This for loop is to determine how many words were used and how many times each word was used.
                            lineHolder = line.Split(" ");
                            for (int p = 0; p < lineHolder.Length; p++)
                            {
                                string newLineHolder = lineHolder[p];
                                //The following ForEach Loop is able to subtract any symbol from a word and compile it into the dictionary.
                                foreach (string item in symbolString)
                                {
                                    if (lineHolder[p].Contains(item))
                                    {
                                        newLineHolder = lineHolder[p].Replace(item, "");
                                    }

                                }
                                if (wordMeasurementDictionary.ContainsKey(newLineHolder))
                                {
                                    wordMeasurementDictionary[newLineHolder] += 1;
                                }
                                else
                                {
                                    wordMeasurementDictionary[newLineHolder] = 1;
                                }
                            }
                        }

                        if (Analysis2)
                        {
                            //This loop is to pull out one specific word to look at.

                            lineHolder = line.Split(" ");

                            for (int p = 0; p < lineHolder.Length; p++)
                            {
                                string newLineHolder = lineHolder[p];
                                //The following ForEach Loop is able to subtract any symbol from a word and compile it into the dictionary.
                                foreach (string item in symbolString)
                                {
                                    if (lineHolder[p].Contains(item))
                                    {
                                        newLineHolder = lineHolder[p].Replace(item, "");
                                    }
                                }
                                if (wordMeasurementDictionary.ContainsKey(newLineHolder) && SearchWord == newLineHolder)
                                {
                                    wordMeasurementDictionary[newLineHolder] += 1;
                                }
                                else if (SearchWord == newLineHolder)
                                {
                                    wordMeasurementDictionary[newLineHolder] = 1;
                                }
                            }
                        }

                        if (Analysis3)
                        {
                            if (SearchWord != "")
                            {
                                string changedLine = line.ToLower();
                                string changedSearchWord = SearchWord.ToLower();
                                if (changedLine.Contains(changedSearchWord))
                                {
                                    lineHolder = line.Split(" ");
                                    for (int i = 0; i < lineHolder.Length; i++)
                                    {
                                        if (lineHolder[i] == changedSearchWord || lineHolder[i] == SearchWord)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                            Console.Write($"{lineHolder[i]} ");
                                            Console.ResetColor();
                                        }
                                        else
                                        {
                                            Console.Write($"{lineHolder[i]} ");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(line);
                                }
                            }
                        }

                        if (Analysis4)
                        {
                            //This For Loop is to determine when a question is posed and how to get the whole question into the dictionary.
                            questionHolder = line.Split(". ");
                            for (int i = 0; i < questionHolder.Length; i++)
                            {
                                if (line.Contains("?"))
                                {

                                    for (int l = 0; l < questionHolder.Length; l++)
                                    {
                                        if (questionHolder[l].EndsWith("?"))
                                        {
                                            Console.WriteLine(questionHolder[l]);
                                        }

                                    }
                                }
                            }
                        }







                    }

                }
            }

            catch (Exception)
            {
                Console.WriteLine("Retrieving file does not exist");
            }

        }

        private void DictionaryAndListResults()
        {
            if (Analysis1 || Analysis2)
            {
                var items = from pair in wordMeasurementDictionary
                            orderby pair.Value descending
                            select pair;


                Console.Clear();
                Console.WriteLine("Please find your results below!");
                foreach (KeyValuePair<string, int> item in items)
                {
                    Console.WriteLine($"{item.Key} {item.Value}");
                }
            }

            Analysis1 = false;
            Analysis2 = false;
            Analysis3 = false;
            Analysis4 = false;
        }


    }
}
