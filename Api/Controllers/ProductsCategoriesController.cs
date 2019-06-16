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
    public class ProductsCategoriesController : ControllerBase
    {
        private IGetProductCategoryCommand _getCommand;

        public ProductsCategoriesController(IGetProductCategoryCommand getCommand)
        {
            _getCommand = getCommand;
        }


        /// <summary>
        /// Returns all products with categories that match provided query
        /// </summary>


        // GET: api/ProductsCategories
        //[LoggedIn("Administrator")]
        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> Get([FromQuery]ProductCategorySearch query)
            => Ok(_getCommand.Execute(query));
        /*
        // GET: api/ProductsCategories/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ProductsCategories
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ProductsCategories/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
