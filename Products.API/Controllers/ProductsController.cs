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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsSvc;
        public ProductsController(IProductsService productsSvc) {
            _productsSvc = productsSvc;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsEntity>>> Get([FromQuery] GetRequestFilter filter)
        {
            try
            {
                return StatusCode(200, await _productsSvc.ListProductsAsync(filter));
            }
            catch (ArgumentException e)
            {
                return StatusCode(400);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                return StatusCode(200, await _productsSvc.FindProductAsync(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode(400);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductsEntity item)
        {
            try
            {
                return StatusCode(200, await _productsSvc.CreateProductAsync(item));
            }
            catch (ArgumentException e)
            {
                return StatusCode(400);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductsEntity item)
        {
            try
            {
                return StatusCode(200, await _productsSvc.PutProductAsync(id, item));
            }
            catch (ArgumentException e)
            {
                return StatusCode(400);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return StatusCode(200, await _productsSvc.DeleteProductAsync(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode(400);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
