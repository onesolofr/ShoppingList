using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SLEntities;
using SLHelpers;

namespace SLApp.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class TokenController : ControllerBase
    {
        [HttpGet, Authorize]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}"), Authorize]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost, AllowAnonymous]
        public void Post([FromBody] User value)
        {
            TokenHelpers.BuildUserToken(value);
        }

        [HttpPut("{id}"), Authorize]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}"), Authorize]
        public void Delete(int id)
        {
        }
    }
}
