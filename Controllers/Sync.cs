using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

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
            var namespaceName = value["parent"]["metadata"]["name"];
            
            JObject response = JObject.FromObject(
                new {
                    children = new[] {
                        new {
                            apiVersion = "v1",
                            kind = "Namespace",
                            metadata = new {
                                name = namespaceName
                            }
                        }
                    },
                    status = new {
                        namespaces = 1,
                        name = namespaceName
                    }
                }
            );

            return Ok(response);
        }
    }    
}
