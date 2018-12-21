using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Http2ClientExperiment1
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://http2aspcoreexperiment120181219030212.azurewebsites.net/api/values";
            int requestCount = 5;

            using (var http2Client = new HttpClient())
            {
                //Establish the connection
                var baseRequest = new HttpRequestMessage(HttpMethod.Get, url) { Version = new Version(2,0) };
                Task<HttpResponseMessage> baseResponse = http2Client.SendAsync(baseRequest);
                PrintResult(baseResponse.Result);

                //Setup additional requests that should be multiplexed
                var tasks = new Task<HttpResponseMessage>[requestCount];
                for (int i = 0; i < requestCount; i++)
                {
                    tasks[i] = http2Client
                        .SendAsync(new HttpRequestMessage(HttpMethod.Get, url) { Version = new Version(2, 0) });
                }

                //Make the requests
                Task.WaitAll(tasks);

                //Print the results
                foreach (var task in tasks)
                {
                    PrintResult(task.Result);
                }
            }
        }

        private static void PrintResult(HttpResponseMessage response)
        {
            Console.WriteLine("-- Result -- \n" +
                $"Status: {response.StatusCode} \n" +
                $"Request HTTP Protocol used: {response.RequestMessage.Version} \n" +
                $"Response HTTP Protocol Used: {response.Version} \n" +
                $"Headers: {response.Headers} \n" +
                $"Response Headers: {response.Content.Headers} \n" +
                $"Response Body: {response.Content.ReadAsStringAsync().Result} \n"
                );
        }
    }
}
