using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace Http2AspCoreExperiment1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        //ConfigureKestrel now allows setting listen options to enable HTTP 2.0
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureKestrel(options =>
                {
                    options.Listen(IPAddress.Any, 8080, listenOptions =>
                    {
                        listenOptions.Protocols = HttpProtocols.Http2;

                        //If running locally create a localhost cert to input below,
                        //otherwise the UseHttps line below can be removed or commented
                        //out if running in an App Service, as the generic Azure cert will be
                        //subbed in and IIS will handle the heavy lifting
                        listenOptions.UseHttps("someCert.pem", "password123");
                    });
                })
                .UseStartup<Startup>();
    }
}
