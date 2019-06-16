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
    public class CommentsController : ControllerBase
    {
       
        private IGetCommentsCommand _getCommand;
        private IGetCommentCommand _getOneCommand;
        private IAddCommentCommand _addCommand;
        private IDeleteCommentCommand _deleteCommand;

        public CommentsController(IGetCommentsCommand getCommand, IGetCommentCommand getOneCommand, IAddCommentCommand addCommand, IDeleteCommentCommand deleteCommand)
        {
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
            _addCommand = addCommand;
            _deleteCommand = deleteCommand;
        }



        /// <summary>
        /// Returns all comments that match provided query
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "userId": 2,
        ///        "productId":4,
        ///        "commentDesc":"Some text..."
        ///        
        ///     }
        ///
        /// </remarks>


        // GET: api/Comments
        //[LoggedIn("Administrator")]
        [HttpGet]
        public ActionResult<IEnumerable<CommentDto>> Get([FromQuery]CommentSearch query)
            => Ok(_getCommand.Execute(query));

        // GET: api/Comments/5
        //[LoggedIn]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var commentDto = _getOneCommand.Execute(id);
                return Ok(commentDto);
            }
            catch (EntityNotFoundException)
            {
                return NotFound("This comment doesn't exist");
            }
        }

        /// <summary>
        /// Post a comment
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "userId": 2,
        ///        "productId":4,
        ///        "commentDesc":"Some text..."
        ///        
        ///     }
        ///
        /// </remarks>

        // POST: api/Comments
        
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]

        public IActionResult Post([FromBody] CommentDto dto)
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

        // PUT: api/Comments/5
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
