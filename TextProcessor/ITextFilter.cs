using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TextProcessor
{
    public interface ITextFilter
    {
        string Apply(string input);
    }
}
