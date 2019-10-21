using System;
using System.Collections.Generic;
using System.Text;

namespace FundaTask.Interfaces
{
    interface IPrinter
    {
        void PrintTopResults(IEnumerable<KeyValuePair<string, int>> makelaars);
    }
}
