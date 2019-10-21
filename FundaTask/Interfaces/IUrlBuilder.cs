using System;
using System.Collections.Generic;
using System.Text;

namespace FundaTask.Interfaces
{
    public interface IUrlBuilder
    {
        string ConstructBaseUrlForApiCall(string type, string zo, string city, string external_space);
    }
}
