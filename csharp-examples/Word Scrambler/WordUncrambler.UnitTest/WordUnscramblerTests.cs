using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordUnscrambler;

namespace UnitTestProject1
{
    [TestClass]
    public class WordUnscramblerTests
    {
        private const string worldListFileName = "wordlist.txt";

        [TestMethod]
        public void FileReader_Readlines_Test()
        {
            //Arrange
            string[] expectedValues = { "Hello", "You" };
            string[] lines = { "Hello", "You" };
            File.WriteAllLines(Path.Combine(Environment.CurrentDirectory, worldListFileName), lines);
            
            //Act
            string[] actualResult = FileReader.Read(worldListFileName);

            //Assert
            CollectionAssert.AreEqual(expectedValues, actualResult);
        }

        [TestMethod]
        public void WordMatcher_MatchWord()
        {
            //Arrange
            string[] wordList  = { "hello", "you" };
            string[] splitScrambledWords = { "ouy", "elloh" };

            List<MatchWord> expectedMatchWord = new List<MatchWord> {
                new MatchWord {ScrambleWord = "ouy", Word = "you" },
                new MatchWord { ScrambleWord = "elloh", Word = "hello" }
                
            };
            
             var actualResult =  WordMatcher.Match(splitScrambledWords, wordList);

            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(expectedMatchWord[i].ScrambleWord, actualResult[i].ScrambleWord);
                Assert.AreEqual(expectedMatchWord[i].Word, actualResult[i].Word);
                
            }


            

        }
    }
}
