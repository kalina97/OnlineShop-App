using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Helpers;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Responses;
using Application.Searches;
using EFDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private IGetUsersCommand _getCommand;
        private IGetUserCommand _getOneCommand;
        private IAddUserCommand _addCommand;
        private IEditUserCommand _editCommand;
        private IDeleteUserCommand _deleteCommand;

        public UsersController(IGetUsersCommand getCommand, IGetUserCommand getOneCommand, IAddUserCommand addCommand, IEditUserCommand editCommand, IDeleteUserCommand deleteCommand)
        {
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
            _addCommand = addCommand;
            _editCommand = editCommand;
            _deleteCommand = deleteCommand;
        }

        /// <summary>
        /// Returns all users that match provided query
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "firstName": "Mark",
        ///        "lastName": "Jones",
        ///         "username": "mark456",
        ///        "password": "markpass",
        ///        "roleId": 1
        ///     }
        ///
        /// </remarks>

        // GET: api/Users
        //[LoggedIn("Administrator")]
        [HttpGet]
        public ActionResult<PagedResponse<UserDto>> Get([FromQuery]UserSearch query)
            => Ok(_getCommand.Execute(query));

        // GET: api/Users/5
        //[LoggedIn("Administrator")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var userDto = _getOneCommand.Execute(id);
                return Ok(userDto);
            }
            catch (EntityNotFoundException)
            {
                return NotFound("This user doesn't exist");
            }
        }

        /// <summary>
        /// Post a user
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "firstName": "Mark",
        ///        "lastName": "Jones",
        ///         "username": "mark456",
        ///        "password": "markpass",
        ///        "roleId": 1
        ///     }
        ///
        /// </remarks>

        // POST: api/Users
       
        [HttpPost]
        public IActionResult Post([FromBody] UserDto dto)
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

        /// <summary>
        /// Edit user
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Todo
        ///     {
        ///       
        ///        "firstName": "New name",
        ///        "lastName": "New lastname",
        ///         "username": "New username",
        ///        "password": "New password",
        ///        "roleId": 1
        ///     }
        ///
        /// </remarks>

        // PUT: api/Users/5
        //[LoggedIn("Administrator")]
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult Put(int id, [FromBody] UserDto dto)
        {
            dto.Id = id;
            try
            {

                _editCommand.Execute(dto);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "User doesn't exist.")
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
