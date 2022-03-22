using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextAnalyzer
{
    class Demo
    {
        private static string testTextFile;
        static void MainDemo()
        {
            Console.WriteLine("Hello World!");


            //Use the Alice in Wonderland Text in our previous project to work through making a text analyzer for several different levels.
            //One, looking at each of the words that is used and adding it into a dictionary 
            //Two, if the same word is used sequentially in a certain order, that also counts towards a potential tag.
            //Build User interface on when they submit a document and how it would tell the user about the suggested tags.
            //Finally, see if we can build towards themes by generating suggestions based on the number of words
            //used what theme the text may fall under because of the number of words used.



            //Eventually I'd like to do this for a visual interface, look at deepfaking as that is something in reverse it


            //Example - 223 So she was considering in her own mind (as well as she could, for the

            string currDir = Environment.CurrentDirectory;
            string mainProjDir = Directory.GetParent(currDir).Parent.Parent.Parent.FullName;
            mainProjDir = mainProjDir.Replace("\\", "/");
            testTextFile = $"{mainProjDir}/TextAnalyzer/alices_adventures_in_wonderland.txt";

            Console.WriteLine(testTextFile);
            List<char> symbols = new List<char>() { ',', '.', '/', ';', '\'', '[', ']', '\\', '-', '=', '<', '>', '?', ':', '"', '{', '}', '|', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', ' ' };
            List<string> symbolString = new List<string>() { ",", ".", "/", ";", "'", "[", "]", "\\", "-", "=", "<", ">", "?", ":", "\"", "{", "}", "|", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", " ", "_", "+" };
            Dictionary<string, int> wordMeasurementDictionary = new Dictionary<string, int>();
            Dictionary<string, int> questionDictionary = new Dictionary<string, int>();
            string[] lineHolder = new string[] { };
            string[] questionHolder = new string[] { };
            //Console.Write("What word are you looking to highlight in the text? (Press Enter if you want to skip) ");
            //string searchWord = Console.ReadLine();


            try
            {
                using (StreamReader sr = new StreamReader(testTextFile))
                {
                    //while (!sr.EndOfStream)
                    //{
                    //    string line = sr.ReadLine();
                    //    Console.WriteLine(line);
                    //}
                    int j = 0;
                    while (!sr.EndOfStream)
                    {
                        j++;
                        string line = sr.ReadLine();
                        string lineLower = line.ToLower();


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



                        //This For Loop is to determine when a question is posed and how to get the whole question into the dictionary.
                        //questionHolder = line.Split(". ");
                        //for (int i = 0; i < questionHolder.Length; i++)
                        //{
                        //    if (line.Contains("?"))
                        //    {

                        //        for (int l = 0; l < questionHolder.Length; l++)
                        //        {
                        //            if (questionHolder[l].EndsWith("?"))
                        //            {
                        //                Console.WriteLine(questionHolder[l]);
                        //            }

                        //        }
                        //    }
                        //}

                        //Loop for trying to get a word and highlight the word.
                        //if(searchWord != "")
                        //{
                        //    string changedLine = line.ToLower();
                        //    string changedSearchWord = searchWord.ToLower();
                        //    if (changedLine.Contains(changedSearchWord))
                        //    {
                        //        Console.WriteLine();
                        //    }
                        //}





                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Retrieving file does not exist");
            }

            var items = from pair in wordMeasurementDictionary
                        orderby pair.Value descending
                        select pair;



            foreach (KeyValuePair<string, int> item in items)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }


























            //******************************************************************************************************************************************************
            //Practice:

            /*Word seperation trial and error:

            //Example of pulling the words out
            if (j == 223)
            {
                lineHolder = line.Split(" ");
                for (int p = 0; p < lineHolder.Length; p++)
                {
                    if (wordMeasurementDictionary.ContainsKey(lineHolder[p]))
                    {
                        wordMeasurementDictionary[lineHolder[p]] += 1;
                    }
                    else
                    {
                        wordMeasurementDictionary[lineHolder[p]] = 1;
                    }
                }
            }

            Trying to find the separations of words.
            Console.WriteLine(j + " " + line);
            if (j == 223)
            {
                for (int p = 0; p < line.Length; p++)
                {
                    string[] word = line[p].Split(" ");
                }                            
            }*/
        }
    }
}
