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
    public class RolesController : ControllerBase
    {
       

        private IGetRolesCommand _getCommand;
        private IGetRoleCommand _getOneCommand;
        private IAddRoleCommand _addCommand;
        private IDeleteRoleCommand _deleteCommand;

        public RolesController(IGetRolesCommand getCommand, IGetRoleCommand getOneCommand, IAddRoleCommand addCommand, IDeleteRoleCommand deleteCommand)
        {
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
            _addCommand = addCommand;
            _deleteCommand = deleteCommand;
        }

        /// <summary>
        /// Returns all roles that match provided query
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "roleName": "Moderator"
        ///        
        ///     }
        ///
        /// </remarks>


        // GET: api/Roles
        //[LoggedIn("Administrator")]
        [HttpGet]
        public ActionResult<IEnumerable<RoleDto>> Get([FromQuery]RoleSearch query)
            => Ok(_getCommand.Execute(query));

        // GET: api/Roles/5
        //[LoggedIn("Administrator")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var roleDto = _getOneCommand.Execute(id);
                return Ok(roleDto);
            }
            catch (EntityNotFoundException)
            {
                return NotFound("This role doesn't exist");
            }
        }

        /// <summary>
        /// Post a role
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "roleName": "Moderator"
        ///        
        ///     }
        ///
        /// </remarks>

        // POST: api/Roles
        //[LoggedIn("Administrator")]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(422)]

        public IActionResult Post([FromBody] RoleDto dto)
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

        /*
        // PUT: api/Roles/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        */

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
