using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace Http2AspCoreExperiment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TunnelController : ControllerBase
    {
        #region controllers
        // GET: api/Chat
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return PassItAlong();
        }
        #endregion

        #region private
        private static HttpResponseMessage PassItAlong()
        {          
            //await may not play well with 500s, so making it a bit dumber for now
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://http2aspcoreexperiment120181219030212.azurewebsites.net");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept
                    .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("api/values");
                response.Wait();

                return response.Result;
            }
        }
        #endregion
    }
}
