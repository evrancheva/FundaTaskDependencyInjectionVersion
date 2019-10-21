using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundaTask.Interfaces
{
    public interface ITopMakelaarsRetrival<count,name>
    {
        IEnumerable<KeyValuePair<name, count>> TopMakelaars(int limit);

        IEnumerable<KeyValuePair<name, count>> TopMakelaarsWithGarden(int limit);

    }
}
