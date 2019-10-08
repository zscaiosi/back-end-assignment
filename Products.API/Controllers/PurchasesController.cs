using System;
using System.Collections.Generic;
using Products.API.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly PurchasesService _purchasesSvc;
        public PurchasesController(PurchasesService purchasesSvc) {
            _purchasesSvc = purchasesSvc;
        }
        [HttpGet]
        public ActionResult<IEnumerable<object>> Get()
        {
            return new string[] { "value1", "value2" };
        }

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