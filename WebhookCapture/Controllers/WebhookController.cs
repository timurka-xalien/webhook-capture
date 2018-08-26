using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/Webhook")]
    public class WebhookController : Controller
    {
        // GET: api/Webhook
        [HttpGet]
        public void Get()
        {

        }

        // POST: api/Webhook
        [HttpPost]
        [Route("json")]
        public void PostJson([FromBody]JToken jsonbody)
        {
            var headers = Newtonsoft.Json.JsonConvert.SerializeObject(this.Request.Headers);

            Utils.WriteTextToFile(Constants.DataFilePath,
                $"\r\n\r\n===== {DateTime.Now} === Data received (POST):" +
                $"\r\nHeaders\r\n:{headers}" +
                $"\r\nBody:\r\n{jsonbody}",
                true);
        }

        // POST: api/Webhook
        [HttpPost]
        [Route("form")]
        public void PostForm()
        {
            var headers = Newtonsoft.Json.JsonConvert.SerializeObject(this.Request.Headers);
            var form = Newtonsoft.Json.JsonConvert.SerializeObject(Request.Form);
            form = form.Replace(@""",""Value"":[", "=")
                .Replace(@"{""Key"":""", "")
                .Replace("[", "")
                .Replace("]", "")
                .Replace(@"""},", "&")
                .Replace("\"", "")
                .Replace("}", "");

            Utils.WriteTextToFile(Constants.DataFilePath,
                $"\r\n\r\n===== {DateTime.Now} === Data received (POST):" +
                $"\r\nHeaders\r\n:{headers}" +
                $"\r\nBody:\r\n{form}",
                true);
        }
    }
}