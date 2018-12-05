using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    public static class ProgramManager
    {
        private const string worldListFileName = "wordlist.txt";

        public static void ExecutescramblewordInManualScenario()
        {
            string words = Console.ReadLine() ?? string.Empty;
            string[] splitScrambledWords = words.Split(',');
            DisplayMatchedWords(splitScrambledWords);
        }


        public static void ExecutescramblewordInFileScenario()
        {
            try
            {
                string fileName = Console.ReadLine() ?? string.Empty;
                string[] splitScrambledWords = FileReader.Read(fileName);
                DisplayMatchedWords(splitScrambledWords);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public static void DisplayMatchedWords(string[] splitScrambledWords)
        {

            string[] wordsList = FileReader.Read(worldListFileName);

            List<MatchWord> matchWords = WordMatcher.Match(splitScrambledWords, wordsList);
            if (matchWords.Any())
            {
                foreach (var matchedWord in matchWords)
                {
                    Console.WriteLine($"Match found for scrambled word {matchedWord.ScrambleWord} : {matchedWord.Word}");
                }

            }
            else
            {
                Console.WriteLine("NO MATCH FOUND!");
            }
        }
    }
}
