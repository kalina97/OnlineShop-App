using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IGetUsersWebCommand _getUsers;
        private readonly IGetUserWebCommand _getUser;
        private readonly IAddUserCommand _addUser;
        private readonly IEditUserWebCommand _editUser;
        private readonly IDeleteUserCommand _deleteUser;

        public UsersController(IGetUsersWebCommand getUsers, IGetUserWebCommand getUser, IAddUserCommand addUser, IEditUserWebCommand editUser, IDeleteUserCommand deleteUser)
        {
            _getUsers = getUsers;
            _getUser = getUser;
            _addUser = addUser;
            _editUser = editUser;
            _deleteUser = deleteUser;
        }



        // GET: Users
        public ActionResult Index(UserWebSearch search)
        {
            var result = _getUsers.Execute(search);
            return View(result);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var dto = _getUser.Execute(id);
                return View(dto);
            }
            catch (Exception)
            {
                return View();
            }

        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            try
            {
                _addUser.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException)
            {
             
                TempData["error"] = "This User already exists";
            }
            catch (Exception)
            {
                TempData["error"] = "This Role doesn't exist";
            }

            return View();

        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {

            try
            {
                var dto = _getUser.Execute(id);
                return View(dto);
            }
            catch (Exception e)
            {

                return RedirectToAction("index");
            }

        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserEditDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            try
            {
                _editUser.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException)
            {
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException)
            {
                TempData["error"] = "That user already exists";
                return View(dto);
            }

        }

        /*
        //GET: Users/Delete/5
        public ActionResult Delete(int id,UserWebDto dto)
        {
            dto.Id = id;
            return View(dto);

        }*/


        // POST: Users/Delete/5
        [HttpGet]
       // [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteUser.Execute(id);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
        }
    }
}