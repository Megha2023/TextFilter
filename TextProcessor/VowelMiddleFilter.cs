using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextProcessor
{
    public class VowelMiddleFilter : ITextFilter
    {
        private readonly HashSet<char> _vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        private static readonly Regex NonAlphanumericRegex = new Regex("[^a-zA-Z0-9]", RegexOptions.Compiled);

        public string Apply(string input)
        {
            return string.Join(" ", input.Split(' ').Where(word =>
            {
                word = NonAlphanumericRegex.Replace(word, "").Trim();
                var len = word.Length;
                if (len < 2) return true; 

                var middleIndex = len / 2;

                if (len % 2 == 0)
                {
                    return !_vowels.Contains(word[middleIndex - 1]) && !_vowels.Contains(word[middleIndex]);
                }
                else
                {
                    return !_vowels.Contains(word[middleIndex]);
                }
            }));
        }
    }
}