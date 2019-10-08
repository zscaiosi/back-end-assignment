using System;
using System.Collections.Generic;
using Products.API.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products.API.Data.Entities;
using Products.API.Contracts.Requests;
using Products.API.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Products.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsSvc;
        public ProductsController(IProductsService productsSvc) {
            _productsSvc = productsSvc;
        }        
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsEntity>>> Get([FromQuery] GetRequestFilter filter) =>
            StatusCode(200, await _productsSvc.ListProductsAsync(filter));

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<object> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
