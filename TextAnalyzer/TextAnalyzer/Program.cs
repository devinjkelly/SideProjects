using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalyzer
{
    class Program
    {
        private static string testTextFile;
        public static string SentenceBeginningInLastLine = "IsEmPtY";
        static void Main(string[] args)
        {
            //ConsoleBase app = new ConsoleBase();
            //app.Run();



            //Console.WriteLine("Hello World!");


            ////Use the Alice in Wonderland Text in our previous project to work through making a text analyzer for several different levels.
            ////One, looking at each of the words that is used and adding it into a dictionary 
            ////Two, if the same word is used sequentially in a certain order, that also counts towards a potential tag.
            ////Build User interface on when they submit a document and how it would tell the user about the suggested tags.
            ////Finally, see if we can build towards themes by generating suggestions based on the number of words
            ////used what theme the text may fall under because of the number of words used.

            ////Next objective, define what a sentence is as well as a question and use that to help parse out your text.


            ////Eventually I'd like to do this for a visual interface, look at deepfaking as that is something in reverse it


            ////Example - 223 So she was considering in her own mind (as well as she could, for the

            string currDir = Environment.CurrentDirectory;
            string mainProjDir = Directory.GetParent(currDir).Parent.Parent.Parent.FullName;
            mainProjDir = mainProjDir.Replace("\\", "/");
            testTextFile = $"{mainProjDir}/TextAnalyzer/alices_adventures_in_wonderland.txt";
            List<string> statements = new List<string>();
            bool continuesToNextLine = false;
            int blankLine = 0;
            Console.WriteLine(testTextFile);
            List<string> sentenceEnders = new List<string>() { ". ", "... ", "? ", "! " };
            //List<string> symbolsWithSpaces = new List<string>() { ", ", ". ", "/", ";", "\'", "[", "]", "\\", "-", "=", '<', '>', '?', ':', '"', '{', '}', '|', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', ' ' };
            List<string> symbolString = new List<string>() { ",", ".", "/", ";", "'", "[", "]", "\\", "-", "=", "<", ">", "?", ":", "\"", "{", "}", "|", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", " ", "_", "+" };
            Dictionary<string, int> wordMeasurementDictionary = new Dictionary<string, int>();
            Dictionary<string, int> questionDictionary = new Dictionary<string, int>();
            string[] lineHolder = new string[] { };
            string[] statementHolder = new string[] { };
            Console.Write("What word are you looking to highlight in the text? (Press Enter if you want to skip) ");
            string searchWord = Console.ReadLine();


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
                        //string lineLower = line.ToLower();


                        //            //////This for loop is to determine how many words were used and how many times each word was used.
                        //            //lineHolder = line.Split(" ");
                        //            //for (int p = 0; p < lineHolder.Length; p++)
                        //            //{
                        //            //    string newLineHolder = lineHolder[p];
                        //            //    //    //The following ForEach Loop is able to subtract any symbol from a word and compile it into the dictionary.
                        //            //    foreach (string item in symbolString)
                        //            //    {
                        //            //        if (lineHolder[p].Contains(item))
                        //            //        {
                        //            //            newLineHolder = lineHolder[p].Replace(item, "");
                        //            //        }

                        //            //    }
                        //            //    if (wordMeasurementDictionary.ContainsKey(newLineHolder))
                        //            //    {
                        //            //        wordMeasurementDictionary[newLineHolder] += 1;
                        //            //    }
                        //            //    else
                        //            //    {
                        //            //        wordMeasurementDictionary[newLineHolder] = 1;
                        //            //    }
                        //            //}



                        //            //////This For Loop is to determine when a question is posed and how to get the whole question into the dictionary.
                        //            /////I have to create a statement list in order to keep track of the number of statements there are. 
                        //            /////I can then divide the whole program into the statement list and do another method to seperate it out into different lists (question list, period list, exclamation list,
                        //            /////Finally, I can then separate the lists so that i can draw forth specific word searches in them.
                        //            /////




                        /*
                        string newLine = line.Replace(". ", ". |[holding]|").Replace("? ", "? |[holding]|").Replace("! ", "! |[holding]|").Replace(".\" ", ".\" |[holding]|").Replace("?\" ", "?\" |[holding]|").Replace("!\" ", "!\" |[holding]|");
                        statementHolder = newLine.Split("|[holding]|");
                        string mayNeedToRemove = $"|||MAYNEEDTOREMOVE||| ";

                        //if (j >= 2628 && j <= 2629)
                        //{
                        for (int i = 0; i < statementHolder.Length; i++)
                        {
                            if (statementHolder[i] == "")
                            {
                                blankLine += 1;
                            }
                            //if ((!statementHolder.Contains(".") || !statementHolder.Contains("!") || !statementHolder.Contains("?")))


                            if (statementHolder[i] != "")
                            {
                                if (statementHolder[i].EndsWith(". ") || statementHolder[i].EndsWith("."))
                                {
                                    continuesToNextLine = true;
                                }
                                else
                                {
                                    if (SentenceBeginningInLastLine.Contains("IsEmPtY"))
                                    {

                                        SentenceBeginningInLastLine = statementHolder[i].Trim();
                                    }
                                    else
                                    {
                                        SentenceBeginningInLastLine = $"{SentenceBeginningInLastLine} {statementHolder[i].Trim()} ";
                                    }
                                }
                                if (continuesToNextLine && SentenceBeginningInLastLine != "IsEmPtY")
                                {
                                    string fullSentence = $"{SentenceBeginningInLastLine} {statementHolder[i].Trim()}";
                                    statements.Add(fullSentence);
                                    continuesToNextLine = false;
                                    SentenceBeginningInLastLine = "IsEmPtY";
                                }
                                else if (continuesToNextLine)
                                {
                                    statements.Add(statementHolder[i].Trim());
                                    continuesToNextLine = false;
                                }
                            }

                            */

                            //Trying to grab a specific word length through spaces and the rollback to a bool of if a period is positive.

                            string newsLine = line.Replace(" ", " |[holding]|");
                            statementHolder = newLine.Split("|[holding]|");
                            string mayNeedToRemove = $"|||MAYNEEDTOREMOVE||| ";

                            //if (j >= 2628 && j <= 2629)
                            //{
                            for (int i = 0; i < statementHolder.Length; i++)
                            {
                                if (statementHolder[i] == "")
                                {
                                    blankLine += 1;
                                }
                                //if ((!statementHolder.Contains(".") || !statementHolder.Contains("!") || !statementHolder.Contains("?")))


                                if (statementHolder[i] != "")
                                {
                                    if (statementHolder[i].EndsWith(". ") || statementHolder[i].EndsWith("."))
                                    {
                                        continuesToNextLine = true;
                                    }
                                    else
                                    {
                                        if (SentenceBeginningInLastLine.Contains("IsEmPtY"))
                                        {

                                            SentenceBeginningInLastLine = statementHolder[i].Trim();
                                        }
                                        else
                                        {
                                            SentenceBeginningInLastLine = $"{SentenceBeginningInLastLine} {statementHolder[i].Trim()} ";
                                        }
                                    }
                                    if (continuesToNextLine && SentenceBeginningInLastLine != "IsEmPtY")
                                    {
                                        string fullSentence = $"{SentenceBeginningInLastLine} {statementHolder[i].Trim()}";
                                        statements.Add(fullSentence);
                                        continuesToNextLine = false;
                                        SentenceBeginningInLastLine = "IsEmPtY";
                                    }
                                    else if (continuesToNextLine)
                                    {
                                        statements.Add(statementHolder[i].Trim());
                                        continuesToNextLine = false;
                                    }
                                }






                                //                    ///CURRENTLY WORKS FOR PULLING ANY SENTENCE THAT ENDS WITH A PERIOD AND EVERYTHING TO THE NEXT PERIOD (OR BEFORE).
                                //                    ////if (statementHolder[i] != "")
                                //                    ////{
                                //                    //if (statementHolder[i].EndsWith(". ") || statementHolder[i].EndsWith("."))
                                //                    //{
                                //                    //    continuesToNextLine = true;
                                //                    //}
                                //                    //else
                                //                    //{
                                //                    //    if (SentenceBeginningInLastLine.Contains("IsEmPtY"))
                                //                    //    {

                                //                    //        SentenceBeginningInLastLine = statementHolder[i].Trim();
                                //                    //    }
                                //                    //    else
                                //                    //    {
                                //                    //        SentenceBeginningInLastLine = $"{SentenceBeginningInLastLine} {statementHolder[i].Trim()} ";
                                //                    //    }
                                //                    //}
                                //                    //if (continuesToNextLine && SentenceBeginningInLastLine != "IsEmPtY")
                                //                    //{
                                //                    //    string fullSentence = $"{SentenceBeginningInLastLine} {statementHolder[i].Trim()}";
                                //                    //    statements.Add(fullSentence);
                                //                    //    continuesToNextLine = false;
                                //                    //    SentenceBeginningInLastLine = "IsEmPtY";
                                //                    //}
                                //                    //else if (continuesToNextLine)
                                //                    //{
                                //                    //    statements.Add(statementHolder[i].Trim());
                                //                    //    continuesToNextLine = false;
                                //                    //}
                                //                    ////}



                                //                }
                            }





                            //            ////Loop for trying to get a word and highlight the word.
                            //            //if (searchWord != "")
                            //            //{
                            //            //    string changedLine = line.ToLower();
                            //            //    string changedSearchWord = searchWord.ToLower();
                            //            //    if (changedLine.Contains(changedSearchWord))
                            //            //    {
                            //            //        lineHolder = line.Split(" ");
                            //            //        for (int i = 0; i < lineHolder.Length; i++)
                            //            //        {
                            //            //            if (lineHolder[i] == changedSearchWord || lineHolder[i] == searchWord)
                            //            //            {
                            //            //                Console.ForegroundColor = ConsoleColor.DarkBlue;
                            //            //                Console.Write($"{lineHolder[i]} ");
                            //            //                Console.ResetColor();
                            //            //            }
                            //            //            else
                            //            //            {
                            //            //                Console.Write($"{lineHolder[i]} ");
                            //            //            }
                            //            //        }
                            //            //    }
                            //            //    else
                            //            //    {
                            //            //        Console.WriteLine(line);
                            //            //    }
                            //            //}

                            //            //I'd like to make a list of search words as well. That way if there are multiple elements that the user is trying to draw out I can provide it.



                        }
                }
            }

            catch (Exception)
            {
                Console.WriteLine("Retrieving file does not exist");
            }

            //var items = from pair in wordMeasurementDictionary
            //            orderby pair.Value descending
            //            select pair;



            ////foreach (KeyValuePair<string, int> item in items)
            ////{
            ////    Console.WriteLine($"{item.Key} {item.Value}");
            ////}
            int o = 0;
            foreach (string item in statements)
            {
                o++;
                Console.WriteLine($"{o}) {item}");
            }


        }
    }
}
