using ConplementAG.CopsController.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

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
            var copsResource = CopsResourceFactory.Create(value);
            var k8sResourceTuple = K8sResourceFactory.Create(copsResource);

            JObject response = JObject.FromObject(
                new
                {
                    children = JArray.FromObject(k8sResourceTuple.Item1),
                    status = JObject.FromObject(k8sResourceTuple.Item2)
                }
            );

            return Ok(response);
        }
    }
}
