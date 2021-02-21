using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public string GetProducts()
        {
            return "This will be a list of products";
        }

        [HttpGet("{id}")]
        public string GetProduct(int id)
        {
            return "Single product returned";
        }
    }
}
