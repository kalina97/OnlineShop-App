using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Helpers;
using Application.Commands;
using Application.DTO;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsOrdersController : ControllerBase
    {
        private IGetProductOrderCommand _getCommand;

        public ProductsOrdersController(IGetProductOrderCommand getCommand)
        {
            _getCommand = getCommand;
        }

        /// <summary>
        /// Returns all products with orders that match provided query
        /// </summary>


        // GET: api/ProductsOrders
        //[LoggedIn("Administrator")]
        [HttpGet]
        public ActionResult<IEnumerable<OrderDto>> Get([FromQuery]ProductOrderSearch query)
            => Ok(_getCommand.Execute(query));

        /*
        // GET: api/ProductsOrders/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ProductsOrders
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ProductsOrders/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
