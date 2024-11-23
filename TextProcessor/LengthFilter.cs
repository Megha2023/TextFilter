using System;
using System.Linq;

namespace TextProcessor
{
    public class LengthFilter : ITextFilter
    {
        public string Apply(string input)
        {
            return string.Join(" ", input.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries).Where(word => word.Length >= 3));
        }
    }
}