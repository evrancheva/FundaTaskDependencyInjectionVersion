using Microsoft.Extensions.DependencyInjection;
using System;
using FundaTask.Interfaces;
using FundaTask.Services;

namespace FundaTask
{

    class Program
    {
  
        static void Main(string[] args)
        {

            //Dependency Resolution
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IUrlBuilder,UrlBuilder>()
                .AddSingleton<ISorter, Sorter>()
                .AddSingleton<ITopMakelaarsRetrival<int,string>, TopMakelaarsRetrival>()
                .AddSingleton<IPrinter, Printer>()
                .BuildServiceProvider();

           //Top 10 Makelaars 
            var topMakelaars = serviceProvider.GetService<ITopMakelaarsRetrival<int,string>>().TopMakelaars(10);
            serviceProvider.GetService<IPrinter>().PrintTopResults(topMakelaars);
            Console.WriteLine();

           //Top 10 Makelaars with Tuin
            var topMakelaarsWithGarden = serviceProvider.GetService<ITopMakelaarsRetrival<int, string>>().TopMakelaarsWithGarden(10);
            serviceProvider.GetService<IPrinter>().PrintTopResults(topMakelaarsWithGarden);

        }   

    }
}
