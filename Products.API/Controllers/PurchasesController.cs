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
    [Authorize()]
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchasesService _purchasesSvc;
        public PurchasesController(IPurchasesService purchasesSvc) {
            _purchasesSvc = purchasesSvc;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchasesEntity>>> Get([FromQuery] GetRequestFilter filter)
        {
            try
            {
                return StatusCode(200, await _purchasesSvc.ListPurchases(filter));
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            try
            {
                return StatusCode(200, await _purchasesSvc.FindPurchase(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PurchaseOperationView item)
        {
            try
            {
                return StatusCode(200, await _purchasesSvc.CreatePurchase(item));
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] PurchasesEntity item)
        {
            try
            {
                return StatusCode(200, await _purchasesSvc.PutPurchase(id, item));
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                return StatusCode(200, await _purchasesSvc.DeletePurchase(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}