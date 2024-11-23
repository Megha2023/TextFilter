using System.Collections.Generic;
using System.Linq;

namespace TextProcessor
{
    public class TextProcessor
    {
        private readonly IEnumerable<ITextFilter> _filters;

        public TextProcessor(IEnumerable<ITextFilter> filters)
        {
            _filters = filters;
        }

        public string Process(string input)
        {
            return _filters.Aggregate(input, (current, filter) => filter.Apply(current));
        }
    }
}