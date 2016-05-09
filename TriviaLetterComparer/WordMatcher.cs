using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaLetterComparer
{
    public class WordMatcher
    {
        public ICollection<string> FindWordsMatchingLetters(ICollection<string> words, string word)
        {
            throw new NotImplementedException();
        }

        public ICollection<string> FindWordsMatchingNotLetters(ICollection<string> words, string searchWord)
        {
            var result = new List<string>();
            var lwrSearch = searchWord.ToLower().Distinct();
            foreach(var word in words)
            {
                var lwrWord = word.ToLower().Distinct();
                var intersect = lwrWord.Intersect(lwrSearch);
                if (intersect.Count() == 0)
                {
                    result.Add(word);
                }
            }
            return result;
        }
    }
}
