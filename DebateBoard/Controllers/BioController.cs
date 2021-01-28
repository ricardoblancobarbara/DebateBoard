using DebateBoard.Models.Bio;
using DebateBoard.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DebateBoard.Controllers
{
    public class BioController : Controller
    {        
        // GET: Bio/Index
        public ActionResult Index()
        {
            var service = CreateBioService();
            var model = service.GetBios();
            return View(model);
        }

        // GET: Bio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bio/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BioCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateBioService();
            if (service.CreateBio(model))
            {
                TempData["SaveResult"] = "Your biography was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Biography could not be created.");
            return View(model);
        }

        // GET: Bio/Details/{id}
        public ActionResult Details(int id)
        {
            var service = CreateBioService();
            var model = service.GetBioById(id);
            return View(model);
        }

        // GET: Bio/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateBioService();
            var detail = service.GetBioById(id);
            var model =
                new BioEdit
                {
                    BioId = detail.BioId,
                    Name = detail.Name,
                    Biography = detail.Biography,
                    Points = detail.Points,
                    CreatedUtc = detail.CreatedUtc,
                    ModifiedUtc = detail.ModifiedUtc
                };
            return View(model);
        }

        // POST: Bio/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BioEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.BioId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateBioService();
            if (service.UpdateBio(model))
            {
                TempData["SaveResult"] = "Your comment was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your comment could not be updated.");
            return View(model);
        }

        // GET: Bio/Delete/{id}
        public ActionResult Delete(int id)
        {
            var service = CreateBioService();
            var model = service.GetBioById(id);
            return View(model);
        }
        // POST: Bio/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateBioService();
            service.DeleteBio(id);
            TempData["SaveResult"] = "Your comment was deleted";
            return RedirectToAction("Index");
        }

        private BioService CreateBioService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BioService(userId);
            return service;
        }
    }
}