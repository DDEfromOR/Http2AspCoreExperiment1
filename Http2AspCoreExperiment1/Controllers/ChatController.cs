using System.Collections.Generic;
using System.IO.Pipelines;
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
    public class ChatController : ControllerBase
    {
        // GET: api/Chat
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Chat/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Chat
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Chat/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
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
