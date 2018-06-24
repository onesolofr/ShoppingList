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

        UserDbContext _dbContext;

        public TokenController(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }


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
        public IActionResult Post([FromBody] User value)
        {
            if (value == null)
                throw SLExceptionManager.Wrap(new ArgumentNullException(nameof(value), "L'argument ne peut pas être NULL."));

            IActionResult response = Unauthorized();

            User user = _dbContext.DbUsers.FirstOrDefault(p => p.Name == value.Name);
            if (user != null)
            {
                response = Ok(value: new { token = TokenHelpers.BuildUserToken(value) });
            }

            return response;
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
