using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriviaLetterComparer;
using System.Collections.Generic;

namespace TriviaLetterComparerTest
{
    [TestClass]
    public class WordMatcherTest
    {
        private WordMatcher wordMatcher;

        [TestInitialize]
        public void Init()
        {
            wordMatcher = new WordMatcher();
        }

        [TestMethod]
        public void FindWordsMatchingLettersTest()
        {

        }

        [TestMethod]
        public void FindWordsMatchingNotLettersOhioTest()
        {
            var wordExtractor = new WordExtractor();

            var states = new[] { "Ohio", "Montgomery" };

            var notMatching = new List<string>(wordMatcher.FindWordsMatchingNotLetters(states, "mackerel"));

            var expected = new List<string>(new[] { "Ohio" });

            CollectionAssert.AreEquivalent(expected, notMatching);
        }

        [TestMethod]
        public void FindWordsMatchingNotLettersTest()
        {
            var wordExtractor = new WordExtractor();

            var states = wordExtractor.Extract("Resources/States.txt");

            var notMatching = new List<string>(wordMatcher.FindWordsMatchingNotLetters(states, "Mackerel"));

            var expected = new List<string>(new[] { "Ohio" });

            CollectionAssert.AreEquivalent(expected, notMatching);
        }
    }
}
