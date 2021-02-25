using API.Errors;
using Infrastructre.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;

        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public IActionResult GetNotFoundRequest()
        {
            var thing = _context.Products.Find(420);
            if(thing == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }

        [HttpGet("servererror")]
        public IActionResult GetServerErrorRequest()
        {
            var thing = _context.Products.Find(420);

            var thingToReturn = thing.ToString();

            return Ok();
        }

        [HttpGet("badrequest")]
        public IActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public IActionResult GetBadRequest(int id)
        {
            return Ok();
        }
    }
}
