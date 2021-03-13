using System;
using System.Net;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenignBeaconer
{
  class Program
  {
    static void Main(string[] args)
    {
      string uri = "https://www.google.com";
      // Time to sleep in milliseconds
      int sleep = 20000;
      // Percentage of variance for sleep
      int jitter = 42;
      string user_agent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.82 Safari/537.36";
      Random rand = new Random();
      // Calculate jitter offets
      int lower = sleep - (sleep * jitter / 100);
      int upper = sleep + (sleep * jitter / 100); 

      while (true)
      {
        WebClient client = new WebClient();
        client.UseDefaultCredentials = true;

        client.Headers.Add("user-agent", user_agent);

        var content = client.DownloadString(uri);

        Console.WriteLine("Sent request. Response length: " + content.Length);
        int random = rand.Next(lower, upper);
        Console.WriteLine("Sleeping for " + random * .001 + " seconds");
        Thread.Sleep(random);
      }
    }
  }
}
