using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    }
}
