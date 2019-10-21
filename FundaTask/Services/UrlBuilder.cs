using System;
using System.Collections.Generic;
using System.Text;
using FundaTask.Interfaces;

namespace FundaTask.Services
{
    class UrlBuilder : IUrlBuilder
    {
        private const string API_KEY = "ac1b0b1572524640a0ecc54de453ea9f";
        public string ConstructBaseUrlForApiCall(string type, string zo, string city, string external_space)
        {
            var parameters = "Aanbod.svc/json/";

            parameters += API_KEY + "/";

            if (type != null)
            {
                parameters += "?type=" + type;
                parameters += "&zo=" + zo;

            }
            if (city != null)
            {
                parameters += "/" + city + "/";
            }
            if (external_space != null)
            {
                parameters += external_space + "/";
            }

            return parameters;
        }
    }
}
