using System;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testAsync561
{
    class Program
    {
        public static HttpClient client = new HttpClient();
        
        static async Task Main(string[] args)
        {

            Console.WriteLine("Press any key to start...");
            Console.ReadLine();

            List<WebsiteDataModel> finalList = new List<WebsiteDataModel>();

            //finalList = await RunDownloadParallelAsync();

            List<string> websites = new List<string>
            {
                "https://www.yahoo.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.cnn.com",
                "https://www.amazon.com",
                "https://www.facebook.com",
                "https://www.twitter.com",
                "https://www.codeproject.com",
                "https://www.stackoverflow.com",
                "https://en.wikipedia.org/wiki/.NET_Framework"
            };
            List<Task<WebsiteDataModel>> tasks = new List<Task<WebsiteDataModel>>();
            List<Task> tasks2 = new List<Task>();

            foreach (string site in websites)
            {
                tasks2.Add(DownloadWebsiteAsync(site));
            }

            //var results = 
            await Task.WhenAll(tasks2);

            Console.WriteLine("Complete!");
            Console.ReadLine();

        }

        //public static async Task<List<WebsiteDataModel>> RunDownloadParallelAsync()
        public static async Task RunDownloadParallelAsync()
        {

            List<string> websites = new List<string>
            {
                "https://www.yahoo.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.cnn.com",
                "https://www.amazon.com",
                "https://www.facebook.com",
                "https://www.twitter.com",
                "https://www.codeproject.com",
                "https://www.stackoverflow.com",
                "https://en.wikipedia.org/wiki/.NET_Framework"
            };
            List <Task<WebsiteDataModel>> tasks = new List<Task<WebsiteDataModel>>();
            List<Task> tasks2 = new List<Task>();

            foreach (string site in websites)
            {
                tasks2.Add(DownloadWebsiteAsync(site));
            }

            //var results = 
            await Task.WhenAll(tasks2);

            //return new List<WebsiteDataModel>(results);
        }

        private static async Task DownloadWebsiteAsync(string websiteURL)
        {
            WebsiteDataModel output = new WebsiteDataModel();
            
            //WebClient client = new WebClient();

            output.WebsiteUrl = websiteURL;
            var testByte = await client.GetByteArrayAsync(websiteURL);

            Console.WriteLine(websiteURL + " " + System.Threading.Thread.CurrentThread.ManagedThreadId + " Content Length: " + (Encoding.UTF8.GetString(testByte)).Length);


        }
    }

    public class WebsiteDataModel
    {
        public string WebsiteUrl { get; set; } = "";
        public string WebsiteData { get; set; } = "";
    }
}
