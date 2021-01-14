using DebateBoard.Models;
using DebateBoard.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DebateBoard.Controllers
{
    public class CommentController : Controller
    {
        // GET: Article/Index
        public ActionResult Index()
        {
            var service = CreateCommentService();
            var model = service.GetComments();
            return View(model);
        }

        // GET: Comment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateCommentService();
            if (service.CreateComment(model))
            {
                TempData["SaveResult"] = "Your comment was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Comment could not be created.");
            return View(model);
        }

        // GET: Comment/Details/{id}
        public ActionResult Details(int id)
        {
            var service = CreateCommentService();
            var model = service.GetCommentById(id);
            return View(model);
        }

        // GET: Comment/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateCommentService();
            var detail = service.GetCommentById(id);
            var model =
                new CommentEdit
                {
                    CommentId = detail.CommentId,
                    Content = detail.Content,
                    Id = detail.Id,
                    ArticleId = detail.ArticleId,
                    Points = detail.Points,
                    //CreatedUtc = detail.CreatedUtc,
                    //ModifiedUtc = detail.ModifiedUtc
                };
            return View(model);
        }

        // POST: Comment/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CommentEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.CommentId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateCommentService();
            if (service.UpdateComment(model))
            {
                TempData["SaveResult"] = "Your comment was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your comment could not be updated.");
            return View(model);
        }

        // GET: Comment/Delete/{id}
        public ActionResult Delete(int id)
        {
            var service = CreateCommentService();
            var model = service.GetCommentById(id);
            return View(model);
        }
        // POST: Comment/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCommentService();
            service.DeleteComment(id);
            TempData["SaveResult"] = "Your comment was deleted";
            return RedirectToAction("Index");
        }

        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CommentService(userId);
            return service;
        }


    }
}