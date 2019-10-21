using System;
using System.Collections.Generic;
using System.Text;
using FundaTask.Interfaces;

namespace FundaTask.Services
{
    class Printer : IPrinter
    {
 
        public void PrintTopResults(IEnumerable<KeyValuePair<string, int>> results)
        {
            foreach (var result in results)
            {
                Console.WriteLine("{0,40} | {1}", result.Key, result.Value);
            }
        }
    }
}
