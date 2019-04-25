using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gahfour_web_shop_2.Models;
using Gahfour_web_shop_2.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gahfour_web_shop_2.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminRepo _adminRepo;

        public AdminController(IAdminRepo repo)
        {
            _adminRepo = repo;
        }


        // GET: Admin
        public ActionResult Index()
        {
            bool anyAdmin = _adminRepo.adminCount() > 0;
            ViewData["anyAdmin"] = anyAdmin;
            ViewData["host"] = ControllerContext.HttpContext.Request.Host.ToString();
            return View();
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                User user = new User();
                user.Name = collection["Name"];
                user.Email = collection["Email"];

                _adminRepo.registerUser(user);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}