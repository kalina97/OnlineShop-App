using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Helpers;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Logging;
using Application.Searches;
using EFDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
      

        private IGetBrandsCommand _getCommand;
        private IGetBrandCommand _getOneCommand;
        private IAddBrandCommand _addCommand;
        private IDeleteBrandCommand _deleteCommand;
        private readonly LoggedUser _user;

        public BrandsController(IGetBrandsCommand getCommand, IGetBrandCommand getOneCommand, IAddBrandCommand addCommand, IDeleteBrandCommand deleteCommand, LoggedUser user)
        {
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
            _addCommand = addCommand;
            _deleteCommand = deleteCommand;
            _user = user;
        }

        /// <summary>
        /// Returns all brands that match provided query
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "brandName": "Assics"
        ///        
        ///     }
        ///
        /// </remarks>



        // GET: api/Brands
        [LoggedIn]
        [HttpGet]
        public ActionResult <IEnumerable<BrandDto>> Get([FromQuery]BrandSearch query)
            => Ok(_getCommand.Execute(query));

        // GET: api/Brands/5
        [LoggedIn]
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(404)]
        public IActionResult Get(int id)
        {
            try
            {
                var brandDto = _getOneCommand.Execute(id);
                return Ok(brandDto);
            }
            catch (EntityNotFoundException)
            {
                return NotFound("This brand doesn't exist");
            }

        }
        /// <summary>
        /// Post a Brand
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "brandName": "Assics"
        ///        
        ///     }
        ///
        /// </remarks>

        // POST: api/Brands
        [LoggedIn("Administrator")]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(422)]
        public IActionResult Post([FromBody] BrandDto dto)
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
                return StatusCode(500, e.Message);
            }
        }

        // PUT: api/Brands/5
        /*
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        */

        // DELETE: api/ApiWithActions/5
        [LoggedIn("Administrator")]
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
