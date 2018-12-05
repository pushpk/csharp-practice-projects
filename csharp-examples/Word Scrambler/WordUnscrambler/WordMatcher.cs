using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    public static class WordMatcher
    {
        public static List<MatchWord> Match(string[] splitScrambledWords, string[] wordsList)
        {
            List<MatchWord> matchedWords = new List<MatchWord>();

            foreach (var scrambleWord in splitScrambledWords)
            {
                foreach (var word in wordsList)
                {
                    if (scrambleWord == word)
                    {
                        matchedWords.Add(new MatchWord { ScrambleWord = scrambleWord, Word = word });
                    }

                    else
                    {
                        var scrambleWordCharArraySortedString = new string(scrambleWord.ToCharArray().OrderBy(s => s).ToArray());
                        var wordCharArraySortedString = new string(word.ToCharArray().OrderBy(s => s).ToArray());

                        if (scrambleWordCharArraySortedString.Equals(wordCharArraySortedString))
                        {
                            matchedWords.Add(new MatchWord { ScrambleWord = scrambleWord, Word = word });
                        }

                    }

                }

            }

            return matchedWords;
        }
    }
}
