using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Helpers;
using Application;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Logging;
using EFDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Encryption _enc;
        private readonly IAuthCommand _command;

        public AuthController(Encryption enc, IAuthCommand command)
        {
            _enc = enc;
            _command = command;
        }

        /// <summary>
        /// For Login please type only your username and password!
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "username": "validusername",
        ///        "password": "validpassword"
        ///        
        ///     }
        ///
        /// </remarks>



        // POST: api/Auth

        [HttpPost]
        [ProducesResponseType(404)]
        public IActionResult Post(AuthDto dto)
        {

            // logovanje korisnika
            try
            {
                var user = _command.Execute(dto);

                var stringObjekat = JsonConvert.SerializeObject(user);

                var encrypted = _enc.EncryptString(stringObjekat);

                return Ok(new { token = encrypted });
            }
            catch (EntityNotFoundException)
            {
                return NotFound("This user doesn't exist");

            }


        }
        [LoggedIn]
        [HttpGet("decode")]
        public IActionResult Decode(string value)
        {
            var decodedString = _enc.DecryptString(value);
            decodedString = decodedString.Substring(0, decodedString.LastIndexOf("}") + 1);
            var user = JsonConvert.DeserializeObject<LoggedUser>(decodedString);

            return null;
        }
    }
}
