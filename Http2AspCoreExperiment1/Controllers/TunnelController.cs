using System.Collections.Generic;
using System.IO.Pipelines;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http2;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http2.FlowControl;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure;

namespace Http2AspCoreExperiment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TunnelController : ControllerBase
    {
        // GET: api/Chat
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return PassItAlong();
        }

        public static HttpResponseMessage PassItAlong()
        {
            //await may not play well with 500s, so making it a bit dumber for now
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("Read the endpoint from appsettings here.");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept
                    .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("api/values");
                response.Wait();

                return response.Result;
            }
        }

        //private void DoSomething(Http2Stream http2Stream)
        //{
        //    Task.Factory.StartNew(async () =>
        //    {
        //        try
        //        {
        //            var context = new Http2StreamContext();

        //        }
        //        catch { };
        //    }

        //    );

        //    Http2StreamContext http2StreamContext = new Http2StreamContext();
        //    Http2Stream bob = new Http2Stream(http2StreamContext);
        //    Http2FrameWriter writer =
        //        new Http2FrameWriter(
        //            new PipeWriter,
        //            new ConnectionContext,
        //            new Http2Connection,
        //            new OutputFlowControl,
        //            new ITimeoutControl,
        //            new MinDataRate,
        //            this.HttpContext.Connection.Id,
        //            this.Request.HttpContext.,
        //            new IKestrelTrace
        //        )
        //}
    }
}
