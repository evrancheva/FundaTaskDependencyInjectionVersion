using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundaTask.Interfaces;

namespace FundaTask.Services
{
    class Sorter : ISorter
    {
        public IOrderedEnumerable<KeyValuePair<string, int>> SortDictionaryByDescending(Dictionary<string, int> dict)
        {
            var sortedDictionary = from pair in dict
                                   orderby pair.Value descending
                                   select pair;

            return sortedDictionary;
        }

    }
}
