using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tutorial1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var websiteURL = args[0];
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(websiteURL);
            if (response.IsSuccessStatusCode)
            {
                var htmlContent = await response.Content.ReadAsStringAsync();

                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);

                var emailAddresses = regex.Matches(htmlContent);

                foreach(var email in emailAddresses)
                {
                    Console.WriteLine(email.ToString());
                }
            }
            Console.ReadKey();
        }
    }
}
