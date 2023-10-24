using ConplementAG.CopsController.Services;
using Newtonsoft.Json.Linq;
using Serilog;
using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConplementAG.CopsController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SyncController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "I am alive.";
        }

        [HttpPost]
        public IActionResult Post([FromBody]JObject value)
        {
            try
            {
                Log.Verbose("REQUEST===============================" + value.ToString(Newtonsoft.Json.Formatting.Indented));

                var copsResource = CopsResourceFactory.Create(value);
                var k8sResources = K8sResourceFactory.Create(copsResource);

                JObject response = JObject.FromObject(
                    new
                    {
                        children = JArray.FromObject(k8sResources)
                    }
                );

                Log.Verbose("RESPONSE===============================" + response.ToString(Newtonsoft.Json.Formatting.Indented));
                return Ok(response);
            }
            catch (Exception ex)
            {
                if (value != null && value["parent"] != null)
                {
                    var errorMessage = $"Error while handling Cops Resource { value["parent"]["kind"] }, { value["parent"]["metadata"]["name"] }";
                    Log.Error(ex, errorMessage);
                }
                else
                {
                    Log.Error(ex, "Error while handling unknown resource type. Here is the entire value object dump: " + value);
                }
            }

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}
