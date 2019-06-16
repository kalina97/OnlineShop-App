using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Application.UploadFiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.UploadProduct;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IGetProductsWebCommand _getProducts;
        private readonly IGetProductWebCommand _getProduct;
        private readonly IAddProductWebCommand _addProduct;
        private readonly IDeleteProductCommand _deleteProduct;
        private readonly IEditProductWebCommand _editProduct;

        public ProductsController(IGetProductsWebCommand getProducts, IGetProductWebCommand getProduct, IAddProductWebCommand addProduct, IDeleteProductCommand deleteProduct, IEditProductWebCommand editProduct)
        {
            _getProducts = getProducts;
            _getProduct = getProduct;
            _addProduct = addProduct;
            _deleteProduct = deleteProduct;
            _editProduct = editProduct;
        }



        // GET: Products
        public ActionResult Index(ProductWebSearch search)
        {
            var result = _getProducts.Execute(search);
            return View(result);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var dto = _getProduct.Execute(id);
                return View(dto);
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Product p)
        {
            var ext = Path.GetExtension(p.ImageSrc.FileName); //.gif

            if (!FileUpload.AllowedExtensions.Contains(ext))
            {
                return UnprocessableEntity("Image extension is not allowed.");
            }


            try
            {
               

                var newFileName = Guid.NewGuid().ToString() + "_" + p.ImageSrc.FileName;

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "fileuploads", newFileName);

                p.ImageSrc.CopyTo(new FileStream(filePath, FileMode.Create));

                var dto = new ProductWebDto
                {
                    ImageSrc = newFileName,
                    Name = p.Name,
                    Price = p.Price,
                    AvailableCount = p.AvailableCount,
                    Description = p.Description,
                    BrandId = p.BrandId
                };

                _addProduct.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View(e.InnerException.ToString());
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var dto = _getProduct.Execute(id);
                return View(dto);
            }
            catch (Exception e)
            {

                return RedirectToAction("index");
            }
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] Product p)
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

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "fileuploads", newFileName);

                p.ImageSrc.CopyTo(new FileStream(filePath, FileMode.Create));

                var dto = new ProductWebDto
                {
                    Id = p.Id,
                    ImageSrc = newFileName,
                    Name = p.Name,
                    Price = p.Price,
                    AvailableCount = p.AvailableCount,
                    Description = p.Description,
                    BrandId = p.BrandId
                };

                _editProduct.Execute(dto);
                return RedirectToAction("Index");
            }
           
            catch (Exception e)
            {
                return View(e.Message); 
            }

        }

        /*
        // GET: Products/Delete/5
        public ActionResult Delete(int id,ProductWebDto dto)
        {
            dto.Id = id;
            return View(dto);
        }
        */

        // POST: Products/Delete/5
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteProduct.Execute(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
    }
}