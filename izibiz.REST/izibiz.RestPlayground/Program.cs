using System;
using System.Threading.Tasks;
using izibiz.REST.Concrete.Mustahsil;
using izibiz.REST.Infrastructure;
using izibiz.REST.Models.Request;

namespace izibiz.RestPlayground
{
    internal class Program
    {
        private static async Task Main()
        {
            var options = new RestApiOptions
            {
                Username = "izibiz-test2",
                Password = "izi321"
            };

            var tokenProvider = new TokenProvider(options);
            var httpClient = HttpClientProvider.Create(options, tokenProvider);
            var mustahsilClient = new MustahsilClient(httpClient, options);

            var result = await mustahsilClient.ListAsync(new ListFilter());

            Console.WriteLine($"Toplam kayit: {result.Pageable.TotalElements}");
            foreach (var item in result.Contents)
            {
                Console.WriteLine($"{item.DocumentNo} - {item.IssueDate} - {item.Amount} {item.Currency}");
            }

            Console.ReadKey();
        }
    }
    }