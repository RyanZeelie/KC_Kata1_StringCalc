using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Helpers
{
    public interface INumberFormatter
    {
        List<int> ParseNumbers(string numbers);
        IEnumerable<string> SplitNumbers(string numbers);
    }
}
