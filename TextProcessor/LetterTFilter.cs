using System;
using System.Linq;

namespace TextProcessor
{
    public class LetterTFilter : ITextFilter
    {
        public string Apply(string input)
        {
            return string.Join(" ", input.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries).Where(word => !word.ToLower().Contains('t')));
        }
    }
}