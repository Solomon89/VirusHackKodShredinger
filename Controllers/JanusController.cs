using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VirusHackKodShredinger.Controllers
{
    [Route("")]
    [ApiController]
    public class JanusController : ControllerBase
    {
        [Route("Janus")]
        [HttpPost]
        public IActionResult GetNewSession(janusIncoming janusIncoming)
        {
            janusOutgoing janusOutgoing = new janusOutgoing(janusIncoming, "success");
            janusOutgoing.data.Add("id", "14552147855");
            return new JsonResult(janusOutgoing);
        }
        [Route("Janus/{id}")]
        [HttpGet]
        public IActionResult GetHZ(long id, long rid, int maxev)
        {
            janusOutgoing janusOutgoing = new janusOutgoing();
            janusOutgoing.janus = "keepalive";
            janusOutgoing.sender = sender;
            janusOutgoing.plugindata.plugin = "janus.plugin.echotest";
            janusOutgoing.plugindata.data.Add("echotest", "event");
            janusOutgoing.plugindata.data.Add("result", "ok");
            return new JsonResult(janusOutgoing);
        }
        string sender = "1815153248";
        
        [Route("Janus/{id}")]
        public IActionResult KeepALive(janusIncoming janusIncoming)
        {
            janusOutgoing janusOutgoing = new janusOutgoing(janusIncoming, janusIncoming.janus);
            if (janusIncoming.janus == events.attach.ToString())
            {
                janusOutgoing.janus = "success";
                janusOutgoing.data.Add("Id","14552147855");
            }
            return new JsonResult(janusOutgoing);
        }

    }
    public enum events
    {
        attach = 0,
        success,
        destroy,
        keepalive
    }
    public class janusIncoming
    {
        public string janus { get; set; }
        public string transaction { get; set; }
        public string sender { get; set; }
        public string plugin { get; set; }
    }
    public class janusOutgoing: janusIncoming
    {
        public plugindata plugindata { get; set; }
        public Dictionary<string, string> data { get; set; }
        public janusOutgoing()
        {
            plugindata = new plugindata();
            data = new Dictionary<string, string>();
        }
        public janusOutgoing(janusIncoming janusIncoming, string janus )
        {
            this.janus = janus;
            transaction = janusIncoming.transaction;
            plugindata = new plugindata();
            data = new Dictionary<string, string>();

        }
    }
    public class plugindata
    {
        public string plugin { get; set; }
        public Dictionary<string, string> data { get; set; }
        public plugindata()
        {
            data = new Dictionary<string, string>();
        }
    }
}