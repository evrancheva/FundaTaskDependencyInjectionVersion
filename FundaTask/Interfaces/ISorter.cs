using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundaTask.Interfaces
{
    interface ISorter
    {
         IOrderedEnumerable<KeyValuePair<string, int>> SortDictionaryByDescending(Dictionary<string, int> dict);
    }
}
