using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Api.Helpers;
using Api.UploadProduct;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Responses;
using Application.Searches;
using Application.UploadFiles;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IGetProductsCommand _getCommand;
        private IGetProductCommand _getOneCommand;
        private IAddProductCommand _addCommand;
        private IEditProductCommand _editCommand;
        private IDeleteProductCommand _deleteCommand;

        public ProductsController(IGetProductsCommand getCommand, IGetProductCommand getOneCommand, IAddProductCommand addCommand, IEditProductCommand editCommand, IDeleteProductCommand deleteCommand)
        {
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
            _addCommand = addCommand;
            _editCommand = editCommand;
            _deleteCommand = deleteCommand;
        }

        /// <summary>
        /// Returns all products that match provided query
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Product",
        ///        "description": "Some text...",
        ///        "availableCount": 30,
        ///        "brandId":3,
        ///        "price": 3400,
        ///        "imageSrc": "image.jpg"
        ///     }
        ///
        /// </remarks>

        // GET: api/Products
        //[LoggedIn]
        [HttpGet]
        public ActionResult<PagedResponse<ProductDto>> Get([FromQuery]ProductSearch query)
            => Ok(_getCommand.Execute(query));

        // GET: api/Products/5
        //[LoggedIn("Customer")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var productDto = _getOneCommand.Execute(id);
                return Ok(productDto);
            }
            catch (EntityNotFoundException)
            {
                return NotFound("This product doesn't exist");
            }
        }

        /// <summary>
        /// Post a product
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Product",
        ///        "description": "Some text...",
        ///        "availableCount": 30,
        ///        "brandId":3,
        ///        "price": 3400,
        ///        "imageSrc": "image.jpg"
        ///     }
        ///
        /// </remarks>

        // POST: api/Products
        //[LoggedIn("Administrator")]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(422)]

        public IActionResult Post([FromForm] Product p)
        {
            var ext = Path.GetExtension(p.ImageSrc.FileName); //.gif

            if (!FileUpload.AllowedExtensions.Contains(ext))
            {
                return UnprocessableEntity("Image extension is not allowed.");
            }

            try
            {
                var newFileName = Guid.NewGuid().ToString() + "_" + p.ImageSrc.FileName;

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", newFileName);

                p.ImageSrc.CopyTo(new FileStream(filePath, FileMode.Create));

                var dto = new ProductDto
                {
                    ImageSrc = newFileName,
                    Name = p.Name,
                    Price = p.Price,
                    AvailableCount=p.AvailableCount,
                    Description=p.Description,
                    BrandId=p.BrandId
                };

                _addCommand.Execute(dto);
                return StatusCode(201);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            



        }


        /// <summary>
        /// Edit product
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///  
        ///        "name": "Product",
        ///        "description": "Some text...",
        ///        "availableCount": 30,
        ///        "brandId":3,
        ///        "price": 3400,
        ///        "imageSrc": "image.jpg"
        ///     }
        ///
        /// </remarks>

        // PUT: api/Products/5
        //[LoggedIn("Administrator")]
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(422)]
        [ProducesResponseType(404)]

        public IActionResult Put(int id, [FromForm] Product p)
        {

            //update proizvoda
            p.Id = id;

            var ext = Path.GetExtension(p.ImageSrc.FileName); //.gif

            if (!FileUpload.AllowedExtensions.Contains(ext))
            {
                return UnprocessableEntity("Image extension is not allowed.");
            }

            try
            {
                var newFileName = Guid.NewGuid().ToString() + "_" + p.ImageSrc.FileName;

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", newFileName);

                p.ImageSrc.CopyTo(new FileStream(filePath, FileMode.Create));

                var dto = new ProductDto
                {
                    Id=p.Id,
                    ImageSrc = newFileName,
                    Name = p.Name,
                    Price = p.Price,
                    AvailableCount = p.AvailableCount,
                    Description = p.Description,
                    BrandId = p.BrandId
                };

                _editCommand.Execute(dto);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "Product doesn't exist.")
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
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]

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
