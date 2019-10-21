using System.Collections.Generic;
using FundaTask.Interfaces;
using RestSharp;
using FundaTask.Models;
using System.Linq;
using System.Linq;

namespace FundaTask.Services
{
    class TopMakelaarsRetrival : ITopMakelaarsRetrival<int,string>
    {
        private readonly IUrlBuilder _urlBuilder;
        private readonly ISorter _sorter;

        public TopMakelaarsRetrival(IUrlBuilder urlBuilder, ISorter sorter)
        {
            _urlBuilder = urlBuilder;
            _sorter = sorter;

        }
   
        public Dictionary<string,int> CountPropertiesOfMakelaars(string type, string zo, string city, string external_space)
        {
            
            Dictionary<string, int> makelaars = new Dictionary<string, int>();

            bool moreResults = true;
            RestClient client = new RestClient("http://partnerapi.funda.nl/feeds/");
            var page = 1;

            while (moreResults == true)
            {
                string baseUrl = _urlBuilder.ConstructBaseUrlForApiCall(type, zo,city, external_space);
                RestRequest request = new RestRequest(baseUrl, Method.GET);
                request.AddQueryParameter("page", page.ToString());
                request.AddQueryParameter("pagesize", 25.ToString());
                IRestResponse<Listing> response = client.Execute<Listing>(request);
                var statusCode = (int)response.StatusCode;
                

                if (statusCode != 200)
                {
                    System.Threading.Thread.Sleep(1 * 60 * 1000);
                    continue;

                }
                var listing = response.Data.Objects;

                if (listing != null && listing.Count != 0)
                {
                    foreach (var house in listing)
                    {
                        if (makelaars.ContainsKey(house.MakelaarNaam))
                        {
                            makelaars[house.MakelaarNaam] = makelaars[house.MakelaarNaam] + 1;
                        }
                        else
                        {
                            makelaars.Add(house.MakelaarNaam, 1);
                        }
                    }
                    page++;
                }
                else
                {
                    moreResults = false;
                }
            }

            return makelaars;
        }



        public IEnumerable<KeyValuePair<string,int>> TopMakelaars(int limit)
        {
            var allMakelaars = CountPropertiesOfMakelaars("koop", null, "amsterdam", null);
            var sortedMakelaars = _sorter.SortDictionaryByDescending(allMakelaars);

            return sortedMakelaars.Take(limit);


        }

        public IEnumerable<KeyValuePair<string, int>> TopMakelaarsWithGarden(int limit)
        {
            var allMakelaars = CountPropertiesOfMakelaars("koop", null, "amsterdam", "tuin");
            var sortedMakelaars = _sorter.SortDictionaryByDescending(allMakelaars);

            return sortedMakelaars.Take(limit);

        }
    }
}
