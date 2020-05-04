using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VirusHackKodShredinger.Controllers
{
    [Route("")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
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

                janusOutgoing.janus = "success";
                janusOutgoing.data.Add("id","14552147855");
            
            return new JsonResult(janusOutgoing);
        }
        [Route("Janus/{id}/{plugin}")]
        [HttpPost]
        public async Task<IActionResult> PluginEvents(janusOutgoungIncoming janusOutgoungIncoming)
        {
            //janusOutgoungPlugin janusOutgoungPlugin = (janusOutgoungPlugin)janusIncoming;
            //janusOutgoungPlugin.body.Add("audio", "true");
            //janusOutgoungPlugin.body.Add("type", "offer");
            //janusOutgoungPlugin.body.Add("sdp", "v=0\r\no=[..more sdp stuff..]");
            string data;
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                data = await reader.ReadToEndAsync();
            }
            
            return new JsonResult(new
            {
                videoroom = "event",
                configured = "ok"
            });
        }
        [Route("Janus/{id}/{pluginId}")]
        [HttpGet]
        public IActionResult PluginEventGet(janusIncoming janusIncoming)
        {
            janusOutgoungPlugin janusOutgoungPlugin = (janusOutgoungPlugin)janusIncoming;
            janusOutgoungPlugin.body.Add("audio", "true");
            janusOutgoungPlugin.body.Add("type", "offer");
            janusOutgoungPlugin.body.Add("sdp", "v=0\r\no=[..more sdp stuff..]");

            return new JsonResult(janusOutgoungPlugin);
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
        public int id { get; set; }
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
    public class janusOutgoungPlugin : janusIncoming
    {
        public Dictionary<string,string> body { get; set; }
        public Dictionary<string,string> jsep { get; set; }
    }
    public class janusOutgoungIncoming: janusIncoming
    {
        public body body { get; set; }
    }
    public class body
    {
        public bool audio { get; set; }
        public bool video { get; set; }
        public string display { get; set; }
        public string ptype { get; set; }
        public string request { get; set; }
        public int room { get; set; }
    }
   

}