using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Helpers;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using EFDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
       
        private IGetOrdersCommand _getCommand;
        private IGetOrderCommand _getOneCommand;
        private IAddOrderCommand _addCommand;
        private IDeleteOrderCommand _deleteCommand;

        public OrdersController(IGetOrdersCommand getCommand, IGetOrderCommand getOneCommand, IAddOrderCommand addCommand, IDeleteOrderCommand deleteCommand)
        {
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
            _addCommand = addCommand;
            _deleteCommand = deleteCommand;
        }


        /// <summary>
        /// Returns all orders that match provided query
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "userId": 3,
        ///        "quantity":5
        ///        
        ///     }
        ///
        /// </remarks>

        // GET: api/Orders
        //[LoggedIn("Salesman")]
        [HttpGet]
        public ActionResult<IEnumerable<OrderDto>> Get([FromQuery]OrderSearch query)
            => Ok(_getCommand.Execute(query));

        // GET: api/Orders/5
       // [LoggedIn]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var orderDto = _getOneCommand.Execute(id);
                return Ok(orderDto);
            }
            catch (EntityNotFoundException)
            {
                return NotFound("This order doesn't exist");
            }
        }

        /// <summary>
        /// Post an order
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "userId": 3,
        ///        "quantity":5
        ///        
        ///     }
        ///
        /// </remarks>

        // POST: api/Orders

        //[LoggedIn]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(422)]

        public IActionResult Post([FromBody] CreateOrderDto dto)
        {
            try
            {
                _addCommand.Execute(dto);
                return StatusCode(201);
            }
            catch (EntityNotFoundException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.InnerException.ToString());
            }
        }

        /*
        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        */

        // DELETE: api/ApiWithActions/5
        //[LoggedIn("Salesman")]
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult Delete(int id)
        {
            try
            {
                _deleteCommand.Execute(id);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Something went wrong.");
            }
        }
    }
}
