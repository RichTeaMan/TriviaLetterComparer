using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriviaLetterComparer;
using System.Collections.Generic;

namespace TriviaLetterComparerTest
{
    [TestClass]
    public class WordExtractorTest
    {
        private WordExtractor wordExtractor;

        [TestInitialize]
        public void Init()
        {
            wordExtractor = new WordExtractor();
        }

        [TestMethod]
        public void TestWordExtractor()
        {
            // Expectations
            var expectations = new HashSet<string>() {
                "Alabama",
                "Alaska",
                "Arizona",
                "Arkansas",
                "California"
           };

            //Test
            var result = wordExtractor.Extract("Resources/StatesShort.txt");

            // Assert
            Assert.IsTrue(expectations.SetEquals(result));
        }
    }
}
