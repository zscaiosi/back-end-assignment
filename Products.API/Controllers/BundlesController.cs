using System;
using System.Collections.Generic;
using Products.API.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products.API.Data.Entities;
using Products.API.Contracts.Requests;
using Products.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Products.API.Contracts.Views;

namespace Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BundlesController : ControllerBase
    {
        private readonly IBundlesService _bundlesSvc;
        public BundlesController(IBundlesService bundlesSvc)
        {
            _bundlesSvc = bundlesSvc;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BundlesEntity>>> Get([FromQuery] GetRequestFilter filter)
        {
            try
            {
                return StatusCode(200, await _bundlesSvc.ListBundlesAsync(filter));
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Creates many Bundles
        /// </summary>
        /// <param name="bundles"></param>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] List<BundlesEntity> bundles)
        {
            try
            {
                await _bundlesSvc.BulkCreateBundlesAsync(bundles);
                return StatusCode(200);
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        /*
            For simplicity and time saving the methods below will not be implemented!
        */

        /// <summary>
        /// NOT NEEDED
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// NOT NEEDED
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// NOT NEEDED
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
