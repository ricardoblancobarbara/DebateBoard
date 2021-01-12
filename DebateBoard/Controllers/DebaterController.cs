using DebateBoard.Models.Debater;
using DebateBoard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DebateBoard.Controllers
{
    public class DebaterController : Controller
    {
        // GET: Debater
        public ActionResult Index()
        {
            var service = new DebaterService();
            var model = service.GetDebaters();
            return View(model);
            //return View();
        }

        // GET: Debater/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Debater/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DebaterCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = new DebaterService();
                service.CreateDebater(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Debater/Details/{id}
        public ActionResult Details(int id)
        {
            var service = new DebaterService();
            var model = service.GetDebaterById(id);
            return View(model);
        }

        // GET: Debater/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = new DebaterService();
            var detail = service.GetDebaterById(id);
            var model =
                new DebaterEdit
                {
                    DebaterId = detail.DebaterId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    UserName = detail.UserName,
                    CreatedUtc = detail.CreatedUtc
                };
            return View(model);
        }
        // POST: Debater/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DebaterEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.DebaterId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new DebaterService();

            if (service.UpdateDebater(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        // GET: Debater/Delete/{id}
        public ActionResult Delete(int id)
        {
            var service = new DebaterService();
            var model = service.GetDebaterById(id);
            return View(model);
        }
        // POST: Debater/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new DebaterService();

            service.DeleteDebater(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }

    }
}