using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Helpers;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Domain;
using EFDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
       

        private IGetCategoriesCommand _getCommand;
        private IGetCategoryCommand _getOneCommand;
        private IAddCategoryCommand _addCommand;
        private IEditCategoryCommand _editCommand;
        private IDeleteCategoryCommand _deleteCommand;

        public CategoriesController(IGetCategoriesCommand getCommand, IGetCategoryCommand getOneCommand, IAddCategoryCommand addCommand, IEditCategoryCommand editCommand, IDeleteCategoryCommand deleteCommand)
        {
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
            _addCommand = addCommand;
            _editCommand = editCommand;
            _deleteCommand = deleteCommand;
        }



        /// <summary>
        /// Returns all categories that match provided query
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Assics"
        ///        
        ///     }
        ///
        /// </remarks>

        // GET: api/Categories
       // [LoggedIn]
        [HttpGet]
        public ActionResult <IEnumerable<CategoryDto>> Get([FromQuery]CategorySearch query)
            => Ok(_getCommand.Execute(query));

        // GET: api/Categories/5
        //[LoggedIn]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var categoryDto = _getOneCommand.Execute(id);
                return Ok(categoryDto);
            }
            catch (EntityNotFoundException)
            {
                return NotFound("This category doesn't exist");
            }
        }

        /// <summary>
        /// Post category
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Socks"
        ///        
        ///     }
        ///
        /// </remarks>

        // POST: api/Categories
        //[LoggedIn("Administrator")]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(422)]

        public IActionResult Post([FromBody] CategoryDto dto)
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
                return StatusCode(500,e.Message);
            }



        }

        /// <summary>
        /// Edit category
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Todo
        ///     {
        ///
        ///        "name": "New Name"
        ///        
        ///     }
        ///
        /// </remarks>

        // PUT: api/Categories/5
        //[LoggedIn("Administrator")]
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(422)]

        public IActionResult Put(int id, [FromBody] CategoryDto dto)
        {
            dto.Id = id;
            try
            {

                _editCommand.Execute(dto);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "Category doesn't exist.")
                {
                    return NotFound(e.Message);
                }

                return UnprocessableEntity(e.Message);

            }
            catch (Exception e)
            {
                return StatusCode(500);
            }


        }

        // DELETE: api/ApiWithActions/5
        //[LoggedIn("Administrator")]
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
