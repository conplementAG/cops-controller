using ConplementAG.CopsController.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Serilog;
using System;
using System.Net;

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
        public IActionResult Post([FromBody]Newtonsoft.Json.Linq.JObject value)
        {
            try
            {
                var copsResource = CopsResourceFactory.Create(value);
                var k8sResourceTuple = K8sResourceFactory.Create(copsResource);

                JObject response = JObject.FromObject(
                    new
                    {
                        children = JArray.FromObject(k8sResourceTuple.Item1),
                        status = JObject.FromObject(k8sResourceTuple.Item2)
                    }
                );

                Log.Debug("CopsResource {CopsResource} mapped to K8sResource {CopsResource}", value["parent"], response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error handling CopsResource {CopsResourceKind}", value["parent"]["kind"]);
            }

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}
